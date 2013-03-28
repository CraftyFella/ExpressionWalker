namespace ExpressionWalker.TestStub
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
            this.buttonSimpleExpression = new System.Windows.Forms.Button();
            this.inputExpression = new System.Windows.Forms.TextBox();
            this.buttonMethodCallExpression = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonSimpleExpression
            // 
            this.buttonSimpleExpression.Location = new System.Drawing.Point(33, 21);
            this.buttonSimpleExpression.Name = "buttonSimpleExpression";
            this.buttonSimpleExpression.Size = new System.Drawing.Size(161, 23);
            this.buttonSimpleExpression.TabIndex = 0;
            this.buttonSimpleExpression.Text = "Simple Expression";
            this.buttonSimpleExpression.UseVisualStyleBackColor = true;
            this.buttonSimpleExpression.Click += new System.EventHandler(this.buttonSimpleExpression_Click);
            // 
            // inputExpression
            // 
            this.inputExpression.Location = new System.Drawing.Point(33, 50);
            this.inputExpression.Multiline = true;
            this.inputExpression.Name = "inputExpression";
            this.inputExpression.Size = new System.Drawing.Size(710, 339);
            this.inputExpression.TabIndex = 1;
            // 
            // buttonMethodCallExpression
            // 
            this.buttonMethodCallExpression.Location = new System.Drawing.Point(200, 21);
            this.buttonMethodCallExpression.Name = "buttonMethodCallExpression";
            this.buttonMethodCallExpression.Size = new System.Drawing.Size(161, 23);
            this.buttonMethodCallExpression.TabIndex = 2;
            this.buttonMethodCallExpression.Text = "Method Call Expression";
            this.buttonMethodCallExpression.UseVisualStyleBackColor = true;
            this.buttonMethodCallExpression.Click += new System.EventHandler(this.buttonMethodCallExpression_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(787, 401);
            this.Controls.Add(this.buttonMethodCallExpression);
            this.Controls.Add(this.inputExpression);
            this.Controls.Add(this.buttonSimpleExpression);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonSimpleExpression;
        public System.Windows.Forms.TextBox inputExpression;
        private System.Windows.Forms.Button buttonMethodCallExpression;
    }
}

