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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void buttonFile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog OPF = new OpenFileDialog())
            {
                OPF.InitialDirectory = "c:\\";
                if (OPF.ShowDialog() == DialogResult.OK) 
                {
                    textBoxPath.Text = OPF.FileName;
                }
            }
        }

        private void textBoxPath_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
