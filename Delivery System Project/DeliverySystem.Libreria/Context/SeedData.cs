using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliverySystem.Libreria.Context
{
    public static class SeedData
    {
        public static string conection = @"Data Source=(local);Initial Catalog=DeliverySystemDatabase1;"
                + "Integrated Security=SSPI;";

        public static bool SeedDataDefault()
        {
            var conn = new SqlConnection(SeedData.conection);
            var deliverySystem = new DeliverySystemContext(conn);
            var clients = deliverySystem.Client.ToList();
            var products = deliverySystem.Producto.ToList();
            var ordenes = deliverySystem.OrdenDeEntrega.ToList();

            if (!clients.Any())
            {
                deliverySystem.Client.Add(new Security.Client
                {
                    Identidad = "1602199700135",
                    Nombres = "Joel Ramiro",
                    Apellidos = "Caballero Castellanos",
                    CorreoElectronico = "joel.ramirocc@gmail.com",
                    Direccion = "Barrio la Primavera, Choloma Cortes",
                    FechaNacimiento = new DateTime(1997, 05, 26),
                    Telefono = 31549099,
                });

                deliverySystem.Client.Add(new Security.Client
                {
                    Identidad = "1602199300132",
                    Nombres = "Bessy Yolani",
                    Apellidos = "Caballero Castellanos",
                    CorreoElectronico = "bessy.yolani@gmail.com",
                    Direccion = "Villas del Marquez, Choloma Cortes",
                    FechaNacimiento = new DateTime(1993, 05, 26),
                    Telefono = 98605328,
                });

                deliverySystem.SaveChanges();
            }

            if (!products.Any())
            {
                deliverySystem.Producto.Add(new Security.Producto
                {
                    Codigo = "BAS",
                    Nombre = "Baleada",
                    Descripcion = "Baleada sencilla",
                    Cantidad = 15,
                    PrecioUnitario = 10,
                });
                deliverySystem.Producto.Add(new Security.Producto
                {
                    Codigo = "BAP",
                    Nombre = "Baleada",
                    Descripcion = "Baleada con pollo",
                    Cantidad = 10,
                    PrecioUnitario = 15,
                });
                deliverySystem.Producto.Add(new Security.Producto
                {
                    Codigo = "TAC",
                    Nombre = "Taco",
                    Descripcion = "Tacos de pollo",
                    Cantidad = 20,
                    PrecioUnitario = 25,
                });

                deliverySystem.SaveChanges();
            }

            if (!ordenes.Any())
            {
                try
                {
                    var orden = deliverySystem.OrdenDeEntrega.Add(new Security.OrdenDeEntrega
                    {
                        Codigo = "1",
                        Descripcion = "Little boys foods",
                        FechaEntrega = DateTime.Now,
                        IdentidadCliente = "1602199700135",
                        Total = 1500,
                    });
                    deliverySystem.OrdenDeEntregaDetalle.Add(new Security.OrdenDeEntregaDetalle
                    {
                        OrdenDeEntregaCodigo = "1",
                        Cantidad = 5,
                        CodigoProducto = "TAC",
                        Total = 125,
                    });
                    deliverySystem.OrdenDeEntregaDetalle.Add(new Security.OrdenDeEntregaDetalle
                    {
                        OrdenDeEntregaCodigo = "1",
                        Cantidad = 5,
                        CodigoProducto = "BAP",
                        Total = 75,
                    });

                    deliverySystem.SaveChanges();
                }
                catch (Exception m)
                {
                    var mmm = m.Message;
                }

            }

            return true;
        }
    }
}
