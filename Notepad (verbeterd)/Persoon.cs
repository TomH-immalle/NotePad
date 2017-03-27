using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileHelpers;

namespace Notepad__verbeterd_
{
    [DelimitedRecord(",")]
    class Persoon
    {
        public string Voornaam { get; set; }
        public string Achternaam { get; set; }
        public DateTime GeboorteDatum { get; set; }

        public void Personen()
        {
            List<Persoon> personen = new List<Persoon>();

      
        }
        public override string ToString()
        {
            return Voornaam + "  "
                + Achternaam
                + String.Format("({0})", GeboorteDatum);
        }


    }
}
