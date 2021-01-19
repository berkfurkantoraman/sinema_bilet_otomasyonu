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
    public partial class KayıtOl : Form
    {
        OracleConnection connection = new OracleConnection("User Id=SYSTEM;Password=5092010berk;Data Source=localhost:1521/XEPDB1;");
        int MouseX, MouseY, MouseXlast, MouseYlast;
        bool MouseM;
        public KayıtOl()
        {
            InitializeComponent();
            this.BackColor = Color.White;
            panel2.BackColor = Color.FromArgb(100, Color.Black);
            checkBox1.BackColor = Color.FromArgb(0, Color.Black);

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                kayıtol_şifre_txt.UseSystemPasswordChar = false;

            }
            else
            {
                kayıtol_şifre_txt.UseSystemPasswordChar = true;
            }
        }

        public bool kullanıcı_exist()
        {
            if (kayıtol_kullanıcıadı_txt.Text == "")
            {
                connection.Open();
                OracleCommand d = new OracleCommand("KULLANICI", connection);
                d.CommandType = System.Data.CommandType.StoredProcedure;
                d.Parameters.Add("X1", OracleDbType.Varchar2).Value = kayıtol_kullanıcıadı_txt.Text;
                d.Parameters.Add("X2", OracleDbType.Varchar2).Value = kayıtol_şifre_txt.Text;
                d.Parameters.Add("X3", OracleDbType.Varchar2).Value = "Üye";
                d.Parameters.Add("X4", OracleDbType.Varchar2).Value = kayıtol_adsoyad_txt.Text;
                d.Parameters.Add("X5", OracleDbType.Varchar2).Value = "EXISTS";
                d.Parameters.Add("X6", OracleDbType.Varchar2).Value = kayıtol_email1_txt.Text+"@"+kayıtol_email2_txt.SelectedItem.ToString(); ;
                d.Parameters.Add("F1", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                OracleDataAdapter adapter = new OracleDataAdapter();
                adapter.SelectCommand = d;
                DataTable tablo2 = new DataTable();
                adapter.Fill(tablo2);                
                connection.Close();
                int u = tablo2.Rows.Count;
                if (u > 0)
                {
                    return false;
                }
                else
                    return true;
            }
            else
            {
                connection.Open();
                OracleCommand d = new OracleCommand("KULLANICI", connection);
                d.CommandType = System.Data.CommandType.StoredProcedure;
                d.Parameters.Add("X1", OracleDbType.Varchar2).Value = kayıtol_kullanıcıadı_txt.Text;
                d.Parameters.Add("X2", OracleDbType.Varchar2).Value = kayıtol_şifre_txt.Text;
                d.Parameters.Add("X3", OracleDbType.Varchar2).Value = "Üye";
                d.Parameters.Add("X4", OracleDbType.Varchar2).Value = kayıtol_adsoyad_txt.Text;
                d.Parameters.Add("X5", OracleDbType.Varchar2).Value = "EXISTS";
                d.Parameters.Add("X6", OracleDbType.Varchar2).Value = kayıtol_email1_txt.Text + "@" + kayıtol_email2_txt.SelectedItem.ToString(); ;
                d.Parameters.Add("F1", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                OracleDataAdapter adapter = new OracleDataAdapter();
                adapter.SelectCommand = d;
                DataTable tablo2 = new DataTable();
                adapter.Fill(tablo2);                
                connection.Close();
                int u = tablo2.Rows.Count;
                if (u > 0)
                {
                    return false;
                }
                else
                    return true;
            }
        }

        public void kullanıcı_Ekle()
        {
            if (kullanıcı_exist())
            {
                connection.Open();
                OracleCommand d = new OracleCommand("KULLANICI", connection);
                d.CommandType = System.Data.CommandType.StoredProcedure;

                d.Parameters.Add("X1", OracleDbType.Varchar2).Value = kayıtol_kullanıcıadı_txt.Text;
                d.Parameters.Add("X2", OracleDbType.Varchar2).Value = kayıtol_şifre_txt.Text;
                d.Parameters.Add("X3", OracleDbType.Varchar2).Value = "Üye";
                d.Parameters.Add("X4", OracleDbType.Varchar2).Value = kayıtol_adsoyad_txt.Text;
                d.Parameters.Add("X5", OracleDbType.Varchar2).Value = "INSERT";
                d.Parameters.Add("X6", OracleDbType.Varchar2).Value = kayıtol_email1_txt.Text + "@" + kayıtol_email2_txt.SelectedItem.ToString(); 
                d.Parameters.Add("F1", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                d.ExecuteNonQuery();

                connection.Close();
                MessageBox.Show("Kayıt Başarılı :) \nGiriş Yapabilirsiniz");
                
                kayıtol_kullanıcıadı_txt.Text = "";
                kayıtol_email1_txt.Text = "";
                kayıtol_email2_txt.SelectedItem = null;
                kayıtol_şifre_txt.Text = "";
                kayıtol_adsoyad_txt.Text = "";
            }
            else
            {
                MessageBox.Show("Bu Kullanıcı  bilgileri bulunmaktadır... ");
            }
                       

        }
        private void KayıtButonu_Click(object sender, EventArgs e)
        {
            kullanıcı_Ekle();
                        

        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
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
    }
}
