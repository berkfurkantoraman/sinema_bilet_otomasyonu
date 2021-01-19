
namespace Proje
{
    partial class biletlerim
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(biletlerim));
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.bilet_data = new System.Windows.Forms.DataGridView();
            this.bilet_sil_btn = new System.Windows.Forms.Button();
            this.bilet_film_adı = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.bilet_kategori = new System.Windows.Forms.TextBox();
            this.bilet_format = new System.Windows.Forms.TextBox();
            this.bilet_tarih = new System.Windows.Forms.TextBox();
            this.bilet_seans = new System.Windows.Forms.TextBox();
            this.bilet_koltuk = new System.Windows.Forms.TextBox();
            this.bilet_salon = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.bilet_biletid = new System.Windows.Forms.TextBox();
            this.bilet_pic = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bilet_data)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bilet_pic)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Location = new System.Drawing.Point(0, -1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(716, 35);
            this.panel1.TabIndex = 10;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            this.panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseUp);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Location = new System.Drawing.Point(763, -1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(35, 35);
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox3.BackgroundImage")));
            this.pictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox3.Location = new System.Drawing.Point(722, -1);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(35, 35);
            this.pictureBox3.TabIndex = 8;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Click += new System.EventHandler(this.pictureBox3_Click);
            // 
            // bilet_data
            // 
            this.bilet_data.AllowUserToAddRows = false;
            this.bilet_data.AllowUserToDeleteRows = false;
            this.bilet_data.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.bilet_data.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.bilet_data.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.bilet_data.Location = new System.Drawing.Point(100, 40);
            this.bilet_data.Name = "bilet_data";
            this.bilet_data.Size = new System.Drawing.Size(616, 138);
            this.bilet_data.TabIndex = 11;
            this.bilet_data.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.bilet_data_CellClick);
            // 
            // bilet_sil_btn
            // 
            this.bilet_sil_btn.BackColor = System.Drawing.Color.Maroon;
            this.bilet_sil_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bilet_sil_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bilet_sil_btn.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.bilet_sil_btn.ForeColor = System.Drawing.Color.White;
            this.bilet_sil_btn.Location = new System.Drawing.Point(552, 373);
            this.bilet_sil_btn.Name = "bilet_sil_btn";
            this.bilet_sil_btn.Size = new System.Drawing.Size(142, 40);
            this.bilet_sil_btn.TabIndex = 12;
            this.bilet_sil_btn.Text = "Seçili Bileti Sil";
            this.bilet_sil_btn.UseVisualStyleBackColor = false;
            this.bilet_sil_btn.Click += new System.EventHandler(this.bilet_sil_btn_Click);
            // 
            // bilet_film_adı
            // 
            this.bilet_film_adı.Location = new System.Drawing.Point(209, 228);
            this.bilet_film_adı.Name = "bilet_film_adı";
            this.bilet_film_adı.ReadOnly = true;
            this.bilet_film_adı.Size = new System.Drawing.Size(100, 20);
            this.bilet_film_adı.TabIndex = 13;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label14.ForeColor = System.Drawing.Color.Transparent;
            this.label14.Location = new System.Drawing.Point(102, 383);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(61, 24);
            this.label14.TabIndex = 46;
            this.label14.Text = "Koltuk";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label12.ForeColor = System.Drawing.Color.Transparent;
            this.label12.Location = new System.Drawing.Point(102, 321);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(53, 24);
            this.label12.TabIndex = 45;
            this.label12.Text = "Tarih";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label11.ForeColor = System.Drawing.Color.Transparent;
            this.label11.Location = new System.Drawing.Point(102, 352);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(63, 24);
            this.label11.TabIndex = 44;
            this.label11.Text = "Seans";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label10.ForeColor = System.Drawing.Color.Transparent;
            this.label10.Location = new System.Drawing.Point(102, 290);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(69, 24);
            this.label10.TabIndex = 43;
            this.label10.Text = "Format";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label9.ForeColor = System.Drawing.Color.Transparent;
            this.label9.Location = new System.Drawing.Point(102, 259);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(79, 24);
            this.label9.TabIndex = 42;
            this.label9.Text = "Kategori";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label8.ForeColor = System.Drawing.Color.Transparent;
            this.label8.Location = new System.Drawing.Point(102, 228);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(79, 24);
            this.label8.TabIndex = 41;
            this.label8.Text = "Film Adı";
            // 
            // bilet_kategori
            // 
            this.bilet_kategori.Location = new System.Drawing.Point(209, 259);
            this.bilet_kategori.Name = "bilet_kategori";
            this.bilet_kategori.ReadOnly = true;
            this.bilet_kategori.Size = new System.Drawing.Size(100, 20);
            this.bilet_kategori.TabIndex = 47;
            // 
            // bilet_format
            // 
            this.bilet_format.Location = new System.Drawing.Point(209, 290);
            this.bilet_format.Name = "bilet_format";
            this.bilet_format.ReadOnly = true;
            this.bilet_format.Size = new System.Drawing.Size(100, 20);
            this.bilet_format.TabIndex = 48;
            // 
            // bilet_tarih
            // 
            this.bilet_tarih.Location = new System.Drawing.Point(209, 321);
            this.bilet_tarih.Name = "bilet_tarih";
            this.bilet_tarih.ReadOnly = true;
            this.bilet_tarih.Size = new System.Drawing.Size(100, 20);
            this.bilet_tarih.TabIndex = 49;
            this.bilet_tarih.TextChanged += new System.EventHandler(this.bilet_tarih_TextChanged);
            // 
            // bilet_seans
            // 
            this.bilet_seans.Location = new System.Drawing.Point(209, 352);
            this.bilet_seans.Name = "bilet_seans";
            this.bilet_seans.ReadOnly = true;
            this.bilet_seans.Size = new System.Drawing.Size(100, 20);
            this.bilet_seans.TabIndex = 50;
            // 
            // bilet_koltuk
            // 
            this.bilet_koltuk.Location = new System.Drawing.Point(209, 383);
            this.bilet_koltuk.Name = "bilet_koltuk";
            this.bilet_koltuk.ReadOnly = true;
            this.bilet_koltuk.Size = new System.Drawing.Size(100, 20);
            this.bilet_koltuk.TabIndex = 51;
            // 
            // bilet_salon
            // 
            this.bilet_salon.Location = new System.Drawing.Point(209, 414);
            this.bilet_salon.Name = "bilet_salon";
            this.bilet_salon.ReadOnly = true;
            this.bilet_salon.Size = new System.Drawing.Size(100, 20);
            this.bilet_salon.TabIndex = 54;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(102, 414);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 24);
            this.label1.TabIndex = 53;
            this.label1.Text = "Salon";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.ForeColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(102, 197);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 24);
            this.label2.TabIndex = 56;
            this.label2.Text = "Bilet ID";
            // 
            // bilet_biletid
            // 
            this.bilet_biletid.Location = new System.Drawing.Point(209, 197);
            this.bilet_biletid.Name = "bilet_biletid";
            this.bilet_biletid.ReadOnly = true;
            this.bilet_biletid.Size = new System.Drawing.Size(100, 20);
            this.bilet_biletid.TabIndex = 55;
            // 
            // bilet_pic
            // 
            this.bilet_pic.BackColor = System.Drawing.Color.Transparent;
            this.bilet_pic.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bilet_pic.Location = new System.Drawing.Point(342, 197);
            this.bilet_pic.Name = "bilet_pic";
            this.bilet_pic.Size = new System.Drawing.Size(161, 237);
            this.bilet_pic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.bilet_pic.TabIndex = 57;
            this.bilet_pic.TabStop = false;
            // 
            // biletlerim
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkRed;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 458);
            this.Controls.Add(this.bilet_pic);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.bilet_biletid);
            this.Controls.Add(this.bilet_salon);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bilet_koltuk);
            this.Controls.Add(this.bilet_seans);
            this.Controls.Add(this.bilet_tarih);
            this.Controls.Add(this.bilet_format);
            this.Controls.Add(this.bilet_kategori);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.bilet_film_adı);
            this.Controls.Add(this.bilet_sil_btn);
            this.Controls.Add(this.bilet_data);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pictureBox3);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "biletlerim";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "biletlerim";
            this.Shown += new System.EventHandler(this.biletlerim_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bilet_data)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bilet_pic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.DataGridView bilet_data;
        private System.Windows.Forms.Button bilet_sil_btn;
        private System.Windows.Forms.TextBox bilet_film_adı;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox bilet_kategori;
        private System.Windows.Forms.TextBox bilet_format;
        private System.Windows.Forms.TextBox bilet_tarih;
        private System.Windows.Forms.TextBox bilet_seans;
        private System.Windows.Forms.TextBox bilet_koltuk;
        private System.Windows.Forms.TextBox bilet_salon;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox bilet_biletid;
        private System.Windows.Forms.PictureBox bilet_pic;
    }
}