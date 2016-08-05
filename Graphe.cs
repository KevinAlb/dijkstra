using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carte_routiere
{
    class Graphe
    {

        public Dictionary<Arret, Dictionary<Arret, double>> sommets {get;set;}

    public Graphe()
    {
        sommets = new Dictionary<Arret, Dictionary<Arret, double>>();
    }

    public void addSommet(Arret vertex) {
        this.sommets[vertex] = new Dictionary<Arret,double>();
    }

    public void addEdge(Arret depart, Arret arrivee)
    {
        if (!this.sommets.ContainsKey(depart))
            addSommet(depart);
        if (!this.sommets.ContainsKey(arrivee))
            addSommet(arrivee);
        double distance = depart.calcul_distance(arrivee);
        this.sommets[depart][arrivee] = distance;
        this.sommets[arrivee][depart] = distance;
    }

    public void afficherGraph () 
    {
        foreach (KeyValuePair<Arret, Dictionary<Arret, double>> vertex in sommets)
        {
            if (vertex.Value.Count == 0)
                Console.Error.WriteLine("Arret : " + vertex.Key + " n'est lié à personne");
            else
            {
                Console.Error.WriteLine("Arret : " + vertex.Key + " lié à :");
                foreach (KeyValuePair<Arret, double> edge in vertex.Value)
                {
                    Console.Error.WriteLine(" - " + edge.Key + " à une distance de " + edge.Value);
                }
            }
            
        }
    }

    public List<Arret> trierCroissant(List<Arret> list, Dictionary<Arret, double> distance)
    {
        var item = from arret in list
                    join pair in distance on arret equals pair.Key
                   orderby pair.Value ascending
                   select pair;
        List<Arret> arrets = new List<Arret>();
        foreach (var v in item) {
            arrets.Add(v.Key);
        }
        return arrets;
    }

    public List<Arret> dijkstra(Arret depart, Arret arrivee)
    {
        var precedent = new Dictionary<Arret, Arret>();
        var distance = new Dictionary<Arret, double>();
        var noeud = new List<Arret>();
        List<Arret> chemin = null;

        foreach (var sommet in sommets)
        {
            if (sommet.Key.Equals(depart))
            {
                distance[sommet.Key] = 0;
            }
            else
                distance[sommet.Key] = double.MaxValue;
            noeud.Add(sommet.Key);
        }
        while (noeud.Count != 0)
        {
            noeud = trierCroissant(noeud, distance);
            
            //Fin du tri des noeuds

            var minimal = noeud[0];
            noeud.Remove(minimal);
            //Si on a trouvé le chemin minimal
            if (minimal.Equals(arrivee))
            {
                chemin = new List<Arret>();
                 while (precedent.ContainsKey(minimal))
                    {
                        chemin.Add(minimal);
                        minimal = precedent[minimal];
                    }
                 break;
            }
            if (distance[minimal] == double.MaxValue)
            {
                break;
            }

            //On parcours les voisins du noeud minimal
            foreach (var neighbor in sommets[minimal])
            {
                var alt = distance[minimal] + neighbor.Value;
                if (alt < distance[neighbor.Key])
                {
                    distance[neighbor.Key] = alt;
                    precedent[neighbor.Key] = minimal;
                }
            }


        }
        return chemin;
    }

    public double calculerDistanceParcours(List<Arret> list) {
        double dist = 0;
        for (int i = 1; i<list.Count;i++) {
            dist += list[i-1].calcul_distance(list[i]);
        }
        return dist;
    }
    }
}
