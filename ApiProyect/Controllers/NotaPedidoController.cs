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
    
    public class NotaPedidoController : ControllerBase 
    {

        private readonly MEContext db = new MEContext();
        private readonly ILogger<NotaPedidoController> _logger;

        public NotaPedidoController(ILogger<NotaPedidoController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("[controller]/ObtenerOrdenCompra")]
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
            resultado.Return = db.NotaPedidos.ToList(); 
            return resultado;
            


        }

        [HttpGet]
        [Route("[controller]/ObtenerOrdenCompra/{id}")] 
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

                var art = db.NotaPedidos.Where(c => c.IdOrdenCompra == id).FirstOrDefault();
                resultado.Ok = true;
                resultado.Return = art;

                return resultado;
            }

            catch (Exception ex)
            {
                resultado.Ok = false;
                resultado.Error = "Orden de compra no encontrada";

                return resultado;
            }
        }

        [HttpPost] 
        [Route("[controller]/AltaOrdenCompra")]
        public ActionResult<ResultAPI> AltaPedido([FromBody] comandoCrearNotaPedido comando)
        {
            var resultado = new ResultAPI();
            if (comando.FechaEmision.Equals(""))
            {
                resultado.Ok = false;
                resultado.Error = "Ingrese Fecha Emision de la orden";
                return resultado;
            }
            if (comando.FechaEntrega.Equals(""))
            {
                resultado.Ok = false;
                resultado.Error = "Ingrese Fecha de entrega de la orden";
                return resultado;
            }
            if (comando.IdEmpleado.Equals(""))
            {
                resultado.Ok = false;
                resultado.Error = "ingrese Empleado";
                return resultado;
            }



            var nt = new NotaPedido();
            nt.FechaEmision = comando.FechaEmision;
            nt.FechaEntrega = comando.FechaEntrega;
            nt.IdEmpleado = comando.IdEmpleado;




            db.NotaPedidos.Add(nt);
            db.SaveChanges(); //despues de un insert, update o delte hacer el SaveChanges()

            resultado.Ok = true;
            resultado.Return = db.NotaPedidos.ToList();

            return resultado;
        }

        [HttpPut]
        [Route("[controller]/UpdateOrdenCompra")]
        public ActionResult<ResultAPI> UpdatePedido([FromBody] comandoUpdateNotaPedido comando)
        {
            var resultado = new ResultAPI();         
            if (comando.FechaEmision.Equals(""))
            {
                resultado.Ok = false;
                resultado.Error = "Ingrese Fecha Emision de la orden";
                return resultado;
            }
            if (comando.FechaEntrega.Equals(""))
            {
                resultado.Ok = false;
                resultado.Error = "Ingrese Fecha de entrega de la orden";
                return resultado;
            }
            if (comando.IdEmpleado.Equals(""))
            {
                resultado.Ok = false;
                resultado.Error = "ingrese Empleado";
                return resultado;
            }

            var nt = db.NotaPedidos.Where(c => c.IdOrdenCompra == comando.IdOrdenCompra).FirstOrDefault();
            if (nt != null)
            {
                nt.FechaEmision = comando.FechaEmision;
                nt.FechaEntrega = comando.FechaEntrega;
                nt.IdEmpleado = comando.IdEmpleado;
                db.NotaPedidos.Update(nt);
                db.SaveChanges();
            }

            resultado.Ok = true;
            resultado.Return = db.NotaPedidos.ToList();

            return resultado;
        }

        [HttpDelete]
        [Route("[controller]/EliminarOrdenCompra{id}")]
        public ActionResult<ResultAPI> deleteById(int id)
        {
            var resultado = new ResultAPI();
            var nt= db.NotaPedidos.Where(c => c.IdOrdenCompra == id).FirstOrDefault();
            db.NotaPedidos.Remove(nt);
            db.SaveChanges();

            resultado.Ok = true;
            resultado.Return = db.NotaPedidos.ToList();
            return resultado;
        }

    }
}