using DataAccessLayer.Model;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Policy;
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
        public List<kullanici_listeLogin> KullaniciReader()
        {
            List<kullanici_listeLogin> kullanicilar = new List<kullanici_listeLogin>();
            try
            {
                cmd.CommandText = "SELECT Kimlik, kullanici_adi FROM kullanici_liste";
                cmd.Parameters.Clear();
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    kullanicilar.Add(new kullanici_listeLogin()
                    {
                        Kimlik = reader.GetByte(0),
                        kullanici_adi = reader.GetString(1)
                    });
                }
                return kullanicilar;
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
                cmd.CommandText = "INSERT INTO DepoGiris(Barkod,Sicil,KayitTarih,Product_ID,Durum) VALUES(@barkod,@sicil,@kayittarih,@product_id,1)";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@barkod", model.Barkod);
                cmd.Parameters.AddWithValue("@sicil", model.Sicil);
                cmd.Parameters.AddWithValue("@kayittarih", model.KayitTarih);
                cmd.Parameters.AddWithValue("@product_id", model.Product_ID);
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
                cmd.CommandText = "SELECT D.Id, D.Barkod, D.Sicil ,KU.kullanici_adi, D.KayitTarih, P.Fault, H.numara, H.tanim, P.ProductCode, K.tanim, K.aciklama, P.Color, R.renkad, P.Quality, KA.kaliteAd FROM DepoGiris AS D JOIN Products AS P ON P.Id=D.Product_ID JOIN renk_liste AS R ON P.Color =R.Kimlik JOIN hata_liste AS H ON P.Fault= H.Kimlik JOIN kod_liste AS K ON P.ProductCode = K.Kimlik JOIN kalite_liste AS KA ON P.Quality = KA.Kimlik JOIN kullanici_liste AS KU ON KU.Kimlik = D.Sicil  WHERE D.Sicil=@sicil AND  D.Durum=1 AND D.KayitTarih  BETWEEN @bugununtarihi AND @ertisigüntarihi   ";
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
                    dg.Kullanici_Isim = reader.GetString(3);
                    dg.KayitTarih = reader.GetDateTime(4);
                    dg.KaliteHata_Id = reader.GetByte(5);
                    dg.KaliteHata_Kod = reader.GetInt16(6);
                    dg.KaliteHata_Isim = reader.GetString(7);
                    dg.Urun_ID = reader.GetInt32(8);
                    dg.UrunKodu = reader.GetString(9);
                    dg.UrunAciklama = reader.GetString(10);
                    dg.Renk_ID = reader.GetByte(11);
                    dg.Renk_Isim = reader.GetString(12);
                    dg.Kalite_ID = reader.GetByte(13);
                    dg.Kalite_Isim = reader.GetString(14);
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
                cmd.CommandText = "SELECT D.Id, D.Barkod, D.Sicil ,KU.kullanici_adi, D.KayitTarih, P.Fault, H.numara, H.tanim, P.ProductCode, K.tanim, K.aciklama, P.Color, R.renkad, P.Quality, KA.kaliteAd FROM DepoGiris AS D JOIN Products AS P ON P.Id=D.Product_ID JOIN renk_liste AS R ON P.Color =R.Kimlik JOIN hata_liste AS H ON P.Fault= H.Kimlik JOIN kod_liste AS K ON P.ProductCode = K.Kimlik JOIN kalite_liste AS KA ON P.Quality = KA.Kimlik JOIN kullanici_liste AS KU ON KU.Kimlik = D.Sicil WHERE D.Durum=1 ";
                cmd.Parameters.Clear();
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DepoGiris dg = new DepoGiris();
                    dg.Id = reader.GetInt32(0);
                    dg.Barkod = reader.GetString(1);
                    dg.Sicil = reader.GetByte(2);
                    dg.Kullanici_Isim = reader.GetString(3);
                    dg.KayitTarih = reader.GetDateTime(4);
                    dg.KaliteHata_Id = reader.GetByte(5);
                    dg.KaliteHata_Kod = reader.GetInt16(6);
                    dg.KaliteHata_Isim = reader.GetString(7);
                    dg.Urun_ID = reader.GetInt32(8);
                    dg.UrunKodu = reader.GetString(9);
                    dg.UrunAciklama = reader.GetString(10);
                    dg.Renk_ID = reader.GetByte(11);
                    dg.Renk_Isim = reader.GetString(12);
                    dg.Kalite_ID = reader.GetByte(13);
                    dg.Kalite_Isim = reader.GetString(14);
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
        public List<DepoGiris> DepogirisListReader(string urunkod, string kullaniciadi, string renkad, DateTime baslangictarih, DateTime bitistarih, string kaliteisim)
        {

            string parameterurunkod = (urunkod != "") ? "@urunkod" : "K.tanim";
            string parameterkullaniciadi = (kullaniciadi != "") ? "@kullanici_adi" : "KU.kullanici_adi";
            string parameterrenkad = (renkad != "") ? "@renkad" : "R.renkad";
            string parameterkaliteisim = (kaliteisim != "") ? "@kaliteisim" : "KA.kaliteAd";
            List<DepoGiris> girisler = new List<DepoGiris>();
            try
            {
                cmd.CommandText = $"SELECT D.Id, D.Barkod, D.Sicil ,KU.kullanici_adi, D.KayitTarih, P.Fault, H.numara, H.tanim, P.ProductCode, K.tanim, K.aciklama, P.Color, R.renkad, P.Quality, KA.kaliteAd FROM DepoGiris AS D JOIN Products AS P ON P.Id=D.Product_ID JOIN renk_liste AS R ON P.Color =R.Kimlik JOIN hata_liste AS H ON P.Fault= H.Kimlik JOIN kod_liste AS K ON P.ProductCode = K.Kimlik JOIN kalite_liste AS KA ON P.Quality = KA.Kimlik JOIN kullanici_liste AS KU ON KU.Kimlik = D.Sicil WHERE D.Durum=1 AND K.tanim={parameterurunkod} AND KU.kullanici_adi={parameterkullaniciadi} AND  R.renkad={parameterrenkad} AND KA.kaliteAd={parameterkaliteisim} AND D.KayitTarih  BETWEEN @baslangictarih AND @bitistarih";
                cmd.Parameters.Clear();
                if (urunkod != "")
                {
                    cmd.Parameters.AddWithValue($"{parameterurunkod}", urunkod);
                }
                if (kullaniciadi != "")
                {
                    cmd.Parameters.AddWithValue($"{parameterkullaniciadi}", kullaniciadi);
                }
                if (renkad != "")
                {
                    cmd.Parameters.AddWithValue($"{parameterrenkad}", renkad);
                }
                if (kaliteisim != "")
                {
                    cmd.Parameters.AddWithValue($"{parameterkaliteisim}", kaliteisim);
                }
                cmd.Parameters.AddWithValue("@baslangictarih", baslangictarih);
                cmd.Parameters.AddWithValue("@bitistarih", bitistarih);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DepoGiris dg = new DepoGiris();
                    dg.Id = reader.GetInt32(0);
                    dg.Barkod = reader.GetString(1);
                    dg.Sicil = reader.GetByte(2);
                    dg.Kullanici_Isim = reader.GetString(3);
                    dg.KayitTarih = reader.GetDateTime(4);
                    dg.KaliteHata_Id = reader.GetByte(5);
                    dg.KaliteHata_Kod = reader.GetInt16(6);
                    dg.KaliteHata_Isim = reader.GetString(7);
                    dg.Urun_ID = reader.GetInt32(8);
                    dg.UrunKodu = reader.GetString(9);
                    dg.UrunAciklama = reader.GetString(10);
                    dg.Renk_ID = reader.GetByte(11);
                    dg.Renk_Isim = reader.GetString(12);
                    dg.Kalite_ID = reader.GetByte(13);
                    dg.Kalite_Isim = reader.GetString(14);
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
        public DepoGiris DepoGirisGetir(string barkodno)
        {
            try
            {
                DepoGiris dg = new DepoGiris();
                cmd.CommandText = "SELECT D.Id, D.Barkod, D.Sicil ,KU.kullanici_adi, D.KayitTarih, P.Fault, H.numara, H.tanim, P.ProductCode, K.tanim, K.aciklama, P.Color, R.renkad, P.Quality, KA.kaliteAd, D.DepoPalet_ID, D.DepoStok_ID  FROM DepoGiris AS D JOIN Products AS P ON P.Id=D.Product_ID JOIN renk_liste AS R ON P.Color =R.Kimlik JOIN hata_liste AS H ON P.Fault= H.Kimlik JOIN kod_liste AS K ON P.ProductCode = K.Kimlik JOIN kalite_liste AS KA ON P.Quality = KA.Kimlik JOIN kullanici_liste AS KU ON KU.Kimlik = D.Sicil WHERE D.Durum=1 AND D.Barkod=@barkod ";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@barkod", barkodno);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    dg.Id = reader.GetInt32(0);
                    dg.Barkod = reader.GetString(1);
                    dg.Sicil = reader.GetByte(2);
                    dg.Kullanici_Isim = reader.GetString(3);
                    dg.KayitTarih = reader.GetDateTime(4);
                    dg.KaliteHata_Id = reader.GetByte(5);
                    dg.KaliteHata_Kod = reader.GetInt16(6);
                    dg.KaliteHata_Isim = reader.GetString(7);
                    dg.Urun_ID = reader.GetInt32(8);
                    dg.UrunKodu = reader.GetString(9);
                    dg.UrunAciklama = reader.GetString(10);
                    dg.Renk_ID = reader.GetByte(11);
                    dg.Renk_Isim = reader.GetString(12);
                    dg.Kalite_ID = reader.GetByte(13);
                    dg.Kalite_Isim = reader.GetString(14);
                    dg.DepoPalet_ID = reader.IsDBNull(15) ? 0 : reader.GetInt32(15);
                    dg.DepoStok_ID = reader.GetInt32(16);
                }
                return dg;
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
        public bool DepoGirisUniqBarkod(string barkod)
        {
            try
            {
                cmd.CommandText = "SELECT COUNT(*) FROM DepoGiris WHERE Barkod=@barkod";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@barkod", barkod);
                con.Open();
                int number = Convert.ToInt32(cmd.ExecuteScalar());
                if (number != 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
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
        public void DepoGirisDepoPaletIDGuncelle(List<DepoGiris> dg, int depoPaletId)
        {
            cmd.CommandText = "UPDATE DepoGiris SET DepoPalet_ID=@DepoPalet_ID WHERE ID=@id";
            con.Open();
            foreach (DepoGiris item in dg)
            {
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@DepoPalet_ID", depoPaletId);
                cmd.Parameters.AddWithValue("@id", item.Id);
                cmd.ExecuteNonQuery();
            }
            con.Close();
        }
        public void DepoGirisDepoPaletIDGuncelle(int id)
        {
            cmd.CommandText = "UPDATE DepoGiris SET DepoPalet_ID=@DepoPalet_ID WHERE ID=@id";
            con.Open();
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@DepoPalet_ID", DBNull.Value);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public List<DepoGiris> DepoGirisDepoPaletDetayGöster(int depopaletid)
        {
            try
            {
                List<DepoGiris> depoGirisler = new List<DepoGiris>();
                cmd.CommandText = "SELECT D.Id, D.Barkod, D.Sicil ,KU.kullanici_adi, D.KayitTarih, P.Fault, H.numara, H.tanim, P.ProductCode, K.tanim, K.aciklama, P.Color, R.renkad, P.Quality, KA.kaliteAd, D.DepoPalet_ID, D.DepoStok_ID  FROM DepoGiris AS D JOIN Products AS P ON P.Id=D.Product_ID JOIN renk_liste AS R ON P.Color =R.Kimlik JOIN hata_liste AS H ON P.Fault= H.Kimlik JOIN kod_liste AS K ON P.ProductCode = K.Kimlik JOIN kalite_liste AS KA ON P.Quality = KA.Kimlik JOIN kullanici_liste AS KU ON KU.Kimlik = D.Sicil WHERE D.Durum=1 AND D.DepoPalet_ID=@DepoPalet_ID ";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@DepoPalet_ID", depopaletid);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DepoGiris dg = new DepoGiris();
                    dg.Id = reader.GetInt32(0);
                    dg.Barkod = reader.GetString(1);
                    dg.Sicil = reader.GetByte(2);
                    dg.Kullanici_Isim = reader.GetString(3);
                    dg.KayitTarih = reader.GetDateTime(4);
                    dg.KaliteHata_Id = reader.GetByte(5);
                    dg.KaliteHata_Kod = reader.GetInt16(6);
                    dg.KaliteHata_Isim = reader.GetString(7);
                    dg.Urun_ID = reader.GetInt32(8);
                    dg.UrunKodu = reader.GetString(9);
                    dg.UrunAciklama = reader.GetString(10);
                    dg.Renk_ID = reader.GetByte(11);
                    dg.Renk_Isim = reader.GetString(12);
                    dg.Kalite_ID = reader.GetByte(13);
                    dg.Kalite_Isim = reader.GetString(14);
                    dg.DepoPalet_ID = reader.IsDBNull(15) ? 0 : reader.GetInt32(15);
                    dg.DepoStok_ID = reader.GetInt32(16);
                    depoGirisler.Add(dg);
                }
                return depoGirisler;
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
        public void DepoGirisGuncelle(List<DepoGiris> dg, int sevkiyatID)
        {
            cmd.CommandText = "UPDATE DepoGiris SET Durum= 0, Sevkiyat_ID=@Sevkiyat_ID WHERE Id = @id";
            con.Open();
            foreach (DepoGiris item in dg)
            {
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@Sevkiyat_ID", sevkiyatID);
                cmd.Parameters.AddWithValue("@id", item.Id);
                cmd.ExecuteNonQuery();
            }
            con.Close();
        }
        public void DepoGirisGuncelle(int depogirisid, int depohataid)
        {
            cmd.CommandText = "UPDATE DepoGiris SET Durum= 0, DepoHata_ID=@DepoHata_ID WHERE Id = @id";
            con.Open();
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@DepoHata_ID", depohataid);
            cmd.Parameters.AddWithValue("@id", depogirisid);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void DepoGirisGuncelle(string barkod, int stokid)
        {
            cmd.CommandText = "UPDATE DepoGiris Set DepoStok_ID = @DepoStok_ID WHERE barkod=@id";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@DepoStok_ID", stokid);
            cmd.Parameters.AddWithValue("@id", barkod);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
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
                while (reader.Read())
                {
                    musteriler.Add(new Musteri()
                    {
                        ID = reader.GetInt32(0),
                        Isim = reader.GetString(1)
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
        public Renk RenkGetir(byte renkid)
        {
            Renk r = new Renk();
            try
            {
                cmd.CommandText = "SELECT * FROM renk_liste WHERE Kimlik=@Kimlik";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@Kimlik", renkid);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    r = new Renk()
                    {
                        Kimlik = reader.GetByte(0),
                        renkad = reader.GetString(1)
                    };
                }
                return r;
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
                while (reader.Read())
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
        public KaliteTipi KaliteGetir(byte kaliteid)
        {
            KaliteTipi k = new KaliteTipi();
            try
            {
                cmd.CommandText = "SELECT Kimlik,kaliteAd FROM kalite_liste WHERE Kimlik=@Kimlik";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@Kimlik", kaliteid);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    k = new KaliteTipi()
                    {
                        Kimlik = reader.GetByte(0),
                        kaliteAd = reader.GetString(1)
                    };
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
        public UrunKod UrunGetir(int urunid)
        {
            UrunKod u = new UrunKod();
            try
            {
                cmd.CommandText = "SELECT Kimlik,tanim, aciklama FROM kod_liste WHERE Kimlik = @Kimlik ";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@Kimlik", urunid);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    u = new UrunKod()
                    {
                        Kimlik = reader.GetInt32(0),
                        tanim = reader.GetString(1),
                        Aciklama = reader.GetString(2)
                    };
                }
                return u;
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
        #region Sevkiyat Metotları
        public bool SevkiyatEkle(Sevkiyat model)
        {
            try
            {
                cmd.CommandText = "INSERT INTO Sevkiyatlar(Musteri_ID,SevkTarih,Kullanici_ID,Aciklama,Durum) VALUES(@Musteri_ID,@SevkTarih,@Kullanici_ID,@Aciklama,0)";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@Musteri_ID", model.Musteri_ID);
                cmd.Parameters.AddWithValue("@SevkTarih", model.SevkTarih);
                cmd.Parameters.AddWithValue("@Kullanici_ID", model.Kullanici_ID);
                cmd.Parameters.AddWithValue("@Aciklama", model.Aciklama);
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
        public List<Sevkiyat> SevkiyatListReader()
        {
            List<Sevkiyat> sevkiyatlar = new List<Sevkiyat>();
            try
            {
                cmd.CommandText = "SELECT S.ID, S.Musteri_ID, M.Isim, S.SevkTarih, S.Kullanici_ID, K.kullanici_adi, S.Aciklama FROM Sevkiyatlar AS S JOIN Musteriler AS M ON M.ID= S.Musteri_ID JOIN kullanici_liste AS K ON K.Kimlik = S.Kullanici_ID WHERE S.Durum = 0";
                cmd.Parameters.Clear();
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    sevkiyatlar.Add(new Sevkiyat()
                    {
                        ID = reader.GetInt32(0),
                        Musteri_ID = reader.GetInt32(1),
                        MusteriIsim = reader.GetString(2),
                        SevkTarih = reader.GetDateTime(3),
                        Kullanici_ID = reader.GetByte(4),
                        kullanici_adi = reader.GetString(5),
                        Aciklama = reader.IsDBNull(6) ? "" : reader.GetString(6),
                    });
                }
                return sevkiyatlar;
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
        public List<Sevkiyat> SevkiyatListReader(DateTime sevkiyattarih)
        {
            List<Sevkiyat> sevkiyatlar = new List<Sevkiyat>();
            try
            {
                cmd.CommandText = "SELECT S.ID, S.Musteri_ID, M.Isim, S.SevkTarih, S.Kullanici_ID, K.kullanici_adi, S.Aciklama FROM Sevkiyatlar AS S JOIN Musteriler AS M ON M.ID= S.Musteri_ID JOIN kullanici_liste AS K ON K.Kimlik = S.Kullanici_ID WHERE S.Durum = 0 AND S.SevkTarih=@SevkTarih";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@SevkTarih", sevkiyattarih);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    sevkiyatlar.Add(new Sevkiyat()
                    {
                        ID = reader.GetInt32(0),
                        Musteri_ID = reader.GetInt32(1),
                        MusteriIsim = reader.GetString(2),
                        SevkTarih = reader.GetDateTime(3),
                        Kullanici_ID = reader.GetByte(4),
                        kullanici_adi = reader.GetString(5),
                        Aciklama = reader.GetString(6)
                    });
                }
                return sevkiyatlar;
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
        public void SevkiyatSil(int sevkiyatid)
        {
            cmd.CommandText = "DELETE SevkiyatDetay WHERE Sevkiyat_ID=@id";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@id", sevkiyatid);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            cmd.CommandText = "DELETE Sevkiyatlar WHERE ID=@id";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@id", sevkiyatid);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void SevkiyatGuncelle(int sevkiyaid)
        {
            cmd.CommandText = "UPDATE Sevkiyatlar SET Durum=1, SevkEdilenTarih=@SevkEdilenTarih  WHERE ID=@id";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@id", sevkiyaid);
            cmd.Parameters.AddWithValue("@SevkEdilenTarih ", DateTime.Now);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public List<DepoGiris> MusteriGecmisiListele (int musteriid, string barkod, DateTime baslangic, DateTime bitis)
        {
            string parameterbarkod = (barkod != "") ? "@barkod" : "D.Barkod";
            List<DepoGiris> sd = new List<DepoGiris>();
            try
            {
                cmd.CommandText = $"SELECT D.ID, D.Barkod,D.Sevkiyat_ID, S.SevkEdilenTarih, S.Musteri_ID, M.Isim, K.tanim, K.aciklama, R.renkad, KA.kaliteAd FROM DepoGiris AS D JOIN Sevkiyatlar AS S ON S.ID=D.Sevkiyat_ID JOIN Musteriler AS M ON S.Musteri_ID= M.ID JOIN Products AS P ON P.Id=D.Product_ID JOIN kod_liste AS K ON P.ProductCode=K.Kimlik JOIN renk_liste AS R ON R.Kimlik=P.Color JOIN kalite_liste AS KA ON KA.Kimlik=P.Quality WHERE S.Musteri_ID =@Musteri_ID AND D.Barkod={parameterbarkod} AND S.SevkEdilenTarih BETWEEN @baslangıc AND @bitis";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@Musteri_ID", musteriid );
                cmd.Parameters.AddWithValue("@barkod", barkod);
                cmd.Parameters.AddWithValue("@baslangıc", baslangic);
                cmd.Parameters.AddWithValue("@bitis", bitis);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    sd.Add(new DepoGiris()
                    {
                        Id=reader.GetInt32(0),
                        Barkod= reader.GetString(1),
                        Sevkiyat_ID=reader.GetInt32(2),
                        SevkEdilenTarih = reader.GetDateTime(3),
                        Musteri_ID = reader.GetInt32(4),
                        Isim = reader.GetString(5),
                        UrunKodu = reader.GetString(6),
                        UrunAciklama = reader.GetString(7),
                        Renk_Isim = reader.GetString(8),
                        Kalite_Isim = reader.GetString(9),
                    });
                }
                return sd;
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
        #region DepoStok Metotları
        public int DepoStokEkleBulGuncelle(int urun_id, byte renk_id, byte kalite_id)
        {
            try
            {
                int sayi1 = 0;
                DepoStok ds = new DepoStok();
                cmd.CommandText = "SELECT COUNT(*) FROM DepoStoklar WHERE Urun_ID=@urun_ID AND Renk_ID=@renk_ID AND Kalite_ID=@kalite_ID ";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@urun_ID", urun_id);
                cmd.Parameters.AddWithValue("@renk_ID", renk_id);
                cmd.Parameters.AddWithValue("@kalite_ID", kalite_id);
                con.Open();
                int sayi = Convert.ToInt32(cmd.ExecuteScalar());
                if (sayi == 0)
                {
                    cmd.CommandText = "INSERT INTO DepoStoklar(Urun_ID, Renk_ID, Kalite_ID, Stok) VALUES(@urun_ID, @renk_ID, @kalite_ID,1) SELECT @@IDENTITY";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@urun_ID", urun_id);
                    cmd.Parameters.AddWithValue("@renk_ID", renk_id);
                    cmd.Parameters.AddWithValue("@kalite_ID", kalite_id);
                    sayi1 = Convert.ToInt32(cmd.ExecuteScalar());
                }
                if (sayi == 1)
                {
                    cmd.CommandText = "SELECT ID, Stok FROM DepoStoklar WHERE Urun_ID=@urun_ID AND Renk_ID=@renk_ID AND Kalite_ID=@kalite_ID";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@urun_ID", urun_id);
                    cmd.Parameters.AddWithValue("@renk_ID", renk_id);
                    cmd.Parameters.AddWithValue("@kalite_ID", kalite_id);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        ds.ID = reader.GetInt32(0);
                        ds.Stok = reader.GetInt32(1);
                        sayi1 = ds.ID;
                    }
                    reader.Close();
                    cmd.CommandText = "UPDATE DepoStoklar SET Stok=@stok WHERE ID = @id ";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@id", ds.ID);
                    cmd.Parameters.AddWithValue("@stok", ds.Stok + 1);
                    cmd.ExecuteNonQuery();
                }
                return sayi1;
            }
            catch (Exception)
            {

                return -1;
            }
            finally
            {
                con.Close();
            }
        }
        public List<DepoStok> DepoStokListele()
        {
            List<DepoStok> depoStoklar = new List<DepoStok>();
            try
            {
                cmd.CommandText = "SELECT D.ID, D.Urun_ID, K.tanim, K.aciklama, D.Renk_ID, R.renkad, D.Kalite_ID, KA.kaliteAd, D.Stok FROM DepoStoklar AS D JOIN kod_liste AS K ON D.Urun_ID=K.Kimlik JOIN renk_liste AS R ON D.Renk_ID= R.Kimlik JOIN kalite_liste AS KA ON KA.Kimlik=D.Kalite_ID WHERE STOK>0";
                cmd.Parameters.Clear();
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    depoStoklar.Add(new DepoStok()
                    {
                        ID = reader.GetInt32(0),
                        Urun_ID = reader.GetInt32(1),
                        UrunKod = reader.GetString(2),
                        UrunAciklama = reader.GetString(3),
                        Renk_ID = reader.GetByte(4),
                        Renk_Isim = reader.GetString(5),
                        Kalite_ID = reader.GetByte(6),
                        Kalite_Isim = reader.GetString(7),
                        Stok = reader.GetInt32(8)
                    });
                }
                return depoStoklar;
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
        public int DepoStokIdBul(int urunid, byte renkid, byte kaliteid)
        {
            int id = 0;
            try
            {
                cmd.CommandText = "SELECT ID FROM DepoStoklar WHERE Urun_ID = @Urun_ID AND Renk_ID=@Renk_ID AND Kalite_ID = @Kalite_ID ";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@Urun_ID", urunid);
                cmd.Parameters.AddWithValue("@Renk_ID", renkid);
                cmd.Parameters.AddWithValue("@Kalite_ID", kaliteid);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DepoStok ds = new DepoStok()
                    {
                        ID = reader.GetInt32(0),
                    };
                    id = ds.ID;
                }
                return id;
            }
            catch (Exception)
            {
                return -1;
            }
            finally
            {
                con.Close();
            }
        }
        public void DepoStokMiktarGuncelle(List<DepoGiris> dg)
        {
            DepoStok ds = new DepoStok();

            foreach (DepoGiris item in dg)
            {
                cmd.CommandText = "SELECT  Stok FROM DepoStoklar WHERE ID = @id";
                con.Open();
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", item.DepoStok_ID);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ds.Stok = reader.GetInt32(0);
                }
                con.Close();
                cmd.CommandText = "UPDATE DepoStoklar SET Stok=@stok WHERE ID = @id ";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", item.DepoStok_ID);
                cmd.Parameters.AddWithValue("@stok", ds.Stok - 1);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }

        }
        public void DepoStokMiktarGuncelle(int depostokid)
        {
            DepoStok ds = new DepoStok();
            cmd.CommandText = "SELECT  Stok FROM DepoStoklar WHERE ID = @id";
            con.Open();
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@id", depostokid);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                ds.Stok = reader.GetInt32(0);
            }
            con.Close();
            cmd.CommandText = "UPDATE DepoStoklar SET Stok=@stok WHERE ID = @id ";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@id", depostokid);
            cmd.Parameters.AddWithValue("@stok", ds.Stok - 1);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
        #endregion
        #region DepoPalet Metot
        public int DepoPaletEkle(DepoPalet model)
        {
            try
            {
                cmd.CommandText = "INSERT INTO DepoPaletler(BarkodNo, Kullanici_ID, Durum) VALUES(@BarkodNo, @Kullanici_ID, 1) SELECT @@IDENTITY";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@BarkodNo", model.BarkodNo);
                cmd.Parameters.AddWithValue("@Kullanici_ID", model.Kullanici_ID);
                con.Open();
                int id = Convert.ToInt32(cmd.ExecuteScalar());
                return id;
            }
            catch (Exception)
            {
                return -1;
            }
            finally
            {
                con.Close();
            }
        }
        public int DepoPaletSonIDBulma()
        {
            try
            {
                cmd.CommandText = "SELECT IDENT_CURRENT('DepoPaletler')";
                cmd.Parameters.Clear();
                con.Open();
                int id = Convert.ToInt32(cmd.ExecuteScalar());
                return id;
            }
            catch (Exception)
            {

                return -1;
            }
            finally
            {
                con.Close();
            }
        }
        public List<DepoPalet> DepoPaletReader()
        {
            List<DepoPalet> list = new List<DepoPalet>();
            try
            {
                cmd.CommandText = "SELECT D.ID, D.BarkodNo, D.Kullanici_ID, K.kullanici_adi FROM DepoPaletler AS D JOIN kullanici_liste AS K ON K.Kimlik=D.Kullanici_ID WHERE D.Durum=1";
                cmd.Parameters.Clear();
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(new DepoPalet()
                    {
                        ID = reader.GetInt32(0),
                        BarkodNo = reader.GetString(1),
                        Kullanici_ID = reader.GetByte(2),
                        Kullanici_Isim = reader.GetString(3),
                    });
                }
                return list;
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
        public void DepoPaletSil(int depoPaletId)
        {
            cmd.CommandText = "UPDATE DepoGiris SET DepoPalet_ID=@DepoPalet_ID WHERE DepoPalet_ID=@id";
            con.Open();
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@id", depoPaletId);
            cmd.Parameters.AddWithValue("@DepoPalet_ID", DBNull.Value);
            cmd.ExecuteNonQuery();
            con.Close();
            cmd.CommandText = "Delete DepoPaletler WHERE ID = @id";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@id", depoPaletId);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public DepoPalet DepoPaletGetir(string barkodno)
        {
            DepoPalet dp = new DepoPalet();
            try
            {
                cmd.CommandText = "SELECT ID, BarkodNo FROM DepoPaletler WHERE BarkodNo= @BarkodNo AND Durum=1";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@BarkodNo", barkodno);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    dp = new DepoPalet()
                    {
                        ID = reader.GetInt32(0),
                        BarkodNo = reader.GetString(1),
                    };
                }
                return dp;
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
        public void DepoPaletDurumGuncelle(List<DepoPalet> dp)
        {
            cmd.CommandText = "UPDATE DepoPaletler Set Durum = 0 WHERE ID = @id";
            con.Open();
            foreach (DepoPalet item in dp)
            {
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", item.ID);
                cmd.ExecuteNonQuery();
            }
            con.Close();
        }
        #endregion
        #region SevkiyatDetayMetotları
        public void SevkiyatDetayEkle(List<SevkiyatDetay> s, int sevkiyatid)
        {
            cmd.CommandText = "INSERT INTO SevkiyatDetay(Urun_ID, Renk_ID, Kalite_ID, Sevkiyat_ID, Miktar) VALUES(@Urun_ID, @Renk_ID, @Kalite_ID, @Sevkiyat_ID, @Miktar) ";
            con.Open();
            foreach (SevkiyatDetay item in s)
            {
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@Urun_ID", item.Urun_ID);
                cmd.Parameters.AddWithValue("@Renk_ID", item.Renk_ID);
                cmd.Parameters.AddWithValue("@Kalite_ID", item.Kalite_ID);
                cmd.Parameters.AddWithValue("@Sevkiyat_ID", sevkiyatid);
                cmd.Parameters.AddWithValue("@Miktar", item.Miktar);
                cmd.ExecuteNonQuery();
            }
            con.Close();
        }
        public List<SevkiyatDetay> SevkiyatDetayGöster(int sevkiyatid)
        {
            List<SevkiyatDetay> sevkiyatDetaylar = new List<SevkiyatDetay>();
            try
            {
                cmd.CommandText = "SELECT S.ID, S.Urun_ID, K.tanim, K.aciklama, S.Renk_ID, R.renkad, S.Kalite_ID, KA.kaliteAd, S.Miktar FROM SevkiyatDetay AS S JOIN kod_liste AS K ON K.Kimlik = S.Urun_ID JOIN renk_liste AS R ON R.Kimlik = S.Renk_ID JOIN kalite_liste AS KA ON KA.Kimlik = S.Kalite_ID WHERE S.Sevkiyat_ID= @ID ";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@ID", sevkiyatid);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    sevkiyatDetaylar.Add(new SevkiyatDetay()
                    {
                        ID = reader.GetInt32(0),
                        Urun_ID = reader.GetInt32(1),
                        UrunKodu = reader.GetString(2),
                        UrunAciklama = reader.GetString(3),
                        Renk_ID = reader.GetByte(4),
                        Renk_Isim = reader.GetString(5),
                        Kalite_ID = reader.GetByte(6),
                        Kalite_Isim = reader.GetString(7),
                        Miktar = reader.GetInt32(8),
                    });
                }
                return sevkiyatDetaylar;
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
        public void SevkiyatDetaySil(int sevkiyatdetayid)
        {
            cmd.CommandText = "DELETE SevkiyatDetay WHERE ID=@id";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@id", sevkiyatdetayid);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public SevkiyatDetay SevkiyatDetayGetir(int sevkiyatdetayid)
        {
            SevkiyatDetay sd = new SevkiyatDetay();
            try
            {
                cmd.CommandText = "SELECT S.ID, S.Urun_ID, K.tanim, K.aciklama, S.Renk_ID, R.renkad, S.Kalite_ID, KA.kaliteAd, S.Miktar FROM SevkiyatDetay AS S JOIN kod_liste AS K ON K.Kimlik = S.Urun_ID JOIN renk_liste AS R ON R.Kimlik = S.Renk_ID JOIN kalite_liste AS KA ON KA.Kimlik = S.Kalite_ID WHERE S.ID= @ID ";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@ID", sevkiyatdetayid);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    sd = new SevkiyatDetay()
                    {
                        ID = reader.GetInt32(0),
                        Urun_ID = reader.GetInt32(1),
                        UrunKodu = reader.GetString(2),
                        UrunAciklama = reader.GetString(3),
                        Renk_ID = reader.GetByte(4),
                        Renk_Isim = reader.GetString(5),
                        Kalite_ID = reader.GetByte(6),
                        Kalite_Isim = reader.GetString(7),
                        Miktar = reader.GetInt32(8),
                    };
                }
                return sd;
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
        public bool SevkiyatDetayGuncelle(SevkiyatDetay sd)
        {
            try
            {
                cmd.CommandText = "UPDATE SevkiyatDetay SET Urun_ID=@Urun_ID, Renk_ID=@Renk_ID, Kalite_ID=@Kalite_ID, Miktar=@Miktar WHERE ID=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@Urun_ID", sd.Urun_ID);
                cmd.Parameters.AddWithValue("@Renk_ID", sd.Renk_ID);
                cmd.Parameters.AddWithValue("@Kalite_ID", sd.Kalite_ID);
                cmd.Parameters.AddWithValue("@Miktar", sd.Miktar);
                cmd.Parameters.AddWithValue("@id", sd.ID);
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
        #endregion
        #region DepoHata Metotları
        public List<DepoHata> DepoHataListele()
        {
            List<DepoHata> depoHatalar = new List<DepoHata>();
            try
            {
                cmd.CommandText = "SELECT * FROM DepoHatalar";
                cmd.Parameters.Clear();
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    depoHatalar.Add(new DepoHata()
                    {
                        ID = reader.GetInt32(0),
                        Isim = reader.GetString(1)
                    });
                }
                return depoHatalar;
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
