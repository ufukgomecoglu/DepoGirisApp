using DataAccessLayer.Model;
using System;
using System.Collections.Generic;
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
                cmd.CommandText = "INSERT INTO DepoGiris(Barkod,Sicil,KayitTarih,Product_ID,Hata_Id,BolumNo,Durum) VALUES(@barkod,@sicil,@kayittarih,@product_id,@hata_id,0,1)";
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
                cmd.CommandText = "SELECT D.Id, D.Barkod, D.Sicil , D.KayitTarih, D.Hata_Id, K.tanim  FROM DepoGiris AS D JOIN Products AS P ON P.Id=D.Product_ID JOIN kod_liste AS K ON P.ProductCode = K.Kimlik WHERE D.Sicil=@sicil AND  D.Durum=1 AND D.KayitTarih  BETWEEN @bugununtarihi AND @ertisigüntarihi   ";
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
                cmd.CommandText = "SELECT D.Id, D.Barkod, D.Sicil , D.KayitTarih, D.Hata_Id, K.tanim  FROM DepoGiris AS D JOIN Products AS P ON P.Id=D.Product_ID JOIN kod_liste AS K ON P.ProductCode = K.Kimlik AND D.Durum=1  ";
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
                cmd.CommandText = "SELECT D.Id, D.Barkod, D.Sicil , D.KayitTarih, D.Hata_Id, K.tanim  FROM DepoGiris AS D JOIN Products AS P ON P.Id=D.Product_ID JOIN kod_liste AS K ON P.ProductCode = K.Kimlik WHERE K.tanim=@tanim AND D.Durum=1 ";
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
                cmd.CommandText = "SELECT D.Id, D.Barkod, D.Sicil , D.KayitTarih, D.Hata_Id, K.tanim  FROM DepoGiris AS D JOIN Products AS P ON P.Id=D.Product_ID JOIN kod_liste AS K ON P.ProductCode = K.Kimlik WHERE D.Sicil=@sicil AND D.Durum=1";
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
                cmd.CommandText = "SELECT D.Id, D.Barkod, D.Sicil , D.KayitTarih, D.Hata_Id, K.tanim  FROM DepoGiris AS D JOIN Products AS P ON P.Id=D.Product_ID JOIN kod_liste AS K ON P.ProductCode = K.Kimlik WHERE D.Durum=1 AND D.KayitTarih  BETWEEN @bugununtarihi AND @ertisigüntarihi  ";
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
        public DepoGiris DepoGirisGetir(string barkodno)
        {
            try
            {
                DepoGiris dg = new DepoGiris();
                cmd.CommandText = "SELECT Id,Barkod,Sicil,KayitTarih,Product_ID,Hata_Id,DepoPaletliUrun_ID FROM DepoGiris WHERE Barkod = @barkod AND Durum = 1";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@barkod", barkodno);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    dg = new DepoGiris()
                    {
                        Id = reader.GetInt32(0),
                        Barkod = reader.GetString(1),
                        Sicil = reader.GetByte(2),
                        KayitTarih = reader.GetDateTime(3),
                        Product_ID = reader.GetInt32(4),
                        Hata_Id=reader.GetByte(5),
                        DepoPaletliUrun_ID = reader.IsDBNull(6) ? 0 : reader.GetInt32(6),
                    };
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
        public bool DepoGirisDepoPaletIDGuncelle(List<DepoGiris> depoGirisler,int id)
        {
            List<int> dpid = new List<int>();
            foreach (DepoGiris depoGiris in depoGirisler)
            {
                dpid.Add(depoGiris.Id);
            }
            try
            {
                for (int i = 0; i < dpid.Count; i++)
                {
                    cmd.CommandText = "UPDATE DepoGiris SET DepoPaletliUrun_ID=@depoPaletliUrun_ID WHERE Id=@id";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@depoPaletliUrun_ID", id);
                    cmd.Parameters.AddWithValue("@id", dpid[i]);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                return true;
            }
            catch (Exception)
            {

                return false;
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
        #region Sevkiyat Metotları
        public bool SevkiyatEkle(Sevkiyat model)
        {
            try
            {
                cmd.CommandText = "INSERT INTO Sevkiyat(Musteri_ID, Kod_liste_kimlik, Miktar, SevkTarih, Renk_liste_kimlik, Kalite_liste_kimlik, Durum, Kullanici_ID) VALUES(@musteri_id, @kod_liste_kimlik, @miktar, @sevktarih, @renk_liste_kimlik, @kalite_liste_kimlik, 0, @Kullanici_ID)";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@musteri_id", model.Musteri_ID);
                cmd.Parameters.AddWithValue("@kod_liste_kimlik", model.Kod_liste_Kimlik);
                cmd.Parameters.AddWithValue("@miktar", model.Miktar);
                cmd.Parameters.AddWithValue("@sevktarih", model.SevkTarih);
                cmd.Parameters.AddWithValue("@renk_liste_kimlik", model.Renk_liste_kimlik);
                cmd.Parameters.AddWithValue("@kalite_liste_kimlik", model.Kalite_liste_kimlik);
                cmd.Parameters.AddWithValue("@Kullanici_ID", model.Kullanici_ID);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {

                throw;
            }
            finally 
            {
                con.Close();
            }
        }
        public List<Sevkiyat> SevkiyatListele()
        {
            List<Sevkiyat> sevkiyatlar = new List<Sevkiyat>();
            try
            {
                cmd.CommandText = "SELECT S.ID, S.Musteri_ID, M.Isim,S.Kod_liste_Kimlik,K.tanim, K.aciklama, S.Miktar, S.SevkTarih, S.Renk_liste_kimlik, R.renkad, S.Kalite_liste_kimlik, KA.kaliteAd, S.Kullanici_ID , KU.ad_soyad, KU.kullanici_adi FROM Sevkiyat AS S JOIN Musteriler AS M ON M.ID= S.Musteri_ID JOIN kod_liste AS K ON S.Kod_liste_Kimlik=K.Kimlik JOIN renk_liste AS R ON R.Kimlik=S.Renk_liste_kimlik JOIN kalite_liste AS KA ON KA.Kimlik = S.Kalite_liste_kimlik JOIN kullanici_liste AS KU ON KU.Kimlik = S.Kullanici_ID WHERE S.Durum= 0";
                cmd.Parameters.Clear();
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Sevkiyat s = new Sevkiyat();
                    s.ID = reader.GetInt32(0);
                    s.Musteri_ID = reader.GetInt32(1);
                    s.MusteriIsim = reader.GetString(2);
                    s.Kod_liste_Kimlik = reader.GetInt32(3);
                    s.UrunKodu = reader.GetString(4);
                    s.Aciklama = reader.GetString(5);
                    s.Miktar = reader.GetInt32(6);
                    s.SevkTarih = reader.GetDateTime(7);
                    s.Renk_liste_kimlik = reader.GetByte(8);
                    s.renkad = reader.GetString(9);
                    s.Kalite_liste_kimlik = reader.GetByte(10);
                    s.kaliteAd = reader.GetString(11);
                    s.Kullanici_ID = reader.GetByte(12);
                    s.ad_soyad = reader.GetString(13);
                    s.kullanici_adi = reader.GetString(14);
                    sevkiyatlar.Add(s);
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
        public Sevkiyat SevkiyatGetir(int id)
        {
            try
            {
                Sevkiyat s = new Sevkiyat();
                cmd.CommandText = "SELECT S.ID, S.Musteri_ID, M.Isim,S.Kod_liste_Kimlik,K.tanim, K.aciklama, S.Miktar, S.SevkTarih, S.Renk_liste_kimlik, R.renkad, S.Kalite_liste_kimlik, KA.kaliteAd, S.Kullanici_ID , KU.ad_soyad, KU.kullanici_adi FROM Sevkiyat AS S JOIN Musteriler AS M ON M.ID= S.Musteri_ID JOIN kod_liste AS K ON S.Kod_liste_Kimlik=K.Kimlik JOIN renk_liste AS R ON R.Kimlik=S.Renk_liste_kimlik JOIN kalite_liste AS KA ON KA.Kimlik = S.Kalite_liste_kimlik JOIN kullanici_liste AS KU ON KU.Kimlik = S.Kullanici_ID WHERE S.ID= @id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    s.ID = reader.GetInt32(0);
                    s.Musteri_ID = reader.GetInt32(1);
                    s.MusteriIsim = reader.GetString(2);
                    s.Kod_liste_Kimlik = reader.GetInt32(3);
                    s.UrunKodu = reader.GetString(4);
                    s.Aciklama = reader.GetString(5);
                    s.Miktar = reader.GetInt32(6);
                    s.SevkTarih = reader.GetDateTime(7);
                    s.Renk_liste_kimlik = reader.GetByte(8);
                    s.renkad = reader.GetString(9);
                    s.Kalite_liste_kimlik = reader.GetByte(10);
                    s.kaliteAd = reader.GetString(11);
                    s.Kullanici_ID = reader.GetByte(12);
                    s.ad_soyad = reader.GetString(13);
                    s.kullanici_adi = reader.GetString(14);
                }
                return s;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }
        public bool SevkiyatGuncelle(Sevkiyat model)
        {
            try
            {
                cmd.CommandText = "UPDATE Sevkiyat SET Musteri_ID=@Musteri_ID, Kod_liste_Kimlik =@Kod_liste_Kimlik, Miktar = @Miktar, SevkTarih=@SevkTarih, Renk_liste_kimlik=@Renk_liste_kimlik, Kalite_liste_kimlik=@Kalite_liste_kimlik, Kullanici_ID=@Kullanici_ID WHERE ID=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", model.ID);
                cmd.Parameters.AddWithValue("@Musteri_ID", model.Musteri_ID);
                cmd.Parameters.AddWithValue("@Kod_liste_Kimlik", model.Kod_liste_Kimlik);
                cmd.Parameters.AddWithValue("@Miktar", model.Miktar);
                cmd.Parameters.AddWithValue("@SevkTarih", model.SevkTarih);
                cmd.Parameters.AddWithValue("@Renk_liste_kimlik", model.Renk_liste_kimlik);
                cmd.Parameters.AddWithValue("@Kalite_liste_kimlik", model.Kalite_liste_kimlik);
                cmd.Parameters.AddWithValue("@Kullanici_ID", model.Kullanici_ID);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                con.Close();
            }
        }
        public bool SevkiyatSil(int id)
        {
            try
            {
                cmd.CommandText = "DELETE Sevkiyat  WHERE ID= @id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        #endregion
        #region DepoStok Metotları
        public bool DepoStokEkleBulGuncelle(int urunkimlik,byte renkkimlik)
        {
            try
            {
                DepoStok ds = new DepoStok();
                cmd.CommandText = "SELECT COUNT(*) FROM DepoStok WHERE Kod_liste_Kimlik=@Kod_liste_Kimlik AND Renk_liste_kimlik=@Renk_liste_kimlik";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@Kod_liste_Kimlik", urunkimlik);
                cmd.Parameters.AddWithValue("@Renk_liste_kimlik", renkkimlik);
                con.Open();
                int sayi = Convert.ToInt32(cmd.ExecuteScalar());
                if (sayi==0)
                {
                    cmd.CommandText = "INSERT INTO DepoStok(Kod_liste_Kimlik,Renk_liste_kimlik,Stok) VALUES(@Kod_liste_Kimlik,@Renk_liste_kimlik,1)";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@Kod_liste_Kimlik", urunkimlik);
                    cmd.Parameters.AddWithValue("@Renk_liste_kimlik", renkkimlik);
                    cmd.ExecuteNonQuery();
                }
                if (sayi==1)
                {
                    cmd.CommandText = "SELECT Stok FROM DepoStok WHERE Kod_liste_Kimlik=@Kod_liste_Kimlik AND Renk_liste_kimlik=@Renk_liste_kimlik ";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@Kod_liste_Kimlik", urunkimlik);
                    cmd.Parameters.AddWithValue("@Renk_liste_kimlik", renkkimlik);
                    cmd.Parameters.AddWithValue("@stok", renkkimlik);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        ds.Stok = reader.GetInt32(0);
                    }
                    reader.Close();
                    cmd.CommandText = "UPDATE DepoStok SET Stok=@stok WHERE Kod_liste_Kimlik=@Kod_liste_Kimlik AND Renk_liste_kimlik=@Renk_liste_kimlik";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@Kod_liste_Kimlik", urunkimlik);
                    cmd.Parameters.AddWithValue("@Renk_liste_kimlik", renkkimlik);
                    cmd.Parameters.AddWithValue("@stok", ds.Stok+1);
                    cmd.ExecuteNonQuery();
                }
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
        public List<DepoStok> DepoStokListele()
        {
            List<DepoStok> depoStoklar = new List<DepoStok>();
            try
            {
                cmd.CommandText = "SELECT D.ID, D.Kod_liste_Kimlik, K.tanim, K.aciklama, D.Renk_liste_kimlik, R.renkad, D.Stok FROM DepoStok AS D JOIN kod_liste AS K ON D.Kod_liste_Kimlik=K.Kimlik JOIN renk_liste AS R ON D.Renk_liste_kimlik= R.Kimlik ";
                cmd.Parameters.Clear();
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while(reader.Read())
                {
                    depoStoklar.Add(new DepoStok()
                    {
                        ID = reader.GetInt32(0),
                        Kod_liste_Kimlik = reader.GetInt32(1),
                        UrunKod = reader.GetString(2),
                        aciklama = reader.GetString(3),
                        Renk_liste_kimlik = reader.GetByte(4),
                        renkad = reader.GetString(5),
                        Stok = reader.GetInt32(6)
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
        #endregion
        #region DepoPaletliUrun Metotları
        public bool DepoPaletEkle(DepoPaletliUrun dpu)
        {
            try
            {
                cmd.CommandText = "INSERT INTO DepoPaletliUrunler(BarkodNo, Adet, Kod_liste_Kimlik, Renk_liste_kimlik, kullanici_liste_kimlik, Durum) VALUES(@barkodNo, @adet, @kod_liste_Kimlik, @renk_liste_kimlik, @kullanici_liste_kimlik, 1)";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@barkodNo", dpu.BarkodNo);
                cmd.Parameters.AddWithValue("@adet", dpu.Adet);
                cmd.Parameters.AddWithValue("@kod_liste_Kimlik", dpu.Kod_liste_Kimlik);
                cmd.Parameters.AddWithValue("@renk_liste_kimlik", dpu.Renk_liste_kimlik);
                cmd.Parameters.AddWithValue("@kullanici_liste_kimlik", dpu.kullanici_liste_kimlik);
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
        public List<DepoPaletliUrun> DepoPaletListele()
        {
            List<DepoPaletliUrun> depoPaletliUrunler = new List<DepoPaletliUrun>();
            try
            {
                cmd.CommandText = "SELECT DP.ID, DP.BarkodNo, DP.Adet, DP.Kod_liste_Kimlik, K.tanim, K.aciklama, DP.Renk_liste_kimlik, R.renkad, DP.kullanici_liste_kimlik, KU.kullanici_adi, KU.ad_soyad FROM DepoPaletliUrunler AS DP JOIN kod_liste AS K ON K.Kimlik=DP.Kod_liste_Kimlik JOIN renk_liste AS R ON R.Kimlik=DP.Renk_liste_kimlik JOIN kullanici_liste AS KU ON KU.Kimlik=DP.kullanici_liste_kimlik WHERE DP.Durum=1";
                cmd.Parameters.Clear();
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    depoPaletliUrunler.Add(new DepoPaletliUrun()
                    {
                        ID = reader.GetInt32(0),
                        BarkodNo = reader.GetString(1),
                        Adet = reader.GetInt32(2),
                        Kod_liste_Kimlik= reader.GetInt32(3),
                        UrunKod = reader.GetString(4),
                        aciklama = reader.GetString(5),
                        Renk_liste_kimlik = reader.GetByte(6),
                        renkad = reader.GetString(7),
                        kullanici_liste_kimlik= reader.GetByte(8),
                        kullanici_adi = reader.GetString(9),
                        ad_soyad = reader.GetString(10),
                    });
                }
                return depoPaletliUrunler;
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
