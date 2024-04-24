using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unik.Application
{
    internal class ResponseKlasse
    {

        public class Rootobject
        {
            public Class1[] Property1 { get; set; }
        }

        public class Class1
        {
            public Data data { get; set; }
            public bool stormodtagerpostnr { get; set; }
            public string type { get; set; }
            public string tekst { get; set; }
            public string forslagstekst { get; set; }
            public int caretpos { get; set; }
        }

        public class Data
        {
            public string id { get; set; }
            public int status { get; set; }
            public int darstatus { get; set; }
            public string vejkode { get; set; }
            public string vejnavn { get; set; }
            public string adresseringsvejnavn { get; set; }
            public string husnr { get; set; }
            public string etage { get; set; }
            public object dør { get; set; }
            public object supplerendebynavn { get; set; }
            public string postnr { get; set; }
            public string postnrnavn { get; set; }
            public object stormodtagerpostnr { get; set; }
            public object stormodtagerpostnrnavn { get; set; }
            public string kommunekode { get; set; }
            public string adgangsadresseid { get; set; }
            public float x { get; set; }
            public float y { get; set; }
            public string href { get; set; }
        }

    }
}
