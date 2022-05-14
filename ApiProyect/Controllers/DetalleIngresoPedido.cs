using System.Data.Common;
using System;
using System.Linq;
using ApiProyect.Comands;
using ApiProyect.Models;
using ApiProyect.Results;
using ApiProyect.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;


namespace ApiProyect.Controllers
{
    [ApiController]
    
    public class DetalleIngresoPedidoController : ControllerBase 
    {

        private readonly MEContext db = new MEContext();
        private readonly ILogger<DetalleIngresoPedidoController> _logger;

        public DetalleIngresoPedidoController(ILogger<DetalleIngresoPedidoController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("[controller]/ObtenerDetalleIngreso")]
        public ActionResult<ResultAPI> Get()
        {
            /*var resultado = new ResultAPI();

            
                resultado.Ok = true;
                var cli   = (from c in db.Clientes
                join b in db.Barrios on c.CodBarrio equals b.CodBarrio
                select new DTOListaClientes
                {
                    NombreCliente = c.NombreCliente,
                    Documento = c.Documento,
                    Direccion = c.Direccion,
                    nombreBarrio = b.Nombre,
                    Telefono = c.Telefono
                }).ToList();
                resultado.Return = cli;

                return resultado;*/
            var resultado = new ResultAPI();
            resultado.Ok = true;
            resultado.Return = db.DetalleIngresoPedidos.ToList(); 
            return resultado;
            


        }

        [HttpGet]
        [Route("[controller]/ObtenerDetalleIngreso/{id}")] 
        public ActionResult<ResultAPI> Get3(int id)
        {
            /*var resultado = new ResultAPI();
            try
            {
                resultado.Ok = true;
                var cli   = (from c in db.Clientes
                join b in db.Barrios on c.CodBarrio equals b.CodBarrio
                where c.IdCliente == id
                select new DTOListaClientes
                {
                    NombreCliente = c.NombreCliente,
                    Documento = c.Documento,
                    Direccion = c.Direccion,
                    nombreBarrio = b.Nombre,
                    Telefono = c.Telefono
                }).FirstOrDefault();
                resultado.Return = cli;

                return resultado;
            }

            catch (Exception ex)
            {
                resultado.Ok = false;
                resultado.Error = "Cliente no encontrado";

                return resultado;
            }*/
            var resultado = new ResultAPI();
            try
            {

                var art = db.DetalleIngresoPedidos.Where(c => c.IdDetalleIngresoPedido == id).FirstOrDefault();
                resultado.Ok = true;
                resultado.Return = art;

                return resultado;
            }

            catch (Exception ex)
            {
                resultado.Ok = false;
                resultado.Error = "Detalle de Ingreso de compra no encontrada";

                return resultado;
            }
        }

        [HttpPost] 
        [Route("[controller]/AltaDetalleIngreso")]
        public ActionResult<ResultAPI> AltaDetalleIngreso([FromBody] ComandoCrearDetalleIngresoPedido comando)
        {
            var resultado = new ResultAPI();
            if (comando.IdIngresoPedido.Equals(""))
            {
                resultado.Ok = false;
                resultado.Error = "Ingrese numero del pedido";
                return resultado;
            }
            if (comando.Cantidad.Equals(""))
            {
                resultado.Ok = false;
                resultado.Error = "Ingrese cantidad";
                return resultado;
            }
            if (comando.Precio.Equals(""))
            {
                resultado.Ok = false;
                resultado.Error = "Ingrese precio";
                return resultado;
            }
            if (comando.IdArticulo.Equals(""))
            {
                resultado.Ok = false;
                resultado.Error = "Ingrese articulo";
                return resultado;
            }



            var nt = new DetalleIngresoPedido();
            nt.IdIngresoPedido = comando.IdIngresoPedido;
            nt.Cantidad = comando.Cantidad;
            nt.Precio = comando.Precio;
            nt.IdArticulo = comando.IdArticulo;




            db.DetalleIngresoPedidos.Add(nt);
            db.SaveChanges(); //despues de un insert, update o delte hacer el SaveChanges()

            resultado.Ok = true;
            resultado.Return = db.DetalleIngresoPedidos.ToList();

            return resultado;
        }

        [HttpPut]
        [Route("[controller]/UpdateDetalleIngreso")]
        public ActionResult<ResultAPI> UpdateDetalleIngreso([FromBody] ComandoUpdateDetalleIngresoPedido comando)
        {
            var resultado = new ResultAPI();
            if (comando.IdIngresoPedido.Equals(""))
            {
                resultado.Ok = false;
                resultado.Error = "Ingrese numero del pedido";
                return resultado;
            }
            if (comando.Cantidad.Equals(""))
            {
                resultado.Ok = false;
                resultado.Error = "Ingrese cantidad";
                return resultado;
            }
            if (comando.Precio.Equals(""))
            {
                resultado.Ok = false;
                resultado.Error = "Ingrese precio";
                return resultado;
            }
            if (comando.IdArticulo.Equals(""))
            {
                resultado.Ok = false;
                resultado.Error = "Ingrese articulo";
                return resultado;
            }

            var nt = db.DetalleIngresoPedidos.Where(c => c.IdDetalleIngresoPedido == comando.IdDetalleIngresoPedido).FirstOrDefault();
            if (nt != null)
            {
                nt.IdIngresoPedido = comando.IdIngresoPedido;
                nt.Cantidad = comando.Cantidad;
                nt.Precio = comando.Precio;
                nt.IdArticulo = comando.IdArticulo;
                db.DetalleIngresoPedidos.Update(nt);
                db.SaveChanges();
            }

            resultado.Ok = true;
            resultado.Return = db.DetalleIngresoPedidos.ToList();

            return resultado;
        }

        [HttpDelete]
        [Route("[controller]/EliminarDetalleIngreso{id}")]
        public ActionResult<ResultAPI> deleteById(int id)
        {
            var resultado = new ResultAPI();
            var nt= db.DetalleIngresoPedidos.Where(c => c.IdDetalleIngresoPedido == id).FirstOrDefault();
            db.DetalleIngresoPedidos.Remove(nt);
            db.SaveChanges();

            resultado.Ok = true;
            resultado.Return = db.DetalleIngresoPedidos.ToList();
            return resultado;
        }

    }
}