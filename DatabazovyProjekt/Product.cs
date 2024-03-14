using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabazovyProjekt
{
    public class Product
    {
       // public int ProductID { get; set; }
        public string Nazev { get; set; }
        public float Cena { get; set; }
        public bool Skladem { get; set; }
        public DateTime VyrobniDatum { get; set; }
    }
}
