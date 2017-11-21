namespace DigitalMethods
{
    partial class FfromKeyboard
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.butOk = new System.Windows.Forms.Button();
            this.butCancle = new System.Windows.Forms.Button();
            this.tBInpurMatrix = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // butOk
            // 
            this.butOk.Location = new System.Drawing.Point(342, 267);
            this.butOk.Name = "butOk";
            this.butOk.Size = new System.Drawing.Size(75, 23);
            this.butOk.TabIndex = 0;
            this.butOk.Text = "ОК";
            this.butOk.UseVisualStyleBackColor = true;
            this.butOk.Click += new System.EventHandler(this.butOk_Click);
            // 
            // butCancle
            // 
            this.butCancle.Location = new System.Drawing.Point(423, 267);
            this.butCancle.Name = "butCancle";
            this.butCancle.Size = new System.Drawing.Size(75, 23);
            this.butCancle.TabIndex = 1;
            this.butCancle.Text = "Отмена";
            this.butCancle.UseVisualStyleBackColor = true;
            this.butCancle.Click += new System.EventHandler(this.butCancle_Click);
            // 
            // tBInpurMatrix
            // 
            this.tBInpurMatrix.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tBInpurMatrix.Location = new System.Drawing.Point(12, 12);
            this.tBInpurMatrix.Multiline = true;
            this.tBInpurMatrix.Name = "tBInpurMatrix";
            this.tBInpurMatrix.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tBInpurMatrix.Size = new System.Drawing.Size(486, 249);
            this.tBInpurMatrix.TabIndex = 2;
            this.tBInpurMatrix.Text = "2 4 -4 6\r\n1 4 2 1\r\n3 8 1 1\r\n2 5 0 5";
            // 
            // FfromKeyboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(510, 302);
            this.Controls.Add(this.tBInpurMatrix);
            this.Controls.Add(this.butCancle);
            this.Controls.Add(this.butOk);
            this.Name = "FfromKeyboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FfromKeyboard";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button butOk;
        private System.Windows.Forms.Button butCancle;
        private System.Windows.Forms.TextBox tBInpurMatrix;
    }
}