using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carte_routiere
{
    class Program
    {
        static void Main(string[] args)
        {
            Graphe graph = new Graphe();

            Arret toulouse = new Arret("TLSE", "Toulouse", 43.6046520, 1.4442090);
            Arret paris = new Arret("PAR", "Paris", 48.8566140, 2.3522219);
            Arret lyon = new Arret("LYON", "Lyon", 45.7640430, 4.8356590);
            Arret marseille = new Arret("MAR", "Marseille", 43.2964820, 5.3697800);
            Arret limoges = new Arret("LIM", "Limoges", 45.8336190, 1.2611050);
            Arret bordeaux = new Arret("BOR", "Bordeaux", 44.8377890, -0.5791800);
            Arret metz = new Arret("METZ", "Metz", 49.1193089, 6.1757156);

            graph.addEdge(toulouse, bordeaux);
            graph.addEdge(toulouse, limoges);
            graph.addEdge(toulouse, marseille);
            graph.addEdge(marseille, lyon);
            graph.addEdge(lyon, paris);
            graph.addEdge(limoges, paris);
            graph.addEdge(paris, metz);
            List<Arret> chemin = graph.dijkstra(metz, bordeaux);
            Console.WriteLine(metz.ToString());
            for (int i = chemin.Count - 1; i >= 0; i--)
            {
                Console.WriteLine(chemin[i].ToString());
            }
                Console.ReadLine();
        }
    }
}

