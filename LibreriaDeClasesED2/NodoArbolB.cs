using System;
using System.Collections.Generic;
using System.Text;

namespace LibreriaDeClasesED2
{
    class NodoArbolB<T> where T : IComparable
    {
        public T Data { get; set; }
        public NodoArbolB<T> Derecha { get; set; }
        public NodoArbolB<T> Izquierda { get; set; }
        public NodoArbolB<T> Siguiente { get; set; }
        public NodoArbolB<T> Anterior { get; set; }

    }
}
