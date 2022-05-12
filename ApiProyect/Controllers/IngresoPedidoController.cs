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
    
    public class IngresoPedidoController : ControllerBase 
    {

        private readonly MEContext db = new MEContext();
        private readonly ILogger<IngresoPedidoController> _logger;

        public IngresoPedidoController(ILogger<IngresoPedidoController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("[controller]/ObtenerIngresoPedido")]
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
            resultado.Return = db.IngresoPedidoProveedors.ToList(); 
            return resultado;
            


        }

        [HttpGet]
        [Route("[controller]/ObtenerIngresoPedido/{id}")] 
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

                var ip = db.IngresoPedidoProveedors.Where(c => c.IdIngresoPedido == id).FirstOrDefault();
                resultado.Ok = true;
                resultado.Return = ip;

                return resultado;
            }

            catch (Exception ex)
            {
                resultado.Ok = false;
                resultado.Error = "Ingreso de pedido no encontrada";

                return resultado;
            }
        }

        [HttpPost] 
        [Route("[controller]/AltaIngresoPedido")]
        public ActionResult<ResultAPI> AltaIngreso([FromBody] comandoCrearIngresoPedido comando)
        {
            var resultado = new ResultAPI();
            if (comando.IdProveedor.Equals(""))
            {
                resultado.Ok = false;
                resultado.Error = "Ingrese identificador del proveedor";
                return resultado;
            }
            if (comando.IdEmpleado.Equals(""))
            {
                resultado.Ok = false;
                resultado.Error = "Ingrese identificador del empleado";
                return resultado;
            }
            if (comando.NroFacturaPedido.Equals(""))
            {
                resultado.Ok = false;
                resultado.Error = "ingrese Numero de factura";
                return resultado;
            }
            if (comando.TipoFactura.Equals(""))
            {
                resultado.Ok = false;
                resultado.Error = "ingrese Tipo de factura";
                return resultado;
            }
            if (comando.Fecha.Equals(""))
            {
                resultado.Ok = false;
                resultado.Error = "ingrese fecha";
                return resultado;
            }
            if (comando.NroOrdenCompra.Equals(""))
            {
                resultado.Ok = false;
                resultado.Error = "ingrese Numero de Orden de compra";
                return resultado;
            }


            var ip = new IngresoPedidoProveedor();
            ip.IdProveedor = comando.IdProveedor;
            ip.IdEmpleado = comando.IdEmpleado;
            ip.NroFacturaPedido = comando.NroFacturaPedido;
            ip.TipoFactura = comando.TipoFactura;
            ip.Fecha = comando.Fecha;
            ip.NroOrdenCompra = comando.NroOrdenCompra;




            db.IngresoPedidoProveedors.Add(ip);
            db.SaveChanges(); //despues de un insert, update o delte hacer el SaveChanges()

            resultado.Ok = true;
            resultado.Return = db.IngresoPedidoProveedors.ToList();

            return resultado;
        }

        [HttpPut]
        [Route("[controller]/UpdateIngresoPedido")]
        public ActionResult<ResultAPI> UpdateIngreso([FromBody] comandoUpdateIngresoPedido comando)
        {
            var resultado = new ResultAPI();         
            if (comando.IdProveedor.Equals(""))
            {
                resultado.Ok = false;
                resultado.Error = "Ingrese identificador del proveedor";
                return resultado;
            }
            if (comando.IdEmpleado.Equals(""))
            {
                resultado.Ok = false;
                resultado.Error = "Ingrese identificador del empleado";
                return resultado;
            }
            if (comando.NroFacturaPedido.Equals(""))
            {
                resultado.Ok = false;
                resultado.Error = "ingrese Numero de factura";
                return resultado;
            }
            if (comando.TipoFactura.Equals(""))
            {
                resultado.Ok = false;
                resultado.Error = "ingrese Tipo de factura";
                return resultado;
            }
            if (comando.Fecha.Equals(""))
            {
                resultado.Ok = false;
                resultado.Error = "ingrese fecha";
                return resultado;
            }
            if (comando.NroOrdenCompra.Equals(""))
            {
                resultado.Ok = false;
                resultado.Error = "ingrese Numero de Orden de compra";
                return resultado;
            }

            var ip = db.IngresoPedidoProveedors.Where(c => c.IdIngresoPedido == comando.IdIngresoPedido).FirstOrDefault();
            if (ip != null)
            {
            ip.IdProveedor = comando.IdProveedor;
            ip.IdEmpleado = comando.IdEmpleado;
            ip.NroFacturaPedido = comando.NroFacturaPedido;
            ip.TipoFactura = comando.TipoFactura;
            ip.Fecha = comando.Fecha;
            ip.NroOrdenCompra = comando.NroOrdenCompra;

                db.IngresoPedidoProveedors.Update(ip);
                db.SaveChanges();
            }

            resultado.Ok = true;
            resultado.Return = db.IngresoPedidoProveedors.ToList();

            return resultado;
        }

        [HttpDelete]
        [Route("[controller]/EliminarIngresoPedido{id}")]
        public ActionResult<ResultAPI> deleteById(int id)
        {
            var resultado = new ResultAPI();
            var ip= db.IngresoPedidoProveedors.Where(c => c.IdIngresoPedido == id).FirstOrDefault();
            db.IngresoPedidoProveedors.Remove(ip);
            db.SaveChanges();

            resultado.Ok = true;
            resultado.Return = db.IngresoPedidoProveedors.ToList();
            return resultado;
        }

    }
}