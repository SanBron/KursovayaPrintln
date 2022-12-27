namespace KursovayaPrintLn
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxFnd = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonFnd = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 16;
            this.listBox1.Location = new System.Drawing.Point(9, 47);
            this.listBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(225, 212);
            this.listBox1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.listBox1);
            this.groupBox1.Location = new System.Drawing.Point(21, 284);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(253, 272);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "База данных";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Тексты:";
            // 
            // textBoxFnd
            // 
            this.textBoxFnd.Location = new System.Drawing.Point(21, 53);
            this.textBoxFnd.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxFnd.Multiline = true;
            this.textBoxFnd.Name = "textBoxFnd";
            this.textBoxFnd.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxFnd.Size = new System.Drawing.Size(669, 212);
            this.textBoxFnd.TabIndex = 5;
            this.textBoxFnd.TextChanged += new System.EventHandler(this.textBoxFnd_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "Поиск:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // buttonFnd
            // 
            this.buttonFnd.Location = new System.Drawing.Point(712, 53);
            this.buttonFnd.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonFnd.Name = "buttonFnd";
            this.buttonFnd.Size = new System.Drawing.Size(100, 36);
            this.buttonFnd.TabIndex = 7;
            this.buttonFnd.Text = "Найти";
            this.buttonFnd.UseVisualStyleBackColor = true;
            this.buttonFnd.Click += new System.EventHandler(this.buttonFnd_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(309, 307);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(393, 112);
            this.label3.TabIndex = 8;
            this.label3.Text = resources.GetString("label3.Text");
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(845, 583);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.buttonFnd);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxFnd);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "PrintLn anti-pagiazm App";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxFnd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonFnd;
        private System.Windows.Forms.Label label3;
    }
}

