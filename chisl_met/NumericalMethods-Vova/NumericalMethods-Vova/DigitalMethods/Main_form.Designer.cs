namespace DigitalMethods
{
    partial class Main_form
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.генерацияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ввестиСКлавиатурыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.случайнымОбразомToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.плохоОбусловленныеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.заданиеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tBResults = new System.Windows.Forms.TextBox();
            this.btn_fact = new System.Windows.Forms.Button();
            this.zadanie = new System.Windows.Forms.Label();
            this.tBMaxSize = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btn_clear = new System.Windows.Forms.Button();
            this.вид1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.вид2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.вид3ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.вид4ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.вид5ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.вид6ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.вид7ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.вид8ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.вид9ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.вид10ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.генерацияToolStripMenuItem,
            this.заданиеToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1271, 33);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // генерацияToolStripMenuItem
            // 
            this.генерацияToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ввестиСКлавиатурыToolStripMenuItem,
            this.случайнымОбразомToolStripMenuItem,
            this.плохоОбусловленныеToolStripMenuItem});
            this.генерацияToolStripMenuItem.Name = "генерацияToolStripMenuItem";
            this.генерацияToolStripMenuItem.Size = new System.Drawing.Size(110, 29);
            this.генерацияToolStripMenuItem.Text = "Генерация";
            // 
            // ввестиСКлавиатурыToolStripMenuItem
            // 
            this.ввестиСКлавиатурыToolStripMenuItem.Name = "ввестиСКлавиатурыToolStripMenuItem";
            this.ввестиСКлавиатурыToolStripMenuItem.Size = new System.Drawing.Size(281, 30);
            this.ввестиСКлавиатурыToolStripMenuItem.Text = "Ввести с клавиатуры";
            this.ввестиСКлавиатурыToolStripMenuItem.Click += new System.EventHandler(this.ввестиСКлавиатурыToolStripMenuItem_Click);
            // 
            // случайнымОбразомToolStripMenuItem
            // 
            this.случайнымОбразомToolStripMenuItem.Name = "случайнымОбразомToolStripMenuItem";
            this.случайнымОбразомToolStripMenuItem.Size = new System.Drawing.Size(281, 30);
            this.случайнымОбразомToolStripMenuItem.Text = "Случайным образом";
            this.случайнымОбразомToolStripMenuItem.Click += new System.EventHandler(this.случайнымОбразомToolStripMenuItem_Click);
            // 
            // плохоОбусловленныеToolStripMenuItem
            // 
            this.плохоОбусловленныеToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.вид1ToolStripMenuItem,
            this.вид2ToolStripMenuItem,
            this.вид3ToolStripMenuItem,
            this.вид4ToolStripMenuItem,
            this.вид5ToolStripMenuItem,
            this.вид6ToolStripMenuItem,
            this.вид7ToolStripMenuItem,
            this.вид8ToolStripMenuItem,
            this.вид9ToolStripMenuItem,
            this.вид10ToolStripMenuItem});
            this.плохоОбусловленныеToolStripMenuItem.Name = "плохоОбусловленныеToolStripMenuItem";
            this.плохоОбусловленныеToolStripMenuItem.Size = new System.Drawing.Size(281, 30);
            this.плохоОбусловленныеToolStripMenuItem.Text = "Плохо обусловленные";
            this.плохоОбусловленныеToolStripMenuItem.Click += new System.EventHandler(this.плохоОбусловленныеToolStripMenuItem_Click);
            // 
            // заданиеToolStripMenuItem
            // 
            this.заданиеToolStripMenuItem.Name = "заданиеToolStripMenuItem";
            this.заданиеToolStripMenuItem.Size = new System.Drawing.Size(91, 29);
            this.заданиеToolStripMenuItem.Text = "Задание";
            this.заданиеToolStripMenuItem.Click += new System.EventHandler(this.заданиеToolStripMenuItem_Click);
            // 
            // tBResults
            // 
            this.tBResults.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tBResults.Location = new System.Drawing.Point(14, 39);
            this.tBResults.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tBResults.Multiline = true;
            this.tBResults.Name = "tBResults";
            this.tBResults.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tBResults.Size = new System.Drawing.Size(1082, 473);
            this.tBResults.TabIndex = 1;
            // 
            // btn_fact
            // 
            this.btn_fact.Location = new System.Drawing.Point(1102, 39);
            this.btn_fact.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_fact.Name = "btn_fact";
            this.btn_fact.Size = new System.Drawing.Size(155, 84);
            this.btn_fact.TabIndex = 3;
            this.btn_fact.Text = "Произвести расчёты";
            this.btn_fact.UseVisualStyleBackColor = true;
            this.btn_fact.Click += new System.EventHandler(this.butFact_Click);
            // 
            // zadanie
            // 
            this.zadanie.AutoSize = true;
            this.zadanie.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.zadanie.Location = new System.Drawing.Point(997, 602);
            this.zadanie.Name = "zadanie";
            this.zadanie.Size = new System.Drawing.Size(0, 22);
            this.zadanie.TabIndex = 4;
            // 
            // tBMaxSize
            // 
            this.tBMaxSize.Location = new System.Drawing.Point(1102, 172);
            this.tBMaxSize.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tBMaxSize.Name = "tBMaxSize";
            this.tBMaxSize.Size = new System.Drawing.Size(155, 26);
            this.tBMaxSize.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1102, 126);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 40);
            this.label1.TabIndex = 6;
            this.label1.Text = "Максимальный\r\nразмер матрицы\r\n";
            // 
            // chart
            // 
            this.chart.BackColor = System.Drawing.SystemColors.Menu;
            chartArea3.Name = "ChartArea1";
            this.chart.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.chart.Legends.Add(legend3);
            this.chart.Location = new System.Drawing.Point(14, 520);
            this.chart.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chart.Name = "chart";
            series3.ChartArea = "ChartArea1";
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            this.chart.Series.Add(series3);
            this.chart.Size = new System.Drawing.Size(1082, 459);
            this.chart.TabIndex = 7;
            this.chart.Text = "chart";
            // 
            // btn_clear
            // 
            this.btn_clear.Location = new System.Drawing.Point(1102, 205);
            this.btn_clear.Name = "btn_clear";
            this.btn_clear.Size = new System.Drawing.Size(155, 55);
            this.btn_clear.TabIndex = 8;
            this.btn_clear.Text = "Очистить все";
            this.btn_clear.UseVisualStyleBackColor = true;
            this.btn_clear.Click += new System.EventHandler(this.btn_clear_Click);
            // 
            // вид1ToolStripMenuItem
            // 
            this.вид1ToolStripMenuItem.Name = "вид1ToolStripMenuItem";
            this.вид1ToolStripMenuItem.Size = new System.Drawing.Size(210, 30);
            this.вид1ToolStripMenuItem.Text = "Вид 1";
            this.вид1ToolStripMenuItem.Click += new System.EventHandler(this.вид1ToolStripMenuItem_Click);
            // 
            // вид2ToolStripMenuItem
            // 
            this.вид2ToolStripMenuItem.Name = "вид2ToolStripMenuItem";
            this.вид2ToolStripMenuItem.Size = new System.Drawing.Size(210, 30);
            this.вид2ToolStripMenuItem.Text = "Вид 2";
            this.вид2ToolStripMenuItem.Click += new System.EventHandler(this.вид2ToolStripMenuItem_Click);
            // 
            // вид3ToolStripMenuItem
            // 
            this.вид3ToolStripMenuItem.Name = "вид3ToolStripMenuItem";
            this.вид3ToolStripMenuItem.Size = new System.Drawing.Size(210, 30);
            this.вид3ToolStripMenuItem.Text = "Вид 3";
            this.вид3ToolStripMenuItem.Click += new System.EventHandler(this.вид3ToolStripMenuItem_Click);
            // 
            // вид4ToolStripMenuItem
            // 
            this.вид4ToolStripMenuItem.Name = "вид4ToolStripMenuItem";
            this.вид4ToolStripMenuItem.Size = new System.Drawing.Size(210, 30);
            this.вид4ToolStripMenuItem.Text = "Вид 4";
            this.вид4ToolStripMenuItem.Click += new System.EventHandler(this.вид4ToolStripMenuItem_Click);
            // 
            // вид5ToolStripMenuItem
            // 
            this.вид5ToolStripMenuItem.Name = "вид5ToolStripMenuItem";
            this.вид5ToolStripMenuItem.Size = new System.Drawing.Size(210, 30);
            this.вид5ToolStripMenuItem.Text = "Вид 5";
            this.вид5ToolStripMenuItem.Click += new System.EventHandler(this.вид5ToolStripMenuItem_Click);
            // 
            // вид6ToolStripMenuItem
            // 
            this.вид6ToolStripMenuItem.Name = "вид6ToolStripMenuItem";
            this.вид6ToolStripMenuItem.Size = new System.Drawing.Size(210, 30);
            this.вид6ToolStripMenuItem.Text = "Вид 6";
            this.вид6ToolStripMenuItem.Click += new System.EventHandler(this.вид6ToolStripMenuItem_Click);
            // 
            // вид7ToolStripMenuItem
            // 
            this.вид7ToolStripMenuItem.Name = "вид7ToolStripMenuItem";
            this.вид7ToolStripMenuItem.Size = new System.Drawing.Size(210, 30);
            this.вид7ToolStripMenuItem.Text = "Вид 7";
            this.вид7ToolStripMenuItem.Click += new System.EventHandler(this.вид7ToolStripMenuItem_Click);
            // 
            // вид8ToolStripMenuItem
            // 
            this.вид8ToolStripMenuItem.Name = "вид8ToolStripMenuItem";
            this.вид8ToolStripMenuItem.Size = new System.Drawing.Size(210, 30);
            this.вид8ToolStripMenuItem.Text = "Вид 8";
            this.вид8ToolStripMenuItem.Click += new System.EventHandler(this.вид8ToolStripMenuItem_Click);
            // 
            // вид9ToolStripMenuItem
            // 
            this.вид9ToolStripMenuItem.Name = "вид9ToolStripMenuItem";
            this.вид9ToolStripMenuItem.Size = new System.Drawing.Size(210, 30);
            this.вид9ToolStripMenuItem.Text = "Вид 9";
            this.вид9ToolStripMenuItem.Click += new System.EventHandler(this.вид9ToolStripMenuItem_Click);
            // 
            // вид10ToolStripMenuItem
            // 
            this.вид10ToolStripMenuItem.Name = "вид10ToolStripMenuItem";
            this.вид10ToolStripMenuItem.Size = new System.Drawing.Size(210, 30);
            this.вид10ToolStripMenuItem.Text = "Вид 10";
            this.вид10ToolStripMenuItem.Click += new System.EventHandler(this.вид10ToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1271, 1038);
            this.Controls.Add(this.btn_clear);
            this.Controls.Add(this.chart);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tBMaxSize);
            this.Controls.Add(this.zadanie);
            this.Controls.Add(this.btn_fact);
            this.Controls.Add(this.tBResults);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem генерацияToolStripMenuItem;
        private System.Windows.Forms.TextBox tBResults;
        private System.Windows.Forms.Button btn_fact;
        private System.Windows.Forms.Label zadanie;
        private System.Windows.Forms.ToolStripMenuItem ввестиСКлавиатурыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem случайнымОбразомToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem плохоОбусловленныеToolStripMenuItem;
        private System.Windows.Forms.TextBox tBMaxSize;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem заданиеToolStripMenuItem;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart;
        private System.Windows.Forms.Button btn_clear;
        private System.Windows.Forms.ToolStripMenuItem вид1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem вид2ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem вид3ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem вид4ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem вид5ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem вид6ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem вид7ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem вид8ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem вид9ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem вид10ToolStripMenuItem;
    }
}

