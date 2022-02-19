namespace ImagefileDelete
{
    partial class ImagefileDelete
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
            this.btnRef = new System.Windows.Forms.Button();
            this.lstImageFile = new System.Windows.Forms.ListBox();
            this.lstDeleteFile = new System.Windows.Forms.ListBox();
            this.txtInputDir = new System.Windows.Forms.TextBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.lblImageFile = new System.Windows.Forms.Label();
            this.lblDeleteFile = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAllClear = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnRef
            // 
            this.btnRef.Location = new System.Drawing.Point(525, 86);
            this.btnRef.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnRef.Name = "btnRef";
            this.btnRef.Size = new System.Drawing.Size(125, 34);
            this.btnRef.TabIndex = 0;
            this.btnRef.Text = "参照";
            this.btnRef.UseVisualStyleBackColor = true;
            this.btnRef.Click += new System.EventHandler(this.btnRef_Click);
            // 
            // lstImageFile
            // 
            this.lstImageFile.FormattingEnabled = true;
            this.lstImageFile.Location = new System.Drawing.Point(58, 240);
            this.lstImageFile.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.lstImageFile.Name = "lstImageFile";
            this.lstImageFile.Size = new System.Drawing.Size(427, 160);
            this.lstImageFile.TabIndex = 1;
            // 
            // lstDeleteFile
            // 
            this.lstDeleteFile.FormattingEnabled = true;
            this.lstDeleteFile.Location = new System.Drawing.Point(58, 490);
            this.lstDeleteFile.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.lstDeleteFile.Name = "lstDeleteFile";
            this.lstDeleteFile.Size = new System.Drawing.Size(427, 160);
            this.lstDeleteFile.TabIndex = 2;
            // 
            // txtInputDir
            // 
            this.txtInputDir.Location = new System.Drawing.Point(58, 94);
            this.txtInputDir.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtInputDir.Name = "txtInputDir";
            this.txtInputDir.Size = new System.Drawing.Size(427, 20);
            this.txtInputDir.TabIndex = 3;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(525, 616);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(125, 34);
            this.btnDelete.TabIndex = 4;
            this.btnDelete.Text = "削除";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(58, 134);
            this.btnLoad.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(125, 34);
            this.btnLoad.TabIndex = 5;
            this.btnLoad.Text = "読み込み";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // lblImageFile
            // 
            this.lblImageFile.AutoSize = true;
            this.lblImageFile.Location = new System.Drawing.Point(55, 200);
            this.lblImageFile.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblImageFile.Name = "lblImageFile";
            this.lblImageFile.Size = new System.Drawing.Size(131, 13);
            this.lblImageFile.TabIndex = 6;
            this.lblImageFile.Text = "存在するイメージファイル";
            // 
            // lblDeleteFile
            // 
            this.lblDeleteFile.AutoSize = true;
            this.lblDeleteFile.Location = new System.Drawing.Point(55, 450);
            this.lblDeleteFile.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblDeleteFile.Name = "lblDeleteFile";
            this.lblDeleteFile.Size = new System.Drawing.Size(163, 13);
            this.lblDeleteFile.TabIndex = 7;
            this.lblDeleteFile.Text = "使われていないイメージファイル";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(55, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(177, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "イメージフォルダを選択してください";
            // 
            // btnAllClear
            // 
            this.btnAllClear.Location = new System.Drawing.Point(605, 12);
            this.btnAllClear.Name = "btnAllClear";
            this.btnAllClear.Size = new System.Drawing.Size(125, 34);
            this.btnAllClear.TabIndex = 9;
            this.btnAllClear.Text = "クリア";
            this.btnAllClear.UseVisualStyleBackColor = true;
            this.btnAllClear.Click += new System.EventHandler(this.btnAllClear_Click);
            // 
            // ImagefileDelete
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(742, 739);
            this.Controls.Add(this.btnAllClear);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblDeleteFile);
            this.Controls.Add(this.lblImageFile);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.txtInputDir);
            this.Controls.Add(this.lstDeleteFile);
            this.Controls.Add(this.lstImageFile);
            this.Controls.Add(this.btnRef);
            this.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "ImagefileDelete";
            this.Text = "イメージファイル削除";
            this.Shown += new System.EventHandler(this.ImagefileDelete_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRef;
        private System.Windows.Forms.ListBox lstImageFile;
        private System.Windows.Forms.ListBox lstDeleteFile;
        private System.Windows.Forms.TextBox txtInputDir;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Label lblImageFile;
        private System.Windows.Forms.Label lblDeleteFile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAllClear;
    }
}

