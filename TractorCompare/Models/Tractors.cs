using Microsoft.AspNetCore.Mvc.Rendering;
using Org.BouncyCastle.Bcpg.OpenPgp;
using System.Collections.Generic;
using System.ComponentModel;


namespace TractorCompare.Models
{
    public class Tractors
    {
        public Tractors() 
        {
        }

        public int tractorID { get; set; }
        public string brandID { get; set; }
        public string brand { get; set; }
        public string Model { get; set; }
        public string Class { get; set; }
        public string HP { get; set; }
        public string PTO { get; set; }
        public string fuel { get; set; }
        public string hydroSteer { get; set; }
        public string hydroImp { get; set; }
        public string threePT { get; set; }
        public string loaderID { get; set; }

        public string image { get; set; }
        public IEnumerable<Brand> name { get; set; }



    }
}
