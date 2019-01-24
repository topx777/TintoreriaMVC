using System;
using Upds.Sistemas.ProgWeb2.Tintoreria.Core;
using Upds.Sistemas.ProgWeb2.Tintoreria.TintoreriaBRL;
namespace Upds.Sistemas.ProgWeb2.Tintoreria.PruebaConsola
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Insertando Cargo");



            //Console.Write("Insertar nuevo cargo?");
            //Console.ReadKey();
            //CargoBrl.Eliminar(2);

            //Console.Write("Cargo Insertado");
            Cliente cliente = new Cliente()
            {
                Ci = "999999999",
                Nombre = "Pepito",
                PrimerApellido = "Fuentes",
                SegundoApellido = "Ramirez",
                Sexo = new Sexo()
                {
                    IdSexo = 1
                },
                FechaNacimiento = new DateTime(1999, 10, 11),
                Usuario = new Usuario()
                {
                    Username = "Pep123",
                    Password = "prueba123",
                    EsAdmin = false
                },
                Borrado = false,
                Nit = 9999016,
                Razon = "Razon",
                FechaRegistro = DateTime.Today
            };
            ClienteBrl.Insertar(cliente);
            Console.ReadKey();
        }
    }
}
