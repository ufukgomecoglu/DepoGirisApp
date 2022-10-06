using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Model
{
    public class DepoGiris
    {
        public DepoGiris()
        {
            
        }
        public int Id { get; set; }
        public string Barkod { get; set; }
        public byte Sicil { get; set; }
        public DateTime KayitTarih { get; set; }
        public int Product_ID { get; set; }
        public byte Hata_Id { get; set; }
        public byte BolumNo { get; set; }


    }
}
