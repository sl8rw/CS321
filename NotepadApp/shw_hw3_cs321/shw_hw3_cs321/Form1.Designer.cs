namespace shw_hw3_cs321
{
    partial class Form1
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.SaveButton = new System.Windows.Forms.Button();
            this.InsertNumberButton = new System.Windows.Forms.Button();
            this.LoadButton = new System.Windows.Forms.Button();
            this.InputBox = new System.Windows.Forms.GroupBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.InputBoxSubmit = new System.Windows.Forms.Button();
            this.InputBoxCancel = new System.Windows.Forms.Button();
            this.InputBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(45, 70);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox1.Size = new System.Drawing.Size(632, 353);
            this.textBox1.TabIndex = 0;
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileDialog1_FileOk);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(46, 12);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(125, 52);
            this.SaveButton.TabIndex = 1;
            this.SaveButton.Text = "Save File";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // InsertNumberButton
            // 
            this.InsertNumberButton.Location = new System.Drawing.Point(480, 12);
            this.InsertNumberButton.Name = "InsertNumberButton";
            this.InsertNumberButton.Size = new System.Drawing.Size(197, 52);
            this.InsertNumberButton.TabIndex = 2;
            this.InsertNumberButton.Text = "Insert Number";
            this.InsertNumberButton.UseVisualStyleBackColor = true;
            this.InsertNumberButton.Click += new System.EventHandler(this.InsertNumberButton_Click);
            // 
            // LoadButton
            // 
            this.LoadButton.Location = new System.Drawing.Point(177, 12);
            this.LoadButton.Name = "LoadButton";
            this.LoadButton.Size = new System.Drawing.Size(126, 52);
            this.LoadButton.TabIndex = 3;
            this.LoadButton.Text = "Load File";
            this.LoadButton.UseVisualStyleBackColor = true;
            this.LoadButton.Click += new System.EventHandler(this.LoadFromFile);
            // 
            // InputBox
            // 
            this.InputBox.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.InputBox.Controls.Add(this.InputBoxCancel);
            this.InputBox.Controls.Add(this.InputBoxSubmit);
            this.InputBox.Controls.Add(this.textBox2);
            this.InputBox.Location = new System.Drawing.Point(133, 166);
            this.InputBox.Name = "InputBox";
            this.InputBox.Size = new System.Drawing.Size(468, 150);
            this.InputBox.TabIndex = 4;
            this.InputBox.TabStop = false;
            this.InputBox.Text = "Input Number";
            this.InputBox.Visible = false;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(6, 62);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(456, 67);
            this.textBox2.TabIndex = 0;
            // 
            // InputBoxSubmit
            // 
            this.InputBoxSubmit.Location = new System.Drawing.Point(206, 19);
            this.InputBoxSubmit.Name = "InputBoxSubmit";
            this.InputBoxSubmit.Size = new System.Drawing.Size(131, 43);
            this.InputBoxSubmit.TabIndex = 1;
            this.InputBoxSubmit.Text = "Submit";
            this.InputBoxSubmit.UseVisualStyleBackColor = true;
            this.InputBoxSubmit.Click += new System.EventHandler(this.InputBoxSubmit_Click);
            // 
            // InputBoxCancel
            // 
            this.InputBoxCancel.Location = new System.Drawing.Point(343, 19);
            this.InputBoxCancel.Name = "InputBoxCancel";
            this.InputBoxCancel.Size = new System.Drawing.Size(119, 43);
            this.InputBoxCancel.TabIndex = 2;
            this.InputBoxCancel.Text = "Cancel";
            this.InputBoxCancel.UseVisualStyleBackColor = true;
            this.InputBoxCancel.Click += new System.EventHandler(this.InputBoxCancel_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.InputBox);
            this.Controls.Add(this.LoadButton);
            this.Controls.Add(this.InsertNumberButton);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.textBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.InputBox.ResumeLayout(false);
            this.InputBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Button InsertNumberButton;
        private System.Windows.Forms.Button LoadButton;
        private System.Windows.Forms.GroupBox InputBox;
        private System.Windows.Forms.Button InputBoxCancel;
        private System.Windows.Forms.Button InputBoxSubmit;
        private System.Windows.Forms.TextBox textBox2;
    }
}

