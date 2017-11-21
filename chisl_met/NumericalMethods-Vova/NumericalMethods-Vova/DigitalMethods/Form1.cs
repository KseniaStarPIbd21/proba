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
    public partial class Form1 : Form
    {
        OptionMatrixPanel[] option_panel = new OptionMatrixPanel[3];
        public Form1()
        {
            InitializeComponent();
            for (int i = 0; i < 3; i++)
            {
                option_panel[i] = new OptionMatrixPanel(flowLayoutPanel1.Width - listBox1.Width - 10, flowLayoutPanel1.Height, i + 1);
                flowLayoutPanel1.Controls.Add(option_panel[i]);
                if (i > 0) option_panel[i].Visible = false;
            }
            listBox1.SelectedIndex = 0;
            listBox1.SelectedIndexChanged += listBox1_SelectedIndexChanged;

        }

        void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < 3; i++) option_panel[i].Visible = false;
            option_panel[listBox1.SelectedIndex].Visible = true;

        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }



        private void Form1_SizeChanged(object sender, EventArgs e)
        {

            listBox1.Height = flowLayoutPanel1.Height;
        }


        public class OptionMatrixPanel : FlowLayoutPanel
        {
            int type; // Тип страницы.
            FlowLayoutPanel[] panels = new FlowLayoutPanel[5];
            // Панели, на которые будут добавлятся компоненты.
            ComboBox[] comb = new ComboBox[2];
            // Выпадающие списки для определения способа ввода и типа
            // специальных матриц.
            TextBox int_ot_txt = new TextBox(); // Текстовое поле для ввода
                                                // начала интервала, с которого будет изменяться порядок матрицы.
            TextBox int_do_txt = new TextBox(); //Текстовое поле для ввода
                                                // конца интервала, до которого будет изменяться порядок матрицы.
            TextBox step_txt = new TextBox(); //Текстовое поле для ввода шага,
                                              // с которым будет изменяться порядок матрицы.
            TextBox arg = new TextBox(); //Текстовое поле для ввода аргумента,
                                         // который необходим для генерации некоторых матриц.
            Button btn_go = new Button(); //Кнопка, при нажатии на которую,
                                          // будут происходить какие-то операции (ввод матриц вручную,
                                          // решение СЛАУ, обращение матриц, вычисление определителя).
            Label title = new Label(); //Заголовок страницы.
            TextBox matrix_input = new TextBox(); //Текстовое поле для ввода
                                                  // матрицы, для вычисления определителя.

            public OptionMatrixPanel(int width, int height, int t)
            {
                this.AutoSize = false;
                type = t;
                switch (type)
                {
                    case 1:
                        title.Text = "Решение СЛАУ";
                        break;
                    case 2:
                        title.Text = "Обращение матриц";
                        break;
                    case 3:
                        title.Text = "Вычисление определителя";
                        break;
                }
                this.Controls.Add(title);
                Resize(width, height);
                if (type == 3)
                {
                    InitComponents2();
                    return;
                }
                InitComponents();
                panels[1].Visible = false;
                panels[2].Visible = false;
                panels[3].Visible = false;
            }
            private void InitComponents2()
            {
                for (int i = 0; i < 3; i++)
                {
                    panels[i] = new FlowLayoutPanel();
                    panels[i].AutoSize = false;
                    panels[i].Width = this.Width;
                    panels[i].AutoScroll = true;
                    this.Controls.Add(panels[i]);
                }
                Label zag = new Label();
                panels[0].Height = 28;
                zag.Text = "Введите матрицу для вычисления определителя (элементы в строке разделяйте пробелом, каждая строка матрицы вводится с новой строчки)";
                panels[0].Controls.Add(zag);
                zag.AutoSize = true;
                matrix_input.Multiline = true;
                matrix_input.Size = new System.Drawing.Size(200, 200);
                panels[1].Controls.Add(matrix_input);
                panels[1].Height = 220;
                btn_go.Text = "Вычислить определитель";
                btn_go.AutoSize = true;
                panels[2].Controls.Add(btn_go);
                btn_go.Click += btn_go_Click;
            }
            private void InitComponents()
            {
                String[] combo_list = new String[] { "Вручную", "Случайные матрицы", "Спецматрицы" };
                Label zag = new Label();
                for (int i = 0; i < 5; i++)
                {

                    panels[i] = new FlowLayoutPanel();
                    panels[i].AutoSize = false;
                    panels[i].Height = 28;
                    panels[i].Width = this.Width;
                    panels[i].AutoScroll = true;
                    this.Controls.Add(panels[i]);
                }
                zag.Text = "Выберите тип ввода матрицы:";
                zag.AutoSize = true;
                zag.Margin = new System.Windows.Forms.Padding(0, 6, 0, 0);
                comb[0] = new ComboBox();
                comb[0].DropDownStyle = ComboBoxStyle.DropDownList;
                comb[0].Items.AddRange(combo_list);
                comb[0].SelectedIndex = 0;
                panels[0].Controls.Add(zag);
                panels[0].Controls.Add(comb[0]);
                zag = new Label();
                zag.Text = "Выберите тип матрицы: ";
                zag.Margin = new System.Windows.Forms.Padding(0, 6, 0, 0);
                zag.AutoSize = true;
                comb[1] = new ComboBox();
                for (int i = 1; i <= 10; i++)
                {
                    comb[1].Items.Add(i.ToString());
                }
                comb[1].DropDownStyle = ComboBoxStyle.DropDownList;
                comb[1].SelectedIndex = 0;
                panels[1].Controls.Add(zag);
                panels[1].Controls.Add(comb[1]);
                zag = new Label();
                zag.Text = "Изменение порядка матрицы, от: ";
                zag.Margin = new System.Windows.Forms.Padding(0, 6, 0, 0);
                zag.AutoSize = true;
                int_ot_txt.Text = "5";
                panels[2].Controls.Add(zag);
                panels[2].Controls.Add(int_ot_txt);
                int_ot_txt.GotFocus += int_txt_GotFocus;
                int_ot_txt.LostFocus += int_txt_LostFocus;

                zag = new Label();
                zag.Text = "; до: ";
                zag.Margin = new System.Windows.Forms.Padding(0, 6, 0, 0);
                zag.AutoSize = true;
                int_do_txt.Text = "100";
                panels[2].Controls.Add(zag);
                panels[2].Controls.Add(int_do_txt);
                int_do_txt.GotFocus += int_txt_GotFocus;
                int_do_txt.LostFocus += int_txt_LostFocus;
                zag = new Label();
                zag.Text = "; шаг: ";
                zag.Margin = new System.Windows.Forms.Padding(0, 6, 0, 0);
                zag.AutoSize = true;
                step_txt.Text = "5";
                panels[2].Controls.Add(zag);
                panels[2].Controls.Add(step_txt);
                step_txt.GotFocus += int_txt_GotFocus;
                step_txt.LostFocus += int_txt_LostFocus;
                zag = new Label();
                zag.Text = "Значение аргумента: ";
                zag.Margin = new System.Windows.Forms.Padding(0, 6, 0, 0);
                zag.AutoSize = true;
                arg.Text = "1";
                arg.GotFocus += int_txt_GotFocus;
                arg.LostFocus += arg_LostFocus;
                panels[3].Controls.Add(zag);
                panels[3].Controls.Add(arg);
                btn_go.Text = "Создать отчёт";
                btn_go.AutoSize = true;
                btn_go.Click += btn_go_Click;
                panels[4].Controls.Add(btn_go);
                panels[4].Height = 30;
                comb[0].SelectedIndexChanged += combo1_SelectedIndexChanged;
                comb[1].SelectedIndexChanged += combo2_SelectedIndexChanged;
            }
            void btn_go_Click(object sender, EventArgs e)
            {
                switch (type)
                {
                    case 1:
                        GenerateSLAU();
                        break;
                    case 2:
                        GenerateInv();
                        break;
                    case 3:
                        CalcDet();
                        break;
                }
            }
            void combo2_SelectedIndexChanged(object sender, EventArgs e)
            {
                for (int i = 1; i < 4; i++) panels[i].Visible = false;
                SpecMatrixSelect();
            }
            void combo1_SelectedIndexChanged(object sender, EventArgs e)
            {
                switch (comb[0].SelectedIndex)
                {
                    case 0:
                        {
                            for (int i = 1; i < 4; i++)
                                panels[i].Visible = false;
                        }
                        break;
                    case 1:
                        {
                            for (int i = 1; i < 4; i++)
                                panels[i].Visible = false;
                            panels[2].Visible = true;
                        }
                        break;
                    case 2:
                        {
                            for (int i = 1; i < 4; i++)
                                panels[i].Visible = false;
                            SpecMatrixSelect();
                        }
                        break;
                }
            }
            void SpecMatrixSelect()
            {
                panels[1].Visible = true;
                switch (comb[1].SelectedIndex + 1)
                {
                    case 1:
                        panels[2].Visible = true;
                        break;
                    case 4:
                        panels[2].Visible = true;
                        break;
                    case 5:
                        panels[2].Visible = true;
                        break;
                    case 6:
                        panels[3].Visible = true;
                        break;
                    case 7:
                        {
                            panels[3].Visible = true;
                            panels[2].Visible = true;
                        }
                        break;
                    case 8:
                        {
                            panels[2].Visible = true;
                            panels[3].Visible = true;

                        }
                        break;
                    case 9:
                        {
                            panels[2].Visible = true;
                            panels[3].Visible = true;
                        }
                        break;
                }

            }

            void arg_LostFocus(object sender, EventArgs e)
            {
                string arr = "0123456789";
                string msg = ((TextBox)sender).Text.Trim();
                try
                {
                    double a = Convert.ToDouble(msg.Replace(".", ","));
                    ((TextBox)sender).Text = msg.Replace(".", ",");
                }
                catch (Exception e3)
                {
                    ((TextBox)sender).Text = ((TextBox)sender).Name;
                    MessageBox.Show("В это поле может быть введено только вещественное число!");
                }
            }
            void int_txt_LostFocus(object sender, EventArgs e)
            {
                string arr = "0123456789";
                string msg = ((TextBox)sender).Text.Trim();
                for (int i = 0; i < arr.Length; i++)
                {
                    msg = msg.Replace(arr[i].ToString(), "");
                }
                if (msg != "")
                {
                    ((TextBox)sender).Text = ((TextBox)sender).Name;
                    MessageBox.Show("В это поле может быть введено только целое положительное число!");
                }
            }
            void int_txt_GotFocus(object sender, EventArgs e)
            {
                ((TextBox)sender).Name = ((TextBox)sender).Text;
            }
            public void Resize(int width, int height)
            {
                this.AutoSize = false;
                this.Size = new Size(width, height);
                title.Width = this.Width;
                for (int i = 0; i < 5; i++)
                {
                    if (panels[i] != null)
                        panels[i].Width = this.Width;
                }
            }

            void CalcDet()
            {
                string[] rows = matrix_input.Text.Split(new char[] { '\r' });
                double[,] A = new double[rows.Length, rows.Length];
                try
                {
                    for (int i = 0; i < rows.Length; i++)
                    {
                        rows[i] = rows[i].Replace("\n", "");
                        string[] cols = rows[i].Split(new char[] { ' ' });
                        if (cols.Length != rows.Length)
                        {
                            MessageBox.Show("Данные введены некорректно!");
                            return;
                        }
                        for (int j = 0; j < cols.Length; j++)
                        {
                            A[i, j] = Convert.ToDouble(cols[j].Replace(".", ","));
                        }
                    }
                    NumMeth meth = new NumMeth();
                    meth.setA(A, rows.Length);
                    double det = meth.getDet();
                    MessageBox.Show("Определитель равен: " +
                    Math.Round(det, 5).ToString());
                }
                catch (Exception e)
                {
                    MessageBox.Show("Данные введены некорректно!");
                }
            }

            void GenerateSLAU()
            {
                int[] arrayN = null; // Массив порядков матриц.
                double[] array1 = null; // Массив времени выполнения.
                double[] array2 = null; // Массив погрешности.
                double[] array3 = null; // Массив теоретического числа операций.
                double[] array4 = null; // Массив фактического числа операций.
                Label tit = null; // Метка для вывода ответа.
                int start_n = Convert.ToInt32(int_ot_txt.Text);
                // Переводим значения текстовых полей в числовой формат.
                int end_n = Convert.ToInt32(int_do_txt.Text); //
                int step_n = Convert.ToInt32(step_txt.Text);
                double ar = Convert.ToDouble(arg.Text.Replace('.', ','));
                switch (comb[0].SelectedIndex)
                {
                    case 0:
                        {
                            Form2 handSlau = new Form2();
                            // Создаём форму с вводом матрицы.
                            if (handSlau.ShowDialog() == DialogResult.OK)
                            {
                                // Открываем её в режиме диалога.
                                arrayN = new int[1]; // Так как матрица вводится одна,
                                                     // то и размеры массивов будут равны единице.
                                array1 = new double[1];
                                array2 = new double[1];
                                array3 = new double[1];
                                array4 = new double[1];
                                NumMeth num = new NumMeth(0);
                                // Создаём экземпляр класса NumMeth.
                                num.setA(handSlau.A, handSlau.N);
                                // Вызываем метод LU-разложения.
                                if (num.flagError)
                                { // Проверям флаг ошибки.
                                    MessageBox.Show("Произошло деление на ноль! \r\nРешение данной системы через LU - разложение невозможно!");
                                    return;
                                }
                                // Читаем остальные введённые данные.
                                double[] X_toch = handSlau.X;
                                double[] B_toch = handSlau.B;
                                double[] X = num.getX(B_toch); // Решаем СЛАУ.
                                array1[0] = num.TIME; // Фиксируем данные для отчёта.
                                array3[0] = num.OPER_T;
                                array4[0] = num.OPER_F;
                                if (X_toch != null)
                                {
                                    // Если X_toch был введён, то вычисляем погрешность, сравнивая эти
                                    // векторы.
                                    array2[0] = num.VectorPogr(X_toch, X);
                                }
                                else
                                {
                                    // Если X_toch введён не был, то погрешность находим через
                                    // сравнение правых частей СЛАУ.
                                    double[] B = num.getB(handSlau.A, X, handSlau.N);
                                    array2[0] = num.VectorPogr(B, B_toch);
                                }
                                arrayN[0] = handSlau.N; // Запоминаем порядок матрицы.
                                tit = new Label(); // Записываем решение.
                                tit.Text = "X = [ ";
                                tit.AutoSize = false;
                                tit.Width = 800;
                                for (int i = 0; i < handSlau.N; i++)
                                {
                                    tit.Text += X[i].ToString();
                                    if (i != handSlau.N - 1) tit.Text += " ; ";
                                }
                                tit.Text += " ]";
                            }
                            else
                            {
                                return;
                            }
                        }
                        break;
                    case 1:
                        {
                            arrayN = new int[(end_n - start_n) / step_n + 1];
                            // Вычисляем и присваиваем длину массива.
                            array1 = new double[arrayN.Length];
                            array2 = new double[arrayN.Length];
                            array3 = new double[arrayN.Length];
                            array4 = new double[arrayN.Length];
                            int l = 0; // Заводим счётчик.
                            for (int i = start_n; i <= end_n; i += step_n)
                            {
                                arrayN[l] = i; // Запоминаем размер матрицы.
                                SpecMatrix matrix; // Создаём экземпляр SpecMatrix.
                                NumMeth lu = null; // Создаём экземпляр NumMeth.
                                do
                                {
                                    lu = new NumMeth(Math.E);
                                    // Так как при случайных матрицах может произойти деление на ноль,

                                    // то выполняем этот цикл до тех пор, пока не будет найдена
                                    // подходящая матрица.
                                    matrix = new SpecMatrix(i, 11);
                                    lu.setA(matrix.Matrix, i);
                                } while (lu.flagError);
                                double[] X_toch = new double[i];
                                // Создаём точное решение системы.
                                for (int j = 0; j < i; j++) X_toch[j] = j + 1;
                                double[] B = lu.getB(matrix.Matrix, X_toch, i);
                                // На основе точного решения вычисляем B.
                                double[] X = lu.getX(B); // Вычисляем вектор X.
                                array1[l] = lu.TIME; // Фиксируем данные для отчёта.
                                array2[l] = lu.VectorPogr(X_toch, X);
                                array3[l] = lu.OPER_T;
                                array4[l] = lu.OPER_F;
                                l++; // Увеличиваем счётчик.
                            }
                        }
                        break;

                    case 2:
                        {
                            arrayN = new int[(end_n - start_n) / step_n + 1];
                            // Вычисляем и присваиваем длину массива.
                            array1 = new double[arrayN.Length];
                            array2 = new double[arrayN.Length];
                            array3 = new double[arrayN.Length];
                            array4 = new double[arrayN.Length];
                            bool flag = false;
                            SpecMatrix matrix; // Создаём экземпляр SpecMatrix.
                            NumMeth lu = new NumMeth(Math.E);// Создаём экземпляр NumMeth.
                            switch (comb[1].SelectedIndex + 1)
                            {
                                case 2:
                                    matrix = new SpecMatrix(2);
                                    lu.setA(matrix.Matrix, 20);
                                    arrayN = new int[1];
                                    arrayN[0] = lu.N;
                                    flag = true;
                                    break;
                                case 3:
                                    matrix = new SpecMatrix(3);
                                    lu.setA(matrix.Matrix, 7);
                                    arrayN = new int[1];
                                    arrayN[0] = lu.N;
                                    flag = true;
                                    break;
                                case 6:
                                    matrix = new SpecMatrix(ar);
                                    lu.setA(matrix.Matrix, 8);
                                    arrayN = new int[1];
                                    arrayN[0] = lu.N;
                                    flag = true;
                                    break;
                                case 10:
                                    matrix = new SpecMatrix(10);
                                    lu.setA(matrix.Matrix, 4);
                                    arrayN = new int[1];
                                    arrayN[0] = lu.N;
                                    flag = true;
                                    break;

                            }

                            if (!flag)
                            {
                                int l = 0; // Заводим счётчик.
                                for (int i = start_n; i <= end_n; i += step_n)
                                {
                                    arrayN[l] = i; // Запоминаем размер матрицы.
                                    matrix = null; // Создаём экземпляр SpecMatrix.
                                    lu = new NumMeth(Math.E);// Создаём экземпляр NumMeth.
                                    switch (comb[1].SelectedIndex + 1)
                                    {
                                        case 1:
                                            matrix = new SpecMatrix(i, 1);
                                            lu.setA(matrix.Matrix, i);
                                            break;

                                        case 4:
                                            matrix = new SpecMatrix(i, 4);
                                            lu.setA(matrix.Matrix, i);
                                            break;
                                        case 5:
                                            matrix = new SpecMatrix(i, 11);
                                            lu.setA(matrix.Matrix, i);
                                            break;

                                        case 7:
                                            matrix = new SpecMatrix(i, 7, ar);
                                            lu.setA(matrix.Matrix, i);
                                            break;
                                        case 8:
                                            matrix = new SpecMatrix(i, 8, ar);
                                            lu.setA(matrix.Matrix, i);
                                            break;
                                        case 9:
                                            matrix = new SpecMatrix(i, 9, ar);
                                            lu.setA(matrix.Matrix, i);
                                            break;


                                    }
                                    double[] X_toch = new double[i];
                                    // Создаём точное решение системы.
                                    for (int j = 0; j < i; j++) X_toch[j] = j + 1;
                                    double[] B = lu.getB(matrix.Matrix, X_toch, i);
                                    // На основе точного решения вычисляем B.
                                    double[] X = lu.getX(B); // Вычисляем вектор X.
                                    array1[l] = lu.TIME; // Фиксируем данные для отчёта.
                                    array2[l] = lu.VectorPogr(X_toch, X);
                                    array3[l] = lu.OPER_T;
                                    array4[l] = lu.OPER_F;
                                    l++; // Увеличиваем счётчик.

                                }
                            }
                            else
                            {
                                double[] X_toch = new double[arrayN[0]];
                                // Создаём точное решение системы.
                                for (int j = 0; j < arrayN[0]; j++) X_toch[j] = j + 1;
                                double[] B = lu.getB(lu.A, X_toch, arrayN[0]);
                                // На основе точного решения вычисляем B.
                                double[] X = lu.getX(B); // Вычисляем вектор X.
                                array1[0] = lu.TIME; // Фиксируем данные для отчёта.
                                array2[0] = lu.VectorPogr(X_toch, X);
                                array3[0] = lu.OPER_T;
                                array4[0] = lu.OPER_F;
                            }
                         
                        }
                        break;
                }


                // Создаём панель для вывода отчёта.
                OutputFlowLayoutPanel output_panel =
                new OutputFlowLayoutPanel(arrayN, array1, array2, array3, array4);

                // Создаём новую форму.
                Report_form output_form = new Report_form();
                // Добавляем на форму панель.
                output_form.flowLayoutPanel1.Controls.Add(output_panel);
                // Если был записан ответ, то его также добавляем на форму.
                if (tit != null)
                {
                    Panel otvet = new Panel();
                    otvet.Location = new System.Drawing.Point(10, 100);
                    otvet.Controls.Add(tit);
                    otvet.Width = 800;
                    output_form.flowLayoutPanel1.Controls.Add(otvet);
                }
                // Открываем форму в режиме диалога
                output_form.ShowDialog();
            }


            void GenerateInv()
            {
                int[] arrayN = null; // Массив порядков матриц.
                double[] array1 = null; // Массив времени выполнения. Способ 1
                double[] array2 = null; // Массив времени выполнения. Способ 2
                double[] array3 = null; // Массив погрешности. Способ 1
                double[] array4 = null; // Массив погрешности. Способ 2
                double[] array5 = null; // Массив фактического числа операций. Способ 1
                double[] array6 = null; // Массив фактического числа операций. Способ 2
                double[] array7 = null; // Массив теоретического числа операций.
                Label tit = null; // Метка для вывода ответа.
                int start_n = Convert.ToInt32(int_ot_txt.Text);
                // Переводим значения текстовых полей в числовой формат.
                int end_n = Convert.ToInt32(int_do_txt.Text); //
                int step_n = Convert.ToInt32(step_txt.Text);
                if (step_n == 0)
                {
                    step_n = 1;
                }
                double ar = Convert.ToDouble(arg.Text.Replace('.', ','));
                switch (comb[0].SelectedIndex)
                {
                    case 0:
                        {
                            HandInputINV handInv = new HandInputINV();
                            // Создаём форму с вводом матрицы.
                            if (handInv.ShowDialog() == DialogResult.OK)
                            {
                                // Открываем её в режиме диалога.
                                arrayN = new int[1]; // Так как матрица вводится одна,
                                                     // то и размеры массивов будут равны единице.
                                array1 = new double[1];
                                array2 = new double[1];
                                array3 = new double[1];
                                array4 = new double[1];
                                array5 = new double[1];
                                array6 = new double[1];
                                array7 = new double[1];
                                NumMeth num = new NumMeth(0);
                                // Создаём экземпляр класса NumMeth.
                                num.setA(handInv.A, handInv.N);
                                // Вызываем метод LU-разложения.
                                if (num.flagError)
                                { // Проверям флаг ошибки.
                                    MessageBox.Show("Произошло деление на ноль! \r\nРешение данной системы через LU - разложение невозможно!");
                                    return;
                                }

                                double[,] A1 = num.Inv1(handInv.A, handInv.N); // Находим обратную матрицу 
                                array1[0] = num.TIME; // Фиксируем данные для отчёта.
                                array7[0] = num.OPER_T;
                                array5[0] = num.OPER_F;
                                array3[0] = num.PogreshInv(handInv.A, A1, handInv.N);
                                double[,] A12 = num.Inv2(handInv.A, handInv.N); // Находим обратную матрицу 
                                array2[0] = num.TIME; // Фиксируем данные для отчёта.
                                array6[0] = num.OPER_F;
                                array4[0] = num.PogreshInv(handInv.A, A12, handInv.N);
                                //if (X_toch != null)
                                //{
                                //    // Если X_toch был введён, то вычисляем погрешность, сравнивая эти
                                //    // векторы.
                                //    array2[0] = num.VectorPogr(X_toch, X);
                                //}
                                arrayN[0] = handInv.N; // Запоминаем порядок матрицы.
                                tit = new Label(); // Записываем решение.
                                tit.Text = "A-1 = [ ";
                                tit.AutoSize = false;
                                tit.Width = 800;
                                tit.Height = 200;
                                for (int i = 0; i < handInv.N; i++)
                                {
                                    for (int j = 0; j < handInv.N; j++)
                                    {
                                        tit.Text += string.Format("{0,20:0.########}", A1[i, j]) + "\t";
                                    }
                                    tit.Text += "\n";
                                }
                                tit.Text += " ]";
                                tit.Text += "\nA-12 = [ ";

                                for (int i = 0; i < handInv.N; i++)
                                {
                                    for (int j = 0; j < handInv.N; j++)
                                    {
                                        tit.Text += string.Format("{0,20:0.########}", A12[i, j]) + "\t";
                                    }
                                    tit.Text += "\n";
                                }
                                tit.Text += " ]";
                            }
                            else
                            {
                                return;
                            }
                        }
                        break;
                    case 1:
                        {
                            arrayN = new int[(end_n - start_n) / step_n + 1];
                            // Вычисляем и присваиваем длину массива.
                            array1 = new double[arrayN.Length];
                            array2 = new double[arrayN.Length];
                            array3 = new double[arrayN.Length];
                            array4 = new double[arrayN.Length];
                            array5 = new double[arrayN.Length];
                            array6 = new double[arrayN.Length];
                            array7 = new double[arrayN.Length];
                            int l = 0; // Заводим счётчик.
                            for (int i = start_n; i <= end_n; i += step_n)
                            {
                                arrayN[l] = i; // Запоминаем размер матрицы.
                                SpecMatrix matrix; // Создаём экземпляр SpecMatrix.
                                NumMeth lu = null; // Создаём экземпляр NumMeth.
                                do
                                {
                                    lu = new NumMeth(Math.E);
                                    // Так как при случайных матрицах может произойти деление на ноль,

                                    // то выполняем этот цикл до тех пор, пока не будет найдена
                                    // подходящая матрица.
                                    matrix = new SpecMatrix(i, 11);
                                    lu.setA(matrix.Matrix, i);
                                } while (lu.flagError);
                                double[,] A1 = lu.Inv1(lu.A, i); // Находим обратную матрицу 
                                array1[l] = lu.TIME; // Фиксируем данные для отчёта.
                                array7[l] = lu.OPER_T;
                                array5[l] = lu.OPER_F;
                                array3[l] = lu.PogreshInv(lu.A, A1, i);
                                double[,] A12 = lu.Inv2(lu.A, i); // Находим обратную матрицу 
                                array2[l] = lu.TIME; // Фиксируем данные для отчёта.
                                array6[l] = lu.OPER_F;
                                array4[l] = lu.PogreshInv(lu.A, A12, i);

                                l++; // Увеличиваем счётчик.
                            }
                        }
                        // Создаём панель для вывода отчёта.
                        OutputFlowLayoutPanel output_panel =
                        new OutputFlowLayoutPanel(arrayN, array1, array2, array3, array4, array5, array6, array7, arrayN[0]);

                        // Создаём новую форму.
                        Report_form output_form = new Report_form();
                        // Добавляем на форму панель.
                        output_form.flowLayoutPanel1.Controls.Add(output_panel);
                        // Если был записан ответ, то его также добавляем на форму.
                        if (tit != null)
                        {
                            Panel otvet = new Panel();
                            otvet.Location = new Point(10, 100);
                            otvet.Controls.Add(tit);
                            otvet.Width = 800;
                            otvet.Height = 200;
                            output_form.flowLayoutPanel1.Controls.Add(otvet);
                        }
                        // Открываем форму в режиме диалога
                        output_form.ShowDialog();
                        break;

                    case 2: {
                            arrayN = new int[(end_n - start_n) / step_n + 1];
                            // Вычисляем и присваиваем длину массива.
                            array1 = new double[arrayN.Length];
                            array2 = new double[arrayN.Length];
                            array3 = new double[arrayN.Length];
                            array4 = new double[arrayN.Length];
                            array5 = new double[arrayN.Length];
                            array6 = new double[arrayN.Length];
                            array7 = new double[arrayN.Length];
                            bool flag = false;
                            SpecMatrix matrix; // Создаём экземпляр SpecMatrix.
                            NumMeth lu = new NumMeth(Math.E);// Создаём экземпляр NumMeth.
                            switch (comb[1].SelectedIndex + 1)
                            {
                                case 2:
                                    matrix = new SpecMatrix(2);
                                    lu.setA(matrix.Matrix, 20);
                                    flag = true;
                                    break;
                                case 3:
                                    matrix = new SpecMatrix(3);
                                    lu.setA(matrix.Matrix, 7);
                                    flag = true;
                                    break;
                                case 6:
                                    matrix = new SpecMatrix(ar);
                                    lu.setA(matrix.Matrix, 8);
                                    flag = true;
                                    break;
                                case 10:
                                    matrix = new SpecMatrix(10);
                                    lu.setA(matrix.Matrix, 4);
                                    flag = true;
                                    break;

                            }

                            if (!flag)
                            {
                                int l = 0; // Заводим счётчик.
                                for (int i = start_n; i <= end_n; i += step_n)
                                {
                                    arrayN[l] = i; // Запоминаем размер матрицы.
                                    matrix = null; // Создаём экземпляр SpecMatrix.
                                    lu = new NumMeth(Math.E);// Создаём экземпляр NumMeth.
                                    switch (comb[1].SelectedIndex + 1)
                                    {
                                        case 1:
                                            matrix = new SpecMatrix(i, 1);
                                            lu.setA(matrix.Matrix, i);
                                            break;

                                        case 4:
                                            matrix = new SpecMatrix(i, 4);
                                            lu.setA(matrix.Matrix, i);
                                            break;
                                        case 5:
                                            matrix = new SpecMatrix(i, 11);
                                            lu.setA(matrix.Matrix, i);
                                            break;

                                        case 7:
                                            matrix = new SpecMatrix(i, 7, ar);
                                            lu.setA(matrix.Matrix, i);
                                            break;
                                        case 8:
                                            matrix = new SpecMatrix(i, 8, ar);
                                            lu.setA(matrix.Matrix, i);
                                            break;
                                        case 9:
                                            matrix = new SpecMatrix(i, 9, ar);
                                            lu.setA(matrix.Matrix, i);
                                            break;


                                    }
                                    double[,] A1 = lu.Inv1(lu.A, i); // Находим обратную матрицу 
                                    array1[l] = lu.TIME; // Фиксируем данные для отчёта.
                                    array7[l] = lu.OPER_T;
                                    array5[l] = lu.OPER_F;
                                    array3[l] = lu.PogreshInv(lu.A, A1, i);
                                    double[,] A12 = lu.Inv2(lu.A, i); // Находим обратную матрицу 
                                    array2[l] = lu.TIME; // Фиксируем данные для отчёта.
                                    array6[l] = lu.OPER_F;
                                    array4[l] = lu.PogreshInv(lu.A, A12, i);

                                    l++; // Увеличиваем счётчик.

                                }
                            } else
                            {                             
                                arrayN = new int[1];
                                arrayN[0] = lu.N;
                                double[,] A1 = lu.Inv1(lu.A, lu.N); // Находим обратную матрицу 
                                array1[0] = lu.TIME; // Фиксируем данные для отчёта.
                                array7[0] = lu.OPER_T;
                                array5[0] = lu.OPER_F;
                                array3[0] = lu.PogreshInv(lu.A, A1, lu.N);
                                double[,] A12 = lu.Inv2(lu.A, lu.N); // Находим обратную матрицу 
                                array2[0] = lu.TIME; // Фиксируем данные для отчёта.
                                array6[0] = lu.OPER_F;
                                array4[0] = lu.PogreshInv(lu.A, A12, lu.N);
                            }
                           output_form = new Report_form();
                            if (flag)
                            {
                                // Создаём панель для вывода отчёта.
                                output_panel =
                                new OutputFlowLayoutPanel(arrayN, array1, array2, array3, array4, array5, array6, array7, arrayN[0]);

                                // Создаём новую форму.

                                // Добавляем на форму панель.
                                output_form.flowLayoutPanel1.Controls.Add(output_panel);
                                // Если был записан ответ, то его также добавляем на форму.
                                if (tit != null)
                                {
                                    Panel otvet = new Panel();
                                    otvet.Location = new Point(10, 100);
                                    otvet.Controls.Add(tit);
                                    otvet.Width = 800;
                                    otvet.Height = 200;
                                    output_form.flowLayoutPanel1.Controls.Add(otvet);
                                }
                            }
                            else
                            {
                                // Создаём панель для вывода отчёта.
                                output_panel =
                                new OutputFlowLayoutPanel(arrayN, array1, array2, array3, array4, array5, array6, array7);

                                // Создаём новую форму.
                               
                                // Добавляем на форму панель.
                                output_form.flowLayoutPanel1.Controls.Add(output_panel);
                                // Если был записан ответ, то его также добавляем на форму.
                                if (tit != null)
                                {
                                    Panel otvet = new Panel();
                                    otvet.Location = new Point(10, 100);
                                    otvet.Controls.Add(tit);
                                    otvet.Width = 800;
                                    otvet.Height = 200;
                                    output_form.flowLayoutPanel1.Controls.Add(otvet);
                                }
                            }
                            // Открываем форму в режиме диалога
                            output_form.ShowDialog();
                        } break;
                }
            }
           
        }

    }

}
