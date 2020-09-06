namespace EtherTestSend
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btn_RecvStart = new System.Windows.Forms.Button();
            this.tbx_RecvData = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // btn_RecvStart
            // 
            this.btn_RecvStart.Location = new System.Drawing.Point(12, 12);
            this.btn_RecvStart.Name = "btn_RecvStart";
            this.btn_RecvStart.Size = new System.Drawing.Size(129, 23);
            this.btn_RecvStart.TabIndex = 0;
            this.btn_RecvStart.Text = "受信開始";
            this.btn_RecvStart.UseVisualStyleBackColor = true;
            this.btn_RecvStart.Click += new System.EventHandler(this.btn_RecvStart_Click);
            // 
            // tbx_RecvData
            // 
            this.tbx_RecvData.Location = new System.Drawing.Point(12, 92);
            this.tbx_RecvData.Multiline = true;
            this.tbx_RecvData.Name = "tbx_RecvData";
            this.tbx_RecvData.Size = new System.Drawing.Size(414, 346);
            this.tbx_RecvData.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(438, 450);
            this.Controls.Add(this.tbx_RecvData);
            this.Controls.Add(this.btn_RecvStart);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_RecvStart;
        private System.Windows.Forms.TextBox tbx_RecvData;
        private System.Windows.Forms.Timer timer1;
    }
}

