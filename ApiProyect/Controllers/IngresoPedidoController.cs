using System.Data.Common;
using System;
using System.Linq;
using ApiProyect.Comands;
using ApiProyect.Models;
using ApiProyect.Results;
//using ApiProyect.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Cors;
using System.Data;


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
            var resultado = new ResultAPI();
            resultado.Ok = true;
            resultado.Return = db.IngresoPedidoProveedors.Include(c=> c.IdEmpleadoNavigation)
                                            .Include(c=> c.IdProveedorNavigation )
                                            .Where(c => c.Flag == 1)
                                            .OrderBy(c=> c.IdIngresoPedido)
                                             .ToList(); 
                            return resultado;
        }

        [HttpGet]
        [Route("[controller]/ObtenerIngresoPedido/{id}")] 
        public ActionResult<ResultAPI> Get3(int id)
        {
                        var resultado = new ResultAPI();
            try
            {

                var ip = db.IngresoPedidoProveedors.Where(c => c.IdIngresoPedido == id && c.Flag == 1).FirstOrDefault();
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
            if (comando.NroRemitoPedido.Equals(""))
            {
                resultado.Ok = false;
                resultado.Error = "ingrese Numero de remito";
                return resultado;
            }
            if (comando.TipoFactura.Equals(""))
            {
                resultado.Ok = false;
                resultado.Error = "ingrese Tipo de factura";
                return resultado;
            }
            if (comando.Pago.Equals(""))
            {
                resultado.Ok = false;
                resultado.Error = "ingrese Pago";
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
            if (comando.Flag.Equals(""))
            {
                resultado.Ok = false;
                resultado.Error = "Ingrese estado";
                return resultado;
            }

            var ip = new IngresoPedidoProveedor();
            ip.IdProveedor = comando.IdProveedor;
            ip.IdEmpleado = comando.IdEmpleado;
            ip.NroRemitoPedido = comando.NroRemitoPedido;
            ip.TipoFactura = comando.TipoFactura;
            ip.Pago = comando.Pago;
            ip.Fecha = comando.Fecha;
            ip.NroOrdenCompra = comando.NroOrdenCompra;
            ip.Flag = comando.Flag;




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
            if (comando.NroRemitoPedido.Equals(""))
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
            if (comando.Pago.Equals(""))
            {
                resultado.Ok = false;
                resultado.Error = "ingrese Pago";
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
            if (comando.Flag.Equals(""))
            {
                resultado.Ok = false;
                resultado.Error = "Ingrese estado";
                return resultado;
            }

            var ip = db.IngresoPedidoProveedors.Where(c => c.IdIngresoPedido == comando.IdIngresoPedido).FirstOrDefault();
            if (ip != null)
            {
            ip.IdProveedor = comando.IdProveedor;
            ip.IdEmpleado = comando.IdEmpleado;
            ip.NroRemitoPedido = comando.NroRemitoPedido;
            ip.TipoFactura = comando.TipoFactura;
            ip.Pago = comando.Pago;
            ip.Fecha = comando.Fecha;
            ip.NroOrdenCompra = comando.NroOrdenCompra;
            ip.Flag = comando.Flag;

                db.IngresoPedidoProveedors.Update(ip);
                db.SaveChanges();
            }

            resultado.Ok = true;
            resultado.Return = db.IngresoPedidoProveedors.ToList();

            return resultado;
        }

        [HttpPut]//PREGUNTAR SI DIRECTAMENTE SE PUEDE HACER EN EL PRIMER PUT O CREO COMANDO PARA LA FLAG
        [Route("[controller]/ActualizarFlagIngresoPedido/{id}")]
        public ActionResult<ResultAPI> UpdateById(comandoFlag comando, int id)
        {
            var resultado = new ResultAPI();

            if (comando.Flag.Equals(""))
            {
                resultado.Ok = false;
                resultado.Error = "Ingrese flag";
                return resultado;
            }

            var cli= db.IngresoPedidoProveedors.Where(c => c.IdIngresoPedido == id).FirstOrDefault();

            if (cli != null)
            {
                cli.Flag = comando.Flag;
                db.IngresoPedidoProveedors.Update(cli);
                db.SaveChanges();
            }
            resultado.Ok = true;
            resultado.Return = db.IngresoPedidoProveedors.ToList();

            return resultado;
        }

    }
}