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
        public DateTime SevkTarih { get; set; }
        public bool Durum { get; set; }
        public DateTime SevkEdilenTarih { get; set; }
        public byte Kullanici_ID { get; set; }
        public string kullanici_adi { get; set; }
        public string Aciklama { get; set; }
    }
}
