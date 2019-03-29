using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace k_means
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            dataGridView1.AutoGenerateColumns = true;
        }

        public Form2(Form1 f):base()
        {

        }

        public void tableCreate(DataTable Table)
        {
            dataGridView1.DataSource = Table;
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        public void Centroids()
        {
            button1.Enabled = false;
            button1.Visible = false;
            this.Text = "Центры";
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Centroids();
            form2.tableCreate(Program.dataCentrs);
            form2.ShowDialog();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
