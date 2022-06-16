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
    
    public class VentaController : ControllerBase 
    {

        private readonly MEContext db = new MEContext();
        private readonly ILogger<VentaController> _logger;

        public VentaController(ILogger<VentaController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("[controller]/ObtenerVenta")]
        public ActionResult<ResultAPI> Get()
        {

            var resultado = new ResultAPI();
            resultado.Ok = true;
            resultado.Return = db.Venta.Include(c=> c.IdClienteNavigation)
                                        .Include(c=> c.IdEmpleadoNavigation)
                                        .Include(c=> c.IdFormaPagoNavigation)
                                           .Where(c => c.Flag == 1)
                                            .OrderBy(c=> c.IdVenta)
                                             .ToList(); 
            return resultado;

            


        }

        [HttpGet]
        [Route("[controller]/FormaPago")]
        public ActionResult<ResultAPI> getFormaPago()
        {
            var resultado = new ResultAPI();
            try
            {
                resultado.Ok = true;
                resultado.Return = db.FormaPagos.ToList();

                return resultado;
            }
            catch (Exception ex)
            {
                resultado.Ok = false;
                resultado.Error = "Error al encontrar forma de pagos";

                return resultado;
            }
        }

        [HttpGet]
        [Route("[controller]/ObtenerVenta/{id}")] 
        public ActionResult<ResultAPI> Get3(int id)
        {
            var resultado = new ResultAPI();
            try
            {

                var v = db.Venta.Where(c => c.IdVenta == id && c.Flag == 1).FirstOrDefault();
                resultado.Ok = true;
                resultado.Return = v;

                return resultado;
            }

            catch (Exception ex)
            {
                resultado.Ok = false;
                resultado.Error = "Venta no encontrada";

                return resultado;
            }
        }

        //etiqueta
        [HttpGet]
        [Route("[controller]/ObtenerVentaEtiqueta/{id}")] 
        public ActionResult<ResultAPI> Get34(int id)
        {
            var resultado = new ResultAPI();
            try
            {

                var v = db.Venta.Include(c => c.IdClienteNavigation)
                .Include(c => c.IdEmpleadoNavigation)
                .Include(c=> c.IdFormaPagoNavigation)
                .Where(c => c.IdVenta == id && c.Flag == 1).FirstOrDefault();
                resultado.Ok = true;
                resultado.Return = v;

                return resultado;
            }

            catch (Exception ex)
            {
                resultado.Ok = false;
                resultado.Error = "Venta no encontrada";

                return resultado;
            }
        }

        [HttpPost] 
        [Route("[controller]/AltaVenta")]
        public ActionResult<ResultAPI> AltaVenta([FromBody] comandoCrearFactura comando)
        {
            var resultado = new ResultAPI();
            if (comando.NroFactura.Equals(""))
            {
                resultado.Ok = false;
                resultado.Error = "Ingrese numero Venta";
                return resultado;
            }
            if (comando.TipoFactura.Equals(""))
            {
                resultado.Ok = false;
                resultado.Error = "Ingrese tipo factura";
                return resultado;
            }
            if (comando.FechaVenta.Equals(""))
            {
                resultado.Ok = false;
                resultado.Error = "ingrese fecha de venta";
                return resultado;
            }
            if (comando.IdCliente.Equals(""))
            {
                resultado.Ok = false;
                resultado.Error = "Ingrese cliente";
                return resultado;
            }
            if (comando.IdEmpleado.Equals(""))
            {
                resultado.Ok = false;
                resultado.Error = "Ingrese empleado";
                return resultado;
            }
            if (comando.IdFormaPago.Equals(""))
            {
                resultado.Ok = false;
                resultado.Error = "ingrese forma de pago";
                return resultado;
            }
            if (comando.Flag.Equals(""))
            {
                resultado.Ok = false;
                resultado.Error = "Ingrese estado";
                return resultado;
            }


            var v = new Ventum();
            v.NroFactura = comando.NroFactura;
            v.TipoFactura= comando.TipoFactura;
            v.FechaVenta= comando.FechaVenta;
            v.IdCliente = comando.IdCliente;
            v.IdEmpleado= comando.IdEmpleado;
            v.IdFormaPago= comando.IdFormaPago;
            v.Flag = comando.Flag;



            db.Venta.Add(v);
            db.SaveChanges(); //despues de un insert, update o delte hacer el SaveChanges()

            resultado.Ok = true;
            resultado.Return = db.Venta.ToList();

            return resultado;
        }

        [HttpPut]
        [Route("[controller]/UpdateVenta")]
        public ActionResult<ResultAPI> UpdateVenta([FromBody] comandoUpdateFactura comando)
        {
            var resultado = new ResultAPI();         
            if (comando.NroFactura.Equals(""))
            {
                resultado.Ok = false;
                resultado.Error = "Ingrese numero venta";
                return resultado;
            }
            if (comando.TipoFactura.Equals(""))
            {
                resultado.Ok = false;
                resultado.Error = "Ingrese tipo factura";
                return resultado;
            }
            if (comando.FechaVenta.Equals(""))
            {
                resultado.Ok = false;
                resultado.Error = "ingrese fecha de venta";
                return resultado;
            }
            if (comando.IdCliente.Equals(""))
            {
                resultado.Ok = false;
                resultado.Error = "Ingrese cliente";
                return resultado;
            }
            if (comando.IdEmpleado.Equals(""))
            {
                resultado.Ok = false;
                resultado.Error = "Ingrese empleado";
                return resultado;
            }
            if (comando.IdFormaPago.Equals(""))
            {
                resultado.Ok = false;
                resultado.Error = "ingrese forma de pago";
                return resultado;
            }
            if (comando.Flag.Equals(""))
            {
                resultado.Ok = false;
                resultado.Error = "Ingrese estado";
                return resultado;
            }
            var v = db.Venta.Where(c => c.IdVenta== comando.IdVenta).FirstOrDefault();
            if (v != null)
            {
                v.NroFactura = comando.NroFactura;
                v.TipoFactura= comando.TipoFactura;
                v.FechaVenta= comando.FechaVenta;
                v.IdCliente = comando.IdCliente;
                v.IdEmpleado= comando.IdEmpleado;
                v.IdFormaPago= comando.IdFormaPago;
                v.Flag = comando.Flag;
                db.Venta.Update(v);
                db.SaveChanges();
            }

            resultado.Ok = true;
            resultado.Return = db.Venta.ToList();

            return resultado;
        }

        [HttpPut]//PREGUNTAR SI DIRECTAMENTE SE PUEDE HACER EN EL PRIMER PUT O CREO COMANDO PARA LA FLAG
        [Route("[controller]/ActualizarFlagVenta/{id}")]
        public ActionResult<ResultAPI> UpdateById(comandoFlag comando, int id)
        {
            var resultado = new ResultAPI();

            if (comando.Flag.Equals(""))
            {
                resultado.Ok = false;
                resultado.Error = "Ingrese flag";
                return resultado;
            }

            var cli= db.Venta.Where(c => c.IdVenta == id).FirstOrDefault();

            if (cli != null)
            {
                cli.Flag = comando.Flag;
                db.Venta.Update(cli);
                db.SaveChanges();
            }
            resultado.Ok = true;
            resultado.Return = db.Venta.ToList();

            return resultado;
        }

    }
}