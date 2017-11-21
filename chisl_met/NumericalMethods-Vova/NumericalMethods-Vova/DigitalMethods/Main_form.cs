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
    public partial class Main_form : Form
    {
        Data data = new Data();
        int action = 1;
        int type_bad_matrix = 1;
        List<double> errorX;
        List<double> errorI;

        public Main_form()
        {
            InitializeComponent();
            chart.Series.Clear();
            
            errorI = new List<double>();
            errorX = new List<double>();
        }

        private void butFact_Click(object sender, EventArgs e)
        {
            if (data != null)
            {
                tBResults.Clear();
                switch (action)
                {
                    case 1:
                        tBResults.Text += Processing.DoChislMethod(ref data);
                        break;
                    case 2:
                        InitRandMatrx();
                        tBResults.Text += Processing.DoChislMethod(ref data);

                        break;
                    case 3:
                        InitBadMatrx(type_bad_matrix);
                        tBResults.Text += Processing.DoChislMethod(ref data);
                        break;
                }
            }
            else
            {
                MessageBox.Show("Данные пусты");

            }
        }

        private void ввестиСКлавиатурыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FfromKeyboard form = new FfromKeyboard();
            form.ShowForm(ref data);
            action = 1;
        }

        private void случайнымОбразомToolStripMenuItem_Click(object sender, EventArgs e)
        {
            action = 2;
        }

        private void заданиеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("LU−1- разложение A = LU на основе жорданова исключения с выбором главного элемента по столбцу.");
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            tBResults.Clear();
        }

        private void плохоОбусловленныеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            action = 3;
        }

        private void вид1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            type_bad_matrix = 1;
        }

        private void InitRandMatrx()
        {
            int n = int.Parse(tBMaxSize.Text);
            errorI.Clear();
            errorX.Clear();
            chart.Series.Clear();
            chart.Series.Add("Погрешность X");
            chart.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            chart.Series.Add("Погрешность обратной матрицы");
            chart.Series[1].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            for (int i = 5; i <= n; i += 5)
            {
                data = new Data();
                data.Init(i);
                tBResults.Text += Processing.DoChislMethod(ref data);
                errorX.Add(data.ErrorX);
                errorI.Add(data.ErrorI);
            }
            for (int i = 1; i < errorX.Count + 1; i++)
            {
                chart.Series[0].Points.AddXY(i * 5, errorX[i - 1]);
                chart.Series[1].Points.AddXY(i * 5, errorI[i - 1]);
            }
        }

        private void InitBadMatrx(int type)
        {
            int n = int.Parse(tBMaxSize.Text);
            errorI.Clear();
            errorX.Clear();
            chart.Series.Clear();
            chart.Series.Add("Погрешность X");
            chart.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            chart.Series.Add("Погрешность обратной матрицы");
            chart.Series[1].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
      
                data = new Data();
                switch (type)
                {
                    case 1:
                        data.InitBadMatrx1(n);
                        break;
                    case 2:
                        data.InitBadMatrx2(n);
                        break;
                    case 3:
                        data.InitBadMatrx3(7);
                        break;
                    case 4:
                        data.InitBadMatrx4(n);
                        break;
                    case 5:
                        data.InitBadMatrx5(n);
                        break;
                    case 6:
                    data.InitBadMatrx6(n, 0.7);
                    break;
                    case 7:
                        data.InitBadMatrx7(n, 1);
                        break;
                    case 8:
                        data.InitBadMatrx8(n, 0.7);
                        break;
                    case 9:
                        data.InitBadMatrx9(n, 150);
                        break;
                    case 10:
                        data.InitBadMatrx10(n);
                        break;
                }
                tBResults.Text += Processing.DoChislMethod(ref data);
                errorX.Add(data.ErrorX);
                errorI.Add(data.ErrorI);
            
            for (int i = 1; i < errorX.Count + 1; i++)
            {
                chart.Series[0].Points.AddXY(i * 5, errorX[i - 1]);
                chart.Series[1].Points.AddXY(i * 5, errorI[i - 1]);
            }
        }

        private void вид2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            type_bad_matrix = 2;
        }

        private void вид3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            type_bad_matrix = 3;
        }

        private void вид4ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            type_bad_matrix = 4;
        }

        private void вид5ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            type_bad_matrix = 5;
        }

        private void вид6ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            type_bad_matrix = 6;
        }

        private void вид7ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            type_bad_matrix = 7;
        }

        private void вид8ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            type_bad_matrix = 8;
        }

        private void вид9ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            type_bad_matrix = 9;
        }

        private void вид10ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            type_bad_matrix = 10;
        }
    }
}
