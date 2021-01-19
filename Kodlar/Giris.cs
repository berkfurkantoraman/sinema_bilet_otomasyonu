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
using System.Data.Odbc;
namespace Proje
{
    public partial class Giris : Form
    {
        OracleConnection connection = new OracleConnection("User Id=SYSTEM;Password=5092010berk;Data Source=localhost:1521/XEPDB1;");
        OracleCommand command = new OracleCommand();

        int MouseX, MouseY, MouseXlast, MouseYlast;
        bool MouseM;
        public Giris()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

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
        
        private void panel3_MouseDown(object sender, MouseEventArgs e)
        {
            MouseX = e.X;
            MouseY = e.Y;
            MouseM = true;
        }

        private void panel3_MouseMove(object sender, MouseEventArgs e)
        {
            
            if (MouseM)
            {
                MouseXlast = MousePosition.X;
                MouseYlast = MousePosition.Y;
            }
        }

        private void panel3_MouseUp(object sender, MouseEventArgs e)
        {
            if(MouseX-MouseXlast<0){
                SetClientSizeCore(this.Size.Width + MouseXlast - MouseX, this.Size.Height);
            }
            else 
            {
                SetClientSizeCore(this.Size.Width - MouseXlast + MouseX, this.Size.Height);
            }

            MouseM = false;
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {
            
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
                 
        private void pictureBox2_Click_1(object sender, EventArgs e)
        {

            connection.Open();
            OracleCommand a = new OracleCommand("GIRIS_KONTROL", connection);
            a.CommandType = System.Data.CommandType.StoredProcedure;
            a.Parameters.Add("X1", OracleDbType.Varchar2).Value = yoneticiadi_txt.Text;
            a.Parameters.Add("X2", OracleDbType.Varchar2).Value = yoneticisifre_txt.Text;
            a.Parameters.Add("X3", OracleDbType.Varchar2).Value = "Admin";
            a.Parameters.Add("F1", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            OracleDataAdapter adapter = new OracleDataAdapter();
            adapter.SelectCommand = a;
            DataTable tablo = new DataTable();
            adapter.Fill(tablo);            
            int p = tablo.Rows.Count;
            Admin frm2 = new Admin();
            Giris giris = new Giris();
            if (p == 1) 
            {
                Admin.admin_adi_text = yoneticiadi_txt.Text;
                this.Hide();
               frm2.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show(" Kullanıcı Adı veya Şifre Hatalı !  ");
            }
                

            connection.Close();
                        
        }

        private void ÜyeButonu_Click(object sender, EventArgs e)
        {
            connection.Open();
            OracleCommand a = new OracleCommand("GIRIS_KONTROL", connection);
            a.CommandType = System.Data.CommandType.StoredProcedure;
            a.Parameters.Add("X1", OracleDbType.Varchar2).Value = uyeadi_txt.Text; 
            a.Parameters.Add("X2", OracleDbType.Varchar2).Value = uyesifre_txt.Text;
            a.Parameters.Add("X3", OracleDbType.Varchar2).Value = "Üye";
            a.Parameters.Add("F1", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            OracleDataAdapter adapter = new OracleDataAdapter();
            adapter.SelectCommand = a;
            DataTable tablo = new DataTable();
            adapter.Fill(tablo);
            int p = tablo.Rows.Count;
            AnaEkran frm3 = new AnaEkran();
            Giris giris = new Giris();
            if (p == 1)
            {
                AnaEkran.kullanici_adi_text= uyeadi_txt.Text;
                this.Hide();
                frm3.ShowDialog();
                this.Show();
            }
            else
                MessageBox.Show(" Kullanıcı Adı veya Şifre Hatalı !  ");

            connection.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            KayıtOl kayıt = new KayıtOl();
            kayıt.ShowDialog();
        }

        private void tabControl1_Click(object sender, EventArgs e)
        {
           
        }

       

        private void label5_Paint(object sender, PaintEventArgs e)
        {
            label5.Text = DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToLongTimeString();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            label5.Text = DateTime.Now.ToLongDateString() +" "+ DateTime.Now.ToLongTimeString();
            //timer1.Start();
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {
            
        }

        private void yoneticisifre_txt_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                connection.Open();
                OracleCommand a = new OracleCommand("GIRIS_KONTROL", connection);
                a.CommandType = System.Data.CommandType.StoredProcedure;
                a.Parameters.Add("X1", OracleDbType.Varchar2).Value = yoneticiadi_txt.Text;
                a.Parameters.Add("X2", OracleDbType.Varchar2).Value = yoneticisifre_txt.Text;
                a.Parameters.Add("X3", OracleDbType.Varchar2).Value = "Admin";
                a.Parameters.Add("F1", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                OracleDataAdapter adapter = new OracleDataAdapter();
                adapter.SelectCommand = a;
                DataTable tablo = new DataTable();
                adapter.Fill(tablo);
                int p = tablo.Rows.Count;
                Admin frm2 = new Admin();
                Giris giris = new Giris();
                if (p == 1)
                {
                    Admin.admin_adi_text = yoneticiadi_txt.Text;
                    this.Hide();
                    frm2.ShowDialog();
                    this.Show();
                }
                else
                    MessageBox.Show(" Kullanıcı Adı veya Şifre Hatalı !  ");

                connection.Close();

            }
        }

        private void uyesifre_txt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                connection.Open();
                OracleCommand a = new OracleCommand("GIRIS_KONTROL", connection);
                a.CommandType = System.Data.CommandType.StoredProcedure;
                a.Parameters.Add("X1", OracleDbType.Varchar2).Value = uyeadi_txt.Text;
                a.Parameters.Add("X2", OracleDbType.Varchar2).Value = uyesifre_txt.Text;
                a.Parameters.Add("X3", OracleDbType.Varchar2).Value = "Üye";
                a.Parameters.Add("F1", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                OracleDataAdapter adapter = new OracleDataAdapter();
                adapter.SelectCommand = a;
                DataTable tablo = new DataTable();
                adapter.Fill(tablo);
                int p = tablo.Rows.Count;
                AnaEkran frm3 = new AnaEkran();
                Giris giris = new Giris();
                if (p == 1)
                {
                    AnaEkran.kullanici_adi_text = uyeadi_txt.Text;
                    this.Hide();
                    frm3.ShowDialog();
                    this.Show();
                }
                else
                    MessageBox.Show(" Kullanıcı Adı veya Şifre Hatalı !  ");

                connection.Close();

            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
            }
            else if (this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal;
            }
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

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

       
    }

        
}
