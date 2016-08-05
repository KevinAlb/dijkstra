using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carte_routiere
{
    class Arret
    {
        public string id { get; set; }
        public string nom { get; set; }
        public double lat { get; set; }
        public double lon { get; set; }


        public Arret(string id, string nom, double lat, double lon)
        {
            this.id = id;
            this.nom = nom;
            this.lat = lat;
            this.lon = lon;
        }

        public Arret(string id)
        {
            this.id = id;
        }

        public override string ToString()
        {
            string chaine = "";
            chaine += nom;
            /* chaine += "Nom : " + nom + "\n";
             chaine += "Latitude : " + lat + "\n";
             chaine += "Longitude : " + lon + "\n";
             chaine += "Type : " + type + "\n";*/
            return chaine;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            Arret a = obj as Arret;
            return a.id == this.id;
        }

        public double calcul_distance(Arret a)
        {
            double lonA, latA, lonB, latB;
            double X, Y;
            lonA = Math.PI * this.lon / 180;
            latA = Math.PI * this.lat / 180;
            lonB = Math.PI * a.lon / 180;
            latB = Math.PI * a.lat / 180;
            X = (lonB - lonA) * Math.Cos((latA + latB) * 0.5);
            Y = latB - latA;
            return (Math.Sqrt(X * X + Y * Y)) * 6371;

        }
    }
}
