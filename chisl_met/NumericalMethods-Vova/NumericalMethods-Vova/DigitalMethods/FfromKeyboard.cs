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
    public partial class FfromKeyboard : Form
    {
        Data result;
        public FfromKeyboard()
        {
            InitializeComponent();
        }
        public void ShowForm(ref Data res)
        {
            result = res;
            Show();
        }

        private void butCancle_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void butOk_Click(object sender, EventArgs e)
        {
            string text = tBInpurMatrix.Text.Replace("\r\n", ";");
            string[] rows = text.Split(';');
            double[,] result = new double[rows.Length, rows.Length];
            for (int i = 0; i < rows.Length; i++)
            {
                string[] numbers = rows[i].TrimEnd(' ').Split(' ');
                for (int j = 0; j < numbers.Length; j++)
                {
                    result[i, j] = double.Parse(numbers[j]);
                }
            }
            this.result.Init(rows.Length);
            this.result.A = result;
            MessageBox.Show("Ввод данных прошёл успешно");
            Close();
        }
    }
}
