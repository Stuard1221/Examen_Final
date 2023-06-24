using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculadoraBasica
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Calculadora Básica");
            Console.WriteLine("------------------");

            Console.Write("Ingrese el primer número: ");
            double num1 = Convert.ToDouble(Console.ReadLine());

            Console.Write("Ingrese el segundo número: ");
            double num2 = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine();
            Console.WriteLine("Resultados: ");
            Console.WriteLine("Suma: " + Sumar(num1, num2));
            Console.WriteLine("Resta: " + Restar(num1, num2));
            Console.WriteLine("Multiplicación: " + Multiplicar(num1, num2));
            Console.WriteLine("División: " + Dividir(num1, num2));

            Console.ReadLine();

        }

        static double Sumar(double num1, double num2)
        {
            return num1 + num2;
        }

        static double Restar(double num1, double num2)
        {
            return num1 - num2;
        }

        static double Multiplicar(double num1, double num2)
        {
            return num1 * num2;
        }

        static double Dividir(double num1, double num2)
        {
            if (num2 != 0)
            {
                return num1 / num2;
            }
            else
            {
                Console.WriteLine("Error: División entre 0 no es posible.");
                return double.NaN;
            }
        }
    }
}

