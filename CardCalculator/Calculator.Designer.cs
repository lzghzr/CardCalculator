namespace CardCalculator
{
    partial class Calculator
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.labLowestPrice = new System.Windows.Forms.Label();
            this.labExchangeRate = new System.Windows.Forms.Label();
            this.texLowestPrice = new System.Windows.Forms.TextBox();
            this.texExchangeRate = new System.Windows.Forms.TextBox();
            this.texResult = new System.Windows.Forms.TextBox();
            this.labResult = new System.Windows.Forms.Label();
            this.butMore = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labLowestPrice
            // 
            this.labLowestPrice.AutoSize = true;
            this.labLowestPrice.Location = new System.Drawing.Point(15, 15);
            this.labLowestPrice.Name = "labLowestPrice";
            this.labLowestPrice.Size = new System.Drawing.Size(77, 12);
            this.labLowestPrice.TabIndex = 0;
            this.labLowestPrice.Text = "市场最低价格";
            // 
            // labExchangeRate
            // 
            this.labExchangeRate.AutoSize = true;
            this.labExchangeRate.Location = new System.Drawing.Point(15, 45);
            this.labExchangeRate.Name = "labExchangeRate";
            this.labExchangeRate.Size = new System.Drawing.Size(77, 12);
            this.labExchangeRate.TabIndex = 2;
            this.labExchangeRate.Text = "当前美元汇率";
            // 
            // texLowestPrice
            // 
            this.texLowestPrice.AllowDrop = true;
            this.texLowestPrice.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.texLowestPrice.Location = new System.Drawing.Point(165, 10);
            this.texLowestPrice.MaxLength = 7;
            this.texLowestPrice.Name = "texLowestPrice";
            this.texLowestPrice.Size = new System.Drawing.Size(100, 21);
            this.texLowestPrice.TabIndex = 1;
            this.texLowestPrice.KeyUp += new System.Windows.Forms.KeyEventHandler(this.texLowestPrice_KeyUp);
            // 
            // texExchangeRate
            // 
            this.texExchangeRate.AllowDrop = true;
            this.texExchangeRate.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.texExchangeRate.Location = new System.Drawing.Point(165, 40);
            this.texExchangeRate.MaxLength = 7;
            this.texExchangeRate.Name = "texExchangeRate";
            this.texExchangeRate.Size = new System.Drawing.Size(100, 21);
            this.texExchangeRate.TabIndex = 3;
            this.texExchangeRate.KeyUp += new System.Windows.Forms.KeyEventHandler(this.texExchangeRate_KeyUp);
            // 
            // texResult
            // 
            this.texResult.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.texResult.Location = new System.Drawing.Point(165, 70);
            this.texResult.MaxLength = 7;
            this.texResult.Name = "texResult";
            this.texResult.ReadOnly = true;
            this.texResult.Size = new System.Drawing.Size(100, 21);
            this.texResult.TabIndex = 5;
            // 
            // labResult
            // 
            this.labResult.AutoSize = true;
            this.labResult.Location = new System.Drawing.Point(15, 75);
            this.labResult.Name = "labResult";
            this.labResult.Size = new System.Drawing.Size(77, 12);
            this.labResult.TabIndex = 4;
            this.labResult.Text = "建议收款价格";
            // 
            // butMore
            // 
            this.butMore.Location = new System.Drawing.Point(15, 105);
            this.butMore.Name = "butMore";
            this.butMore.Size = new System.Drawing.Size(77, 23);
            this.butMore.TabIndex = 6;
            this.butMore.Tag = "";
            this.butMore.Text = "更多";
            this.butMore.UseVisualStyleBackColor = true;
            this.butMore.Click += new System.EventHandler(this.butMore_Click);
            // 
            // Calculator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 141);
            this.Controls.Add(this.butMore);
            this.Controls.Add(this.labResult);
            this.Controls.Add(this.texResult);
            this.Controls.Add(this.texExchangeRate);
            this.Controls.Add(this.texLowestPrice);
            this.Controls.Add(this.labExchangeRate);
            this.Controls.Add(this.labLowestPrice);
            this.Name = "Calculator";
            this.Text = "CardCalculator";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Calculator_FormClosing);
            this.Load += new System.EventHandler(this.Calculator_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labLowestPrice;
        private System.Windows.Forms.Label labExchangeRate;
        private System.Windows.Forms.TextBox texLowestPrice;
        private System.Windows.Forms.TextBox texExchangeRate;
        private System.Windows.Forms.TextBox texResult;
        private System.Windows.Forms.Label labResult;
        private System.Windows.Forms.Button butMore;
    }
}

