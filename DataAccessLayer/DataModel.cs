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
                        if (!reader.IsDBNull(4))
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
                while (reader.Read())
                {
                    p = new Product()
                    {
                        Id = reader.GetInt32(0),
                        Barcode = reader.GetString(1),
                        ProductCode = reader.GetInt32(2),
                        CastDate = reader.GetDateTime(3),
                        CastPersonel = reader.GetInt32(4),
                        GlazingTerritory = reader.GetByte(5),
                        Quality = reader.GetByte(6),
                        Foult = reader.GetByte(7),
                        ControlDate = reader.GetDateTime(8),
                        ControlPersonel = reader.GetString(9),
                        Kiln = reader.GetByte(10),
                        Fring = reader.GetByte(11),
                        Color = reader.GetByte(12),
                        StockTerritory = reader.GetByte(13),
                        ControlTime = reader.GetDateTime(14)
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
            catch (Exception)
            {
                return false;
            }
            finally
            {
                con.Close();
            }
        }
        public List<DepoGiris> DepogirisListReader(byte sicil)
        {
            DateTime date = DateTime.Now.Date;
            List<DepoGiris> girisler = new List<DepoGiris>();
            try
            {
                cmd.CommandText = "SELECT D.Id, D.Barkod, D.Sicil , D.KayitTarih, D.Hata_Id, K.tanim  FROM DepoGiris AS D JOIN Products AS P ON P.Id=D.Product_ID JOIN kod_liste AS K ON P.ProductCode = K.Kimlik WHERE D.Sicil=@sicil AND D.KayitTarih  BETWEEN @bugununtarihi AND @ertisigüntarihi  ";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@sicil", sicil);
                cmd.Parameters.AddWithValue("@bugununtarihi", date);
                cmd.Parameters.AddWithValue("@ertisigüntarihi ", DateTime.Today.AddDays(1));
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DepoGiris dg = new DepoGiris();
                    dg.Id = reader.GetInt32(0);
                    dg.Barkod = reader.GetString(1);
                    dg.Sicil = reader.GetByte(2);
                    dg.KayitTarih = reader.GetDateTime(3);
                    dg.Hata_Id = reader.GetByte(4);
                    dg.UrunKodu = reader.GetString(5);
                    girisler.Add(dg);
                }
                return girisler;
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

        public List<DepoGiris> DepogirisListReader()
        {
            List<DepoGiris> girisler = new List<DepoGiris>();
            try
            {
                cmd.CommandText = "SELECT D.Id, D.Barkod, D.Sicil , D.KayitTarih, D.Hata_Id, K.tanim  FROM DepoGiris AS D JOIN Products AS P ON P.Id=D.Product_ID JOIN kod_liste AS K ON P.ProductCode = K.Kimlik  ";
                cmd.Parameters.Clear();

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DepoGiris dg = new DepoGiris();
                    dg.Id = reader.GetInt32(0);
                    dg.Barkod = reader.GetString(1);
                    dg.Sicil = reader.GetByte(2);
                    dg.KayitTarih = reader.GetDateTime(3);
                    dg.Hata_Id = reader.GetByte(4);
                    dg.UrunKodu = reader.GetString(5);
                    girisler.Add(dg);
                }
                return girisler;
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
        public List<DepoGiris> DepogirisListReader(string urunkodu)
        {
            List<DepoGiris> girisler = new List<DepoGiris>();
            try
            {
                cmd.CommandText = "SELECT D.Id, D.Barkod, D.Sicil , D.KayitTarih, D.Hata_Id, K.tanim  FROM DepoGiris AS D JOIN Products AS P ON P.Id=D.Product_ID JOIN kod_liste AS K ON P.ProductCode = K.Kimlik WHERE K.tanim=@tanim  ";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@tanim", urunkodu);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DepoGiris dg = new DepoGiris();
                    dg.Id = reader.GetInt32(0);
                    dg.Barkod = reader.GetString(1);
                    dg.Sicil = reader.GetByte(2);
                    dg.KayitTarih = reader.GetDateTime(3);
                    dg.Hata_Id = reader.GetByte(4);
                    dg.UrunKodu = reader.GetString(5);
                    girisler.Add(dg);
                }
                return girisler;
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
        public List<DepoGiris> DepogirisListReaderSicilAra(byte sicil)
        {
            List<DepoGiris> girisler = new List<DepoGiris>();
            try
            {
                cmd.CommandText = "SELECT D.Id, D.Barkod, D.Sicil , D.KayitTarih, D.Hata_Id, K.tanim  FROM DepoGiris AS D JOIN Products AS P ON P.Id=D.Product_ID JOIN kod_liste AS K ON P.ProductCode = K.Kimlik WHERE D.Sicil=@sicil ";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@sicil", sicil);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DepoGiris dg = new DepoGiris();
                    dg.Id = reader.GetInt32(0);
                    dg.Barkod = reader.GetString(1);
                    dg.Sicil = reader.GetByte(2);
                    dg.KayitTarih = reader.GetDateTime(3);
                    dg.Hata_Id = reader.GetByte(4);
                    dg.UrunKodu = reader.GetString(5);
                    girisler.Add(dg);
                }
                return girisler;
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
        public List<DepoGiris> DepogirisListReader(DateTime baslangic, DateTime bitis)
        {
            List<DepoGiris> girisler = new List<DepoGiris>();
            try
            {
                cmd.CommandText = "SELECT D.Id, D.Barkod, D.Sicil , D.KayitTarih, D.Hata_Id, K.tanim  FROM DepoGiris AS D JOIN Products AS P ON P.Id=D.Product_ID JOIN kod_liste AS K ON P.ProductCode = K.Kimlik WHERE D.KayitTarih  BETWEEN @bugununtarihi AND @ertisigüntarihi  ";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@bugununtarihi", baslangic);
                cmd.Parameters.AddWithValue("@ertisigüntarihi", bitis);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DepoGiris dg = new DepoGiris();
                    dg.Id = reader.GetInt32(0);
                    dg.Barkod = reader.GetString(1);
                    dg.Sicil = reader.GetByte(2);
                    dg.KayitTarih = reader.GetDateTime(3);
                    dg.Hata_Id = reader.GetByte(4);
                    dg.UrunKodu = reader.GetString(5);
                    girisler.Add(dg);
                }
                return girisler;
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
        #region Musteri Metotları
        public List<Musteri> MusteriListele()
        {
            List<Musteri> musteriler = new List<Musteri>();
            try
            {
                cmd.CommandText = "SELECT ID,Isim FROM Musteriler";
                cmd.Parameters.Clear();
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while(reader.Read())
                {
                    musteriler.Add(new Musteri()
                    {
                        ID = reader.GetInt32(0),
                        Isim =reader.GetString(1)
                    });
                }
                return musteriler;
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
        #region Renk Metotları
        public List<Renk> RenkListele()
        {
            List<Renk> renkler = new List<Renk>();
            try
            {
                cmd.CommandText = "SELECT * FROM renk_liste";
                cmd.Parameters.Clear();
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    renkler.Add(new Renk()
                    {
                        Kimlik = reader.GetByte(0),
                        renkad = reader.GetString(1)
                    });
                }
                return renkler;
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
        #region KaliteTipi Metotları
        public List<KaliteTipi> KaliteTipiListele()
        {
            List<KaliteTipi> kaliteTipleri = new List<KaliteTipi>();
            try
            {
                cmd.CommandText = "SELECT Kimlik,kaliteAd FROM kalite_liste";
                cmd.Parameters.Clear();
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while(reader.Read())
                {
                    kaliteTipleri.Add(new KaliteTipi()
                    {
                        Kimlik = reader.GetByte(0),
                        kaliteAd = reader.GetString(1)
                    });
                }
                return kaliteTipleri;
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
        #region Ürün kod metotları
        public List<UrunKod> UrunKodListele()
        {
            List<UrunKod> urunKodlar = new List<UrunKod>();
            try
            {
                cmd.CommandText = "SELECT Kimlik,tanim FROM kod_liste";
                cmd.Parameters.Clear();
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    urunKodlar.Add(new UrunKod()
                    {
                        Kimlik = reader.GetInt32(0),
                        tanim = reader.GetString(1)
                    });
                }
                return urunKodlar;
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
    }
}
