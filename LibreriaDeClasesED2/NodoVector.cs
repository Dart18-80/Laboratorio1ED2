using System;
using System.Collections.Generic;
using System.Text;

namespace LibreriaDeClasesED2
{
    class NodoVector <T> where T : IComparable
    {
        public NodoArbolB<T>[] Posicion { get; set; }
        public NodoVector<T> Padre { get; set; }
    }
}
