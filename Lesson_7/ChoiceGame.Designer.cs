namespace Lesson_7
{
    partial class ChoiceGame
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
            this.label1 = new System.Windows.Forms.Label();
            this.BtnUdvoitel = new System.Windows.Forms.Button();
            this.BtnGuess = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(30, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(265, 39);
            this.label1.TabIndex = 0;
            this.label1.Text = "Выбирете игру";
            // 
            // BtnUdvoitel
            // 
            this.BtnUdvoitel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.BtnUdvoitel.Location = new System.Drawing.Point(37, 73);
            this.BtnUdvoitel.Name = "BtnUdvoitel";
            this.BtnUdvoitel.Size = new System.Drawing.Size(110, 50);
            this.BtnUdvoitel.TabIndex = 1;
            this.BtnUdvoitel.Text = "Удвоитель";
            this.BtnUdvoitel.UseVisualStyleBackColor = false;
            this.BtnUdvoitel.Click += new System.EventHandler(this.BtnUdvoitel_Click);
            // 
            // BtnGuess
            // 
            this.BtnGuess.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.BtnGuess.Location = new System.Drawing.Point(185, 73);
            this.BtnGuess.Name = "BtnGuess";
            this.BtnGuess.Size = new System.Drawing.Size(110, 50);
            this.BtnGuess.TabIndex = 2;
            this.BtnGuess.Text = "Угадайка";
            this.BtnGuess.UseVisualStyleBackColor = false;
            this.BtnGuess.Click += new System.EventHandler(this.BtnGuess_Click);
            // 
            // ChoiceGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(324, 154);
            this.Controls.Add(this.BtnGuess);
            this.Controls.Add(this.BtnUdvoitel);
            this.Controls.Add(this.label1);
            this.Name = "ChoiceGame";
            this.Text = "Выбор игры";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BtnUdvoitel;
        private System.Windows.Forms.Button BtnGuess;
    }
}