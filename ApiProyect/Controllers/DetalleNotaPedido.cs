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
    
    public class DetalleNotaPedidoController : ControllerBase 
    {

        private readonly MEContext db = new MEContext();
        private readonly ILogger<DetalleNotaPedidoController> _logger;

        public DetalleNotaPedidoController(ILogger<DetalleNotaPedidoController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("[controller]/ObtenerDetalleOrdenCompra")]
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
            resultado.Return = db.DetalleNotaPedidos.ToList(); 
            return resultado;
            


        }

        [HttpGet]
        [Route("[controller]/ObtenerDetalleOrdenCompra/{id}")] 
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

                var art = db.DetalleNotaPedidos.Where(c => c.NroDetalleOrdenCompra == id).FirstOrDefault();
                resultado.Ok = true;
                resultado.Return = art;

                return resultado;
            }

            catch (Exception ex)
            {
                resultado.Ok = false;
                resultado.Error = "Detalle de orden de compra no encontrada";

                return resultado;
            }
        }

        [HttpPost] 
        [Route("[controller]/AltaDetalleOrdenCompra")]
        public ActionResult<ResultAPI> AltaDetallePedido([FromBody] comandoCrearDetalleNotaPedido comando)
        {
            var resultado = new ResultAPI();
            if (comando.NroOrdenCompra.Equals(""))
            {
                resultado.Ok = false;
                resultado.Error = "Ingrese numero de la orden de compra";
                return resultado;
            }
            if (comando.Cantidad.Equals(""))
            {
                resultado.Ok = false;
                resultado.Error = "Ingrese cantidad";
                return resultado;
            }
            if (comando.IdArticulo.Equals(""))
            {
                resultado.Ok = false;
                resultado.Error = "Ingrese Articulo";
                return resultado;
            }



            var nt = new DetalleNotaPedido();
            nt.NroOrdenCompra = comando.NroOrdenCompra;
            nt.Cantidad = comando.Cantidad;
            nt.IdArticulo = comando.IdArticulo;




            db.DetalleNotaPedidos.Add(nt);
            db.SaveChanges(); //despues de un insert, update o delte hacer el SaveChanges()

            resultado.Ok = true;
            resultado.Return = db.DetalleNotaPedidos.ToList();

            return resultado;
        }

        [HttpPut]
        [Route("[controller]/UpdateDetalleOrdenCompra")]
        public ActionResult<ResultAPI> UpdateDetallePedido([FromBody] comandoUpdateDetalleNotaPedido comando)
        {
            var resultado = new ResultAPI();
            if (comando.NroOrdenCompra.Equals(""))
            {
                resultado.Ok = false;
                resultado.Error = "Ingrese numero de la orden de compra";
                return resultado;
            }
            if (comando.Cantidad.Equals(""))
            {
                resultado.Ok = false;
                resultado.Error = "Ingrese cantidad";
                return resultado;
            }
            if (comando.IdArticulo.Equals(""))
            {
                resultado.Ok = false;
                resultado.Error = "Ingrese Articulo";
                return resultado;
            }

            var nt = db.DetalleNotaPedidos.Where(c => c.NroDetalleOrdenCompra == comando.NroDetalleOrdenCompra).FirstOrDefault();
            if (nt != null)
            {
                nt.NroOrdenCompra = comando.NroOrdenCompra;
                nt.Cantidad = comando.Cantidad;
                nt.IdArticulo = comando.IdArticulo;
                db.DetalleNotaPedidos.Update(nt);
                db.SaveChanges();
            }

            resultado.Ok = true;
            resultado.Return = db.DetalleNotaPedidos.ToList();

            return resultado;
        }

        [HttpDelete]
        [Route("[controller]/EliminarDetalleOrdenCompra{id}")]
        public ActionResult<ResultAPI> deleteById(int id)
        {
            var resultado = new ResultAPI();
            var nt= db.DetalleNotaPedidos.Where(c => c.NroDetalleOrdenCompra == id).FirstOrDefault();
            db.DetalleNotaPedidos.Remove(nt);
            db.SaveChanges();

            resultado.Ok = true;
            resultado.Return = db.DetalleNotaPedidos.ToList();
            return resultado;
        }

    }
}