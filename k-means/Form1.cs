using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Threading;

namespace k_means
{

    public partial class Form1 : Form
    {
        OpenFileDialog OPF;
        public Form1()
        {
            InitializeComponent();
            initialization();
        }
        private void initialization()
        {
            OPF = new OpenFileDialog();
            dataGridView1.AutoGenerateColumns = true;
            OPF.Filter = "Файлы DataSet (*.tab)|*.tab";
        }

        private void buttonFile_Click(object sender, EventArgs e)
        {
            try
            {
                if (OPF.ShowDialog()==DialogResult.OK)
                {
                    Parser parser = new Parser();
                    try
                    {
                        Program.dataTable = parser.TabToDataTable(OPF.FileName);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка");
                        dataGridView1.DataSource = null;
                        allEnableWithoutOPF(false);
                        buttonRes.Enabled = false;
                        checkedListBoX.Items.Clear();
                        textBoxPath.Text = null;
                        return;
                    }
                    textBoxProgress.Text = "";
                    buttonStartKMeans.Enabled = true;
                    numberOfCluster.Enabled = true;
                    checkedListBoX.Enabled = true;
                    buttonRes.Enabled = false;
                    checkBoxOnlyNumbers.Enabled = true;

                    numberOfCluster.Maximum = Program.dataTable.Rows.Count;
                    textBoxPath.Text = OPF.SafeFileName;
                    loadCheckBox(Program.dataTable);
                    dataGridView1.DataSource = Program.dataTable;
                    numericUpDown1.Enabled = true;
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void allEnableWithoutOPF(bool enable)
        {
            checkedListBoX.Enabled=enable;
            checkBoxOnlyNumbers.Enabled = enable;

            buttonStartKMeans.Enabled = enable;
            buttonCancle.Enabled = enable;

            numberOfCluster.Enabled = enable;
            numericUpDown1.Enabled = enable;

   
        }
        private void loadCheckBox(DataTable table)
        {
            checkedListBoX.Items.Clear();
            List<string> words = new List<string>();
            if (checkBoxOnlyNumbers.Checked == true)
            {
                for (int i = 0; i < table.Columns.Count - 1; i++)
                {
                    if (table.Columns[i + 1].Caption == "c")
                        words.Add(table.Columns[i + 1].ColumnName);
                }

            }
            else
            {
                for (int i = 0; i < table.Columns.Count - 1; i++)
                {
                    if (table.Columns[i + 1].Caption != "s")
                        words.Add(table.Columns[i + 1].ColumnName);
                }
            }
            checkedListBoX.Items.Add("Выбрать все");
            checkedListBoX.Items.AddRange(words.ToArray());
        }

        private void buttonStartKMeans_Click(object sender, EventArgs e)
        {
            List<string> selectItem = new List<string>();
            for (int i = 1; i < checkedListBoX.Items.Count; i++)
            {
                if (checkedListBoX.GetItemChecked(i))
                    selectItem.Add(checkedListBoX.Items[i].ToString());
            }
            if (selectItem.Count <= 0)
            {
                MessageBox.Show("Выберите хотя бы один столбец сортировки.");
                return;
            }
            dataGridView1.DataSource = null;
            KMeans kMeans = new KMeans();
            object obj = new object[] { Program.dataTable, selectItem.ToArray(), (int)numberOfCluster.Value, (int)numericUpDown1.Value };
            backgroundWorker1.RunWorkerAsync(obj);

            allEnableWithoutOPF(false);
            buttonFile.Enabled = false;
            buttonCancle.Enabled = true;
        }

        private void buttonRes_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.tableCreate(Program.dataTRes);
            form2.ShowDialog();
        }

        private void numberOfCluster_ValueChanged(object sender, EventArgs e)
        {
            textBoxProgress.Text = "";
            buttonRes.Enabled = false;
        }

        private void checkedListBoX_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            CheckedListBox checkNumbZero = sender as CheckedListBox; //создаем ссылку на объект-инициатор события
            if (e.Index == 0) //если изменено состояние первой строки
            {
                //флаг соответствующий новому состоянию нулевой строки (вкл/выкл)
                bool flag = e.NewValue == CheckState.Checked ? true : false;
                //устанавливаем все остальные строки в то же положение
                for (int i = 1; i < checkNumbZero.Items.Count; i++)
                    checkNumbZero.SetItemChecked(i, flag);
            }
        }

        private void checkBoxOnlyNumbers_CheckedChanged(object sender, EventArgs e)
        {
            loadCheckBox(Program.dataTable);
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;

            e.Result = new KMeans().GetTableKMeansAndCentrs((DataTable)((object[])e.Argument)[0],
                (string[])((object[])e.Argument)[1], (int)((object[])e.Argument)[2], (int)((object[])e.Argument)[3], 
                worker,e);
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if(e.Error!=null)
            {
                MessageBox.Show("Ошибка: " + e.Error.Message);
            }
            else if(e.Cancelled)
            {
                textBoxProgress.Text = "Остановлено";
            }
            else
            {
                textBoxProgress.Text="Готово!";
                buttonRes.Enabled = true;
                Program.dataTRes = ((List<DataTable>)e.Result)[0];
                Program.dataCentrs = ((List<DataTable>)e.Result)[1];
                Program.dataTRes.DefaultView.Sort = Program.dataTRes.Columns[Program.dataTRes.Columns.Count - 2].ColumnName;
            }
            buttonFile.Enabled = true;
            dataGridView1.DataSource = Program.dataTable;
            Program.dataTable.DefaultView.Sort = Program.dataTable.Columns[0].ColumnName;
            allEnableWithoutOPF(true);
            buttonCancle.Enabled = false;
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            textBoxProgress.Text = e.ProgressPercentage + "/" + numericUpDown1.Value;
        }

        private void buttonCancle_Click(object sender, EventArgs e)
        {
            backgroundWorker1.CancelAsync();
            buttonCancle.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Программная реализация алгоритма K-Means.\nИнструкция:\n1. Нажмите кнопку \"Открыть\" и выберите файл *.tab,\n"+
                "2. Установите максимальное количество итераций и количество кластеров,\n3. Выберите колонки по которым будет производиться сортировка,\n"+
                "4. Нажмите кнопку \"Запуск алгоритма\", после чего дождитесь завершения работы алгоритма,\n"+
                "5. Нажмите кнопку \"Результат\", в открывшемся окне последние две колонки являются результатом.\n"+
                "Приятного пользования!", "Помощь");
        }
    }
}
