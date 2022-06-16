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
    
    public class DetalleDevolucionController : ControllerBase 
    {

        private readonly MEContext db = new MEContext();
        private readonly ILogger<DetalleDevolucionController> _logger;

        public DetalleDevolucionController(ILogger<DetalleDevolucionController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("[controller]/ObtenerDetalleDevolucion")]
        public ActionResult<ResultAPI> Get()
        {
            var resultado = new ResultAPI();
            resultado.Ok = true;
            resultado.Return = db.DetalleDevolucion.Include(c=> c.IdArticuloNavigation)
                                                    .Include(c=> c.IdMotivoNavigation)
                                                    .Where(c => c.Flag == 1)
                                                    .OrderBy(c=> c.IdDevolucion)
                                                    .ToList(); 
            return resultado;
            


        }

        [HttpGet]
        [Route("[controller]/ObtenerMotivo")]
        public ActionResult<ResultAPI> getTipoArticulo()
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
        [Route("[controller]/ObtenerDetalleDevolucion/{id}")] 
        public ActionResult<ResultAPI> Get3(int id)
        {
            var resultado = new ResultAPI();
            try
            {

                var v = db.DetalleDevolucion.Where(c => c.Flag == 1).FirstOrDefault();
                resultado.Ok = true;
                resultado.Return = v;

                return resultado;
            }

            catch (Exception ex)
            {
                resultado.Ok = false;
                resultado.Error = "Detalle Devolucion no encontrada";

                return resultado;
            }
        }

        [HttpPost] 
        [Route("[controller]/AltaDetalleDevolucion")]
        public ActionResult<ResultAPI> AltaVenta([FromBody] comandoCrearDetalleDevolucion comando)
        {
            var resultado = new ResultAPI();
            if (comando.IdDevolucion.Equals(""))
            {
                resultado.Ok = false;
                resultado.Error = "Ingrese identidicar devolucion";
                return resultado;
            }
            if (comando.IdArticulo.Equals(""))
            {
                resultado.Ok = false;
                resultado.Error = "Ingrese articulo";
                return resultado;
            }
            if (comando.IdMotivo.Equals(""))
            {
                resultado.Ok = false;
                resultado.Error = "Ingrese motivo";
                return resultado;
            }
            if (comando.Cantidad.Equals(""))
            {
                resultado.Ok = false;
                resultado.Error = "ingrese cantidad";
                return resultado;
            }
            if (comando.Flag.Equals(""))
            {
                resultado.Ok = false;
                resultado.Error = "Ingrese estado";
                return resultado;
            }

            var d = new DetalleDevolucion();
            d.IdDevolucion = comando.IdDevolucion;
            d.IdArticulo = comando.IdArticulo;
            d.IdMotivo= comando.IdMotivo;
            d.Cantidad= comando.Cantidad;
            d.Flag= comando.Flag;



            db.DetalleDevolucion.Add(d);
            db.SaveChanges(); //despues de un insert, update o delte hacer el SaveChanges()

            resultado.Ok = true;
            //resultado.Return = db.DetalleDevolucion.ToList();

            return resultado;
        }

        [HttpPut]
        [Route("[controller]/UpdateDevolucion")]
        public ActionResult<ResultAPI> UpdateVenta([FromBody] comandoUpdateDetalleDevolucion comando)
        {
            var resultado = new ResultAPI();         
            if (comando.IdDevolucion.Equals(""))
            {
                resultado.Ok = false;
                resultado.Error = "Ingrese identidicar devolucion";
                return resultado;
            }
            if (comando.IdArticulo.Equals(""))
            {
                resultado.Ok = false;
                resultado.Error = "Ingrese identidicar articulo";
                return resultado;
            }
            if (comando.IdMotivo.Equals(""))
            {
                resultado.Ok = false;
                resultado.Error = "Ingrese motivo";
                return resultado;
            }
            if (comando.Cantidad.Equals(""))
            {
                resultado.Ok = false;
                resultado.Error = "ingrese cantidad";
                return resultado;
            }


            var d = db.DetalleDevolucion.Where(c => c.IdDetalleDevolucion== comando.IdDetalleDevolucion).FirstOrDefault();
            if (d != null)
            {
            d.IdDevolucion = comando.IdDevolucion;
            d.IdArticulo = comando.IdArticulo;
            d.IdMotivo= comando.IdMotivo;
            d.Cantidad= comando.Cantidad;
            db.DetalleDevolucion.Update(d);
            db.SaveChanges();
            }

            resultado.Ok = true;
            resultado.Return = d;

            return resultado;
        }

        [HttpPut]//PREGUNTAR SI DIRECTAMENTE SE PUEDE HACER EN EL PRIMER PUT O CREO COMANDO PARA LA FLAG
        [Route("[controller]/ActualizarFlagDetalleDevolucion/{id}")]
        public ActionResult<ResultAPI> UpdateById(comandoFlag comando, int id)
        {
            var resultado = new ResultAPI();

            if (comando.Flag.Equals(""))
            {
                resultado.Ok = false;
                resultado.Error = "Ingrese flag";
                return resultado;
            }

            var cli= db.DetalleDevolucion.Where(c => c.IdDetalleDevolucion== id).FirstOrDefault();

            if (cli != null)
            {
                cli.Flag = comando.Flag;
                db.DetalleDevolucion.Update(cli);
                db.SaveChanges();
            }
            resultado.Ok = true;
            resultado.Return = db.DetalleDevolucion.ToList();

            return resultado;
        }


    }
}