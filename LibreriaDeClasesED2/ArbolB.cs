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

        public void Insertar(T Info, Delegate Condicion, NodoVector<T> padre, int contador) 
        {
            if (contador <= grado-1)
            {
                if (padre.Posicion[contador] == null)
                {
                    padre.Posicion[contador] = CrearNodo(Info);
                }
                else
                {
                    Insertar(Info, Condicion, padre, contador + 1);
                }
            }
            else 
            {
                if (padre.Padre == null) 
                {
                    if (padre.Posicion[0].Izquierda == null && padre.Posicion[0].Derecha == null) 
                    {
                        NodoVector<T> Arriba = new NodoVector<T>();
                        NodoVector<T> VectorIzquierda = new NodoVector<T>();
                        NodoVector<T> VectorDerecha = new NodoVector<T>();
                        Arriba.Posicion[0].Data = padre.Posicion[(grado / 2) - 1].Data;
                        int VectorPosicion = 0;
                        for (int i = (grado / 2) - 1; i >= 0; i--) 
                        {
                            VectorIzquierda.Posicion[VectorPosicion] = padre.Posicion[i - 1];
                            VectorPosicion++;
                        }
                        VectorPosicion = 0;
                        for (int i = (grado / 2) - 1; i < grado-1; i++)
                        {
                            VectorIzquierda.Posicion[VectorPosicion] = padre.Posicion[i + 1];
                            VectorPosicion++;
                        }
                        Raiz = Arriba;
                        Raiz.Posicion[0].Izquierda = VectorIzquierda;
                        Raiz.Posicion[0].Derecha = VectorDerecha;
                    }
                }
            }
        }


        void BuscarInsert(NodoVector<T>Raiz, T Info, Delegate Condicion) 
        {
            
        }
        
    }
}
