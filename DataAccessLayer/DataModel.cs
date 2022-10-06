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
        public Product BarkodNoGöreProductBul(string barkodno)
        {
            Product p = new Product();
            try
            {
                cmd.CommandText = "SELECT Id,Barcode,ProductCode,CastDate,CastPersonal,GlazingTerritory,Quality,Fault,ControlDate,ControlPersonal,Kiln,Firing,Color,StockTerritory,ControlDate FROM Products WHERE Barcode=@barcode";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@barcode", barkodno);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while(reader.Read())
                {
                    p= new Product()
                    {
                        Id = reader.GetInt32(0),
                        Barcode = reader.GetString(1),
                        ProductCode = reader.GetInt32(2),
                        CastDate = reader.GetDateTime(3),
                        CastPersonel= reader.GetInt32(4),
                        GlazingTerritory=reader.GetByte(5),
                        Quality= reader.GetByte(6),
                        Foult=reader.GetByte(7),
                        ControlDate = reader.GetDateTime(8),
                        ControlPersonel=reader.GetString(9),
                        Kiln=reader.GetByte(10),    
                        Fring = reader.GetByte(11),
                        Color=reader.GetByte(12),
                        StockTerritory=reader.GetByte(13),
                        ControlTime= reader.GetDateTime(14)
                    };
                }
                return p;
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
        #region Hata metotları
        public List<Hata> HataListesi()
        {
            List<Hata> hatalar = new List<Hata>();
            try
            {
                cmd.CommandText = "SELECT Kimlik,tanim FROM hata_liste";
                cmd.Parameters.Clear();
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    hatalar.Add(new Hata()
                    {
                        Kimlik = reader.GetByte(0),
                        tanim = reader.GetString(1)
                    });
                }
                    return hatalar;
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
        #region DepoGiris Metotları
        public bool DepoGirisEkle(DepoGiris model)
        {
            try
            {
                cmd.CommandText = "INSERT INTO DepoGiris(Barkod,Sicil,KayitTarih,Product_ID,Hata_Id,BolumNo) VALUES(@barkod,@sicil,@kayittarih,@product_id,@hata_id,0)";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@barkod", model.Barkod);
                cmd.Parameters.AddWithValue("@sicil", model.Sicil);
                cmd.Parameters.AddWithValue("@kayittarih", model.KayitTarih);
                cmd.Parameters.AddWithValue("@product_id", model.Product_ID);
                cmd.Parameters.AddWithValue("@hata_id", model.Hata_Id);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch(Exception)
            {
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        #endregion
    }
}
