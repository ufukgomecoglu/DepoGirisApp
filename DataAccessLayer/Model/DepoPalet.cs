using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Model
{
    public class DepoPalet
    {
        public int ID { get; set; }
        public string BarkodNo { get; set; }
        public byte Kullanici_ID { get; set; }
        public string Kullanici_Isim { get; set; }
    }
}
