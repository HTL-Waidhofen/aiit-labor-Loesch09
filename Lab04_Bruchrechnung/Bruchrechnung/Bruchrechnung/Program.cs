using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bruchrechnung
{
    class Bruch
    {
        private int zaehler;
        private int nenner;

        public Bruch(int zaehler, int nenner)
        {
            this.zaehler = zaehler;
            this.nenner = nenner;
        }

        public int getZaehler()
        {
            return zaehler;
        }

        public int getNenner()
        {
            return nenner;
        }

        public void SetZaehler(int zaehler)
        {
            this.zaehler = zaehler;
        }

        public void SetNenner(int nenner)
        {
            if (nenner == 0)
            {
                throw new Exception();
            }
            this.nenner = nenner;
        }

        public override string ToString()
        {
            return $"{zaehler} / {nenner}";
        }

        public void Kuerzen()
        {
            int kleinster = Math.Min(zaehler, nenner);
            for (int i = kleinster; i > 1; i--)
            {
                if ((zaehler % i ==  0) && (nenner % i == 0))
                {
                    nenner = nenner / i;
                    zaehler = zaehler / i;
                }
            }
        }

        public static Bruch Parse(string str)
        {
            string[] teile = str.Split('/');
            int zaehler = int.Parse(teile[0]);
            int nenner = int.Parse(teile[1]);
            return new Bruch(zaehler, nenner);
        }

        public void Add(Bruch b)
        {
            int n = this.nenner * b.getNenner();
            int z = this.zaehler * b.getNenner() + b.getZaehler() * this.nenner;
            this.nenner = n;
            this.zaehler = z;
            Kuerzen();
        }

        public void Subtract(Bruch b)
        {
            int n = this.nenner * b.getNenner();
            int z = this.zaehler * b.getNenner() - b.getZaehler() * this.nenner;
            this.zaehler = z;
            this.nenner = n;
            Kuerzen();
        }

        public void Multiply(Bruch b)
        {
            int n = this.nenner * b.getNenner();
            int z = this.zaehler * b.getZaehler();
            this.zaehler = z;
            this.nenner = n;
            Kuerzen();
        }

        public void Divide(Bruch b)
        {
            int n = this.nenner * b.getZaehler();
            int z = this.zaehler * b.getNenner();
            this.zaehler = z;
            this.nenner = n;
            Kuerzen();
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Bitte Bruch eingeben: ");
            string line1 = Console.ReadLine();
            string line2 = Console.ReadLine();

            Bruch b1 = Bruch.Parse(line1);
            Bruch b2 = Bruch.Parse(line2);
            b1.Kuerzen();

            b1.add(b2);

            Console.WriteLine(b1);

            Console.ReadKey();
        }
    }
}
