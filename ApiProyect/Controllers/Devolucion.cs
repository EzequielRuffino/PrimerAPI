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
    
    public class DevolucionController : ControllerBase 
    {

        private readonly MEContext db = new MEContext();
        private readonly ILogger<DevolucionController> _logger;

        public DevolucionController(ILogger<DevolucionController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("[controller]/ObtenerDevolucion")]
        public ActionResult<ResultAPI> Get()
        {
            var resultado = new ResultAPI();


            resultado.Ok = true;
            resultado.Return = db.Devolucion.Include(c=> c.IdEmpleadoNavigation)
                                            .Where(c => c.Flag == 1)
                                            .OrderBy(c=> c.IdDevolucion)
                                            .ToList(); 
            return resultado;

        }


        [HttpGet]
        [Route("[controller]/ObtenerMotivo")]
        public ActionResult<ResultAPI> GetMotivo()
        {
            var resultado = new ResultAPI();
            try
            {
                resultado.Ok = true;
                resultado.Return = db.MotivoDevolucions.ToList();

                return resultado;
            }
            catch (Exception ex)
            {
                resultado.Ok = false;
                resultado.Error = "Error al encontrar motivos";

                return resultado;
            }           
        }

        [HttpGet]
        [Route("[controller]/ObtenerDevolucion/{id}")] 
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

                var v = db.Devolucion.Where(c => c.IdDevolucion == id && c.Flag == 1).FirstOrDefault();
                resultado.Ok = true;
                resultado.Return = v;

                return resultado;
            }

            catch (Exception ex)
            {
                resultado.Ok = false;
                resultado.Error = "Devolucion no encontrada";

                return resultado;
            }
        }

        [HttpPost] 
        [Route("[controller]/AltaDevolucion")]
        public ActionResult<ResultAPI> AltaVenta([FromBody] comandoCrearDevolucion comando)
        {
            var resultado = new ResultAPI();
            if (comando.NroDevolucion.Equals(""))
            {
                resultado.Ok = false;
                resultado.Error = "Ingrese numero devolucion";
                return resultado;
            }
            if (comando.FechaDevolucion.Equals(""))
            {
                resultado.Ok = false;
                resultado.Error = "Ingrese fecha devolucion";
                return resultado;
            }
            if (comando.IdVenta.Equals(""))
            {
                resultado.Ok = false;
                resultado.Error = "ingrese numero venta";
                return resultado;
            }
            if (comando.IdEmpleado.Equals(""))
            {
                resultado.Ok = false;
                resultado.Error = "Ingrese empleado";
                return resultado;
            }
            if (comando.Flag.Equals(""))
            {
                resultado.Ok = false;
                resultado.Error = "Ingrese estado";
                return resultado;
            }




            var d = new Devolucion();
            d.NroDevolucion = comando.NroDevolucion;
            d.FechaDevolucion= comando.FechaDevolucion;
            d.IdVenta= comando.IdVenta;
            d.IdEmpleado= comando.IdEmpleado;
            d.Flag= comando.Flag;



            db.Devolucion.Add(d);
            db.SaveChanges(); //despues de un insert, update o delte hacer el SaveChanges()

            resultado.Ok = true;
            resultado.Return = d;

            return resultado;
        }

        [HttpPut]
        [Route("[controller]/UpdateDevolucion")]
        public ActionResult<ResultAPI> UpdateVenta([FromBody] comandoUpdateDevolucion comando)
        {
            var resultado = new ResultAPI();         
            if (comando.NroDevolucion.Equals(""))
            {
                resultado.Ok = false;
                resultado.Error = "Ingrese numero devolucion";
                return resultado;
            }
            if (comando.FechaDevolucion.Equals(""))
            {
                resultado.Ok = false;
                resultado.Error = "Ingrese fecha devolucion";
                return resultado;
            }
            if (comando.IdVenta.Equals(""))
            {
                resultado.Ok = false;
                resultado.Error = "ingrese numero venta";
                return resultado;
            }
            if (comando.IdEmpleado.Equals(""))
            {
                resultado.Ok = false;
                resultado.Error = "Ingrese empleado";
                return resultado;
            }
            if (comando.Flag.Equals(""))
            {
                resultado.Ok = false;
                resultado.Error = "Ingrese estado";
                return resultado;
            }

            var d = db.Devolucion.Where(c => c.IdDevolucion== comando.IdDevolucion).FirstOrDefault();
            if (d != null)
            {
            d.NroDevolucion = comando.NroDevolucion;
            d.FechaDevolucion= comando.FechaDevolucion;
            d.IdVenta= comando.IdVenta;
            d.IdEmpleado= comando.IdEmpleado;
            d.Flag= comando.Flag;
            db.Devolucion.Update(d);
            db.SaveChanges();
            }

            resultado.Ok = true;
            resultado.Return = db.Devolucion.ToList();

            return resultado;
        }


        [HttpPut]//PREGUNTAR SI DIRECTAMENTE SE PUEDE HACER EN EL PRIMER PUT O CREO COMANDO PARA LA FLAG
        [Route("[controller]/ActualizarFlagDevolucion/{id}")]
        public ActionResult<ResultAPI> UpdateById(comandoFlag comando, int id)
        {
            var resultado = new ResultAPI();

            if (comando.Flag.Equals(""))
            {
                resultado.Ok = false;
                resultado.Error = "Ingrese flag";
                return resultado;
            }

            var cli= db.Devolucion.Where(c => c.IdDevolucion == id).FirstOrDefault();

            if (cli != null)
            {
                cli.Flag = comando.Flag;
                db.Devolucion.Update(cli);
                db.SaveChanges();
            }
            resultado.Ok = true;
            resultado.Return = db.Devolucion.ToList();

            return resultado;
        }

    }
}