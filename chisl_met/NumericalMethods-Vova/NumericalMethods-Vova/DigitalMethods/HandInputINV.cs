using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DigitalMethods
{
    public partial class HandInputINV : Form
    {
        double[,] a = null;
        int n;
        public double[,] A { get { return a; } }
        public int N { get { return n; } }
        public HandInputINV()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string[] rowsA = textBox1.Text.Split(new char[] { '\r' });
                n = rowsA.Length;
                
a = new double[n, n];
                for (int i = 0; i < n; i++)
                {
                    rowsA[i] = rowsA[i].Replace("\n", "");
                    string[] cols = rowsA[i].Trim().Split(new char[] { ' ' });
                    if (cols.Length != n)
                    {
                        MessageBox.Show("Данные введены некорректно!");
                        return;
                    }
                    for (int j = 0; j < n; j++)
                    {
                        a[i, j] = Convert.ToDouble(cols[j].Replace(".", ","));
                    }
                }
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
            catch (Exception exception)
            {
                MessageBox.Show("Неверный формат введённых данных!");
            }
        }

    }
}
