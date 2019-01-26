using System;
using System.Collections.Generic;
using Upds.Sistemas.ProgWeb2.Tintoreria.Core;
using Upds.Sistemas.ProgWeb2.Tintoreria.TintoreriaBRL;
namespace Upds.Sistemas.ProgWeb2.Tintoreria.PruebaConsola
{
    class Program
    {
        static void Main(string[] args)
        {

            //Correo correo = new Correo()
            //{
            //    Nombre = "mauricio@gmail.com",
            //    Principal=true
            //};
            //CorreoBrl.Insertar(correo, 26);
            //Console.WriteLine("Insertando Cargo");



            //Console.Write("Insertar nuevo cargo?");
            //Console.ReadKey();
            //CargoBrl.Eliminar(2);

            //Console.Write("Cargo Insertado");
            
            Cliente cliente = new Cliente()
            {
                Ci = "999999999",
                Nombre = "Cliente",
                PrimerApellido = "Mauri",
                SegundoApellido = "Gama",
                Sexo = new Sexo()
                {
                    IdSexo = 1
                },
                FechaNacimiento = new DateTime(1999, 10, 11),
                Usuario = new Usuario()
                {
                    Username = "cli123",
                    Password = "prueba123",
                    EsAdmin = false
                },
                Borrado = false,
                Nit = "222333",
                Razon = "Razon",
                FechaRegistro = DateTime.Now,
                Correos = new List<Correo>()
                    {
                        new Correo()
                        {
                            Nombre = "cliente1@gmail.com",
                            Principal = true
                        },
                        new Correo()
                        {
                            Nombre = "cliente1@hotmail.com",
                            Principal = false
                        }
                    },
                Direcciones = new List<Direccion>()
                    {
                        new Direccion()
                        {
                            Descripcion = "Av. de las casas",
                            Latitud = 16.2555,
                            Longitud = 33.667,
                            Tipo = new Tipo()
                            {
                                IdTipo = 1
                            }
                        }
                    },
                Telefonos = new List<Telefono>()
                    {
                        new Telefono()
                        {
                            Numero = "4414017",
                            Tipo = new Tipo()
                            {
                                IdTipo = 1
                            }
                        }
                    }

            };
            ClienteBrl.Insertar(cliente);

            /*

            Personal personal = new Personal()
            {
                IdPersona = 15,
                Ci = "9511300",
                Nombre = "Jaunito",
                PrimerApellido = "Agreda",
                SegundoApellido = "Paniagua",
                Sexo = new Sexo
                {
                    IdSexo = 1,
                },
                FechaNacimiento = new DateTime(1995, 5, 29),
                Correos = new List<Correo>()
                {
                    new Correo()
                    {
                        Nombre = "topxsan@gmail.com",
                        Principal = true
                    },
                    new Correo()
                    {
                        Nombre = "topx555@hotmail.com",
                        Principal = false
                    }
                },
                Usuario = new Usuario()
                {
                    Username = "topx777",
                    Password = "slr8830213",
                    EsAdmin = false
                },
                Direcciones = new List<Direccion>()
                {
                    new Direccion()
                    {
                        Descripcion = "Av. Dorvigni 1827",
                        Latitud = 17.25555345,
                        Longitud = 36.66778812,
                        Tipo = new Tipo()
                        {
                            IdTipo = 1
                        }
                    }
                },
                Telefonos = new List<Telefono>()
                {
                    new Telefono()
                    {
                        Numero = "4414017",
                        Tipo = new Tipo()
                        {
                            IdTipo = 1
                        }
                    }
                },
                Borrado = false,
                CodPersonal = "FX12222",
                FechaIngreso = DateTime.Now,
                Cargo = new Cargo()
                {
                    IdCargo = 3
                },
                Sueldo = 2500
            };

            //PersonalBrl.Insertar(personal);

            //Personal personal = PersonalBrl.Get(15);
            //PersonalBrl.Actualizar(personal);

            PersonalBrl.Eliminar(15);

            Personal personale = PersonalBrl.Get(15);

            personale.Dump(Console.Out);
            personale.Usuario.Dump(Console.Out);
            personale.Cargo.Dump(Console.Out);

            foreach (Telefono x in personale.Telefonos)
            {
                x.Dump(Console.Out);
            }

            foreach (Direccion x in personale.Direcciones)
            {
                x.Dump(Console.Out);
            }

            foreach (Correo x in personale.Correos)
            {
                x.Dump(Console.Out);
            }

            //Console.ReadKey();*/
        }
    }
}
