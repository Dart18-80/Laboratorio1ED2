using System;
using LibreriaDeClasesED2;

namespace ConsolaArbolB
{
    class Program
    {
        delegate int DelegadosN(int Numero1, int Numero2);
        static void Main(string[] args)
        {
            Console.WriteLine("Arbol B");
            Console.WriteLine("Ingrese el valor del grado:");
            int val = Convert.ToInt16(Console.ReadLine());
            bool OpArbol = true;

            ArbolPrueba<int> NuevoArbolCons = new ArbolPrueba<int>(val);
            Enteros CallDatosNumeros = new Enteros();
            DelegadosN InvocarNumero = new DelegadosN(CallDatosNumeros.CompareToNumero);

            while (OpArbol)//while general
            {
                Console.WriteLine("Seleccione la opcion que desea realizar");
                Console.WriteLine("1) Ingresar valores uno por uno");
                Console.WriteLine("2) Ingresar valores en conjunto"); 
                Console.WriteLine("3) Eliminar");
                Console.WriteLine("4) Buscar");
                Console.WriteLine("5) Salir del Programa");
                int opcion = Convert.ToInt32(Console.ReadLine());

                if (opcion==1)
                {
                    bool OpArbol1 = true;
                    while (OpArbol1)//while de ingreso uno por uno
                    {
                        Console.WriteLine("Ingrese un valor numerico:");
                        int valorUno = Convert.ToInt32(Console.ReadLine());
                        NuevoArbolCons.Insert(valorUno, InvocarNumero);

                        Console.WriteLine("1) Seguir ingresando valores");
                        Console.WriteLine("2) Salir del ingreso de valores uno por uno");
                        int Exit1 = Convert.ToInt32(Console.ReadLine());
                        if (Exit1 == 2) 
                        {
                            OpArbol1 = false;
                        }
                        else {}
                    }
                }
                else if (opcion==2)
                {
                    bool OpArbol2 = true;
                    while (OpArbol2)//while del ingreso en conjunto de valores
                    {
                        Console.WriteLine("Ingrese un conjunto de valores como el ejemplo:");
                        Console.WriteLine("Ejm:1,2,3,4,5 (sin espacios entre numeros y comas)");
                        string ValorConj= Convert.ToString(Console.ReadLine());
                        string[] NumerosdeConj = ValorConj.Split(',');
                        int lengtg = NumerosdeConj.Length-1;
                        for (int i = 0; i < NumerosdeConj.Length-1; i++)
                        {
                            int[] cadena=new int[lengtg];
                            cadena[i] = Convert.ToInt32(NumerosdeConj[i]);
                        }

                        Console.WriteLine("1) Seguir ingresando valores en conjunto");
                        Console.WriteLine("2) Salir del ingreso de valores por conjunto");
                        int Exit2 = Convert.ToInt32(Console.ReadLine());
                        if (Exit2 == 2)
                        {
                            OpArbol2 = false;
                        }
                        else { }
                    }
                }
                else if (opcion==3)
                {
                    bool OpArbol3 = true;
                    while (OpArbol3)
                    {
                        Console.WriteLine("Ingrese el valor que desea eliminar:");
                        int valorElim = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("1) Seguir elimianndo valores");
                        Console.WriteLine("2) Salir de la eliminacion");
                        int Exit3 = Convert.ToInt32(Console.ReadLine());
                        if (Exit3 == 2)
                        {
                            OpArbol3 = false;
                        }
                        else { }
                    }
                }
                else if (opcion==4)
                {

                }
                else if (opcion==5)
                {
                    OpArbol = false;
                }
                else
                {
                    OpArbol = false;
                }
            }
        }
    }
}
