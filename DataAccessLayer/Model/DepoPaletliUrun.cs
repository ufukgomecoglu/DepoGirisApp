using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Model
{
    public class DepoPaletliUrun
    {
        public int ID { get; set; }
        public string BarkodNo { get; set; }
        public int Adet { get; set; }
        public int Kod_liste_Kimlik { get; set; }
        public string UrunKod { get; set; }
        public string aciklama { get; set; }
        public byte Renk_liste_kimlik { get; set; }
        public string renkad { get; set; }
        public byte kullanici_liste_kimlik { get; set; }
        public string kullanici_adi { get; set; }
        public string ad_soyad { get; set; }
    }
}
