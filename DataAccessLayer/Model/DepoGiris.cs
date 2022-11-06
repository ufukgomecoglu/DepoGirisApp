using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Model
{
    public class DepoGiris
    {
        
        public int Id { get; set; }
        public string Barkod { get; set; }
        public byte Sicil { get; set; }
        public string Kullanici_Isim { get; set; }
        public DateTime KayitTarih { get; set; }
        public int Product_ID { get; set; }
        public byte KaliteHata_Id { get; set; }
        public string KaliteHata_Isim { get; set; }
        public short KaliteHata_Kod { get; set; }
        public int Urun_ID { get; set; }
        public string UrunKodu { get; set; }
        public string UrunAciklama { get; set; }
        public byte Renk_ID { get; set; }
        public string Renk_Isim { get; set; }
        public byte Kalite_ID { get; set; }
        public string Kalite_Isim { get; set; }
        public int DepoPalet_ID { get; set; }
        public int Sevkiyat_ID { get; set; }
        public int DepoHata_ID { get; set; }
        public int DepoStok_ID { get; set; }
        public int Musteri_ID { get; set; }
        public string Isim { get; set; }
        public DateTime SevkEdilenTarih { get; set; }
    }
}
