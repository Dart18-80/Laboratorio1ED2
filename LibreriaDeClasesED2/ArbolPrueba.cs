using System;
using System.Collections.Generic;
using System.Text;

namespace LibreriaDeClasesED2
{
    public class ArbolPrueba<T> where T : IComparable
    {
        NodoVector<T> Raiz;
        int Degree;
        bool RaizEntrar = true;

        public ArbolPrueba(int Grado)
        {
            Degree = Grado;
            NodoVector<T> NodoV = new NodoVector<T>(Grado);// Es un espacio mas, cuando se llene por conpleto se tiene que balancear
            NodoV.Vector = new NodoArbolB<T>[Grado];
            Raiz = NodoV;
        }

        public void Insert(T NewNodo, Delegate Comparacion)
        {
            NodoArbolB<T> NuevoMe = new NodoArbolB<T>();
            NuevoMe.Data = NewNodo;
            if (Raiz.Vector[0] == null)
            {
                Raiz.Vector[0] = NuevoMe;
            }
            else
            {
                Insert(NuevoMe, Raiz, Comparacion);
            }
        }

        public void Insert(NodoArbolB<T> NewNodo, NodoVector<T> VectorPadre, Delegate Comparacion)
        {
            if (VectorPadre.Vector[0].Izquierda == null)
            {
                bool ciclo = true;
                for (int i = 0; i <= Degree - 1 && ciclo == true; i++)
                {
                    if (VectorPadre.Vector[i] == null)
                    {
                        VectorPadre.Vector[i] = NewNodo;
                        ciclo = false;
                    }
                }
                NodoArbolB<T> Auxiliar = new NodoArbolB<T>();
                VectorPadre.Vector = ShellSort(VectorPadre.Vector, Comparacion);
                if (FullVector(VectorPadre.Vector))
                {
                    if (RaizEntrar)
                    {
                        Auxiliar = UploadNode(VectorPadre.Vector);
                        Raiz.Vector = VaciarVector(Raiz.Vector);
                        Raiz.Vector[0] = Auxiliar;
                        Raiz.Vector[0].Izquierda.Padre = Raiz;
                        Raiz.Vector[0].Derecha.Padre = Raiz;
                        Raiz.Padre = null;
                        RaizEntrar = false;
                    }
                    else
                    {
                        Auxiliar = UploadNode(VectorPadre.Vector);

                    }
                }
            }
            else
            {
                int Comp = 0;
                bool VerificacionDeEntrada = true;
                for (int i = 0; i <= Degree - 2 && VerificacionDeEntrada; i++)
                {
                    Comp = Convert.ToInt32(Comparacion.DynamicInvoke(NewNodo.Data, VectorPadre.Vector[i].Data));
                    if (Comp < 0)
                    {
                        Comp = -1;
                        VerificacionDeEntrada = false;
                        Insert(NewNodo, VectorPadre.Vector[i].Izquierda, Comparacion);
                    }
                    else
                    {
                        if (VectorPadre.Vector[i] != null)
                        {
                            VerificacionDeEntrada = true;
                        }
                        else
                        {
                            Insert(NewNodo, VectorPadre.Vector[i].Derecha, Comparacion);
                        }
                    }
                }

            }
        }

        //Insertar Un desvordamiento que no es la Raiz 
        public void InsertNotRoot(NodoArbolB<T> NodeToInsert, NodoVector<T> Padre, Delegate Comparacion)
        {
            int indice = -1;
            for (int i = 0; i <= Degree - 2; i++)
            {
                int CompAfter = Convert.ToInt32(Comparacion.DynamicInvoke(NodeToInsert.Data, Padre.Vector[i].Data));
                if (indice == -1)
                {
                    if (CompAfter < 0)
                    {
                        indice = i;
                    }
                    else
                    {
                        if (i == Degree - 2)
                        {
                            indice = Degree - 2;
                        }
                    }
                }
            }
            NodoArbolB<T> AuxCambio = new NodoArbolB<T>();
            if (indice == 0)
            {

                for (int i = Degree - 2; i >= 0; i--)
                {
                    if (Padre.Padre.Vector[i].Data != null)
                    {
                        AuxCambio = Padre.Padre.Vector[i];
                        Padre.Padre.Vector[i + 1] = AuxCambio;
                    }
                }
                Padre.Padre.Vector[0] = NodeToInsert;
                if (Padre.Padre.Vector[1] != null)
                {
                    Padre.Padre.Vector[1].Izquierda = NodeToInsert.Derecha;
                }
            }
            else if (indice == Degree - 2)
            {
                Padre.Padre.Vector[indice + 1] = NodeToInsert;
                Padre.Padre.Vector[indice].Derecha = NodeToInsert.Izquierda;
            }
            else
            {
                for (int i = indice; i <= Degree - 2; i++)
                {
                    if (Padre.Padre.Vector[i].Data != null)
                    {
                        AuxCambio = Padre.Padre.Vector[i];
                        Padre.Padre.Vector[i + 1] = AuxCambio;
                    }
                }
                Padre.Padre.Vector[indice] = NodeToInsert;
                Padre.Padre.Vector[indice - 1].Derecha = NodeToInsert.Izquierda;
                if (Padre.Padre.Vector[indice + 1] != null)
                {
                    Padre.Padre.Vector[indice + 1].Izquierda = NodeToInsert.Derecha;
                }
            }
        }

