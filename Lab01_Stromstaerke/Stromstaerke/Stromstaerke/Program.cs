using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stromstaerke
{
    internal class Program
    {
        static void Main(string[] args)
        {
            float Widerstand = 0;
            float Spannung = 0;
            float Strom;
            string Widerstand1;

            do
            {
                Console.Write("Widerstand (Ohm, kOHM, MOhm): ");
                Widerstand1 = Console.ReadLine();
                string[] Widerstand_split = Widerstand1.Split(' ');
                if (Widerstand1 != "ende" && Widerstand1 != "q")
                {
                    float Widerstand_float = float.Parse(Widerstand_split[0]);

                    switch (Widerstand_split[1])
                    {
                        case "Ohm":
                            Widerstand = Widerstand_float * 1;
                            break;

                        case "kOhm":
                            Widerstand = Widerstand_float * 1000;
                            break;

                        case "MOhm":
                            Widerstand = Widerstand_float * 1000000;
                            break;

                        default:
                            Console.WriteLine("Falsche Eingabe!");
                            break;

                    }

                    Console.Write("Spannung (V, kV, mV): ");
                    string Spannung1 = Console.ReadLine();
                    string[] Spannung_split = Spannung1.Split(' ');
                    float Spannung_float = float.Parse(Spannung_split[0]);

                    switch (Spannung_split[1])
                    {
                        case "V":
                            Spannung = Spannung_float * 1;
                            break;

                        case "kV":
                            Spannung = Spannung_float * 1000;
                            break;

                        case "mV":
                            Spannung = Spannung_float / 1000;
                            break;

                        default:
                            Console.WriteLine("Falsche Eingabe!");
                            break;

                    }

                    Strom = Spannung / Widerstand;

                    Console.WriteLine("Die Stromstärke beträgt {0} A", Strom);
                }
                
            } while (Widerstand1 != "ende");
            
            Console.ReadKey();

        }
    }
}
