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
    public partial class Form2 : Form
    {
        double[,] a;
        double[] b;
        double[] x;
        int n;
        public double[,] A { get { return a; } }
        public double[] X { get { return x; } }
        public double[] B { get { return b; } }
        public int N { get { return n; }}
public Form2()
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
                string[] rowsB = textBox3.Text.Split(new char[] {'\r' });
                if (rowsB.Length != n)
                {
                    MessageBox.Show("Данные введены некорректно!");
                    return;
                }
 b = new double[n];
                for (int i = 0; i < n; i++)
                {
                    rowsB[i] = rowsB[i].Replace("\n", "").Trim();
                    b[i] = Convert.ToDouble(rowsB[i].Replace(".", ","));
                }
                if (textBox2.Text.Trim() != "")
                {
                    string[] rowsX = textBox2.Text.Split(new char[] {'\r'});
                    if (rowsX.Length == n)
                    {
                        x = new double[n];
                        for (int i = 0; i < n; i++)
                        {
                            rowsX[i] = rowsX[i].Replace("\n", "").Trim();
                            x[i] = Convert.ToDouble(rowsX[i].Replace(".", ","));
                        }
                    }
                    else
                    {
                        MessageBox.Show("Вектор X был введён неправильно!(поле можно оставить пустым)");
                    return;
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

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
