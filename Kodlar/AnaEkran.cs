using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace Proje
{
    public partial class AnaEkran : Form
    {
        public static string kullanici_adi_text; 
        public static string []film_info= new string[9];
        OracleConnection connection = new OracleConnection("User Id=SYSTEM;Password=5092010berk;Data Source=localhost:1521/XEPDB1;");
        int MouseX, MouseY, MouseXlast, MouseYlast;
        bool MouseM;
        public Giris grs = new Giris();
        public AnaEkran()
        {
            InitializeComponent();
            panel2.BackColor = Color.FromArgb(150, Color.Black);
            panel3.BackColor = Color.FromArgb(150, Color.Black);
        }



        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Minimized;
            }
            else if (this.WindowState == FormWindowState.Minimized)
            {
                this.WindowState = FormWindowState.Normal;
            }
            else if (this.WindowState == FormWindowState.Minimized)
            {
                this.WindowState = FormWindowState.Maximized;
            }
            else if (this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Minimized;
            }
        }

        int sayac1 = 0;

        public int film_eleman_sayici()
        {
            OracleConnection connection2 = new OracleConnection("User Id=SYSTEM;Password=5092010berk;Data Source=localhost:1521/XEPDB1;");
            connection2.Open();
            OracleCommand d = new OracleCommand("FILM", connection2);
            d.CommandType = System.Data.CommandType.StoredProcedure;
            d.Parameters.Add("X1", OracleDbType.Int64).Value = 0;
            d.Parameters.Add("X2", OracleDbType.Varchar2).Value = "";
            d.Parameters.Add("X3", OracleDbType.Varchar2).Value = "";
            d.Parameters.Add("X4", OracleDbType.Varchar2).Value = "";
            d.Parameters.Add("X5", OracleDbType.Varchar2).Value = "";
            d.Parameters.Add("X6", OracleDbType.Varchar2).Value = "";
            d.Parameters.Add("X7", OracleDbType.Varchar2).Value = "";
            d.Parameters.Add("X8", OracleDbType.Varchar2).Value = "";
            d.Parameters.Add("X9", OracleDbType.Varchar2).Value = "";
            d.Parameters.Add("X10", OracleDbType.Varchar2).Value = "SELECT";
            d.Parameters.Add("b", OracleDbType.Int64).Value = 0;
            d.Parameters.Add("F1", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            OracleDataAdapter adapter = new OracleDataAdapter();
            adapter.SelectCommand = d;
            DataTable tablo3 = new DataTable();
            adapter.Fill(tablo3);
            int u = tablo3.Rows.Count;


            connection2.Close();
            return u;
        }
        public void film_select()
        {


            connection.Open();
            OracleCommand d = new OracleCommand("FILM", connection);
            d.CommandType = System.Data.CommandType.StoredProcedure;
            d.Parameters.Add("X1", OracleDbType.Int64).Value = 0;
            d.Parameters.Add("X2", OracleDbType.Varchar2).Value = "";
            d.Parameters.Add("X3", OracleDbType.Varchar2).Value = "";
            d.Parameters.Add("X4", OracleDbType.Varchar2).Value = "";
            d.Parameters.Add("X5", OracleDbType.Varchar2).Value = "";
            d.Parameters.Add("X6", OracleDbType.Varchar2).Value = "";
            d.Parameters.Add("X7", OracleDbType.Varchar2).Value = "";
            d.Parameters.Add("X8", OracleDbType.Varchar2).Value = "";
            d.Parameters.Add("X9", OracleDbType.Varchar2).Value = "";
            d.Parameters.Add("X10", OracleDbType.Varchar2).Value = "SELECT";
            d.Parameters.Add("b", OracleDbType.Int64).Value = 0;
            d.Parameters.Add("F1", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            OracleDataAdapter adapter = new OracleDataAdapter();
            adapter.SelectCommand = d;
            DataTable tablo2 = new DataTable();
            adapter.Fill(tablo2);
            dataGridView1.DataSource = tablo2;
            connection.Close();

        }

        public void panel_silici(Panel panel)
        {
            sayac1 = 1;
            for (int i = 0; i < film_eleman_sayici()*4/9; i++)
            {
                foreach (Control c in panel.Controls)
                {
                    panel.Controls.Remove(c);
                    c.Dispose();
                }

            }
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            grs.Show();
            grs.Close();
            this.Close();
        }
        PictureBox btn1 ;
        Label btn3 ;
        Label btn2 ;
        Label btn ;

        public void kategori_doldur()
        {
            connection.Open();
            OracleCommand d = new OracleCommand("KATEGORI", connection);
            d.CommandType = System.Data.CommandType.StoredProcedure;
            d.Parameters.Add("X1", OracleDbType.Varchar2).Value = "";
            d.Parameters.Add("X2", OracleDbType.Varchar2).Value = "COUNT";
            d.Parameters.Add("F1", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            OracleDataAdapter adapter = new OracleDataAdapter();
            adapter.SelectCommand = d;
            DataTable tablo2 = new DataTable();
            adapter.Fill(tablo2);
            int a = tablo2.Rows.Count;
            connection.Close();
            kategori_txt.Items.Clear();
            kategori_txt.Text = "";
            for (int i = 0; i < a; i++)
            {
                kategori_txt.Items.Add(tablo2.Rows[i].ItemArray[0]);
                
            }

        }
        private void AnaEkran_Load(object sender, EventArgs e)
        {
            kategori_doldur();
            dinamik_buton("","", panel2);
            label2.Text=(kullanici_adi_text);
        }

        private void Btn1_Click(object sender, EventArgs e)
        {
            BilgiEkranı blg = new BilgiEkranı();
            PictureBox pic = (PictureBox)sender;
            
            for (int i=0; i<9;i++)
            {
                film_info[i] = dataGridView1.Rows[int.Parse(pic.Name) - 1].Cells[i].Value.ToString();
            }
            
            blg.ShowDialog();
            

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void arama_btn_Click(object sender, EventArgs e)
        {
            kategori_txt.Text = "";
            panel_silici(panel2);
            dinamik_buton(arama_txt.Text, "SELECT_ARAMA", panel2);
        }

        public void film_special_select(String sorgu,String sorgu_tipi)
        {
            connection.Open();
            OracleCommand d = new OracleCommand("FILM", connection);
            d.CommandType = System.Data.CommandType.StoredProcedure;
            d.Parameters.Add("X1", OracleDbType.Int64).Value = 0;
            d.Parameters.Add("X2", OracleDbType.Varchar2).Value = sorgu;
            d.Parameters.Add("X3", OracleDbType.Varchar2).Value = sorgu;
            d.Parameters.Add("X4", OracleDbType.Varchar2).Value = "";
            d.Parameters.Add("X5", OracleDbType.Varchar2).Value = "";
            d.Parameters.Add("X6", OracleDbType.Varchar2).Value = "";
            d.Parameters.Add("X7", OracleDbType.Varchar2).Value = "";
            d.Parameters.Add("X8", OracleDbType.Varchar2).Value = "";
            d.Parameters.Add("X9", OracleDbType.Varchar2).Value = "";
            d.Parameters.Add("X10", OracleDbType.Varchar2).Value = sorgu_tipi;
            d.Parameters.Add("b", OracleDbType.Int64).Value = 0;
            d.Parameters.Add("F1", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            OracleDataAdapter adapter = new OracleDataAdapter();
            adapter.SelectCommand = d;
            DataTable tablo2 = new DataTable();
            adapter.Fill(tablo2);
            dataGridView1.DataSource = tablo2;
            connection.Close();
        }
        public void dinamik_buton(string str, String str2,Panel gelen)
        {
            sayac1 = 1;            
             if (str == "")
            {
                film_select();
            }
            else
            {
                film_special_select(str,str2);
            }
            int eleman_syc = dataGridView1.Rows.Count-1; 
            for (int i = 0; i < eleman_syc / 2 + 2; i++)
            {
                if (i % 2 == 0)

                {
                    for (int j = 0; j < 8; j++)
                    {
                        if (i * 2 + j / 2 < eleman_syc)
                        {
                            btn1 = new PictureBox();
                            btn3 = new Label();
                            btn2 = new Label();
                            btn = new Label();

                            btn.Size = new Size(170, 15);
                            btn.BackColor = Color.Cyan;                            
                            btn.Location = new Point(j * 100 + 30, i * 150 + 260);
                            btn.Name = sayac1.ToString() + "Label";
                            btn.Text = dataGridView1.Rows[sayac1 - 1].Cells[1].Value.ToString();


                            btn2.Size = new Size(170, 15);
                            btn2.BackColor = Color.LightGreen;
                            btn2.Location = new Point(j * 100 + 30, i * 150 + 275);
                            btn2.Name = sayac1.ToString() + "Label";
                            btn2.Text = "Film Türü: " + dataGridView1.Rows[sayac1 - 1].Cells[2].Value.ToString();


                            btn3.Size = new Size(170, 15);
                            btn3.BackColor = Color.Pink;
                            btn3.Location = new Point(j * 100 + 30, i * 150 + 290);
                            btn3.Name = sayac1.ToString() + "Label";
                            btn3.Text = "IMDB: " + dataGridView1.Rows[sayac1 - 1].Cells[7].Value.ToString();


                            btn1.SizeMode = PictureBoxSizeMode.StretchImage;
                            btn1.Size = new Size(170, 230);
                            btn1.BackColor = Color.Transparent;
                            btn1.Cursor = System.Windows.Forms.Cursors.Hand;
                            btn1.Location = new Point(j * 100 + 30, i * 150 + 30);
                            btn1.Name = sayac1.ToString();
                            btn1.ImageLocation = dataGridView1.Rows[sayac1 - 1].Cells[8].Value.ToString();
                            if (j % 2 == 0)
                            {
                                continue;
                            }

                            sayac1++;

                            gelen.Controls.Add(btn1);
                            gelen.Controls.Add(btn);
                            gelen.Controls.Add(btn2);
                            gelen.Controls.Add(btn3);
                            btn1.Click += Btn1_Click;
                        }

                    }
                }



            }
        }

        int sayac2 = 0;
        public void dinamik_buton_yiyecek()
        {            
            sayac2 = 1;      
            
            yiyecek_select();            
            int eleman_syc = dataGridView2.Rows.Count - 1;
            for (int i = 0; i < eleman_syc / 2 + 2; i++)
            {
                if (i % 2 == 0)

                {
                    for (int j = 0; j < 8; j++)
                    {
                        if (i * 2 + j / 2 < eleman_syc)
                        {
                            btn1 = new PictureBox();
                            btn3 = new Label();
                            btn2 = new Label();
                            btn = new Label();

                            btn.Size = new Size(170, 15);
                            btn.BackColor = Color.Cyan;
                            btn.Location = new Point(j * 100 + 30, i * 150 + 260);
                            btn.Name = sayac2.ToString() + "YLabel";
                            btn.Text = dataGridView2.Rows[sayac2 - 1].Cells[1].Value.ToString();


                            btn2.Size = new Size(170, 15);
                            btn2.BackColor = Color.LightGreen;
                            btn2.Location = new Point(j * 100 + 30, i * 150 + 275);
                            btn2.Name = sayac2.ToString() + "YLabel";
                            btn2.Text = "Ürün Türü: " + dataGridView2.Rows[sayac2 - 1].Cells[3].Value.ToString();


                            btn3.Size = new Size(170, 15);
                            btn3.BackColor = Color.Pink;
                            btn3.Location = new Point(j * 100 + 30, i * 150 + 290);
                            btn3.Name = sayac2.ToString() + "YLabel";
                            btn3.Text = "Ürün Fiyatı: " + dataGridView2.Rows[sayac2 - 1].Cells[2].Value.ToString();


                            btn1.SizeMode = PictureBoxSizeMode.StretchImage;
                            btn1.Size = new Size(170, 230);
                            btn1.BackColor = Color.Transparent;
                            //btn1.Cursor = System.Windows.Forms.Cursors.Hand;
                            btn1.Location = new Point(j * 100 + 30, i * 150 + 30);
                            btn1.Name = sayac2.ToString()+"Y";
                            btn1.ImageLocation = dataGridView2.Rows[sayac2 - 1].Cells[4].Value.ToString();
                            if (j % 2 == 0)
                            {
                                continue;
                            }

                            sayac2++;

                            panel3.Controls.Add(btn1);
                            panel3.Controls.Add(btn);
                            panel3.Controls.Add(btn2);
                            panel3.Controls.Add(btn3);
                            
                        }

                    }
                }



            }
        }
        int yiyecek_sayısı=0;
        public void yiyecek_select()
        {
            yiyecek_panel_silici();
            connection.Open();
            OracleCommand d = new OracleCommand( );
            d.Connection = connection;
            d.CommandText = "SELECT * FROM YIYECEK_MENU ";
            OracleDataAdapter adapter = new OracleDataAdapter();
            adapter.SelectCommand = d;
            DataTable tablo2 = new DataTable();
            adapter.Fill(tablo2);
            dataGridView2.DataSource = tablo2;
            yiyecek_sayısı = tablo2.Rows.Count;
            connection.Close();
        }

        public void yiyecek_panel_silici()
        {
            sayac2 = 1;
            for (int i = 0; i < yiyecek_sayısı * 4 / 9; i++)
            {
                foreach (Control c in panel3.Controls)
                {
                    panel3.Controls.Remove(c);
                    c.Dispose();
                }

            }
        }

        private void anaekran_btn_Click(object sender, EventArgs e)
        {
            label3.Visible = true;
            label1.Visible = true;
            pictureBox2.Visible = true;
            arama_btn.Visible = true;
            kategori_txt.Visible = true;
            arama_txt.Visible = true;
            panel2.Visible = true;
            panel3.Visible = false;
            arama_txt.Text = "";
            kategori_txt.Text = "";
            panel_silici(panel2);
            dinamik_buton("","",panel2);
        }

        private void button1_Click(object sender, EventArgs e)
        {

            sayac1 = 1;
            for(int i =0;i<6; i++){
                foreach (Control c in panel2.Controls)
                {                       
                    panel2.Controls.Remove(c);
                    c.Dispose();
                }
                
            }
            
        }

        private void kategori_txt_SelectedIndexChanged(object sender, EventArgs e)
        {
            panel_silici(panel2);
            dinamik_buton(kategori_txt.SelectedItem.ToString(),"SELECT_KATEGORI", panel2);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            biletlerim blt = new biletlerim();
            blt.ShowDialog();
        }

        private void yiyecek_menu_Click(object sender, EventArgs e)
        {
            label3.Visible = false;
            label1.Visible = false;
            pictureBox2.Visible = false;
            arama_btn.Visible = false;
            kategori_txt.Visible = false;
            arama_txt.Visible = false;
            panel3.Visible = true;
            panel2.Visible = false;
            panel_silici(panel2);
            dinamik_buton_yiyecek();

        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            MouseX = e.X;
            MouseY = e.Y;
            MouseM = true;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (MouseM)
            {
                SetDesktopLocation(MousePosition.X - MouseX, MousePosition.Y - MouseY);
            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            MouseM = false;
        }
    }
}
