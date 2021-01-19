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
    public partial class Admin : Form
    {
        OracleConnection connection = new OracleConnection("User Id=SYSTEM;Password=5092010berk;Data Source=localhost:1521/XEPDB1;");
        OracleCommand command = new OracleCommand();
        int MouseX, MouseY;
        bool MouseM,salon_tıklandı=false,film_tıklandı=false;
        public Giris grs = new Giris();
        KayıtOl kyt = new KayıtOl();
        public static string admin_adi_text;


        public Admin()
        {
            InitializeComponent();
            this.BackColor = Color.White;
            SalonPanel.BackColor = Color.FromArgb(100, Color.Black);
            YiyecekPanel.BackColor = Color.FromArgb(100, Color.Black);
            FilmPanel.BackColor = Color.FromArgb(100, Color.Black);
            KullanıcılarPanel.BackColor = Color.FromArgb(100, Color.Black);
            SeansPanel.BackColor = Color.FromArgb(100, Color.Black);
        }


        /*

        -------------------------------------------------------------------------------------------------------------
        -------------------------------------------------------------------------------------------------------------

        */

        public bool salon_bosmu()
        {
            if (salon_salonNo_txt.Text == "" || salon_kapasite_txt.Text == "")
            {
                MessageBox.Show("Tüm Boşlukları Doldurun !..");
                return false;
            }
            else return true;
        }

        public void salon_select()
        {
           
                connection.Open();
                OracleCommand c = new OracleCommand("SALON", connection);
                c.CommandType = System.Data.CommandType.StoredProcedure;
                c.Parameters.Add("X1", OracleDbType.Int64).Value = 65;
                c.Parameters.Add("X2", OracleDbType.Varchar2).Value = salon_kapasite_txt.Text;
                c.Parameters.Add("X3", OracleDbType.Varchar2).Value = "SELECT";
                c.Parameters.Add("F1", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                OracleDataAdapter adapter = new OracleDataAdapter();
                adapter.SelectCommand = c;
                DataTable tablo1 = new DataTable();
                adapter.Fill(tablo1);
                Salon_Data.DataSource = tablo1;
                seans_salon_data.DataSource = tablo1;
                connection.Close();
                        

        }

        public bool salon_exist()
        {
            
                connection.Open();
                OracleCommand b = new OracleCommand("SALON", connection);
                b.CommandType = System.Data.CommandType.StoredProcedure;
                b.Parameters.Add("X1", OracleDbType.Int64).Value = int.Parse(salon_salonNo_txt.Text);
                b.Parameters.Add("X2", OracleDbType.Varchar2).Value = salon_kapasite_txt.Text;
                b.Parameters.Add("X3", OracleDbType.Varchar2).Value = "EXISTS";
                b.Parameters.Add("F1", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                OracleDataAdapter adapter = new OracleDataAdapter();
                adapter.SelectCommand = b;
                DataTable tablo2 = new DataTable();
                adapter.Fill(tablo2);
                Salon_Data.DataSource = tablo2;
                connection.Close();
                int u = tablo2.Rows.Count;
                if (u > 0)
                {
                    return false;
                }
                else
                    return true;
            
        }
        
        public void salon_ekle()
        {
            if (salon_bosmu())
            {
                if (salon_exist())
                {
                    connection.Open();
                    OracleCommand d = new OracleCommand("SALON", connection);
                    d.CommandType = System.Data.CommandType.StoredProcedure;
                    d.Parameters.Add("X1", OracleDbType.Varchar2).Value = salon_salonNo_txt.Text;
                    d.Parameters.Add("X2", OracleDbType.Varchar2).Value = salon_kapasite_txt.Text;
                    d.Parameters.Add("X3", OracleDbType.Varchar2).Value = "INSERT";
                    d.Parameters.Add("F1", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                    d.ExecuteNonQuery();

                    connection.Close();

                }
                else
                {
                    MessageBox.Show("Böyle bir kayıt bulunmaktadır !!  \nFarklı bir salon numarası seçiniz. ");
                }

                salon_select();
            }
        }

        public void salon_guncelle()
        {
            if (salon_bosmu())
            {
                if (!salon_exist())
                {
                    connection.Open();
                    OracleCommand d = new OracleCommand("SALON", connection);
                    d.CommandType = System.Data.CommandType.StoredProcedure;
                    d.Parameters.Add("X1", OracleDbType.Varchar2).Value = salon_salonNo_txt.Text;
                    d.Parameters.Add("X2", OracleDbType.Varchar2).Value = salon_kapasite_txt.Text;
                    d.Parameters.Add("X3", OracleDbType.Varchar2).Value = "UPDATE";
                    d.Parameters.Add("F1", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                    d.ExecuteNonQuery();

                    connection.Close();

                }
                else
                {
                    MessageBox.Show("Böyle bir salon bulunmamaktadır !!  \nFarklı bir salon numarası seçiniz. ");
                }

                salon_select();
            }
        }

        public void salon_sil()
        {
            if (salon_bosmu())
            {
                if (!salon_exist())
                {
                    connection.Open();
                    OracleCommand d = new OracleCommand("SALON", connection);
                    d.CommandType = System.Data.CommandType.StoredProcedure;
                    d.Parameters.Add("X1", OracleDbType.Varchar2).Value = salon_salonNo_txt.Text;
                    d.Parameters.Add("X2", OracleDbType.Varchar2).Value = salon_kapasite_txt.Text;
                    d.Parameters.Add("X3", OracleDbType.Varchar2).Value = "DELETE";
                    d.Parameters.Add("F1", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                    d.ExecuteNonQuery();

                    connection.Close();

                }
                else
                {
                    MessageBox.Show("Böyle bir salon bulunmamaktadır !!  \nFarklı bir salon numarası seçiniz. ");
                }

                salon_select();
            }
        }

        /*

        -------------------------------------------------------------------------------------------------------------
        -------------------------------------------------------------------------------------------------------------

        */
        
        public int film_eleman_sayici()
        {
            OracleConnection connection2 = new OracleConnection("User Id=SYSTEM;Password=5092010berk;Data Source=localhost:1521/XEPDB1;");
            connection2.Open();
            OracleCommand d = new OracleCommand("FILM", connection2);
            d.CommandType = System.Data.CommandType.StoredProcedure;
            d.Parameters.Add("X1", OracleDbType.Int64).Value = 0;
            d.Parameters.Add("X2", OracleDbType.Varchar2).Value = film_filmisim_txt.Text;
            d.Parameters.Add("X3", OracleDbType.Varchar2).Value = film_kategori_txt.Text;
            d.Parameters.Add("X4", OracleDbType.Varchar2).Value = film_etiket_txt.Text;
            d.Parameters.Add("X5", OracleDbType.Varchar2).Value = film_format_txt.Text;
            d.Parameters.Add("X6", OracleDbType.Varchar2).Value = film_dil_txt.Text;
            d.Parameters.Add("X7", OracleDbType.Varchar2).Value = film_özet_txt.Text;
            d.Parameters.Add("X8", OracleDbType.Varchar2).Value = film_imdb_txt.Text;
            d.Parameters.Add("X9", OracleDbType.Varchar2).Value = afis_pic.ImageLocation;
            d.Parameters.Add("X10", OracleDbType.Varchar2).Value = "SELECT";
            d.Parameters.Add("b", OracleDbType.Int64).Value = 0 ;
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
            d.Parameters.Add("X2", OracleDbType.Varchar2).Value = film_filmisim_txt.Text;
            d.Parameters.Add("X3", OracleDbType.Varchar2).Value = film_kategori_txt.Text;
            d.Parameters.Add("X4", OracleDbType.Varchar2).Value = film_etiket_txt.Text;
            d.Parameters.Add("X5", OracleDbType.Varchar2).Value = film_format_txt.Text;
            d.Parameters.Add("X6", OracleDbType.Varchar2).Value = film_dil_txt.Text;
            d.Parameters.Add("X7", OracleDbType.Varchar2).Value = film_özet_txt.Text;
            d.Parameters.Add("X8", OracleDbType.Varchar2).Value = film_imdb_txt.Text;
            d.Parameters.Add("X9", OracleDbType.Varchar2).Value = afis_pic.ImageLocation;
            d.Parameters.Add("X10", OracleDbType.Varchar2).Value = "SELECT";
            d.Parameters.Add("b", OracleDbType.Int64).Value = film_eleman_sayici(); ;
            d.Parameters.Add("F1", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            OracleDataAdapter adapter = new OracleDataAdapter();
            adapter.SelectCommand = d;
            DataTable tablo2 = new DataTable();
            adapter.Fill(tablo2);
            Film_Data.DataSource = tablo2;
            seans_film_data.DataSource = tablo2;
            connection.Close();

        }

        public bool film_exist()
        {
            if(film_filmid_txt.Text==""){
                connection.Open();
                OracleCommand d = new OracleCommand("FILM", connection);
                d.CommandType = System.Data.CommandType.StoredProcedure;
                d.Parameters.Add("X1", OracleDbType.Int64).Value = -1;
                d.Parameters.Add("X2", OracleDbType.Varchar2).Value = film_filmisim_txt.Text;
                d.Parameters.Add("X3", OracleDbType.Varchar2).Value = film_kategori_txt.Text;
                d.Parameters.Add("X4", OracleDbType.Varchar2).Value = film_etiket_txt.Text;
                d.Parameters.Add("X5", OracleDbType.Varchar2).Value = film_format_txt.Text;
                d.Parameters.Add("X6", OracleDbType.Varchar2).Value = film_dil_txt.Text;
                d.Parameters.Add("X7", OracleDbType.Varchar2).Value = film_özet_txt.Text;
                d.Parameters.Add("X8", OracleDbType.Varchar2).Value = film_imdb_txt.Text;
                d.Parameters.Add("X9", OracleDbType.Varchar2).Value = afis_pic.ImageLocation;
                d.Parameters.Add("X10", OracleDbType.Varchar2).Value = "EXISTS";
                d.Parameters.Add("b", OracleDbType.Int64).Value = film_eleman_sayici(); ;
                d.Parameters.Add("F1", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                OracleDataAdapter adapter = new OracleDataAdapter();
                adapter.SelectCommand = d;
                DataTable tablo2 = new DataTable();
                adapter.Fill(tablo2);
                Film_Data.DataSource = tablo2;
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
                OracleCommand d = new OracleCommand("FILM", connection);
                d.CommandType = System.Data.CommandType.StoredProcedure;
                d.Parameters.Add("X1", OracleDbType.Int64).Value = int.Parse(film_filmid_txt.Text);
                d.Parameters.Add("X2", OracleDbType.Varchar2).Value = film_filmisim_txt.Text;
                d.Parameters.Add("X3", OracleDbType.Varchar2).Value = film_kategori_txt.Text;
                d.Parameters.Add("X4", OracleDbType.Varchar2).Value = film_etiket_txt.Text;
                d.Parameters.Add("X5", OracleDbType.Varchar2).Value = film_format_txt.Text;
                d.Parameters.Add("X6", OracleDbType.Varchar2).Value = film_dil_txt.Text;
                d.Parameters.Add("X7", OracleDbType.Varchar2).Value = film_özet_txt.Text;
                d.Parameters.Add("X8", OracleDbType.Varchar2).Value = film_imdb_txt.Text;
                d.Parameters.Add("X9", OracleDbType.Varchar2).Value = afis_pic.ImageLocation;
                d.Parameters.Add("X10", OracleDbType.Varchar2).Value = "EXISTS";
                d.Parameters.Add("b", OracleDbType.Int64).Value = film_eleman_sayici(); ;
                d.Parameters.Add("F1", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                OracleDataAdapter adapter = new OracleDataAdapter();
                adapter.SelectCommand = d;
                DataTable tablo2 = new DataTable();
                adapter.Fill(tablo2);
                Film_Data.DataSource = tablo2;
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

        public void film_Ekle()
        {

            if (film_filmisim_txt.Text == "" || film_dil_txt.Text == "" || film_kategori_txt.Text=="" || film_etiket_txt.Text == "" ||
                film_format_txt.Text == "" || film_özet_txt.Text == "" || film_imdb_txt.Text == "" || afis_pic.ImageLocation=="" )
            {
                MessageBox.Show("İlgili Boşlukları Doldurun ");
            }
            else
            {
                if (film_exist())
                {
                    connection.Open();
                    OracleCommand d = new OracleCommand("FILM", connection);
                    d.CommandType = System.Data.CommandType.StoredProcedure;

                    if (film_filmid_txt.Text == "")
                    {
                        d.Parameters.Add("X1", OracleDbType.Int64).Value = -1;
                    }
                    else
                    {
                        d.Parameters.Add("X1", OracleDbType.Int64).Value = int.Parse(film_filmid_txt.Text);
                    }
                    d.Parameters.Add("X2", OracleDbType.Varchar2).Value = film_filmisim_txt.Text;
                    d.Parameters.Add("X3", OracleDbType.Varchar2).Value = film_kategori_txt.Text;
                    d.Parameters.Add("X4", OracleDbType.Varchar2).Value = film_etiket_txt.Text;
                    d.Parameters.Add("X5", OracleDbType.Varchar2).Value = film_format_txt.Text;
                    d.Parameters.Add("X6", OracleDbType.Varchar2).Value = film_dil_txt.Text;
                    d.Parameters.Add("X7", OracleDbType.Varchar2).Value = film_özet_txt.Text;
                    d.Parameters.Add("X8", OracleDbType.Varchar2).Value = film_imdb_txt.Text;
                    d.Parameters.Add("X9", OracleDbType.Varchar2).Value = afis_pic.ImageLocation;
                    d.Parameters.Add("X10", OracleDbType.Varchar2).Value = "INSERT";
                    d.Parameters.Add("b", OracleDbType.Int64).Value = film_eleman_sayici(); ;
                    d.Parameters.Add("F1", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                    d.ExecuteNonQuery();

                    connection.Close();

                }
                else
                {
                    MessageBox.Show("Bu film ID ya da film bilgileri kullanılmaktadır... ");
                }

                film_select();
            }
            

        }

        public void film_guncelle()
        {


            if (!film_exist())
            {
                connection.Open();
                OracleCommand d = new OracleCommand("FILM", connection);
                d.CommandType = System.Data.CommandType.StoredProcedure;
                d.Parameters.Add("X1", OracleDbType.Int64).Value = int.Parse(film_filmid_txt.Text);
                d.Parameters.Add("X2", OracleDbType.Varchar2).Value = film_filmisim_txt.Text;
                d.Parameters.Add("X3", OracleDbType.Varchar2).Value = film_kategori_txt.Text;
                d.Parameters.Add("X4", OracleDbType.Varchar2).Value = film_etiket_txt.Text;
                d.Parameters.Add("X5", OracleDbType.Varchar2).Value = film_format_txt.Text;
                d.Parameters.Add("X6", OracleDbType.Varchar2).Value = film_dil_txt.Text;
                d.Parameters.Add("X7", OracleDbType.Varchar2).Value = film_özet_txt.Text;
                d.Parameters.Add("X8", OracleDbType.Varchar2).Value = film_imdb_txt.Text;
                d.Parameters.Add("X9", OracleDbType.Varchar2).Value = afis_pic.ImageLocation;
                d.Parameters.Add("X10", OracleDbType.Varchar2).Value = "UPDATE";
                d.Parameters.Add("b", OracleDbType.Int64).Value = film_eleman_sayici(); ;
                d.Parameters.Add("F1", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                
                d.ExecuteNonQuery();
                
                connection.Close();

            }
            else
            {
                MessageBox.Show("Böyle bir film bulunmamaktadır !!  \nFarklı bir film bilgisi giriniz. ");
            }

            film_select();

        }

        public void film_sil()
        {
            if (!film_exist())
            {
                 connection.Open();
                OracleCommand d = new OracleCommand("FILM", connection);
                d.CommandType = System.Data.CommandType.StoredProcedure;
                d.Parameters.Add("X1", OracleDbType.Int64).Value = int.Parse(film_filmid_txt.Text);
                d.Parameters.Add("X2", OracleDbType.Varchar2).Value = film_filmisim_txt.Text;
                d.Parameters.Add("X3", OracleDbType.Varchar2).Value = film_kategori_txt.Text;
                d.Parameters.Add("X4", OracleDbType.Varchar2).Value = film_etiket_txt.Text;
                d.Parameters.Add("X5", OracleDbType.Varchar2).Value = film_format_txt.Text;
                d.Parameters.Add("X6", OracleDbType.Varchar2).Value = film_dil_txt.Text;
                d.Parameters.Add("X7", OracleDbType.Varchar2).Value = film_özet_txt.Text;
                d.Parameters.Add("X8", OracleDbType.Varchar2).Value = film_imdb_txt.Text;
                d.Parameters.Add("X9", OracleDbType.Varchar2).Value = afis_pic.ImageLocation;
                d.Parameters.Add("X10", OracleDbType.Varchar2).Value = "DELETE";
                d.Parameters.Add("b", OracleDbType.Int64).Value = film_eleman_sayici(); ;
                d.Parameters.Add("F1", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                d.ExecuteNonQuery();

                connection.Close();


            }
            else
            {
                MessageBox.Show("Böyle bir film bulunmamaktadır !!  \nFarklı bir film bilgisi giriniz. ");
            }

            film_select();

        }

        /*

        -------------------------------------------------------------------------------------------------------------
        -------------------------------------------------------------------------------------------------------------

        */

        public int yiyecek_eleman_sayici()
        {
            OracleConnection connection2 = new OracleConnection("User Id=SYSTEM;Password=5092010berk;Data Source=localhost:1521/XEPDB1;");
            connection2.Open();
            OracleCommand d = new OracleCommand("YIYECEK", connection2);
            d.CommandType = System.Data.CommandType.StoredProcedure;
            d.Parameters.Add("X1", OracleDbType.Int64).Value = 0;
            d.Parameters.Add("X2", OracleDbType.Varchar2).Value = urunadi_txt.Text;
            d.Parameters.Add("X3", OracleDbType.Int64).Value = 0;
            d.Parameters.Add("X4", OracleDbType.Int64).Value = 0;
            d.Parameters.Add("X5", OracleDbType.Varchar2).Value = "SELECT";
            d.Parameters.Add("X6", OracleDbType.Varchar2).Value = urun_pic.ImageLocation;
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

        public void yiyecek_select()
        {
            connection.Open();
            OracleCommand d = new OracleCommand("YIYECEK", connection);
            d.CommandType = System.Data.CommandType.StoredProcedure;
            d.Parameters.Add("X1", OracleDbType.Int64).Value = 0;
            d.Parameters.Add("X2", OracleDbType.Varchar2).Value = urunadi_txt.Text;
            d.Parameters.Add("X3", OracleDbType.Int64).Value = 0;
            d.Parameters.Add("X4", OracleDbType.Varchar2).Value = "";
            d.Parameters.Add("X5", OracleDbType.Varchar2).Value = "SELECT";
            d.Parameters.Add("X6", OracleDbType.Varchar2).Value = urun_pic.ImageLocation;
            d.Parameters.Add("b", OracleDbType.Int64).Value = 0; 
            d.Parameters.Add("F1", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            OracleDataAdapter adapter = new OracleDataAdapter();
            adapter.SelectCommand = d;
            DataTable tablo2 = new DataTable();
            adapter.Fill(tablo2);
            yiyecek_data.DataSource = tablo2;
            connection.Close();

        }

        public bool yiyecek_exist()
        {

            String a, b, c = urunfiyati_txt.Text, e = urun_kurus_txt.Text;
            if (c == "")
            {
                a = "0";
            }
            else
            {
                a = c;
            }

            if (e == "")
            {
                b = "00";
            }
            else if (e.Length == 1)
            {
                b = e + "0";
            }
            else
            {
                b = e;
            }
            if (urunid_txt.Text == "")
            {
                connection.Open();
                OracleCommand d = new OracleCommand("YIYECEK", connection);
                d.CommandType = System.Data.CommandType.StoredProcedure;
                d.Parameters.Add("X1", OracleDbType.Int64).Value = -1;
                d.Parameters.Add("X2", OracleDbType.Varchar2).Value = urunadi_txt.Text;
                d.Parameters.Add("X3", OracleDbType.Varchar2).Value = a +"."+ b;
                d.Parameters.Add("X4", OracleDbType.Varchar2).Value = uruntype_txt.SelectedItem.ToString();
                d.Parameters.Add("X5", OracleDbType.Varchar2).Value = "EXISTS";
                d.Parameters.Add("X6", OracleDbType.Varchar2).Value = urun_pic.ImageLocation;
                d.Parameters.Add("b", OracleDbType.Int64).Value = 0;
                d.Parameters.Add("F1", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                OracleDataAdapter adapter = new OracleDataAdapter();
                adapter.SelectCommand = d;
                DataTable tablo2 = new DataTable();
                adapter.Fill(tablo2);
                yiyecek_data.DataSource = tablo2;
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
                OracleCommand d = new OracleCommand("YIYECEK", connection);
                d.CommandType = System.Data.CommandType.StoredProcedure;
                d.Parameters.Add("X1", OracleDbType.Int64).Value = int.Parse(urunid_txt.Text);
                d.Parameters.Add("X2", OracleDbType.Varchar2).Value = urunadi_txt.Text;
                d.Parameters.Add("X3", OracleDbType.Varchar2).Value = a + "." + b;
                d.Parameters.Add("X4", OracleDbType.Varchar2).Value = uruntype_txt.SelectedItem.ToString();
                d.Parameters.Add("X5", OracleDbType.Varchar2).Value = "EXISTS";
                d.Parameters.Add("X6", OracleDbType.Varchar2).Value = urun_pic.ImageLocation;
                d.Parameters.Add("b", OracleDbType.Int64).Value =0;
                d.Parameters.Add("F1", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                OracleDataAdapter adapter = new OracleDataAdapter();
                adapter.SelectCommand = d;
                DataTable tablo2 = new DataTable();
                adapter.Fill(tablo2);
                yiyecek_data.DataSource = tablo2;
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

        public void yiyecek_Ekle()
        {
            if (yiyecek_exist())
            {
                String a, b, c = urunfiyati_txt.Text, e = urun_kurus_txt.Text;
                if (c == "")
                {
                    a = "0";
                }
                else
                {
                    a = c;
                }

                if (e == "")
                {
                    b = "00";
                }
                else if (e.Length == 1)
                {
                    b = e + "0";
                }
                else
                {
                    b = e;
                }
                connection.Open();
                OracleCommand d = new OracleCommand("YIYECEK", connection);
                d.CommandType = System.Data.CommandType.StoredProcedure;

                if (urunid_txt.Text == "")
                {
                    d.Parameters.Add("X1", OracleDbType.Int64).Value = -1;
                }
                else
                {
                    d.Parameters.Add("X1", OracleDbType.Int64).Value = int.Parse(urunid_txt.Text);
                }
                d.Parameters.Add("X2", OracleDbType.Varchar2).Value = urunadi_txt.Text;
                d.Parameters.Add("X3", OracleDbType.Varchar2).Value = a+ "." +b;
                d.Parameters.Add("X4", OracleDbType.Varchar2).Value = uruntype_txt.SelectedItem.ToString();
                d.Parameters.Add("X5", OracleDbType.Varchar2).Value = "INSERT";
                d.Parameters.Add("X6", OracleDbType.Varchar2).Value = urun_pic.ImageLocation;
                d.Parameters.Add("b", OracleDbType.Int64).Value = yiyecek_eleman_sayici();
                d.Parameters.Add("F1", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                d.ExecuteNonQuery();

                connection.Close();

            }
            else
            {
                MessageBox.Show("Bu Ürün ID ya da Ürün bilgileri kullanılmaktadır... ");
            }

            yiyecek_select();

        }

        public void yiyecek_guncelle()
        {
            String a, b,c=urunfiyati_txt.Text,e=urun_kurus_txt.Text;
            if (c == "")
            {
                a = "0";
            }
            else
            {
                a = c;
            }

            if (e == "")
            {
                b = "00";
            }
            else if (e.Length == 1)
            {
                b = e + "0";
            }
            else
            {
                b = e;
            }
            if (!yiyecek_exist())
            {
                connection.Open();
                OracleCommand d = new OracleCommand("YIYECEK", connection);
                d.CommandType = System.Data.CommandType.StoredProcedure;
                d.Parameters.Add("X1", OracleDbType.Int64).Value = int.Parse(urunid_txt.Text);
                d.Parameters.Add("X2", OracleDbType.Varchar2).Value = urunadi_txt.Text;
                d.Parameters.Add("X3", OracleDbType.Varchar2).Value = a + "." + b;
                d.Parameters.Add("X4", OracleDbType.Varchar2).Value = uruntype_txt.SelectedItem.ToString();
                d.Parameters.Add("X5", OracleDbType.Varchar2).Value = "UPDATE";
                d.Parameters.Add("X6", OracleDbType.Varchar2).Value = urun_pic.ImageLocation;
                d.Parameters.Add("b", OracleDbType.Int64).Value = yiyecek_eleman_sayici();
                d.Parameters.Add("F1", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                d.ExecuteNonQuery();

                connection.Close();

            }
            else
            {
                MessageBox.Show("Böyle bir Ürün bulunmamaktadır !!  \nFarklı bir Ürün bilgisi giriniz. ");
            }

            yiyecek_select();

        }

        public void yiyecek_sil()
        {
            String a, b, c = urunfiyati_txt.Text, e = urun_kurus_txt.Text;
            if (c == "")
            {
                a = "0";
            }
            else
            {
                a = c;
            }

            if (e == "")
            {
                b = "00";
            }
            else if (e.Length == 1)
            {
                b = e + "0";
            }
            else
            {
                b = e;
            }
            if (!yiyecek_exist())
            {
                connection.Open();
                OracleCommand d = new OracleCommand("YIYECEK", connection);
                d.CommandType = System.Data.CommandType.StoredProcedure;
                d.Parameters.Add("X1", OracleDbType.Int64).Value = int.Parse(urunid_txt.Text);
                d.Parameters.Add("X2", OracleDbType.Varchar2).Value = urunadi_txt.Text;
                d.Parameters.Add("X3", OracleDbType.Varchar2).Value = a + "." + b;
                d.Parameters.Add("X4", OracleDbType.Varchar2).Value = uruntype_txt.SelectedItem.ToString();
                d.Parameters.Add("X5", OracleDbType.Varchar2).Value = "DELETE";
                d.Parameters.Add("X6", OracleDbType.Varchar2).Value = urun_pic.ImageLocation;
                d.Parameters.Add("b", OracleDbType.Int64).Value = yiyecek_eleman_sayici();
                d.Parameters.Add("F1", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                d.ExecuteNonQuery();

                connection.Close();


            }
            else
            {
                MessageBox.Show("Böyle bir Ürün bulunmamaktadır !!  \nFarklı bir Ürün bilgisi giriniz. ");
            }

                yiyecek_select();

        }

        /*

        -------------------------------------------------------------------------------------------------------------
        -------------------------------------------------------------------------------------------------------------

        */

        public int kullanıcı_sayici()
        {
            OracleConnection connection2 = new OracleConnection("User Id=SYSTEM;Password=5092010berk;Data Source=localhost:1521/XEPDB1;");
            connection2.Open();
            OracleCommand d = new OracleCommand("KULLANICI", connection2);
            d.CommandType = System.Data.CommandType.StoredProcedure;
            d.Parameters.Add("X1", OracleDbType.Int64).Value = 0;
            d.Parameters.Add("X2", OracleDbType.Varchar2).Value = urunadi_txt.Text;
            d.Parameters.Add("X3", OracleDbType.Int64).Value = int.Parse(urunfiyati_txt.Text);
            d.Parameters.Add("X4", OracleDbType.Int64).Value = 0;
            d.Parameters.Add("X5", OracleDbType.Varchar2).Value = "SELECT";          
            d.Parameters.Add("F1", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            OracleDataAdapter adapter = new OracleDataAdapter();
            adapter.SelectCommand = d;
            DataTable tablo3 = new DataTable();
            adapter.Fill(tablo3);
            int u = tablo3.Rows.Count;

            connection2.Close();
            return u;
        }

        public void kullanıcı_select()
        {
            connection.Open();
            OracleCommand d = new OracleCommand("KULLANICI", connection);
            d.CommandType = System.Data.CommandType.StoredProcedure;
            d.Parameters.Add("X1", OracleDbType.Varchar2).Value = 0;
            d.Parameters.Add("X2", OracleDbType.Varchar2).Value = urunadi_txt.Text;
            d.Parameters.Add("X3", OracleDbType.Varchar2).Value = 0;
            d.Parameters.Add("X4", OracleDbType.Varchar2).Value = "";
            d.Parameters.Add("X5", OracleDbType.Varchar2).Value = "SELECT";
            d.Parameters.Add("X6", OracleDbType.Varchar2).Value = "";
            d.Parameters.Add("F1", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            OracleDataAdapter adapter = new OracleDataAdapter();
            adapter.SelectCommand = d;
            DataTable tablo2 = new DataTable();
            adapter.Fill(tablo2);
            kullanıcılar_data.DataSource = tablo2;
            connection.Close();

        }
        
        public bool kullanıcı_exist()
        {
            if (kullanıcıadı_txt.Text == "")
            {
                connection.Open();
                OracleCommand d = new OracleCommand("KULLANICI", connection);
                d.CommandType = System.Data.CommandType.StoredProcedure;
                d.Parameters.Add("X1", OracleDbType.Varchar2).Value = kullanıcıadı_txt.Text;
                d.Parameters.Add("X2", OracleDbType.Varchar2).Value = sifre_txt.Text;
                d.Parameters.Add("X3", OracleDbType.Varchar2).Value = type_txt.SelectedItem.ToString();
                d.Parameters.Add("X4", OracleDbType.Varchar2).Value = adsoyad_txt.Text;
                d.Parameters.Add("X5", OracleDbType.Varchar2).Value = "EXISTS";
                d.Parameters.Add("X6", OracleDbType.Varchar2).Value = mail1_txt.Text + "@" + mail2_txt.SelectedItem.ToString();
                d.Parameters.Add("F1", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                OracleDataAdapter adapter = new OracleDataAdapter();
                adapter.SelectCommand = d;
                DataTable tablo2 = new DataTable();
                adapter.Fill(tablo2);
                kullanıcılar_data.DataSource = tablo2;
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
                d.Parameters.Add("X1", OracleDbType.Varchar2).Value = kullanıcıadı_txt.Text;
                d.Parameters.Add("X2", OracleDbType.Varchar2).Value = sifre_txt.Text;
                d.Parameters.Add("X3", OracleDbType.Varchar2).Value = type_txt.SelectedItem.ToString();
                d.Parameters.Add("X4", OracleDbType.Varchar2).Value = adsoyad_txt.Text;
                d.Parameters.Add("X5", OracleDbType.Varchar2).Value = "EXISTS";
                d.Parameters.Add("X6", OracleDbType.Varchar2).Value = mail1_txt.Text + "@" + mail2_txt.SelectedItem.ToString();
                d.Parameters.Add("F1", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                OracleDataAdapter adapter = new OracleDataAdapter();
                adapter.SelectCommand = d;
                DataTable tablo2 = new DataTable();
                adapter.Fill(tablo2);
                kullanıcılar_data.DataSource = tablo2;
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

                d.Parameters.Add("X1", OracleDbType.Varchar2).Value = kullanıcıadı_txt.Text;
                d.Parameters.Add("X2", OracleDbType.Varchar2).Value = sifre_txt.Text;
                d.Parameters.Add("X3", OracleDbType.Varchar2).Value = type_txt.SelectedItem.ToString();
                d.Parameters.Add("X4", OracleDbType.Varchar2).Value = adsoyad_txt.Text;
                d.Parameters.Add("X5", OracleDbType.Varchar2).Value = "INSERT";
                d.Parameters.Add("X6", OracleDbType.Varchar2).Value = mail1_txt.Text + "@" + mail2_txt.SelectedItem.ToString();
                d.Parameters.Add("F1", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                d.ExecuteNonQuery();

                connection.Close();

            }
            else
            {
                MessageBox.Show("Bu Kullanıcı  bilgileri bulunmaktadır... ");
            }

            kullanıcı_select();

        }

        public void kullanıcı_guncelle()
        {
            if (!kullanıcı_exist())
            {
                connection.Open();
                OracleCommand d = new OracleCommand("KULLANICI", connection);
                d.CommandType = System.Data.CommandType.StoredProcedure;
                d.Parameters.Add("X1", OracleDbType.Varchar2).Value = kullanıcıadı_txt.Text;
                d.Parameters.Add("X2", OracleDbType.Varchar2).Value = sifre_txt.Text;
                d.Parameters.Add("X3", OracleDbType.Varchar2).Value = type_txt.SelectedItem.ToString();
                d.Parameters.Add("X4", OracleDbType.Varchar2).Value = adsoyad_txt.Text;
                d.Parameters.Add("X5", OracleDbType.Varchar2).Value = "UPDATE";
                d.Parameters.Add("X6", OracleDbType.Varchar2).Value = mail1_txt.Text + "@" + mail2_txt.SelectedItem.ToString();
                d.Parameters.Add("F1", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                d.ExecuteNonQuery();

                connection.Close();

            }
            else
            {
                MessageBox.Show("Böyle bir Kullanıcı bulunmamaktadır !!  \nFarklı bir Kullanıcı bilgisi giriniz. ");
            }

            kullanıcı_select();

        }

        public void kullanıcı_sil()
        {
            if (!kullanıcı_exist())
            {
                connection.Open();
                OracleCommand d = new OracleCommand("KULLANICI", connection);
                d.CommandType = System.Data.CommandType.StoredProcedure;
                d.Parameters.Add("X1", OracleDbType.Varchar2).Value = kullanıcıadı_txt.Text;
                d.Parameters.Add("X2", OracleDbType.Varchar2).Value = sifre_txt.Text;
                d.Parameters.Add("X3", OracleDbType.Varchar2).Value = type_txt.SelectedItem.ToString();
                d.Parameters.Add("X4", OracleDbType.Varchar2).Value = adsoyad_txt.Text;
                d.Parameters.Add("X5", OracleDbType.Varchar2).Value = "DELETE";
                d.Parameters.Add("X6", OracleDbType.Varchar2).Value = mail1_txt.Text + "@" + mail2_txt.SelectedItem.ToString();
                d.Parameters.Add("F1", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                d.ExecuteNonQuery();

                connection.Close();


            }
            else
            {
                MessageBox.Show("Böyle bir Kullanıcı bulunmamaktadır !!  \nFarklı bir Kullanıcı bilgisi giriniz. ");
            }

            kullanıcı_select();

        }

        /*

        -------------------------------------------------------------------------------------------------------------
        -------------------------------------------------------------------------------------------------------------

        */

        
        public void seans_select()
        {
            connection.Open();
            OracleCommand d = new OracleCommand("SEANS", connection);
            d.CommandType = System.Data.CommandType.StoredProcedure;
            d.Parameters.Add("X1", OracleDbType.Int64).Value = 0;
            d.Parameters.Add("X2", OracleDbType.Int64).Value = 0;
            d.Parameters.Add("X3", OracleDbType.Varchar2).Value = "";
            d.Parameters.Add("X4", OracleDbType.Varchar2).Value = "";
            d.Parameters.Add("X5", OracleDbType.Varchar2).Value = "SELECT";
            d.Parameters.Add("F1", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            OracleDataAdapter adapter = new OracleDataAdapter();
            adapter.SelectCommand = d;
            DataTable tablo2 = new DataTable();
            adapter.Fill(tablo2);
            seans_data.DataSource = tablo2;
            connection.Close();

        }
        
        public bool seans_exist(String saat)
        {
            
                connection.Open();
                OracleCommand d = new OracleCommand("SEANS", connection);
                d.CommandType = System.Data.CommandType.StoredProcedure;
                d.Parameters.Add("X1", OracleDbType.Int64).Value = int.Parse(seans_salonid_txt.Text);
                d.Parameters.Add("X2", OracleDbType.Int64).Value = int.Parse(seans_filmid_txt.Text);
                d.Parameters.Add("X3", OracleDbType.Varchar2).Value = saat;
                d.Parameters.Add("X4", OracleDbType.Varchar2).Value = seans_tarih.Value.ToString("dd/MM/yyyy");
                d.Parameters.Add("X5", OracleDbType.Varchar2).Value = "EXISTS";
                d.Parameters.Add("F1", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                OracleDataAdapter adapter = new OracleDataAdapter();
                adapter.SelectCommand = d;
                DataTable tablo2 = new DataTable();
                adapter.Fill(tablo2);
                seans_data.DataSource = tablo2;                
                connection.Close();
                int u = tablo2.Rows.Count;
                if (u > 0)
                {
                    return true;
                }
                else
                    return false;
           
        }
        
        public bool secili_seans(RadioButton a)
        {
            if (a.Checked)
            {
                return true;
            }
            else
            {
                return false;
            }

            
        } 

        public void seans_Ekle()
        {
            RadioButton []butonlar = new RadioButton[7];
            String hatalar="";
            butonlar[0] = seans9;
            butonlar[1] = seans11;
            butonlar[2] = seans13;
            butonlar[3] = seans15;
            butonlar[4] = seans17;
            butonlar[5] = seans19;
            butonlar[6] = seans21;
            //String[] saatler = { "09:00", "11:00", "13:00", "15:00", "17:00", "19:00", "21:00" };
            for(int i=0; i<7; i++)
            {
                if (secili_seans(butonlar[i]) )
                {
                    if (seans_exist(butonlar[i].Text))
                    {
                        hatalar+=butonlar[i].Text+" ";
                    }
                    else
                    {
                        connection.Open();
                        OracleCommand d = new OracleCommand("SEANS", connection);
                        d.CommandType = System.Data.CommandType.StoredProcedure;
                        d.Parameters.Add("X1", OracleDbType.Int64).Value = int.Parse(seans_salonid_txt.Text);
                        d.Parameters.Add("X2", OracleDbType.Int64).Value = int.Parse(seans_filmid_txt.Text);
                        d.Parameters.Add("X3", OracleDbType.Varchar2).Value = butonlar[i].Text;
                        d.Parameters.Add("X4", OracleDbType.Varchar2).Value = seans_tarih.Value.ToString("dd/MM/yyyy");
                        d.Parameters.Add("X5", OracleDbType.Varchar2).Value = "INSERT";
                        d.Parameters.Add("F1", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                        d.ExecuteNonQuery();
                        connection.Close();
                    }                  
                                        
                }
                
            }
            if (hatalar.Length != 0)
            {
                MessageBox.Show(hatalar + " Seansları Doludur !!!");
            }
            seans_select();

        }
            
        public void seans_sil1()
        {
            
                connection.Open();
                OracleCommand d = new OracleCommand("SEANS", connection);
                d.CommandType = System.Data.CommandType.StoredProcedure;
                d.Parameters.Add("X1", OracleDbType.Int64).Value = int.Parse(seans_salonid_txt.Text);
                d.Parameters.Add("X2", OracleDbType.Int64).Value = int.Parse(seans_filmid_txt.Text);                
                if(seans9.Checked) d.Parameters.Add("X3", OracleDbType.Varchar2).Value = seans9.Text;
                else if (seans11.Checked) d.Parameters.Add("X3", OracleDbType.Varchar2).Value = seans11.Text;
                else if (seans13.Checked) d.Parameters.Add("X3", OracleDbType.Varchar2).Value = seans13.Text;
                else if (seans15.Checked) d.Parameters.Add("X3", OracleDbType.Varchar2).Value = seans15.Text;
                else if (seans17.Checked) d.Parameters.Add("X3", OracleDbType.Varchar2).Value = seans17.Text;
                else if (seans19.Checked) d.Parameters.Add("X3", OracleDbType.Varchar2).Value = seans19.Text;
                else  d.Parameters.Add("X3", OracleDbType.Varchar2).Value = seans21.Text;

                d.Parameters.Add("X4", OracleDbType.Varchar2).Value = seans_tarih.Value.ToString("dd/MM/yyyy");
                d.Parameters.Add("X5", OracleDbType.Varchar2).Value = "DELETE";
                d.Parameters.Add("F1", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                d.ExecuteNonQuery();

                connection.Close();


            

            seans_select();

        }        

        public void seans_sil_ast()
        {
            connection.Open();
            OracleCommand d = new OracleCommand("SEANS", connection);
            d.CommandType = System.Data.CommandType.StoredProcedure;
            d.Parameters.Add("X1", OracleDbType.Int64).Value = 0;
            d.Parameters.Add("X2", OracleDbType.Int64).Value = int.Parse(seans_filmid_txt.Text);
            d.Parameters.Add("X3", OracleDbType.Varchar2).Value = " ";
            d.Parameters.Add("X4", OracleDbType.Varchar2).Value = " ";
            d.Parameters.Add("X5", OracleDbType.Varchar2).Value = "SSELECT";
            d.Parameters.Add("F1", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            OracleDataAdapter adapter = new OracleDataAdapter();
            adapter.SelectCommand = d;
            DataTable tablo2 = new DataTable();
            adapter.Fill(tablo2);
            special_data.DataSource = tablo2;
            seans_filmadi_txt.Text = special_data.Rows[0].Cells[0].Value.ToString();
            seans_afis.ImageLocation= special_data.Rows[0].Cells[1].Value.ToString();
            connection.Close();
            
            
        }

        /*

        -------------------------------------------------------------------------------------------------------------
        -------------------------------------------------------------------------------------------------------------

        */
        private void Form2_Load(object sender, EventArgs e)
        {
            seans_tarih.Text= DateTime.Now.Day.ToString()+ "." +DateTime.Now.Month.ToString()+"."+ DateTime.Now.Year.ToString();
            //seans_tarih.MinDate = DateTime.Now ;
            label34.Text = (admin_adi_text);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

            grs.Show();
            grs.Close();
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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            film_temizle_btn.PerformClick();
            yiyecek_temizle_btn.PerformClick();
            seans_temizle.PerformClick();
            button3.PerformClick();
            SalonPanel.Visible = true;
            FilmPanel.Visible = false;
            YiyecekPanel.Visible = false;
            KullanıcılarPanel.Visible = false;
            SeansPanel.Visible = false;
            salon_select();
            
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            kyt.ShowDialog();
        }

        private void Salon_Data_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Salon_Ekle_Click(object sender, EventArgs e)
        {
            salon_ekle();            
            
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

        private void Salon_Güncelleme_Click(object sender, EventArgs e)
        {
            salon_guncelle();
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            salon_sil();
        }

        private void salon_salonNo_txt_KeyPress(object sender, KeyPressEventArgs e)
        {
           
            
        }

        private void salon_salonNo_txt_KeyPress_1(object sender, KeyPressEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void salon_salonNo_txt_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            afis_pic.ImageLocation=openFileDialog1.FileName;
        }

        private void fılm_fılmıd_txt_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            film_Ekle();
            film_temizle_btn.PerformClick();
        }

        private void Film_Yönetim_Click(object sender, EventArgs e)
        {
            yiyecek_temizle_btn.PerformClick();
            seans_temizle.PerformClick();
            button3.PerformClick();
            salon_temizle.PerformClick();
            kategori_doldur();
            SalonPanel.Visible = false;
            YiyecekPanel.Visible = false;
            FilmPanel.Visible = true;
            KullanıcılarPanel.Visible = false;
            SeansPanel.Visible = false;
                        
            film_select();
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            film_sil();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            film_guncelle();
        }

        private void Film_Data_Click(object sender, EventArgs e)
        {

        }

        private void Film_Data_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {

                DataGridViewRow row = this.Film_Data.Rows[e.RowIndex];
                film_filmid_txt.Text = row.Cells[0].Value.ToString();
                film_filmisim_txt.Text = row.Cells[1].Value.ToString();
                film_kategori_txt.Text = row.Cells[2].Value.ToString();
                film_etiket_txt.Text = row.Cells[3].Value.ToString();
                film_format_txt.Text = row.Cells[4].Value.ToString();
                film_dil_txt.Text = row.Cells[5].Value.ToString();
                film_özet_txt.Text = row.Cells[6].Value.ToString();
                film_imdb_txt.Text = row.Cells[7].Value.ToString();
                afis_pic.ImageLocation= row.Cells[8].Value.ToString();
            }
        }

        private void Salon_Data_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {

                DataGridViewRow row = this.Salon_Data.Rows[e.RowIndex];
                salon_salonNo_txt.Text = row.Cells[0].Value.ToString();
                salon_kapasite_txt.Text = row.Cells[1].Value.ToString();
                
            }
        }

        private void afis_pic_Click(object sender, EventArgs e)
        {

        }

        private void film_temizle_btn_Click(object sender, EventArgs e)
        {
            film_filmid_txt.Text = "";
            film_filmisim_txt.Text = " ";
            film_kategori_txt.SelectedItem = null;
            film_etiket_txt.SelectedItem = null;
            film_format_txt.SelectedItem = null;
            film_dil_txt.SelectedItem = null;
            film_özet_txt.Text = " ";
            film_imdb_txt.Text = " ";
            afis_pic.ImageLocation = "";
            kategori_doldur();
        }

        private void yiyecek_data_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void FilmPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Yiyecek_Yönetim_Click(object sender, EventArgs e)
        {
            film_temizle_btn.PerformClick();
            seans_temizle.PerformClick();
            button3.PerformClick();
            salon_temizle.PerformClick();
            SalonPanel.Visible = false;
            FilmPanel.Visible = false;
            YiyecekPanel.Visible = true;
            KullanıcılarPanel.Visible = false;
            SeansPanel.Visible = false;            
            yiyecek_select();
        }

        private void film_etiket_txt_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            urunid_txt.Text = "";
            urunadi_txt.Text = "";
            urunfiyati_txt.Text = "";
            urun_kurus_txt.Text = "";
            uruntype_txt.SelectedItem = null;
            urun_pic.ImageLocation = "";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            openFileDialog2.ShowDialog();
            urun_pic.ImageLocation = openFileDialog2.FileName;
        }

        private void yiyecek_data_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.yiyecek_data.Rows[e.RowIndex];
                String fiyat = row.Cells[2].Value.ToString();      
                
                urunid_txt.Text = row.Cells[0].Value.ToString();
                urunadi_txt.Text = row.Cells[1].Value.ToString();
                urunfiyati_txt.Text = fiyat.Substring(0, (fiyat.Length - 3));
                urun_kurus_txt.Text = fiyat.Substring(fiyat.Length - 2, 2);
                uruntype_txt.Text = row.Cells[3].Value.ToString();                
                urun_pic.ImageLocation = row.Cells[4].Value.ToString();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            yiyecek_Ekle();
            yiyecek_temizle_btn.PerformClick();
            
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            yiyecek_guncelle();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            yiyecek_sil();
        }

        private void SalonPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Seans_Yönetim_Click(object sender, EventArgs e)
        {
            film_temizle_btn.PerformClick();
            yiyecek_temizle_btn.PerformClick();
            button3.PerformClick();
            salon_temizle.PerformClick();
            salon_select();
            film_select();
            seans_select();
            SalonPanel.Visible = false;
            FilmPanel.Visible = false;
            YiyecekPanel.Visible = false;
            KullanıcılarPanel.Visible = false;
            SeansPanel.Visible = true;
            
        }

        private void pictureBox2_Click_1(object sender, EventArgs e)

        {
            film_temizle_btn.PerformClick();
            yiyecek_temizle_btn.PerformClick();
            seans_temizle.PerformClick();
            salon_temizle.PerformClick();
            SalonPanel.Visible = false;
            FilmPanel.Visible = false;
            YiyecekPanel.Visible = false;
            KullanıcılarPanel.Visible = true;
            SeansPanel.Visible = false;
            
            kullanıcı_select();

        }

        private void button10_Click(object sender, EventArgs e)
        {
            kullanıcı_Ekle();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            kullanıcı_guncelle();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            kullanıcı_sil();
        }

        private void button3_Click_2(object sender, EventArgs e)
        {
            kullanıcıadı_txt.Text = "";
            sifre_txt.Text = "";
            type_txt.SelectedItem = null;
            adsoyad_txt.Text = "";
            mail1_txt.Text = "";
            mail2_txt.SelectedItem = null;
        }

        private void kullanıcılar_data_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.kullanıcılar_data.Rows[e.RowIndex];
                String e_mailstring = row.Cells[4].Value.ToString(); ;
                Char[] e_mailchar = new Char[e_mailstring.Length];
                e_mailchar = e_mailstring.ToCharArray();
                int whereat = 0;
                for (int i = 0; i < e_mailstring.Length; i++)
                {
                    if (e_mailchar[i] == '@') whereat = i;
                }
                string onceat = e_mailstring.Substring(0, whereat);
                string sonraat = e_mailstring.Substring(whereat + 1, e_mailstring.Length - whereat - 1);
                 
                kullanıcıadı_txt.Text = row.Cells[0].Value.ToString();
                sifre_txt.Text = row.Cells[1].Value.ToString();
                type_txt.Text = row.Cells[2].Value.ToString();
                adsoyad_txt.Text = row.Cells[3].Value.ToString();
                mail1_txt.Text= onceat;
                mail2_txt.Text = sonraat;
                

            }
        }

        private void seans_salon_data_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.seans_salon_data.Rows[e.RowIndex];
                seans_salonid_txt.Text = row.Cells[0].Value.ToString();
                salon_tıklandı = true;
            }
            if (film_tıklandı && salon_tıklandı)
            {
                seans9.Enabled = Enabled;
                seans11.Enabled = Enabled;
                seans13.Enabled = Enabled;
                seans15.Enabled = Enabled;
                seans17.Enabled = Enabled;
                seans19.Enabled = Enabled;
                seans21.Enabled = Enabled;

            }
        }

        private void seans_film_data_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.seans_film_data.Rows[e.RowIndex];
                seans_filmid_txt.Text = row.Cells[0].Value.ToString();
                seans_filmadi_txt.Text = row.Cells[1].Value.ToString();
                seans_afis.ImageLocation = row.Cells[8].Value.ToString();
                film_tıklandı = true;
            }
            if (film_tıklandı && salon_tıklandı)
            {
                seans9.Enabled = Enabled;
                seans11.Enabled = Enabled;
                seans13.Enabled = Enabled;
                seans15.Enabled = Enabled;
                seans17.Enabled = Enabled;
                seans19.Enabled = Enabled;
                seans21.Enabled = Enabled;

            }
        }

        bool secildi = false;
                   
        private void seans9_CheckedChanged(object sender, EventArgs e)
        {
            secildi = seans9.Checked;
        }

        private void seans9_Click(object sender, EventArgs e)
        {
            if (seans9.Checked && !secildi)
            {
                seans9.Checked = false;
            }
            else
            {
                seans9.Checked = true;
                secildi = false;
            }
        }
        private void seans11_CheckedChanged(object sender, EventArgs e)
        {
            secildi = seans11.Checked;
        }
        private void seans11_Click(object sender, EventArgs e)
        {
            if (seans11.Checked && !secildi)
            {
                seans11.Checked = false;
            }
            else
            {
                seans11.Checked = true;
                secildi = false;
            }
        }        
        
        private void seans_sil_Click(object sender, EventArgs e)
        {
            seans_sil1();
        }

        private void seans13_CheckedChanged(object sender, EventArgs e)
        {
            secildi = seans13.Checked;
        }

        private void seans13_Click(object sender, EventArgs e)
        {
            
            if (seans13.Checked && !secildi)
            {
                seans13.Checked = false;
            }
            else
            {
                seans13.Checked = true;
                secildi = false;
            }
        }

        private void seans15_CheckedChanged(object sender, EventArgs e)
        {
            secildi = seans15.Checked;
        }

        private void seans15_Click(object sender, EventArgs e)
        {
            if (seans15.Checked && !secildi)
            {
                seans15.Checked = false;
            }
            else
            {
                seans15.Checked = true;
                secildi = false;
            }
        }

        private void seans17_CheckedChanged(object sender, EventArgs e)
        {
            secildi = seans17.Checked;
        }

        private void seans17_Click(object sender, EventArgs e)
        {
            if (seans17.Checked && !secildi)
            {
                seans17.Checked = false;
            }
            else
            {
                seans17.Checked = true;
                secildi = false;
            }
        }

        private void seans19_CheckedChanged(object sender, EventArgs e)
        {
            secildi = seans19.Checked;
        }

        private void seans19_Click(object sender, EventArgs e)
        {
            if (seans19.Checked && !secildi)
            {
                seans19.Checked = false;
            }
            else
            {
                seans19.Checked = true;
                secildi = false;
            }
        }

        private void seans21_CheckedChanged(object sender, EventArgs e)
        {
            secildi = seans21.Checked;
        }

        private void seans21_Click(object sender, EventArgs e)
        {
            if (seans21.Checked && !secildi)
            {
                seans21.Checked = false;
            }
            else
            {
                seans21.Checked = true;
                secildi = false;
            }
        }

        private void seans_data_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            seans_temizle.PerformClick();
            if (e.RowIndex >= 0)
            {                          
                DataGridViewRow row = this.seans_data.Rows[e.RowIndex];
                if (row.Cells[2].Value.ToString()=="09:00") seans9.Checked = true;
                else if (row.Cells[2].Value.ToString() == "11:00") seans11.Checked = true;
                else if (row.Cells[2].Value.ToString() == "13:00") seans13.Checked = true;
                else if (row.Cells[2].Value.ToString() == "15:00") seans15.Checked = true;
                else if (row.Cells[2].Value.ToString() == "17:00") seans17.Checked = true;
                else if (row.Cells[2].Value.ToString() == "19:00") seans19.Checked = true;
                else if (row.Cells[2].Value.ToString() == "21:00") seans21.Checked = true;                

                seans_salonid_txt.Text = row.Cells[0].Value.ToString();
                seans_filmid_txt.Text = row.Cells[1].Value.ToString();
                seans_tarih.Text= row.Cells[3].Value.ToString();

            }
            seans_sil_ast();
        }

        private void salon_temizle_Click(object sender, EventArgs e)
        {
            salon_salonNo_txt.Text = "";
            salon_kapasite_txt.Text = "";
        }

        /*

        -------------------------------------------------------------------------------------------------------------
        -------------------------------------------------------------------------------------------------------------

        */

        public bool kategori_exists()
        {
            if (comboBox1.Text=="")
            {
                MessageBox.Show("Kategori Boş Bırakılamaz !!");
                return false;
            }
            else
            {
                OracleConnection connection2 = new OracleConnection("User Id=SYSTEM;Password=5092010berk;Data Source=localhost:1521/XEPDB1;");
                connection2.Open();
                OracleCommand d = new OracleCommand("KATEGORI", connection2);
                d.CommandType = System.Data.CommandType.StoredProcedure;
                d.Parameters.Add("X1", OracleDbType.Varchar2).Value = comboBox1.Text;
                d.Parameters.Add("X2", OracleDbType.Varchar2).Value = "EXISTS";
                d.Parameters.Add("F1", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                OracleDataAdapter adapter = new OracleDataAdapter();
                adapter.SelectCommand = d;
                DataTable tablo2 = new DataTable();
                adapter.Fill(tablo2);
                connection2.Close();
                int a = tablo2.Rows.Count;                
                if (a > 0)
                {
                    return true;
                }
                else 
                return false;
                
            }
            


        }

        public void kategori_ekle()
        {
            if (comboBox1.Text == "")
            {
                MessageBox.Show("Kategori Boş Bırakılamaz !!");

            }
            else if(kategori_exists()==false)
            {                
                connection.Open();
                OracleCommand d = new OracleCommand("KATEGORI", connection);
                d.CommandType = System.Data.CommandType.StoredProcedure;
                d.Parameters.Add("X1", OracleDbType.Varchar2).Value = comboBox1.Text;
                d.Parameters.Add("X2", OracleDbType.Varchar2).Value = "INSERT";
                d.Parameters.Add("F1", OracleDbType.RefCursor).Direction = ParameterDirection.Output;              
                d.ExecuteNonQuery();
                connection.Close();
            }
        }

        public void kategori_sil()
        {
            if (comboBox1.Text == "")
            {
                MessageBox.Show("Kategori Boş Bırakılamaz !!");

            }
            else if (kategori_exists() == true)
            {
                connection.Open();
                OracleCommand d = new OracleCommand("KATEGORI", connection);
                d.CommandType = System.Data.CommandType.StoredProcedure;
                d.Parameters.Add("X1", OracleDbType.Varchar2).Value = comboBox1.Text;
                d.Parameters.Add("X2", OracleDbType.Varchar2).Value = "DELETE";
                d.Parameters.Add("F1", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                d.ExecuteNonQuery();
                connection.Close();
            }
        }

        public void kategori_doldur()
        {
            connection.Open();
            OracleCommand d = new OracleCommand("KATEGORI", connection);
            d.CommandType = System.Data.CommandType.StoredProcedure;
            d.Parameters.Add("X1", OracleDbType.Varchar2).Value = comboBox1.Text;
            d.Parameters.Add("X2", OracleDbType.Varchar2).Value = "COUNT";
            d.Parameters.Add("F1", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            OracleDataAdapter adapter = new OracleDataAdapter();
            adapter.SelectCommand = d;
            DataTable tablo2 = new DataTable();
            adapter.Fill(tablo2);            
            int a = tablo2.Rows.Count;
            connection.Close();
            comboBox1.Text = "";
            comboBox1.Items.Clear();
            film_kategori_txt.Items.Clear();
            for (int i =0; i<a ;i++)
            {
                comboBox1.Items.Add(tablo2.Rows[i].ItemArray[0]);
                film_kategori_txt.Items.Add(tablo2.Rows[i].ItemArray[0]);
            }

        }

        /*

        -------------------------------------------------------------------------------------------------------------
        -------------------------------------------------------------------------------------------------------------

        */
        private void button11_Click(object sender, EventArgs e)
        {
            kategori_ekle();
            kategori_doldur();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            kategori_sil();
            kategori_doldur();
        }

        private void seans_ekle_Click(object sender, EventArgs e)
        {
            seans_Ekle();
        }

        private void seans_temizle_Click(object sender, EventArgs e)
        {
            seans_salonid_txt.Text = "";
            seans_filmid_txt.Text = "";
            seans_filmadi_txt.Text = "";
            seans_afis.ImageLocation = "";

            salon_tıklandı = false;
            film_tıklandı = false;
           
            seans9.Enabled = false;
            seans11.Enabled = false;
            seans13.Enabled = false;
            seans15.Enabled = false;
            seans17.Enabled = false;
            seans19.Enabled = false;
            seans21.Enabled = false;
            seans9.Checked = false;
            seans11.Checked = false;
            seans13.Checked = false;
            seans15.Checked = false;
            seans17.Checked = false;
            seans19.Checked = false;
            seans21.Checked = false;

        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            MouseM = false;
        }
    }
}
