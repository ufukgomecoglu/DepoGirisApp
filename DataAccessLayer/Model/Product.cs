using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Model
{
    public class Product
    {
        public int Id { get; set; }
        public string Barcode { get; set; }
        public int ProductCode { get; set; }
        public DateTime CastDate { get; set; }
        public int CastPersonel { get; set; }
        public byte GlazingTerritory { get; set; }
        public byte Quality { get; set; }
        public byte Foult { get; set; }
        public DateTime ControlDate { get; set; }
        public string ControlPersonel { get; set; }
        public byte Kiln { get; set; }
        public byte Fring { get; set; }
        public byte Color { get; set; }
        public byte StockTerritory { get; set; }
        public string IsItTest { get; set; }
        public DateTime ControlTime { get; set; }
    }
}
