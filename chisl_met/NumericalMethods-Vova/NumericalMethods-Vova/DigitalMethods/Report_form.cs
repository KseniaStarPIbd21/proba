using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DigitalMethods
{
    public partial class Report_form : Form
    {
        public Report_form()
        {
            InitializeComponent();
        }

        private void Report_form_Load(object sender, EventArgs e)
        {

        }
    }

    class TablePanel : TableLayoutPanel
    {
        // Унаследован от контейнера TableLayoutPanel.
        double eps;
        // В значение этой переменной будет записан машинный эпсилон.
        // Массив из двух цветов,
        // чтобы проще было читать данные из таблицы.
        System.Drawing.Color[] colors = new System.Drawing.Color[]
        { System.Drawing.Color.White, System.Drawing.Color.LightGray };
        // Конструктор:
        // В этот конструктор передается 5 массивов, в теле
        // генерируется таблица для отчёта по решению СЛАУ, array1 -
        // массив с порядками матриц, array2 - массив с временем
        // выполнения операций, array3 - массив с погрешностями,
        // array4 - массив с теоретическим числом операций, array5 -
        // массив с фактическим числом операций.
        public TablePanel(int[] array1, double[] array2, double[] array3,
        double[] array4, double[] array5)
        {
            double a = 1; // Вычисляем машинный эпсилон.
            do { eps = a; a /= 2; } while (a != 0);
            this.Padding = new Padding(0, 0, 0, 0);
            // Обнуляем отступы в таблице.
            this.RowCount = array1.Length + 1;
            // Вычисляем и присваиваем количество строк.
            this.ColumnCount = 5; // Присваиваем количество столбцов.
            this.AutoSize = true;
            // Устанавливаем автоматический подгон размеров.
            // Строковый массив с заголовками столбцов.
            string[] titles = new string[] { "Порядок", "Время",
"Точность", "Теор. ЧО", "Факт. ЧО"};
            for (int i = 0; i < titles.Length; i++)
            {
                // В этом цикле создаются заголовки столбцов
                Label l = new Label();
                // Создание метки с текстом (заголовок столбца).
                l.Text = titles[i]; // Присваиваем название столбца.
                l.AutoSize = false; // Устанавливаем точные размеры,
                l.Width = 125; // иначе таблица может получиться
                               // "кривой".

                l.Height = 20;
                l.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
                // Убираем отступы.
                l.BackColor = System.Drawing.Color.DarkGray;
                // Закрашиваем в темно-серый цвет.
                l.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                // Выравнивание текста по центру.
                l.ForeColor = System.Drawing.Color.White;
                // Цвет текста - белый.
                this.Controls.Add(l);
                // Добавляем элемент в таблицу.
            }
            for (int i = 0; i < array1.Length; i++)
            {
                // Заполняем таблицу данными.
                Label[] labs = new Label[5];
                // В каждой строке будет 5 столбцов.
                for (int j = 0; j < 5; j++)
                { // Создаём и оформляем ячейки.
                    labs[j] = new Label();
                    labs[j].Margin = new
                    System.Windows.Forms.Padding(0, 0, 0, 0);
                    labs[j].AutoSize = false;
                    labs[j].TextAlign =
                    System.Drawing.ContentAlignment.MiddleCenter;
                    labs[j].BorderStyle =
                    System.Windows.Forms.BorderStyle.FixedSingle;
                    labs[j].BackColor = colors[i % 2];
                    labs[j].Width = 125;
                    labs[j].Height = 20;
                    this.Controls.Add(labs[j]);
                }
                labs[0].Text = array1[i].ToString();
                // Заполнение ячеек данными.
                labs[1].Text = Mant(array2[i]);
                labs[2].Text = Mant(array3[i]);
                labs[3].Text = Mant(array4[i]);
                labs[4].Text = Mant(array5[i]);
            }

        }
        // Конструктор:
        // Этот конструктор вызывается для отчёта по обращению матриц,
        // array1 - порядки матриц,
        // array2 - время выполнения 1 способом,
        // array3 - время выполнения 2 способом,
        // array4 - погрешность 1 способом,
        // array5 - погрешность 2 способом,
        // array6 - число операций 1 способом,
        // array7 - число операций 2 способом,
        // array8 - теоретическое число операций.
        public TablePanel(int[] array1, double[] array2,
        double[] array3,
        double[] array4, double[] array5, double[]
        array6,
        double[] array7, double[] array8)
        {
            double a = 1;
            do { eps = a; a /= 2; } while (a != 0);
            this.Padding = new Padding(0, 0, 0, 0);
            this.RowCount = array1.Length + 1;
            this.ColumnCount = 8;
            this.AutoSize = true;
            string[] titles = new string[] { "Порядок",
"Время 1",
"Время 2",
"Погрешность 1",
"Погрешность 2",
"Реал. ЧО 1",
"Реал. ЧО 2",
"Теор. ЧО"};
            for (int i = 0; i < titles.Length; i++)
            {
                Label l = new Label();
                l.Text = titles[i];
                l.AutoSize = false;
                l.Width = 125;
                l.Height = 20;

                l.Margin = new Padding(0, 0, 0, 0);
                l.BackColor = Color.DarkGray;
                l.TextAlign = ContentAlignment.MiddleCenter;
                l.ForeColor = Color.White;
                this.Controls.Add(l);
            }
            for (int i = 0; i < array1.Length; i++)
            {
                Label[] labs = new Label[8];
                for (int j = 0; j < 8; j++)
                {
                    labs[j] = new Label();
                    labs[j].Margin = new
                    System.Windows.Forms.Padding(0, 0, 0, 0);
                    labs[j].AutoSize = false;
                    labs[j].TextAlign =
                    System.Drawing.ContentAlignment.MiddleCenter;
                    labs[j].BorderStyle =
                    System.Windows.Forms.BorderStyle.FixedSingle;
                    labs[j].BackColor = colors[i % 2];
                    labs[j].Width = 125;
                    labs[j].Height = 20;
                    this.Controls.Add(labs[j]);
                }
                labs[0].Text = array1[i].ToString();
                labs[1].Text = Mant(array2[i]);
                labs[2].Text = Mant(array3[i]);
                labs[3].Text = Mant(array4[i]);
                labs[4].Text = Mant(array5[i]);
                labs[5].Text = Mant(array6[i]);
                labs[6].Text = Mant(array7[i]);
                labs[7].Text = Mant(array8[i]);

               
            }
            //using (StreamWriter sw = new StreamWriter("D:/" + DateTime.Now.ToString("yyyy.MM.dd_HH-mm-ss") + ".txt"))
            //    {
            //    for (int i = 0; i < array1.Length; i++)
            //    {
            //        sw.WriteLine(labs[].Text);
            //    }
            //    }
        }
        string Mant(double arg)
        {
            int pow = 0;
            if (arg >= 1 && arg < 1000) return
            Math.Round(arg, 4).ToString();
            if (arg >= 1000)
            {
                while (arg > 100)
                {
                    arg /= 10;
                    pow++;
                }
                return
                Math.Round(arg, 4).ToString() + "*(10^" + pow.ToString() + ")";
            }
            if (arg < eps) arg = eps;
            while (arg < 1) { pow++; arg *= 10; }
            return
            Math.Round(arg, 4).ToString() + "*(-10^" + pow.ToString() + ")";
        }
    }


    class GraphicPanel : PictureBox
    {
        int x_c, y_c, x_max, y_max;
        // В переменных будет записано значение начала координат и
        // максимальное значение в пикселях.
        Graphics g;
        // Переменная, через которую будет всё рисоваться на Bitmap.
        Bitmap btm;
        // Само изображение, которое будет выводить изображение на этот
        // экземпляр этого класса (Класс унаследован от PictureBox).
        int N_S; // Начало отсчёта порядка матриц
        int N_E; // Конец отсчёта порядка матриц
        int N_STEP; // Шаг, с которым будет изменяться порядок матрицы

        Label title = new Label();
        // Метка с текстом, будет появляться при наведении пользователем
        // указателя мыши на график. В тексте будет указано точно
        // значение по оси Y для текущего положения курсора.
        double strForText;
        // В переменной будет сохранено значение по оси Y, которое
        // приходится на 1 px
        // Конструктор:
        public GraphicPanel(String x_name, String y_name, int n_s,
        int n_e, int n_step)
        {
            // Аргументы: x_name - метка оси X, y_name - метка оси Y,
            // n_s - начало отсчёта порядка матриц, n_e - конец отсчёта
            // порядка матриц, n_step - шаг изменения порядка матрицы
            title.BorderStyle =
            System.Windows.Forms.BorderStyle.FixedSingle;
            // Оформление и добавление метки с текстом на экземпляр этого
            // класса
            title.Visible = false;
            this.Controls.Add(title);
            this.MouseMove += GraphicPanel_MouseMove;
            // Присваиваем метод событию движения мыши по графику.
            N_S = n_s;
            // Сохраняем начало, конец отсчёта и шаг в глобальные переменные.
            N_E = n_e;
            N_STEP = n_step;
            this.Width = 600; // Устанавливаем размер графика
            this.Height = 600;
            x_c = 10;
            // Устанавливаем границы рабочей части графика.
            y_c = 400;
            x_max = 580;
            y_max = 10;
            this.BackColor = Color.White; // Делаем белый фон
                                          // на графике.
            btm = new Bitmap(this.Width, this.Height);
            // Создаём Bitmap по размерам этого класса.
            g = Graphics.FromImage(btm); // Создаём экземпляр класса

            // Graphics.
            // Рисуем оси, стрелки и название осей.
            g.DrawLine(new Pen(Color.Black, 2), new Point(x_c, y_c),
new Point(x_c, y_max));
            g.DrawLine(new Pen(Color.Black, 2), new Point(x_c, y_c),
            new Point(x_max, y_c));
            g.DrawLine(new Pen(Color.Black, 2), new Point(x_c, y_max),
            new Point(x_c - 5, y_max + 5));
            g.DrawLine(new Pen(Color.Black, 2), new Point(x_c, y_max),
            new Point(x_c + 5, y_max + 5));
            g.DrawLine(new Pen(Color.Black, 2), new Point(x_max, y_c),
            new Point(x_max - 5, y_c + 5));
            g.DrawLine(new Pen(Color.Black, 2), new Point(x_max, y_c),
            new Point(x_max - 5, y_c - 5));
            g.DrawString(x_name, new Font(x_name, 9),
            new SolidBrush(Color.Blue), new PointF(x_c + 5, y_max - 5));
            int x_ = x_max - y_name.Length * 6;
            g.DrawString(y_name, new Font("Arial", 9),
            new SolidBrush(Color.Blue), new PointF(x_, y_c - 20));
            y_max += 10;
            x_max -= 10;
            this.Image = btm;
         
            // Присваиваем изображению этого класса только что созданный
            // Bitmap.
        }
        // Метод, вызываемый при движении курсора мыши по графику.
        void GraphicPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.X > x_c && e.X < x_max && e.Y < y_c && e.Y > y_max)
            {
                // Если курсор находится над рабочей частью графика, то делаем
                // видимой подсказку,
                title.Visible = true;
                title.Top = e.Y + 5;
                // присваиваем ей новое положение
                if (e.X + title.Width + 15 > this.Width) title.Left =
                e.X - title.Width - 5;
                else title.Left = e.X + 15;
                double val = (double)(y_c - e.Y) * strForText;

                // и записываем в неё новый текст.
                if (val > 10 && val < 100000) title.Text =
                Math.Round(val, 4).ToString();
                else title.Text = Mant(val);
            }
            else
            {
                title.Visible = false;
            }
        }
        // Метод добавления одного графика
        public void setData(double[] array1, String name1)
        {
            // Аргументы: array1 - набор значений для отрисовки,
            // name1 - имя графика для истории.
            double max = Max(array1);
            // Ищем максимальное значение в массиве.
            strForText = max / 380;
            // Вычисляем, какое значение приходится на один пиксель.
            LoadPanel(max);
            // Создаём разметку.
            DrawGraphic(Color.Green, array1, max);
            // Рисуем график
            DrawHistory(name1, Color.Green, x_c + 10, y_c + 20);
            // Пишем пояснение к графику (историю).
            if (File.Exists("D:/" + DateTime.Now.ToString("yyyy.MM.dd_HH-mm-ss-ms") + "№1.bmp"))
            {
                btm.Save("D:/№1.bmp");
            }
            else
            {
                btm.Save("D:/" + DateTime.Now.ToString("yyyy.MM.dd_HH-mm-ss-ms") + "№1.bmp");
            }
        }
        // Метод добавления двух графиков.
        public void setData(double[] array1, double[] array2,
        String name1, String name2)
        {
            // Аргументы: array1, array2 - наборы значений для двух графиков,
            // name1, name2 - имена графиков.
            double max = Max(Max(array1), Max(array2));
            // Ищем максимум из двух массивов.
            strForText = max / 380;
            // Вычисляем, какое значение приходится на 1px.
            LoadPanel(max); //Делаем разметку.
            DrawGraphic(Color.Green, array1, max); // Рисуем графики.
            DrawGraphic(Color.Blue, array2, max);
            DrawHistory(name1, Color.Green, x_c + 10, y_c + 20);

            // Рисуем историю.
            DrawHistory(name2, Color.Blue, x_c + 10, y_c + 45);
            if (File.Exists("D:/" + DateTime.Now.ToString("yyyy.MM.dd_HH-mm-ss-ms") + "№2.bmp"))
            {
                btm.Save("D:/№2.bmp");
            }
            else {
                btm.Save("D:/" + DateTime.Now.ToString("yyyy.MM.dd_HH-mm-ss-ms") + "№2.bmp");
            }
            
        }
        // Метод добавления трёх графиков.
        public void setData(double[] array1, double[] array2,
        double[] array3, String name1, String name2,
        String name3)
        {
            // Аргументы: array1, array2, array3 - наборы значений для
            // графиков; name1, name2, name3 - имена графиков.
            double max = Max(Max(Max(array1), Max(array2)), Max(array3));
            // Поиск максимума из трёх графиков.
            strForText = max / 380;
            // Вычисляем, какое значение приходится на 1px.
            LoadPanel(max); // Делаем разметку.
            DrawGraphic(Color.Green, array1, max); // Рисуем графики.
            DrawGraphic(Color.Blue, array2, max);
            DrawGraphic(Color.Red, array3, max);
            DrawHistory(name1, Color.Green, x_c + 10, y_c + 20);
            // Рисуем историю.
            DrawHistory(name2, Color.Blue, x_c + 10, y_c + 45);
            DrawHistory(name3, Color.Red, x_c + 10, y_c + 70);
            btm.Save("D:/"+ DateTime.Now.ToString("yyyy.MM.dd_HH-mm-ss")+"№3.bmp");
        }
        // Метод рисует график
        void DrawGraphic(Color color, double[] array, double max)
        {
            // Аргументы: color - цвет графика, array - значения для
            // отрисовки,
            // max - максимально возможное значение на всём графике.
            double stepY = 380 / max; // Вычисляем, сколько пикселей
                                      // приходится на единицу в значениях графика по Y.
            int step_x = 560 / array.Length; // Вычисляем, сколько пикселей
                                             // приходится на единицу в значениях графика по X.
            for (int i = 1; i < array.Length; i++)
            { // Рисуем график.
                int x1 = x_c + step_x * i;
                // Вычисляем коордниты текущей и предыдущей точек.
                int x2 = x_c + step_x * (i + 1);
                int y1 = y_c - (int)Math.Round(stepY * array[i - 1]);
                int y2 = y_c - (int)Math.Round(stepY * array[i]);

                Draw(color, 2, x1, x2, y1, y2); // Рисуем линию
            }

        }
        // Метод рисует строку и закрашеный цветной квадрат (пояснения
        // к графику).
        void DrawHistory(String str, Color color, int x, int y)
        {
            // Аргументы: str - строка для отрисовки, сolor - цвет отрисовки
            // квадрата, x, y - координаты.
            g.FillRectangle(new SolidBrush(color),
            new Rectangle(new Point(x, y), new Size(20, 20)));
            g.DrawString("-" + str, new Font("Arial", 14),
            new SolidBrush(Color.Black), new PointF(x + 24, y + 1));
        }
        // Метод выполняет разметку графика, а также подписывает значения
        // на осях координат.
        void LoadPanel(double max)
        {
            // Аргументы: max - максимальное возможное значение на графике.
            double step_str = (max) / 10;
            // Всего по оси Y будет 10 записей, вычисляем, сколько будет
            // приходиться на одну.
            int l = 1; // Заводим счётчик.
            int l_array = (N_E - N_S) / N_STEP;
            // Вычисляем количество элементов в массиве.
            double stepX = 560 / (double)l_array;
            // Вычисляем шаг по оси X в пикселях.
            int startStr = N_S; // Сохраняем начало отсчёта.
            for (int i = 1; i <= l_array; i++)
            {
                // Отрисовываем вертикальные полосы на графике и пишем к ним
                // пояснения через одно (чтобы график был более читабельным).
                int x = x_c + (int)Math.Round((double)i * stepX);
                Draw(Color.LightGray, 1, x, x, y_c - 2, y_max);
                if (i % 2 == 1)
                    DrawString(startStr.ToString(), x - 3, y_c + 3, 8);
                startStr += N_STEP;
            }
            for (int i = y_c - 38; i > y_max - 3; i -= 38)
            {
                // Рисуем горизонтальные полосы и подписываем значения по оси Y.

                Draw(Color.LightGray, 1, x_c + 1, x_max, i, i);
                DrawString(Mant(step_str * l), x_c + 3, i - 1, 8);
                l++;
            }
        }
        // Метод вывода текста на график.
        void DrawString(String str, int x, int y, float size)
        {
            g.DrawString(str, new Font("Arial", size),
            new SolidBrush(Color.Black), new PointF(x, y));
        }
        // Метод отрисовки прямой.
        void Draw(Color color, int size, int x1, int x2, int y1, int y2)
        { 
            if (x1 >0 && x2>0 && y1 >0 && y2 >0) { g.DrawLine(new Pen(color, size), new Point(x1, y1),
            new Point(x2, y2)); }
           
        }
        // Метод поиска максимума для двух значений.
        double Max(double a, double b) { return a > b ? a : b; }
        // Метод поиска максимума в массиве.
        double Max(double[] arg)
        {
            double result = 0;
            for (int i = 0; i < arg.Length; i++)
            {
                if (arg[i] > result) result = arg[i];
            }
            return result;
        }
        // Метод перевода вещественного числа в строку.
        string Mant(double arg)
        {
            int pow = 0;
            if (arg >= 1 && arg < 1000)
                return Math.Round(arg, 4).ToString();
            if (arg >= 1000)
            {
                while (arg > 100)
                {
                    arg /= 10;
                    pow++;
                }
                return Math.Round(arg, 4).ToString() + "*(10^" + pow.ToString() + ")";
            }
            while (arg < 1 && arg != 0) { pow++; arg *= 10; }
            return Math.Round(arg, 4).ToString() + "*(-10^" +
            pow.ToString() + ")";
        }
       
    }

    // Класс для отображения таблицы и графиков
    public class OutputFlowLayoutPanel : FlowLayoutPanel
    {

        // Конструктор для передачи данных об обращении матриц.       
        public OutputFlowLayoutPanel(int[] array1, double[] array2,
        double[] array3, double[] array4, double[] array5,
        double[] array6, double[] array7, double[] array8)
        {
            this.AutoSize = true;
            this.Controls.Add(new TablePanel(array1, array2, array3, array4,
            array5, array6, array7, array8));
            if (array1.Length != 1)
            {
                GraphicPanel graph1 = new GraphicPanel("Число операций",
                "Порядок матрицы", array1[0], array1[array1.Length - 1],
                array1[1] - array1[0]);
                GraphicPanel graph2 = new GraphicPanel("Время выполнения",
                "Порядок матрицы", array1[0], array1[array1.Length - 1],
                array1[1] - array1[0]);
                GraphicPanel graph3 = new GraphicPanel("Погрешность решения",
                "Порядок матрицы", array1[0], array1[array1.Length - 1],
                array1[1] - array1[0]);

                graph1.setData(array6, array7, array8, "Реал. ЧО сп.1",
                "Реал. ЧО сп.2", "Теор. ЧО");
                graph2.setData(array2, array3, "Время сп.1", "Время сп. 2");
                graph3.setData(array4, array5, "Погрешность сп.1",
                "Погрешность сп.2");
                this.Controls.Add(graph1);
                this.Controls.Add(graph2);
                this.Controls.Add(graph3);
            }
        }


        // Конструктор для передачи данных об обращении матриц.       
        public OutputFlowLayoutPanel(int[] array1, double[] array2,
        double[] array3, double[] array4, double[] array5,
        double[] array6, double[] array7, double[] array8, int n)
        {
            this.AutoSize = true;
            this.Controls.Add(new TablePanel(array1, array2, array3, array4,
            array5, array6, array7, array8));
            if (array1.Length != 1)
            {
                GraphicPanel graph1 = new GraphicPanel("Число операций",
                "Порядок матрицы", n,n,1);
                GraphicPanel graph2 = new GraphicPanel("Время выполнения",
                "Порядок матрицы", n, n, 1);
                GraphicPanel graph3 = new GraphicPanel("Погрешность решения",
                "Порядок матрицы", n, n, 1);

                graph1.setData(array6, array7, array8, "Реал. ЧО сп.1",
                "Реал. ЧО сп.2", "Теор. ЧО");
                graph2.setData(array2, array3, "Время сп.1", "Время сп. 2");
                graph3.setData(array4, array5, "Погрешность сп.1",
                "Погрешность сп.2");
                this.Controls.Add(graph1);
                this.Controls.Add(graph2);
                this.Controls.Add(graph3);
            }
        }
        //  Конструктор для передачи данных о решении СЛАУ
        public OutputFlowLayoutPanel(int[] array1, double[] array2,
        double[] array3, double[] array4, double[] array5)
        {
            this.AutoSize = true;
            this.Controls.Add(new TablePanel(array1, array2, array3, array4,
            array5));
            if (array1.Length != 1)
            {
                GraphicPanel graph1 = new GraphicPanel("Число операций",
                "Порядок матрицы", array1[0], array1[array1.Length - 1],
                array1[1] - array1[0]);
                GraphicPanel graph2 = new GraphicPanel("Время выполнения",
                "Порядок матрицы", array1[0], array1[array1.Length - 1],
                array1[1] - array1[0]);
                GraphicPanel graph3 = new GraphicPanel("Погрешность решения",
                "Порядок матрицы", array1[0], array1[array1.Length - 1],
                array1[1] - array1[0]);
                graph1.setData(array4, array5, "Теоретическое ЧО",
                "Фактическое ЧО");
                graph2.setData(array2, "Время выполнения");
                graph3.setData(array3, "Погрешность решения");
                this.Controls.Add(graph1);
                this.Controls.Add(graph2);
                this.Controls.Add(graph3);
            }
        }

        
    }
}
