using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Model
{
    public class kullanici_listeLogin
    {
        public byte Kimlik { get; set; }
        public string kullanici_adi { get; set; }
        public string sifre { get; set; }
        public string ad_soyad { get; set; }
        public string Departman { get; set; }

    }
}
