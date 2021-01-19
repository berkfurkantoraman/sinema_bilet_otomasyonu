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
    public partial class BilgiEkranı : Form
    {
        OracleConnection connection = new OracleConnection("User Id=SYSTEM;Password=5092010berk;Data Source=localhost:1521/XEPDB1;");
        OracleConnection connection2 = new OracleConnection("User Id=SYSTEM;Password=5092010berk;Data Source=localhost:1521/XEPDB1;");
        OracleConnection connection3 = new OracleConnection("User Id=SYSTEM;Password=5092010berk;Data Source=localhost:1521/XEPDB1;");
        int MouseX, MouseY;
        bool MouseM;
        int x = 0;
        bool[] koltuklar;

        public string[] film_info = new string[9];
        public BilgiEkranı()
        {
            InitializeComponent();
            bilgiekranı_panel.BackColor = Color.FromArgb(150, Color.Black);
            bilet_pnl.BackColor = Color.FromArgb(100, Color.Cyan);
            koltuk_pnl.BackColor = Color.FromArgb(70, Color.Black);
            pictureBox1.ImageLocation = AnaEkran.film_info[8];
        }

        private void bilgiekranı_panel_Paint(object sender, PaintEventArgs e)
        {
           
        }

        public int bilet_sayici()
        {
            connection3.Open();
            OracleCommand d = new OracleCommand("BILET", connection3);
            d.CommandType = System.Data.CommandType.StoredProcedure;
            d.Parameters.Add("X1", OracleDbType.Int64).Value = 0;
            d.Parameters.Add("X2", OracleDbType.Int64).Value = 0;
            d.Parameters.Add("X3", OracleDbType.Varchar2).Value = " ";
            d.Parameters.Add("X4", OracleDbType.Varchar2).Value = "";
            d.Parameters.Add("X5", OracleDbType.Varchar2).Value = "";
            d.Parameters.Add("X6", OracleDbType.Varchar2).Value = "";
            d.Parameters.Add("X7", OracleDbType.Int64).Value = 0;            
            d.Parameters.Add("X9", OracleDbType.Varchar2).Value = "SAY";
            d.Parameters.Add("b", OracleDbType.Int64).Value = 0;
            d.Parameters.Add("F1", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            OracleDataAdapter adapter = new OracleDataAdapter();
            connection3.Close();
            adapter.SelectCommand = d;
            DataTable tablo2 = new DataTable();
            adapter.Fill(tablo2);
            int u = tablo2.Rows.Count;
            return u;
        } 
        public bool koltuk_kirmizi(String lazım)
        {
            
            connection2.Open();
            OracleCommand d = new OracleCommand("BILET", connection2);
            d.CommandType = System.Data.CommandType.StoredProcedure;
            d.Parameters.Add("X1", OracleDbType.Int64).Value = 0;
            d.Parameters.Add("X2", OracleDbType.Int64).Value = int.Parse(bilet_salon_txt.SelectedItem.ToString());
            d.Parameters.Add("X3", OracleDbType.Varchar2).Value = " ";
            d.Parameters.Add("X4", OracleDbType.Varchar2).Value = bilet_seans_txt.SelectedItem.ToString();
            d.Parameters.Add("X5", OracleDbType.Varchar2).Value = bilet_tarih_txt.SelectedItem.ToString();
            d.Parameters.Add("X6", OracleDbType.Varchar2).Value = lazım;
            d.Parameters.Add("X7", OracleDbType.Int64).Value = 0;            
            d.Parameters.Add("X9", OracleDbType.Varchar2).Value = "KOLTUK";
            d.Parameters.Add("b", OracleDbType.Int64).Value = 0;
            d.Parameters.Add("F1", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            OracleDataAdapter adapter = new OracleDataAdapter();
            connection2.Close();
            adapter.SelectCommand = d;
            DataTable tablo2 = new DataTable();
            adapter.Fill(tablo2);
            int u = tablo2.Rows.Count;
            if (u > 0)
            {
                return true;
            }
            else
                return false;
            
                        
        }

        int sayac1=0;
        private void BilgiEkranı_Load(object sender, EventArgs e)
        {
            
        }

        int sayac = 0;
        private void bilet_salon_txt_SelectedIndexChanged(object sender, EventArgs e)
        {
            pictureBox7.Enabled = true;
            koltuk_silici(koltuk_pnl);
            pictureBox5.Visible = true;
            koltuk_pnl.Visible = true;
            x = salon_kapasite(bilet_salon_txt.SelectedItem.ToString());
            koltuklar = new bool[x+1];
            sayac = 1;
            for (int i = 0; i < x / 8 + 2; i++)
            {
                for (int j = 0; j < 9; j++)
                {

                    Button btn = new Button();
                    btn.Size = new Size(35, 35);
                    if (koltuk_kirmizi(sayac.ToString()))
                    {
                        btn.BackColor = Color.FromArgb(220, Color.Red);
                        btn.Enabled = false;                       

                    }
                    else btn.BackColor = Color.White;
                    btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                    
                    btn.Location = new Point(j * 35 + 20, i * 35 + 30);
                    btn.Name = sayac.ToString();
                    btn.Text = sayac.ToString();
                    if (j == 4)
                    {
                        continue;
                    }
                    if (sayac < x+1)
                    {
                        sayac++;
                        koltuk_pnl.Controls.Add(btn);
                        btn.Click += Btn_Click;
                    }
                    else if (sayac==x)
                    {
                        btn.Visible = false;
                        sayac++;
                        koltuk_pnl.Controls.Add(btn);
                        btn.Click += Btn_Click;
                    }

                }

            }

        }

        private void Btn_Click(object sender, EventArgs e)
        {
            
            Button btn = (Button)sender;
            if (btn.BackColor == Color.White)
            {
                btn.BackColor = Color.LightGreen;
                koltuklar[int.Parse(btn.Text)] = true;
            }
            else
            {
                koltuklar[int.Parse(btn.Text)] = false;
                btn.BackColor = Color.White;
            }



        }
        private void BilgiEkranı_Shown(object sender, EventArgs e)
        {
            for (int i=0;i <9;i++)
            {
                this.film_info[i] = AnaEkran.film_info[i];
            }
            
            textBox2.Text = film_info[1];
            textBox3.Text = film_info[2];
            textBox4.Text = film_info[3];
            textBox5.Text = film_info[4];
            textBox6.Text = film_info[5];
            textBox7.Text = film_info[6];
            textBox8.Text = film_info[7];
            pictureBox1.ImageLocation = AnaEkran.film_info[8];

            bilet_filmadi_txt.Text = film_info[1];
            bilet_kategori_txt.Text = film_info[2];
            bilet_format_txt.Text = film_info[4];
            bilet_pic.ImageLocation = AnaEkran.film_info[8];

            tarih_select();
        }

        public void tarih_select()
        {
            connection.Open();
            OracleCommand d = new OracleCommand("BILET", connection);
            d.CommandType = System.Data.CommandType.StoredProcedure;
            d.Parameters.Add("X1", OracleDbType.Int64).Value = 0;
            d.Parameters.Add("X2", OracleDbType.Int64).Value = 0;
            d.Parameters.Add("X3", OracleDbType.Varchar2).Value = " ";
            d.Parameters.Add("X4", OracleDbType.Varchar2).Value = " ";
            d.Parameters.Add("X5", OracleDbType.Varchar2).Value = " ";
            d.Parameters.Add("X6", OracleDbType.Varchar2).Value = " ";
            d.Parameters.Add("X7", OracleDbType.Int64).Value = int.Parse(film_info[0]);            
            d.Parameters.Add("X9", OracleDbType.Varchar2).Value = "TARIH";
            d.Parameters.Add("b", OracleDbType.Int64).Value = 0;
            d.Parameters.Add("F1", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            OracleDataAdapter adapter = new OracleDataAdapter();
            adapter.SelectCommand = d;
            DataTable tablo2 = new DataTable();
            adapter.Fill(tablo2);
            bilet_data.DataSource = tablo2;
            for (int i=0; i<bilet_data.Rows.Count-1;i++)
            {
                bilet_tarih_txt.Items.Add(bilet_data.Rows[i].Cells[0].Value.ToString());
            }
            connection.Close();

        
        }

        public void seans_select()
        {
            connection.Open();
            OracleCommand d = new OracleCommand("BILET", connection);
            d.CommandType = System.Data.CommandType.StoredProcedure;
            d.Parameters.Add("X1", OracleDbType.Int64).Value = 0;
            d.Parameters.Add("X2", OracleDbType.Int64).Value = 0;
            d.Parameters.Add("X3", OracleDbType.Varchar2).Value = " ";
            d.Parameters.Add("X4", OracleDbType.Varchar2).Value = " ";
            d.Parameters.Add("X5", OracleDbType.Varchar2).Value = bilet_tarih_txt.SelectedItem.ToString();
            d.Parameters.Add("X6", OracleDbType.Varchar2).Value = " ";
            d.Parameters.Add("X7", OracleDbType.Int64).Value = int.Parse(film_info[0]);            
            d.Parameters.Add("X9", OracleDbType.Varchar2).Value = "SEANS";
            d.Parameters.Add("b", OracleDbType.Int64).Value = 0;
            d.Parameters.Add("F1", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            OracleDataAdapter adapter = new OracleDataAdapter();
            adapter.SelectCommand = d;
            DataTable tablo2 = new DataTable();
            adapter.Fill(tablo2);
            bilet_data.DataSource = tablo2;
            for (int i = 0; i < bilet_data.Rows.Count - 1; i++)
            {
                bilet_seans_txt.Items.Add(bilet_data.Rows[i].Cells[0].Value.ToString());
            }
            connection.Close();
        }

        public void salon_select()
        {
            connection.Open();
            OracleCommand d = new OracleCommand("BILET", connection);
            d.CommandType = System.Data.CommandType.StoredProcedure;
            d.Parameters.Add("X1", OracleDbType.Int64).Value = 0;
            d.Parameters.Add("X2", OracleDbType.Int64).Value = 0;
            d.Parameters.Add("X3", OracleDbType.Varchar2).Value = " ";
            d.Parameters.Add("X4", OracleDbType.Varchar2).Value = bilet_seans_txt.SelectedItem.ToString();
            d.Parameters.Add("X5", OracleDbType.Varchar2).Value = bilet_tarih_txt.SelectedItem.ToString();
            d.Parameters.Add("X6", OracleDbType.Varchar2).Value = " ";
            d.Parameters.Add("X7", OracleDbType.Int64).Value = int.Parse(film_info[0]);            
            d.Parameters.Add("X9", OracleDbType.Varchar2).Value = "SALON";
            d.Parameters.Add("b", OracleDbType.Int64).Value = 0;
            d.Parameters.Add("F1", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            OracleDataAdapter adapter = new OracleDataAdapter();
            adapter.SelectCommand = d;
            DataTable tablo2 = new DataTable();
            adapter.Fill(tablo2);
            bilet_data.DataSource = tablo2;
            for (int i = 0; i < bilet_data.Rows.Count - 1; i++)
            {
                bilet_salon_txt.Items.Add(bilet_data.Rows[i].Cells[0].Value.ToString());
            }
            connection.Close();
        }
        private void pictureBox3_Click_1(object sender, EventArgs e)
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

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_MouseDown_1(object sender, MouseEventArgs e)
        {
            MouseX = e.X;
            MouseY = e.Y;
            MouseM = true;
        }

        private void panel1_MouseMove_1(object sender, MouseEventArgs e)
        {
            if (MouseM)
            {
                SetDesktopLocation(MousePosition.X - MouseX, MousePosition.Y - MouseY);
            }
        }

        private void bilet_pnl_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            bilgiekranı_panel.Visible = false;
            bilet_pnl.Visible = true;
        }

        public void koltuk_silici(Panel panel)
        {
            sayac1 = 1;
            for (int i = 0; i < x/9; i++)
            {
                
                foreach (Control c in panel.Controls)
                {
                   
                    panel.Controls.Remove(c);
                    c.Dispose();
                }

            }
        }
        private void bilet_tarih_txt_SelectedIndexChanged(object sender, EventArgs e)
        {
            pictureBox7.Enabled = false;
            pictureBox5.Visible = false;
            koltuk_pnl.Visible = false;
            bilet_salon_txt.Items.Clear();
            bilet_seans_txt.Items.Clear();
            bilet_salon_txt.Enabled = false;
            bilet_salon_txt.Text = "";
            bilet_seans_txt.Text = "";
            bilet_salon_txt.SelectedItem = null;
            bilet_seans_txt.SelectedItem = null;
            
            if (bilet_tarih_txt.SelectedItem!=null) seans_select();
            
            bilet_seans_txt.Enabled = true;
        }

        private void bilet_seans_txt_SelectedIndexChanged(object sender, EventArgs e)
        {
            pictureBox7.Enabled = false;
            pictureBox5.Visible = false;
            koltuk_pnl.Visible = false;
            bilet_salon_txt.Items.Clear();
            bilet_salon_txt.Enabled = false;
            bilet_salon_txt.Text = "";
            if (bilet_seans_txt.SelectedItem != null) salon_select();
            bilet_salon_txt.Enabled = true;
        }

        public int salon_kapasite(String salon)
        {
            connection.Open();
            OracleCommand d = new OracleCommand("BILET", connection);
            d.CommandType = System.Data.CommandType.StoredProcedure;
            d.Parameters.Add("X1", OracleDbType.Int64).Value = 0;
            d.Parameters.Add("X2", OracleDbType.Int64).Value = int.Parse(salon) ;
            d.Parameters.Add("X3", OracleDbType.Varchar2).Value = " ";
            d.Parameters.Add("X4", OracleDbType.Varchar2).Value = "";
            d.Parameters.Add("X5", OracleDbType.Varchar2).Value = "";
            d.Parameters.Add("X6", OracleDbType.Varchar2).Value = " ";
            d.Parameters.Add("X7", OracleDbType.Int64).Value = 0;            
            d.Parameters.Add("X9", OracleDbType.Varchar2).Value = "SALON_KAPASITE";
            d.Parameters.Add("b", OracleDbType.Int64).Value = 0;
            d.Parameters.Add("F1", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            OracleDataAdapter adapter = new OracleDataAdapter();
            adapter.SelectCommand = d;
            DataTable tablo2 = new DataTable();
            adapter.Fill(tablo2);
            bilet_data.DataSource = tablo2;            
            connection.Close();

            return int.Parse(bilet_data.Rows[0].Cells[0].Value.ToString());
        }
        

       

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            string koltuk_bilet="";
            for (int i = 0; i < x + 1; i++)
            {
                if (koltuklar[i] == true)
                {
                    if (koltuk_bilet == "")
                    {
                        koltuk_bilet = i.ToString();
                    }
                    else
                    {
                        koltuk_bilet += "," + i.ToString();
                    }
                }
                
            }

            connection.Open();
            OracleCommand t = new OracleCommand("BILET", connection);
            t.CommandType = System.Data.CommandType.StoredProcedure;
            t.Parameters.Add("X1", OracleDbType.Int64).Value = 0;
            t.Parameters.Add("X2", OracleDbType.Int64).Value = int.Parse(bilet_salon_txt.SelectedItem.ToString());
            t.Parameters.Add("X3", OracleDbType.Varchar2).Value = AnaEkran.kullanici_adi_text;
            t.Parameters.Add("X4", OracleDbType.Varchar2).Value = bilet_seans_txt.SelectedItem.ToString();
            t.Parameters.Add("X5", OracleDbType.Varchar2).Value = bilet_tarih_txt.SelectedItem.ToString();
            t.Parameters.Add("X6", OracleDbType.Varchar2).Value = koltuk_bilet;
            t.Parameters.Add("X7", OracleDbType.Int64).Value = film_info[0];            
            t.Parameters.Add("X9", OracleDbType.Varchar2).Value = "EKLE";
            t.Parameters.Add("b", OracleDbType.Int64).Value = bilet_sayici();
            t.Parameters.Add("F1", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            t.ExecuteNonQuery();
            connection.Close();

            for (int i=0; i < x+1; i++)
            {
                if (koltuklar[i]==true)
                {
                    connection.Open();
                    OracleCommand d = new OracleCommand("BILET", connection);
                    d.CommandType = System.Data.CommandType.StoredProcedure;
                    d.Parameters.Add("X1", OracleDbType.Int64).Value = 0;
                    d.Parameters.Add("X2", OracleDbType.Int64).Value = int.Parse(bilet_salon_txt.SelectedItem.ToString());
                    d.Parameters.Add("X3", OracleDbType.Varchar2).Value = AnaEkran.kullanici_adi_text;
                    d.Parameters.Add("X4", OracleDbType.Varchar2).Value = bilet_seans_txt.SelectedItem.ToString();
                    d.Parameters.Add("X5", OracleDbType.Varchar2).Value = bilet_tarih_txt.SelectedItem.ToString();
                    d.Parameters.Add("X6", OracleDbType.Varchar2).Value = i.ToString();
                    d.Parameters.Add("X7", OracleDbType.Int64).Value = film_info[0];                    
                    d.Parameters.Add("X9", OracleDbType.Varchar2).Value = "KOLTUK_EKLE";
                    d.Parameters.Add("b", OracleDbType.Int64).Value = bilet_sayici();
                    d.Parameters.Add("F1", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                    OracleDataAdapter adapter = new OracleDataAdapter();
                    adapter.SelectCommand = d;
                    DataTable tablo2 = new DataTable();
                    adapter.Fill(tablo2);
                    bilet_data.DataSource = tablo2;
                    connection.Close();                    
                    
                    koltuklar[i] = false;
                }
            }
            MessageBox.Show("Rezervasyon başarıyla gerçekleştirildi. \nİyi eğlenceler :)");

            

            koltuk_pnl.Visible = false;
            bilet_tarih_txt.SelectedItem = null;
            bilet_tarih_txt.Text = "";
            bilet_pnl.Visible = false;
            bilgiekranı_panel.Visible = true;

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            koltuk_pnl.Visible = false;
            bilet_tarih_txt.SelectedItem = null;
            bilet_tarih_txt.Text = "";
            bilet_pnl.Visible = false;
            bilgiekranı_panel.Visible = true;
        }

        private void panel1_MouseUp_1(object sender, MouseEventArgs e)
        {
            MouseM = false;
        }

        
    }
}
