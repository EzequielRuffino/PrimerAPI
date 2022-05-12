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
            resultado.Return = db.Venta.ToList(); 
            return resultado;
            


        }

        [HttpGet]
        [Route("[controller]/ObtenerVenta/{id}")] 
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

                var v = db.Venta.Where(c => c.IdVenta == id).FirstOrDefault();
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



            var v = new Ventum();
            v.NroFactura = comando.NroFactura;
            v.TipoFactura= comando.TipoFactura;
            v.FechaVenta= comando.FechaVenta;
            v.IdCliente = comando.IdCliente;
            v.IdEmpleado= comando.IdEmpleado;
            v.IdFormaPago= comando.IdFormaPago;



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

            var v = db.Venta.Where(c => c.IdVenta== comando.IdVenta).FirstOrDefault();
            if (v != null)
            {
                v.NroFactura = comando.NroFactura;
                v.TipoFactura= comando.TipoFactura;
                v.FechaVenta= comando.FechaVenta;
                v.IdCliente = comando.IdCliente;
                v.IdEmpleado= comando.IdEmpleado;
                v.IdFormaPago= comando.IdFormaPago;
                db.Venta.Update(v);
                db.SaveChanges();
            }

            resultado.Ok = true;
            resultado.Return = db.Venta.ToList();

            return resultado;
        }

        [HttpDelete]
        [Route("[controller]/EliminarVenta{id}")]
        public ActionResult<ResultAPI> deleteById(int id)
        {
            var resultado = new ResultAPI();
            var v= db.Venta.Where(c => c.IdVenta == id).FirstOrDefault();
            db.Venta.Remove(v);
            db.SaveChanges();

            resultado.Ok = true;
            resultado.Return = db.Venta.ToList();
            return resultado;
        }

    }
}