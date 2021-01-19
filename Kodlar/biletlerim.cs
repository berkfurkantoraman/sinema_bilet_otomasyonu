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
    public partial class biletlerim : Form
    {
        OracleConnection connection = new OracleConnection("User Id=SYSTEM;Password=5092010berk;Data Source=localhost:1521/XEPDB1;");
        int MouseX, MouseY, MouseXlast, MouseYlast;
        bool MouseM;
        public biletlerim()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void bilet_select()
        {
            connection.Open();
            OracleCommand d = new OracleCommand("BILET", connection);
            d.CommandType = System.Data.CommandType.StoredProcedure;
            d.Parameters.Add("X1", OracleDbType.Int64).Value = 0;
            d.Parameters.Add("X2", OracleDbType.Int64).Value = 0;
            d.Parameters.Add("X3", OracleDbType.Varchar2).Value = AnaEkran.kullanici_adi_text;
            d.Parameters.Add("X4", OracleDbType.Varchar2).Value = " ";
            d.Parameters.Add("X5", OracleDbType.Varchar2).Value = " ";
            d.Parameters.Add("X6", OracleDbType.Varchar2).Value = " ";
            d.Parameters.Add("X7", OracleDbType.Int64).Value = 0;            
            d.Parameters.Add("X9", OracleDbType.Varchar2).Value = "SELECT";
            d.Parameters.Add("b", OracleDbType.Int64).Value = 0;
            d.Parameters.Add("F1", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            OracleDataAdapter adapter = new OracleDataAdapter();
            adapter.SelectCommand = d;
            DataTable tablo2 = new DataTable();
            adapter.Fill(tablo2);
            bilet_data.DataSource = tablo2;
            
            connection.Close();
        }

        public void bilet_delete()
        {
            connection.Open();
            OracleCommand d = new OracleCommand("BILET", connection);
            d.CommandType = System.Data.CommandType.StoredProcedure;
            d.Parameters.Add("X1", OracleDbType.Int64).Value = int.Parse(bilet_biletid.Text);
            d.Parameters.Add("X2", OracleDbType.Int64).Value = 0;
            d.Parameters.Add("X3", OracleDbType.Varchar2).Value = AnaEkran.kullanici_adi_text;
            d.Parameters.Add("X4", OracleDbType.Varchar2).Value = " ";
            d.Parameters.Add("X5", OracleDbType.Varchar2).Value = " ";
            d.Parameters.Add("X6", OracleDbType.Varchar2).Value = " ";
            d.Parameters.Add("X7", OracleDbType.Int64).Value = 0;            
            d.Parameters.Add("X9", OracleDbType.Varchar2).Value = "DELETE";
            d.Parameters.Add("b", OracleDbType.Int64).Value = 0;
            d.Parameters.Add("F1", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            d.ExecuteNonQuery();

            connection.Close();
            bilet_select();
            bilet_biletid.Text = "";
            bilet_film_adı.Text = "";
            bilet_format.Text = "";
            bilet_kategori.Text = "";
            bilet_koltuk.Text = "";
            bilet_salon.Text = "";
            bilet_seans.Text = "";
            bilet_tarih.Text = "";
            bilet_pic.ImageLocation = "";
        }

        public void resim()
        {
            connection.Open();
            OracleCommand d = new OracleCommand("BILET", connection);
            d.CommandType = System.Data.CommandType.StoredProcedure;
            d.Parameters.Add("X1", OracleDbType.Int64).Value = int.Parse(bilet_biletid.Text);
            d.Parameters.Add("X2", OracleDbType.Int64).Value = 0;
            d.Parameters.Add("X3", OracleDbType.Varchar2).Value = "";
            d.Parameters.Add("X4", OracleDbType.Varchar2).Value = " ";
            d.Parameters.Add("X5", OracleDbType.Varchar2).Value = " ";
            d.Parameters.Add("X6", OracleDbType.Varchar2).Value = " ";
            d.Parameters.Add("X7", OracleDbType.Int64).Value = 0;            
            d.Parameters.Add("X9", OracleDbType.Varchar2).Value = "RESIM";
            d.Parameters.Add("b", OracleDbType.Int64).Value = 0;
            d.Parameters.Add("F1", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            OracleDataAdapter adapter = new OracleDataAdapter();
            adapter.SelectCommand = d;
            DataTable tablo2 = new DataTable();
            adapter.Fill(tablo2);
            bilet_pic.ImageLocation=tablo2.Rows[0].ItemArray[1].ToString();
            

            connection.Close();
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

        private void biletlerim_Shown(object sender, EventArgs e)
        {
            bilet_select();
        }

        private void bilet_data_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = this.bilet_data.Rows[e.RowIndex];
            bilet_biletid.Text = row.Cells[0].Value.ToString();
            bilet_film_adı.Text = row.Cells[1].Value.ToString();
            bilet_kategori.Text = row.Cells[2].Value.ToString();
            bilet_format.Text = row.Cells[3].Value.ToString();
            bilet_tarih.Text = row.Cells[4].Value.ToString();
            bilet_seans.Text = row.Cells[5].Value.ToString();
            bilet_koltuk.Text = row.Cells[6].Value.ToString();
            bilet_salon.Text = row.Cells[7].Value.ToString();
            resim();

            //seans_afis.ImageLocation = row.Cells[8].Value.ToString();
        }

        private void bilet_tarih_TextChanged(object sender, EventArgs e)
        {

        }

        private void bilet_sil_btn_Click(object sender, EventArgs e)
        {
            bilet_delete();
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
