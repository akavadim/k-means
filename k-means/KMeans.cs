using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.ComponentModel;

namespace k_means
{
    class KMeans
    {
        public List<DataTable> GetTableKMeansAndCentrs(DataTable table, string[] tableNamesSelected, int numberOfClusters, int iter, BackgroundWorker worker, DoWorkEventArgs e)
        {
            EditData editTable = new EditData();
            if (editTable.tableEmpty(table))
                throw new Exception("Таблица пустая.");
            editTable.DeleteEmpty(table, tableNamesSelected);
            if (editTable.tableEmpty(table))
            {
                editTable.ComebackEmptyRows(table);
                throw new Exception("Каждая строка выбранных колонок содержит пустую ячейку.");
            }
            editTable.TableToNumber(table, tableNamesSelected);

            Centroid centrs = new Centroid();
            try
            {
                centrs.CreateCentr(table, tableNamesSelected, numberOfClusters);
            }
            catch (Exception ex)
            {
                editTable.TableComback(table, tableNamesSelected);
                editTable.ComebackEmptyRows(table);
                throw new Exception(ex.Message);
            }

            centrs.UpdateDataRows(table);
            centrs.UpdateCentrs(table);

            int it = 0;
            while (!centrs.CentersSame() && (it < iter))
            {
                if (worker.CancellationPending)
                {
                    e.Cancel = true;
                    break;
                }
                else
                {
                    worker.ReportProgress(it);
                    centrs.UpdateDataRows(table);
                    centrs.UpdateCentrs(table);
                    it++;
                }
            }

            editTable.TableComback(table, tableNamesSelected);
            editTable.ComebackEmptyRows(table);

            DataTable dataTRes = table.Copy();
            centrs.DataColumnsAdd(dataTRes);
            
            List<DataTable> res = new List<DataTable>();
            res.Add(dataTRes);
            res.Add(centrs.centrs);
            return res;
        }

    }
    class EditData
    {
        List<List<string>> rowsBack;
        List<List<string>> rowsEmpty;
        public void TableToNumber(DataTable table, string[] tableNameSelected)
        {
            rowsBack = new List<List<string>>();
            for (int i=0;i< tableNameSelected.Length; i++)
            {
                if (table.Columns[tableNameSelected[i]].Caption != "d")
                    continue;
                List<string> rowNames = new List<string>();
                rowNames.Add((string)table.Rows[0][tableNameSelected[i]]);
                table.Rows[0][tableNameSelected[i]] = 0;
                for (int j=1;j<table.Rows.Count;j++)
                {
                    if(rowNames.IndexOf((string)table.Rows[j][tableNameSelected[i]])<0)
                    {
                        rowNames.Add((string)table.Rows[j][tableNameSelected[i]]);
                    }
                    table.Rows[j][tableNameSelected[i]] = rowNames.IndexOf((string)table.Rows[j][tableNameSelected[i]]);
                }
                rowsBack.Add(rowNames);
            }
        }
        public void TableComback(DataTable table, string[] tableNameSelected)
        {
            int iter = 0;
            for(int i=0;i<tableNameSelected.Length;i++)
            {
                if (table.Columns[tableNameSelected[i]].Caption != "d")
                    continue;
                for(int j=0;j<table.Rows.Count;j++)
                {
                    table.Rows[j][tableNameSelected[i]] = rowsBack[iter][int.Parse((string)table.Rows[j][tableNameSelected[i]])];
                }
                iter++;
            }
        }
        public void CopyRows(DataTable tableFrom, DataTable tableTo, int number)
        {
            DataRow row = tableTo.NewRow();
            for(int i=0;i<tableTo.Columns.Count;i++)
            {
                row[i] = tableFrom.Rows[number][tableTo.Columns[i].ColumnName].ToString();
            }
            tableTo.Rows.Add(row);
        }
        public void DeleteEmpty(DataTable table, string[] tableNamesSelected)
        {
            rowsEmpty = new List<List<string>>();
            for(int i=table.Rows.Count-1;i>=0;i--)
            {
                List<string> s = new List<string>();
                for(int j=0;j< tableNamesSelected.Length; j++)
                {
                    if(DBNull.Value.Equals(table.Rows[i][tableNamesSelected[j]]))
                    {
                        for(int k=0;k<table.Columns.Count;k++)
                        {
                            s.Add(table.Rows[i][k].ToString());
                        }
                        rowsEmpty.Add(s);
                        table.Rows.RemoveAt(i);
                        break;
                    }
                }
            }
        }
        public void ComebackEmptyRows(DataTable table)
        {
            for(int i=0;i<rowsEmpty.Count;i++)
            {
                DataRow rowBack = table.NewRow();
                List<string> stringRows = rowsEmpty[i];
                for (int j = 0; j < stringRows.Count;j++)
                {
                    if (stringRows[j] != "")
                    {

                            rowBack[j] = stringRows[j];
                    }
                }
                table.Rows.Add(rowBack);
            }
        }
        public bool tableEmpty(DataTable table)
        {
            if (table.Rows.Count == 0)
                return true;
            return false;
        }
    }
    class Centroid
    {
        public string clusterName = "Кластер";
        public string clusterDistName = "Расстояние";
        public DataTable centrs;
        DataTable dataRows;
        DataTable backCentrs;

