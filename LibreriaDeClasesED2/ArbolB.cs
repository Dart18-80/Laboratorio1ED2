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
            if (contador <= grado-1) //Llena la Raiz hasta que el contador sea igual a 3, eso quiere decir que ya sobrepaso el limite de grado 4
            {
                if (padre.Posicion[contador] == null)
                {
                    padre.Posicion[contador] = CrearNodo(Info);// Inserta el nodo Arbol en la posicion correspondiente al NodoVector
                }
                else
                {
                    Insertar(Info, Condicion, padre, contador + 1);
                }
            }
            else 
            {
                if (padre.Padre == null) // Para la primera separacion debe preguntar si tiene padre el nodo en el que nos encontramos
                {
                    if (padre.Posicion[0].Izquierda == null && padre.Posicion[0].Derecha == null) // Sino tiene padre ni hijos debemos separar el nodo en el que nos encontramos
                    {
                        // Declaracion de Nodos de Apoyo
                        NodoVector<T> Arriba = new NodoVector<T>();
                        NodoVector<T> VectorIzquierda = new NodoVector<T>();
                        NodoVector<T> VectorDerecha = new NodoVector<T>();

                        //Obtenemos la primera posicion del nuevo nodo Raiz
                        Arriba.Posicion[0].Data = padre.Posicion[(grado / 2) - 1].Data;

                        // LLenamos los vectores de los hijos tanto derecha como izquiera
                        int VectorPosicion = 0;
                        for (int i = (grado / 2) - 1; i >= 0; i--) //Ciclo de llenado para hijos izquierdos
                        {
                            VectorIzquierda.Posicion[VectorPosicion] = padre.Posicion[i - 1];
                            VectorPosicion++;
                        }
                        VectorPosicion = 0;

                        for (int i = (grado / 2) - 1; i < grado - 1; i++)//Ciclo de llenado para hijos Derechos
                        {
                            VectorIzquierda.Posicion[VectorPosicion] = padre.Posicion[i + 1];
                            VectorPosicion++;
                        }

                        //Igualamos el nodo que subio a la Raiz 
                        Raiz = Arriba;

                        //Insertamos los hijos correspondientes a cada apuntador
                        Raiz.Posicion[0].Izquierda = VectorIzquierda;
                        Raiz.Posicion[0].Derecha = VectorDerecha;
                    }
                    else 
                    {
                        //Tenemos que poner la funcion de sino tiene padre pero el primer nodo tiene hijos entonces debe de buscar la posicion en la que le toca insertarse en el nodo raiz 
                    }
                }
            }
        }


        void BuscarInsert(NodoVector<T>Raiz, T Info, Delegate Condicion) 
        {
            
        }
        
    }
}
