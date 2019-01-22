using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Upds.Sistemas.ProgWeb2.Tintoreria.Core;
using Upds.Sistemas.ProgWeb2.Tintoreria.TintoreriaBRL;

namespace Upds.Sistemas.ProgWeb2.Tintoreria.PruebaConsola
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Insertando Cargo");

            Cargo cargo = new Cargo()
            {
                Nombre = "Secretaria"
            };

            Console.Write("Insertar nuevo cargo?");
            Console.ReadKey();
            CargoBrl.Insertar(cargo);

            Console.Write("Cargo Insertado");
            Console.ReadKey();
        }
    }
}
