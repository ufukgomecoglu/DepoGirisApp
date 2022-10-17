using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Model
{
    public class DepoStok
    {
        public int ID { get; set; }
        public int Kod_liste_Kimlik { get; set; }
        public string UrunKod { get; set; }
        public string aciklama { get; set; }
        public byte Renk_liste_kimlik { get; set; }
        public string renkad { get; set; }
        public int Stok { get; set; }
    }
}
