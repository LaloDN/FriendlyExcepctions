using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FriendlyExcepctions
{
    class Program
    {
        static void Main(string[] args)
        {
            ExcepcionNombre();
            ExcepcionEdad();
            ExcepcionCarrera();
            Console.WriteLine("Presione cualquier tecla para salir de la aplicación");
            Console.ReadKey();
        }

        //En este método implementamos una excepción donde avisa al usuario si introduce algún dígito o símbolo no permitido en su nombre
        private static void ExcepcionNombre()
        {
            string nombre;
            Console.WriteLine("Introduzca su nombre:");
            nombre = Console.ReadLine();
            try
            {
                foreach(char caracter in nombre){
                    if (!(char.IsLetter(caracter) || (char.IsWhiteSpace(caracter)) ))
                    {
                        throw new Exception("al parecer ha introducido algún caracter que no es una letra del alfabeto,");
                    }
                }
            }catch(Exception ex)
            {
                Console.WriteLine("Se ha producido una excpeción:" + ex.Message + ex.StackTrace);
            }
        }

        //Aquí vamos a tener una excepción que se va a lanzar si el usuario introduce una edad negativa o muy grande, y también
        //validaremos que sea una número.
        private static void ExcepcionEdad()
        {
            Console.WriteLine("\nIntroduzca su edad en años:");
            string aux = Console.ReadLine();
            //Primer bloque try catch, para comprobar si es un dígito la cadena que ha introducido el usuario.
            try
            {
                if (aux.All(char.IsDigit))
                {
                    int edad = int.Parse(aux);
                    //Segundo bloque try catch, aquí comprobaremos que la edad introducida es positiva pero no muy grande
                    try
                    {
                        if (edad < 0 || edad > 150)
                        {
                            throw new Exception("la edad introducida no es válida,");
                        }
                    }catch (Exception ex)
                    {
                        Console.WriteLine("Se ha producido una excpeción:" + ex.Message + ex.StackTrace);
                    }
                }
                else
                {
                    throw new Exception("lo entrada que ha introducido no es un número entero valido,");
                }
            }catch(Exception ex)
            {
                Console.WriteLine("Se ha producido una excepción:" + ex.Message + ex.StackTrace);
            }
        }

        //En esta excepción comprobamos que el usuario introduce un número que este dentro de un rango para accesar a un elemento
        //dentro de un array
        public static void ExcepcionCarrera()
        {
            string[] carreras = new string[6] { "LCC","LMAD","LM","LSTI","LF","LA"};
            string aux;
            Console.WriteLine("\n*LICENCIATURAS*:");
            Console.WriteLine("\n\t1-Ciencias computacionales (LCC)\n\t2-Multimedia y animación digital (LMAD)\n\t3-Matemáticas (LM)");
            Console.WriteLine("\t4-Seguridad en tecnología e información (LSTI)\n\t5-Física (LF)\n\t6-Actuaría (LA)");
            Console.WriteLine("\nDigite el número de la licenciatura que esta cursando:");
            aux = Console.ReadLine();
            //Primer bloque try catch, hacemos la comprobación de que se nos ha introducido un número
            try
            {
                if (aux.All(char.IsDigit))
                {
                    int lic = int.Parse(aux);
                    //Segundo bloque try catch, aquí aseguraremos que el usuario eligió una licenciatura dentro del rango
                    try
                    {
                        if(lic<1 || lic > 6)
                        {
                            throw new Exception("el número de la licenciatura que ha introducido no existe,");
                        }
                        else
                        {
                            Console.WriteLine("Su licenciatura es: "+carreras[lic-1]);
                        }
                    }catch(Exception ex)
                    {
                        Console.WriteLine("Se ha producido una excepción:" + ex.Message + ex.StackTrace);
                    }
                }
                else
                {
                    throw new Exception(" la entrada que ha introducido no es un número entero valido,");
                }
            }catch(Exception ex)
            {
                Console.WriteLine("Se ha producido una excepción: " + ex.Message + ex.StackTrace);
            }

        }
    }

}
