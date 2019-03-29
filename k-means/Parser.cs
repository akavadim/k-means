using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;
using System.IO;

namespace k_means
{
    class Parser
    {
        public DataTable TabToDataTable(string filePath)
        {
                DataTable table = new DataTable(Path.GetFileNameWithoutExtension(filePath));
            using (StreamReader reader = new StreamReader(filePath))
            {
                try
                {
                    addID(table);   //Добавление колоннки с ID

                    addColumns(table, reader.ReadLine(), reader.ReadLine());    //Добавление колонок и их типов из файла
                    reader.ReadLine();  //Пропуск третей строчки

                    addRows(table, reader); //Добавление всех строчек с данными из файла
                }
                catch
                {
                    throw new Exception("Не соответствует фоормат файла.");
                }
            return table;
            }

        }
        private void addID(DataTable table)
        {
            table.Columns.Add("id", typeof(int));
            table.Columns["id"].AutoIncrement = true;
            table.Columns["id"].AutoIncrementSeed = 1;
            table.Columns["id"].AutoIncrementStep = 1;
        }
        private void addColumns(DataTable table, string ColumnNames, string typeColumns)
        {
            string[] tableNames = ColumnNames.Split('\t');
            string[] typeTable = typeColumns.Split('\t');
            if (tableNames.Length != typeTable.Length)
                throw new Exception("Данные повреждены");
            for (int i = 0; i < tableNames.Length; i++)
            {
                if ((typeTable[i].Replace(" ", "") == "c") || (typeTable[i].Replace(" ", "") == "continuous"))
                    table.Columns.Add(tableNames[i], typeof(Double)).Caption = "c";
                else if ((typeTable[i].Replace(" ", "") == "string") || (typeTable[i].Replace(" ", "") == "text") || (typeTable[i].Replace(" ", "") == "s") || (typeTable[i].Replace(" ", "") == "basket"))
                {
                    table.Columns.Add(tableNames[i], typeof(object)).Caption = "s";
                }
                else
                    table.Columns.Add(tableNames[i], typeof(string)).Caption = "d";
            }
        }
        private void addRows(DataTable table,StreamReader reader)
        {
            DataRow row;
            string line;
            string[] words;
            while ((line = reader.ReadLine()) != null)
            {
                row = table.NewRow();
                words = line.Split('\t');
                for (int i = 0; i < table.Columns.Count-1; i++)
                {
                    if ((words[i] != "?")&&(words[i]!=""))
                    {
                        if (table.Columns[i+1].DataType == typeof(double))
                        {
                            row[i+1] = double.Parse(words[i].Replace('.', ','));
                        }
                        else row[i+1] = words[i];
                    }
                }
                table.Rows.Add(row);
            }
        }
    }
}
