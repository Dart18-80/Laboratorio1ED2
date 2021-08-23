using System;
using System.Collections.Generic;
using System.Text;


namespace LibreriaDeClasesED2
{
    class ArbolB <T> where T : IComparable
    {
        public int grado;
        NodoArbolB<T> Raiz;
        public ArbolB()
        {
            NodoArbolB<T> Raiz = new NodoArbolB<T>();
            Raiz.Data = default;
            Raiz.Anterior = null;
            Raiz.Derecha = null;
            Raiz.Izquierda = null;
            Raiz.Siguiente = null;
        }

        public void AgregarGrado(int Numero) 
        {
            if (Numero >= 4) 
            {
                grado = Numero;
            }
        }

        public void Insertar(T Info) 
        {
            if (Raiz.Data == null)
            {
                Raiz.Data = Info;
            }
            else
            {
                Insertar(Raiz,Info);
            }
        }

        public void Insertar(NodoArbolB<T> Padre, T Info) 
        {
            if (Raiz.Data == null)
            {
                Raiz.Data = Info;
            }
            else 
            {
                if () 
                {

                }
            }
        }
    }
}
