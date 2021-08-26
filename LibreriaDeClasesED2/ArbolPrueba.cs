using System;
using System.Collections.Generic;
using System.Text;

namespace LibreriaDeClasesED2
{
    class ArbolPrueba<T> where T : IComparable
    {
        NodoVector<T> Raiz;
        int Degree; 

        public ArbolPrueba(int Grado)
        {
            Degree = Grado;
            NodoVector<T> NodoV = new NodoVector<T>(Grado);
            NodoV.Vector = new NodoArbolB<T>[Grado];
            Raiz = NodoV;
        }

        // Llenado del Vector en la posicion que se dice
        NodoVector<T> SheetFilling(T New, NodoVector<T> Capsule,Delegate Condicion) 
        {
            return SheetFilling(New, Capsule, 0, Condicion);
        }
        // Procedimiento de busqueda de Indice
        NodoVector<T> SheetFilling(T New, NodoVector<T> Capsule, int IndexVector, Delegate Condicion)
        {
            if (Capsule.Vector[IndexVector].Data == null)
            {
                Capsule.Vector[IndexVector].Data = New;
                ShellSort(Capsule.Vector,Condicion);
                return Capsule;
            }
            else 
            {
                return SheetFilling(New, Capsule, IndexVector+1,Condicion);
            }
        }
        //Ordenar el Vector 
        public void ShellSort(NodoArbolB<T>[] Ordenar, Delegate Condicion)
        {
            int Salto = 0;
            int Ciclo = 0;
            T Aux = default;
            int e = 0;
            Salto = Ordenar.Length / 2;
            while (Salto > 0)
            {
                Ciclo = 1;
                while (Ciclo != 0)
                {
                    Ciclo = 0;
                    e = 1;
                    while (e <= (Ordenar.Length - Salto))
                    {
                        int Comparacion = Convert.ToInt32(Condicion.DynamicInvoke(Ordenar[e - 1].Data, Ordenar[(e - 1) + Salto].Data));
                        if (Comparacion > 0)
                        {
                            Aux = Ordenar[(e - 1) + Salto].Data;
                            Ordenar[(e - 1) + Salto].Data = Ordenar[e - 1].Data;
                            Ordenar[(e - 1)].Data = Aux;
                            Ciclo = 1;
                        }
                        e++;
                    }
                }
                Salto = Salto / 2;
            }
        }
        // Separacion de Nodo por desvordamiento
        public NodoArbolB<T> UploadNode(NodoArbolB<T>[] UploadVector) 
        {
            NodoArbolB<T> Aux = new NodoArbolB<T>();
            NodoVector<T> Left = new NodoVector<T>(Degree);
            NodoVector<T> Right = new NodoVector<T>(Degree);

            int Div = (UploadVector.Length / 2) - 1;
            Aux = UploadVector[Div];

            for (int i = 0; i<Div; i++) 
            {
                Left.Vector[i] =UploadVector[i];
            }
            int Begin = 0;
            for (int i = UploadVector.Length-1; i>Div; i++) 
            {
                Right.Vector[Begin] = UploadVector[i];
                Begin++;
            }

            Aux = UploadVector[Div];

            Aux.Izquierda = Left;
            Aux.Derecha = Right;

            return Aux;
        }

        public void Desvordamiento(NodoArbolB<T>[] Padre, Delegate Comparacion)
        {
            for (int i = 0; i <= Padre.Length-1;) 
            {
                if (HasNode(Padre, i)) 
                {

                }
            }
        }

        public bool RootComparacion(NodoArbolB<T>[] Padre, Delegate Comparacion) 
        {
            bool Retorno = false;
            int Verificacion;
            for (int i = 0; i <= Padre.Length-1 && Retorno == false; i++)
            {
                Verificacion = Convert.ToInt32(Comparacion.DynamicInvoke(Padre[i].Data, Raiz.Vector[i].Data));
                if (Verificacion != 0) 
                {
                    Retorno = true;
                }
            }
            return Retorno;
        }




        // Verifica si en verdad tiene todos los espacios del vector llenos
        public bool FullVector(NodoArbolB<T>[] Verificar) 
        {
            bool Ciclo = true;
            bool Vacio = false;
            for (int i = 0; i <= Verificar.Length-1; i++) 
            {
                if (Verificar[i].Data == null) 
                {
                    Vacio = true;
                }
            }
            return Vacio; 
        }

        public bool HasNode(NodoArbolB<T>[] Verificar, int i) 
        {
            bool Vacio = true;
            if (Verificar[i].Data == null) 
            {
                Vacio = false;
            }
            return Vacio;
        }

    }
}
