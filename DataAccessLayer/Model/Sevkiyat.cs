using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Model
{
    public class Sevkiyat
    {
        public int ID { get; set; }
        public int Musteri_ID { get; set; }
        public string MusteriIsim { get; set; }
        public int Kod_liste_Kimlik { get; set; }
        public string UrunKodu { get; set; }
        public string Aciklama { get; set; }
        public int Miktar { get; set; }
        public DateTime SevkTarih { get; set; }
        public byte Renk_liste_kimlik { get; set; }
        public string renkad { get; set; }
        public byte Kalite_liste_kimlik { get; set; }
        public string kaliteAd { get; set; }
        public int DepoGiris_Id { get; set; }
        public bool Durum { get; set; }
        public DateTime SevkEdielenTarih { get; set; }
        public string ad_soyad { get; set; }
        public byte Kullanici_ID { get; set; }
        public string kullanici_adi { get; set; }
    }
}
