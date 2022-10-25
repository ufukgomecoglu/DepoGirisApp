using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Model
{
    public class SevkiyatDetay
    {
        public int ID { get; set; }
        public int Urun_ID { get; set; }
        public string UrunKodu { get; set; }
        public string UrunAciklama { get; set; }
        public byte Renk_ID { get; set; }
        public string Renk_Isim { get; set; }
        public byte Kalite_ID { get; set; }
        public string Kalite_Isim { get; set; }
        public int Sevkiyat_ID { get; set; }
        public int Miktar { get; set; }
    }
}
