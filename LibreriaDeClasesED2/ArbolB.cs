using System;
using System.Collections.Generic;
using System.Text;


namespace LibreriaDeClasesED2
{
    class ArbolB<T> where T : IComparable
    {
        public int grado;
        NodoVector<T> Raiz;

        public void Grado (int NumGrado)
        {
            if (NumGrado <= 4)
            {
                grado = NumGrado;
            }
        }

        public NodoArbolB<T> CrearNodo (T Info) 
        {
            NodoArbolB<T> Nuevo = new NodoArbolB<T>();
            Nuevo.Data = Info;
            Nuevo.Derecha = null;
            Nuevo.Izquierda = null;
            return Nuevo;
        }

        public void Insertar(T Info, Delegate Condicion) 
        {
            int contador = 0; 
            if (Raiz == null)
            {
                Raiz.Posicion[contador] = CrearNodo(Info);
            }
            else 
            {
                Insertar(Info, Condicion, Raiz, contador+1);
            }
        }

        public void Insertar(T Info, Delegate Condicion, NodoVector<T> Padre, int contador) 
        {
            if (contador <= grado) 
            {
                if (Padre.Posicion[contador] == null)
                {
                    Padre.Posicion[contador] = CrearNodo(Info);
                }
                else 
                {
                    Insertar(Info, Condicion, Padre, contador+1);
                }
            }
        }
        
    }
}
