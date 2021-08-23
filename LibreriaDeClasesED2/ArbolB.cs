using System;
using System.Collections.Generic;
using System.Text;


namespace LibreriaDeClasesED2
{
    class ArbolB<T> where T : IComparable
    {
        public int grado;
        int contador;
        NodoVector<T> Raiz;

        public void Grado (int NumGrado)
        {
            if (NumGrado <= 4)
            {
                grado = NumGrado;
            }
        }

        public void Insertar(T Info, Delegate Condicion) 
        {
            if (Raiz == null) 
            {
                NodoArbolB<T> Nuevo = new NodoArbolB<T>();
                Nuevo.Data = Info;
                Raiz.Posicion[0] = Nuevo;
            }
        }

        
    }
}
