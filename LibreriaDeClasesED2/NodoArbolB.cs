using System;
using System.Collections.Generic;
using System.Text;

namespace LibreriaDeClasesED2
{
    class NodoArbolB<T> where T : IComparable
    {
        public T Data { get; set; }
        public NodoVector<T> Derecha { get; set; }
        public NodoArbolB<T> Izquierda { get; set; }
    }
}
