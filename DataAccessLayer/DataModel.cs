using DataAccessLayer.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class DataModel
    {
        SqlConnection con; SqlCommand cmd;

        public DataModel()
        {
            con = new SqlConnection(ConnectionStrings.ConStrTest);
            cmd = con.CreateCommand();
        }
        #region Kullanici Metotları
        public kullanici_listeLogin KullaniciGiris(string kullaniciadi, string sifre)
        {
            try
            {
                kullanici_listeLogin k = new kullanici_listeLogin();
                cmd.CommandText = "SELECT COUNT(*) FROM kullanici_liste WHERE kullanici_adi=@kullanici_adi AND sifre=@sifre ";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@kullanici_adi", kullaniciadi);
                cmd.Parameters.AddWithValue("@sifre", sifre);
                con.Open();
                int sayi = Convert.ToInt32(cmd.ExecuteScalar());
                if (sayi != 0)
                {
                    cmd.CommandText = "SELECT Kimlik,kullanici_adi,sifre,ad_soyad,departman FROM kullanici_liste WHERE kullanici_adi=@kullanici_adi AND sifre=@sifre ";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@kullanici_adi", kullaniciadi);
                    cmd.Parameters.AddWithValue("@sifre", sifre);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        k.Kimlik = reader.GetByte(0);
                        k.kullanici_adi = reader.GetString(1);
                        k.sifre = reader.GetString(2);
                        k.ad_soyad = reader.GetString(3);
                        if (!reader.IsDBNull (4))
                        {
                            k.Departman = reader.GetString(4);
                        }
                        else
                        {
                            k.Departman = "";
                        }
                    }
                }
                return k;
            }
            catch (Exception)
            {

                return null;
            }
            finally
            {
                con.Close();
            }
        }
        #endregion
        #region Product Metotları
        public void BarkodNoGöreProductBul(string barkodno)
        {
            List<Product> products = new List<Product>();
            try
            {
                cmd.CommandText = "SELECT * FROM Products WHERE Barcode=@barcode";
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion
    }
}