        public void CreateCentr(DataTable table, string[] tableNamesSelected, int numberOfClusters)
        {
            centrs = new DataTable();
            for (int i = 0; i < tableNamesSelected.Length; i++)
            {
                centrs.Columns.Add(new DataColumn(tableNamesSelected[i]));
            }
            int k;
            for (k = 0; k < table.Rows.Count; k++)
            {
                if (!CentrSame(table, k))
                {
                    new EditData().CopyRows(table, centrs, k);
                }
                if (centrs.Rows.Count == numberOfClusters)
                    return;
            }
            throw new Exception($"Количество кластеров не может превышать {centrs.Rows.Count}");
        }
        public void UpdateDataRows(DataTable table)
        {
            dataRows = new DataTable();
            dataRows.Columns.Add(clusterName,typeof(int));
            dataRows.Columns.Add(clusterDistName,typeof(double));
            for(int i=0;i<table.Rows.Count;i++)
            {
                DataRow row = dataRows.NewRow();
                double[] d = SearchDistance(table, i);
                row[clusterName] = (int)d[0]+1;
                row[clusterDistName] = d[1];
                dataRows.Rows.Add(row);
            }
        }
        public void UpdateCentrs(DataTable table)
        {
            backCentrs = centrs.Copy();
            for (int i=0;i<centrs.Columns.Count;i++)
            {
                int[] iter = new int[centrs.Rows.Count];
                double[] sum = new double[centrs.Rows.Count];
                for (int j=0;j<table.Rows.Count;j++)
                {
                    sum[(int)dataRows.Rows[j][clusterName]-1] += double.Parse(table.Rows[j][centrs.Columns[i].ColumnName].ToString());
                    iter[(int)dataRows.Rows[j][clusterName] - 1]++;
                }
                for(int j=0;j<centrs.Rows.Count;j++)
                {
                    centrs.Rows[j][i] = sum[j] / iter[j];
                }
            }
        }
        private double[] SearchDistance(DataTable table, int number)
        {
            double[] min = new double[centrs.Rows.Count];
            for (int j = 0; j < centrs.Rows.Count; j++)
            {
                for (int i = 0; i < centrs.Columns.Count;i++)
                {
                    min[j] += Math.Pow(double.Parse(centrs.Rows[j][i].ToString()) - double.Parse(table.Rows[number][centrs.Columns[i].ColumnName].ToString()),2);
                }
                min[j] = Math.Sqrt(min[j]);
            }
            double[] res = new double[2];
            res[0] = Array.IndexOf<double>(min, min.Min());
            res[1] = min.Min();
            return res;
        }
        public bool CentrSame(DataTable table, int row)
        {
            bool same = false;
            for(int i=0;i<centrs.Rows.Count;i++)
            {
                same = true;
                for(int j=0;j<centrs.Columns.Count;j++)
                {
                    if(table.Rows[row][centrs.Columns[j].ColumnName].ToString()!=centrs.Rows[i][j].ToString())
                    {
                        same = false;
                        break;
                    }
                }
                if (same)
                    return true;
            }
            return same;
        }

        public bool CentersSame()
        {
            bool res = true;
            for(int i=0;i<centrs.Rows.Count; i++)
            {
                for(int j=0;j < centrs.Columns.Count; j++)
                {
                    if (double.Parse(centrs.Rows[i][j].ToString()) != double.Parse(backCentrs.Rows[i][j].ToString()))
                        return false;
                }
            }
            return res;
        }
        public void DataColumnsAdd(DataTable table)
        {
            table.Columns.Add(clusterName,typeof(int));
            table.Columns.Add(clusterDistName,typeof(double));
            for (int i=0;i<dataRows.Rows.Count;i++)
            {
                table.Rows[i][clusterName] = dataRows.Rows[i][clusterName];
                table.Rows[i][clusterDistName] = dataRows.Rows[i][clusterDistName];
            }
        }
    }
}
