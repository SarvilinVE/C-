namespace Lesson_7
{
    partial class WF_Guess
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
            this.LblRules = new System.Windows.Forms.Label();
            this.LblMessage = new System.Windows.Forms.Label();
            this.BtnBegin = new System.Windows.Forms.Button();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LblRules
            // 
            this.LblRules.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LblRules.AutoSize = true;
            this.LblRules.Location = new System.Drawing.Point(12, 9);
            this.LblRules.Name = "LblRules";
            this.LblRules.Size = new System.Drawing.Size(34, 13);
            this.LblRules.TabIndex = 0;
            this.LblRules.Text = "Rules";
            // 
            // LblMessage
            // 
            this.LblMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LblMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LblMessage.Location = new System.Drawing.Point(12, 92);
            this.LblMessage.Name = "LblMessage";
            this.LblMessage.Size = new System.Drawing.Size(356, 46);
            this.LblMessage.TabIndex = 1;
            this.LblMessage.Text = "Начем?";
            this.LblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BtnBegin
            // 
            this.BtnBegin.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnBegin.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BtnBegin.Location = new System.Drawing.Point(29, 148);
            this.BtnBegin.Name = "BtnBegin";
            this.BtnBegin.Size = new System.Drawing.Size(130, 48);
            this.BtnBegin.TabIndex = 2;
            this.BtnBegin.Text = "Вперед";
            this.BtnBegin.UseVisualStyleBackColor = true;
            this.BtnBegin.Click += new System.EventHandler(this.BtnBegin_Click);
            // 
            // BtnCancel
            // 
            this.BtnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnCancel.Location = new System.Drawing.Point(206, 148);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(130, 48);
            this.BtnCancel.TabIndex = 3;
            this.BtnCancel.Text = "Нет";
            this.BtnCancel.UseVisualStyleBackColor = true;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // WF_Guess
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(373, 223);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.BtnBegin);
            this.Controls.Add(this.LblMessage);
            this.Controls.Add(this.LblRules);
            this.Name = "WF_Guess";
            this.Text = "Угадайка";
            this.Load += new System.EventHandler(this.WF_Guess_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LblRules;
        private System.Windows.Forms.Label LblMessage;
        private System.Windows.Forms.Button BtnBegin;
        private System.Windows.Forms.Button BtnCancel;
    }
}