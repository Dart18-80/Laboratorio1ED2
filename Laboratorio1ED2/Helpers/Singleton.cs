using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibreriaDeClasesED2;
using Laboratorio1ED2.Models;

namespace Laboratorio1ED2.Helpers
{
    public class Singleton
    {
        private static Singleton _intance; 
        public static Singleton Intance 
        {
            get 
            {
                if (_intance == null) _intance = new Singleton();
                return _intance;
            }
        }

        public ArbolPrueba<Peliculas> Arbol;
        public string Way;
    }
}
