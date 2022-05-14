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
    
    public class DetalleVentaController : ControllerBase 
    {

        private readonly MEContext db = new MEContext();
        private readonly ILogger<DetalleVentaController> _logger;

        public DetalleVentaController(ILogger<DetalleVentaController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("[controller]/ObtenerDetalleVenta")]
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
            resultado.Return = db.DetalleVenta.ToList(); 
            return resultado;
            


        }

        [HttpGet]
        [Route("[controller]/ObtenerDetalleVenta/{id}")] 
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

                var art = db.DetalleVenta.Where(c => c.IdDetalle == id).FirstOrDefault();
                resultado.Ok = true;
                resultado.Return = art;

                return resultado;
            }

            catch (Exception ex)
            {
                resultado.Ok = false;
                resultado.Error = "Detalle de venta no encontrada";

                return resultado;
            }
        }

        [HttpPost] 
        [Route("[controller]/AltaDetalleVenta")]
        public ActionResult<ResultAPI> AltaDetalleVenta([FromBody] ComandoCrearDetalleVenta comando)
        {
            var resultado = new ResultAPI();
            if (comando.IdVenta.Equals(""))
            {
                resultado.Ok = false;
                resultado.Error = "Ingrese numero de venta";
                return resultado;
            }
            if (comando.IdArticulo.Equals(""))
            {
                resultado.Ok = false;
                resultado.Error = "Ingrese articulo";
                return resultado;
            }
            if (comando.Cantidad.Equals(""))
            {
                resultado.Ok = false;
                resultado.Error = "Ingrese cantidad";
                return resultado;
            }
            if (comando.PrecioUnitario.Equals(""))
            {
                resultado.Ok = false;
                resultado.Error = "Ingrese precio unitario";
                return resultado;
            }



            var nt = new DetalleVentum();
            nt.IdVenta = comando.IdVenta;
            nt.IdArticulo = comando.IdArticulo;
            nt.Cantidad = comando.Cantidad;
            nt.PrecioUnitario = comando.PrecioUnitario;




            db.DetalleVenta.Add(nt);
            db.SaveChanges(); //despues de un insert, update o delte hacer el SaveChanges()

            resultado.Ok = true;
            resultado.Return = db.DetalleVenta.ToList();

            return resultado;
        }

        [HttpPut]
        [Route("[controller]/UpdateDetalleVenta")]
        public ActionResult<ResultAPI> UpdateDetalleVenta([FromBody] ComandoUpdateDetalleVenta comando)
        {
            var resultado = new ResultAPI();
            if (comando.IdVenta.Equals(""))
            {
                resultado.Ok = false;
                resultado.Error = "Ingrese numero de venta";
                return resultado;
            }
            if (comando.IdArticulo.Equals(""))
            {
                resultado.Ok = false;
                resultado.Error = "Ingrese articulo";
                return resultado;
            }
            if (comando.Cantidad.Equals(""))
            {
                resultado.Ok = false;
                resultado.Error = "Ingrese cantidad";
                return resultado;
            }
            if (comando.PrecioUnitario.Equals(""))
            {
                resultado.Ok = false;
                resultado.Error = "Ingrese precio unitario";
                return resultado;
            }

            var nt = db.DetalleVenta.Where(c => c.IdDetalle == comando.IdDetalle).FirstOrDefault();
            if (nt != null)
            {
                nt.IdVenta = comando.IdVenta;
                nt.IdArticulo = comando.IdArticulo;
                nt.Cantidad = comando.Cantidad;
                nt.PrecioUnitario = comando.PrecioUnitario;
                db.DetalleVenta.Update(nt);
                db.SaveChanges();
            }

            resultado.Ok = true;
            resultado.Return = db.DetalleVenta.ToList();

            return resultado;
        }

        [HttpDelete]
        [Route("[controller]/EliminarDetalleVenta{id}")]
        public ActionResult<ResultAPI> deleteById(int id)
        {
            var resultado = new ResultAPI();
            var nt= db.DetalleVenta.Where(c => c.IdDetalle == id).FirstOrDefault();
            db.DetalleVenta.Remove(nt);
            db.SaveChanges();

            resultado.Ok = true;
            resultado.Return = db.DetalleVenta.ToList();
            return resultado;
        }

    }
}