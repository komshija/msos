namespace Adaptive_Huffman_Compression
{
    partial class form_Glavna
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(form_Glavna));
            this.ms_meni = new System.Windows.Forms.MenuStrip();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dialog_open = new System.Windows.Forms.OpenFileDialog();
            this.dialog_save = new System.Windows.Forms.SaveFileDialog();
            this.btn_compress = new System.Windows.Forms.Button();
            this.btn_decompress = new System.Windows.Forms.Button();
            this.tb_ime = new System.Windows.Forms.TextBox();
            this.lbl_ime = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.ms_meni.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // ms_meni
            // 
            this.ms_meni.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.ms_meni.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.ms_meni.Location = new System.Drawing.Point(0, 0);
            this.ms_meni.Name = "ms_meni";
            this.ms_meni.Size = new System.Drawing.Size(521, 33);
            this.ms_meni.TabIndex = 0;
            this.ms_meni.Text = "menuStrip1";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(78, 29);
            this.aboutToolStripMenuItem.Text = "Autori";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // dialog_open
            // 
            this.dialog_open.FileName = "fd_open";
            // 
            // btn_compress
            // 
            this.btn_compress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_compress.Location = new System.Drawing.Point(135, 98);
            this.btn_compress.Name = "btn_compress";
            this.btn_compress.Size = new System.Drawing.Size(231, 28);
            this.btn_compress.TabIndex = 1;
            this.btn_compress.Text = "Izvrsi kompresiju";
            this.btn_compress.UseVisualStyleBackColor = true;
            this.btn_compress.Click += new System.EventHandler(this.btn_compress_Click);
            // 
            // btn_decompress
            // 
            this.btn_decompress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_decompress.Location = new System.Drawing.Point(133, 72);
            this.btn_decompress.Name = "btn_decompress";
            this.btn_decompress.Size = new System.Drawing.Size(231, 28);
            this.btn_decompress.TabIndex = 2;
            this.btn_decompress.Text = "Izvrsi dekompresiju";
            this.btn_decompress.UseVisualStyleBackColor = true;
            this.btn_decompress.Click += new System.EventHandler(this.btn_decompress_Click);
            // 
            // tb_ime
            // 
            this.tb_ime.Location = new System.Drawing.Point(57, 61);
            this.tb_ime.Name = "tb_ime";
            this.tb_ime.Size = new System.Drawing.Size(386, 22);
            this.tb_ime.TabIndex = 3;
            // 
            // lbl_ime
            // 
            this.lbl_ime.AutoSize = true;
            this.lbl_ime.Location = new System.Drawing.Point(54, 41);
            this.lbl_ime.Name = "lbl_ime";
            this.lbl_ime.Size = new System.Drawing.Size(174, 17);
            this.lbl_ime.TabIndex = 4;
            this.lbl_ime.Text = "Izaberite ime izlaznog fajla";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_compress);
            this.groupBox1.Controls.Add(this.lbl_ime);
            this.groupBox1.Controls.Add(this.tb_ime);
            this.groupBox1.Location = new System.Drawing.Point(12, 36);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(497, 166);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Kompresija";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btn_decompress);
            this.groupBox2.Location = new System.Drawing.Point(12, 237);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(497, 172);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Dekompresija";
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(12, 208);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(497, 23);
            this.progressBar.TabIndex = 3;
            // 
            // form_Glavna
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(521, 421);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ms_meni);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.ms_meni;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(539, 468);
            this.Name = "form_Glavna";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Adaptivna Huffman Kompresija - A Varijanta";
            this.ms_meni.ResumeLayout(false);
            this.ms_meni.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip ms_meni;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog dialog_open;
        private System.Windows.Forms.SaveFileDialog dialog_save;
        private System.Windows.Forms.Button btn_compress;
        private System.Windows.Forms.Button btn_decompress;
        private System.Windows.Forms.TextBox tb_ime;
        private System.Windows.Forms.Label lbl_ime;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ProgressBar progressBar;
    }
}

