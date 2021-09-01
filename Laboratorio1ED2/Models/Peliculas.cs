using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Laboratorio1ED2.Models
{
    public class Peliculas : IComparable
    {
        public string TituloPeliculas { get; set; }
        public int DuracionMinutos { get; set; }
        public string Director { get; set; }
        public DateTime FechaDeCreacion { get; set; }
        public string Genero { get; set; }




        public int CompareToString(string obj1, string obj2)
        {
            int Comparar = obj1.CompareTo(obj2);
            if (Comparar == 0)
                return 0;
            else if (Comparar < 0)
                return -1;
            else
                return 1;
        }

        public int CompareToObjeto(object obj1, string obj2)
        {
            int Comparar = Convert.ToString(obj1).CompareTo(obj2);
            if (Comparar == 0)
                return 0;
            else if (Comparar < 0)
                return -1;
            else
                return 1;
        }

        public int CompareTo(object obj)
        {
            throw new NotImplementedException();
        }
    }
}