        //Vaciar vector
        public NodoArbolB<T>[] VaciarVector(NodoArbolB<T>[] NodoAVaciar)
        {
            for (int i = 0; i <= Degree - 1; i++)
            {
                NodoAVaciar[i] = null;
            }
            return NodoAVaciar;
        }

        // Llenado del Vector en la posicion que se dice
        /*NodoArbolB<T>[] SheetFilling(T New, NodoArbolB<T>[] Capsule,Delegate Condicion) 
        {
            return SheetFilling(New, Capsule, 0, Condicion);
        }
        // Procedimiento de busqueda de Indice
        NodoArbolB<T>[] SheetFilling(T New, NodoArbolB<T>[] Capsule, int IndexVector, Delegate Condicion)
        {
            if (Capsule[IndexVector].Data == null)
            {
                Capsule[IndexVector].Data = New;
                ShellSort(Capsule,Condicion);
                return Capsule;
            }
            else 
            {
                return SheetFilling(New, Capsule, IndexVector+1,Condicion);
            }
        }
        */
        //Ordenar el Vector 
        public NodoArbolB<T>[] ShellSort(NodoArbolB<T>[] Ordenar, Delegate Condicion)
        {
            for (int k = 0; k < Degree - 1; k++)
            {
                for (int f = 0; f < (Degree - 1) - k; f++)
                {
                    if (Ordenar[f] != null && Ordenar[f + 1] != null)
                    {
                        int Comparar = Convert.ToInt32(Condicion.DynamicInvoke(Ordenar[f].Data, Ordenar[f + 1].Data));
                        if (Comparar > 0)
                        {
                            NodoArbolB<T> aux;
                            aux = Ordenar[f];
                            Ordenar[f] = Ordenar[f + 1];
                            Ordenar[f + 1] = aux;
                        }
                    }
                }
            }
            return Ordenar;
        }
        // Separacion de Nodo por desvordamiento
        public NodoArbolB<T> UploadNode(NodoArbolB<T>[] UploadVector)
        {
            NodoArbolB<T> Aux = new NodoArbolB<T>();
            NodoVector<T> Left = new NodoVector<T>(Degree);
            NodoVector<T> Right = new NodoVector<T>(Degree);

            int Div = (Degree / 2) - 1;
            Aux = UploadVector[Div - 1];

            for (int i = 0; i < Div; i++)
            {
                Left.Vector[i] = UploadVector[i];
            }
            int Begin = 0;
            for (int i = Degree - 1; i > Div; i--)
            {
                Right.Vector[Begin] = UploadVector[i];
                Begin++;
            }

            Aux = UploadVector[Div];


            Aux.Izquierda = Left;
            Aux.Derecha = Right;

            return Aux;
        }


        // Verifica si el nodo desvordado es la raiz
        public bool RootComparacion(NodoArbolB<T>[] Padre, Delegate Comparacion)
        {
            bool Retorno = false;
            int Verificacion;
            for (int i = 0; i <= Padre.Length - 1 && Retorno == false; i++)
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
            bool Vacio = true;
            for (int i = 0; i <= Degree - 1; i++)
            {
                if (Verificar[i] == null)
                {
                    Vacio = false;
                }
            }
            return Vacio;
        }

        public int HasNode(NodoArbolB<T>[] Verificar)
        {
            int i = 0;
            return HasNode(Verificar, i);
        }

        public int HasNode(NodoArbolB<T>[] Verificar, int Contador)
        {
            if (Contador == Degree - 1)
            {
                return Contador;
            }
            else
            {
                if (Verificar[Contador] != null)
                {
                    return HasNode(Verificar, Contador + 1);
                }
                else
                {
                    return Contador;
                }
            }
        }

        public void Delete(T New, NodoVector<T> Capsule, Delegate Comparacion)
        {
            int i = 0;
            bool vacio = true;
            while (vacio)
            {
                if (Capsule.Vector[i].Data != null)
                {
                    int compar = Convert.ToInt32(Comparacion.DynamicInvoke(New, Capsule.Vector[i].Data));
                    if (compar == 0)
                    {
                        vacio = false;
                        Delete(New);
                    }
                    else if (compar < 0)
                    {
                        if (Capsule.Vector[i].Izquierda != null)
                        {
                            Delete(New, Capsule.Vector[i].Izquierda, Comparacion);
                        }
                    }
                    else if (compar > 0)
                    {
                        if (Capsule.Vector[i+1].Data!=null)
                        {
                            i++;
                            Delete(New, Capsule, Comparacion); //Si no se encontro se pasa al siguiente del vector si es que existe
                        }
                        else
                        {
                            if (Capsule.Vector[i].Derecha!=null)
                            {
                                Delete(New, Capsule.Vector[i].Derecha, Comparacion);
                            }
                        }
                    }
                    else
                    {
                        vacio = false; // no se encontro el valor en el arbol
                    }
                }
                i++;
            }
        }
        public void Delete(T New)
        {

        }
    }
}