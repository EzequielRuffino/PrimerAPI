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
            var resultado = new ResultAPI();
            resultado.Ok = true;
            resultado.Return = db.NotaPedidos.Include(c=> c.IdEmpleadoNavigation)
                                            .Where(c => c.Flag == 1)
                                            .OrderBy(c=> c.IdOrdenCompra)
                                             .ToList(); 
            return resultado;

        }

        [HttpGet]
        [Route("[controller]/ObtenerOrdenCompra/{id}")] 
        public ActionResult<ResultAPI> Get3(int id)
        {
                        var resultado = new ResultAPI();
            try
            {

                var art = db.NotaPedidos.Where(c => c.IdOrdenCompra == id && c.Flag == 1).FirstOrDefault();
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
            if (comando.Flag.Equals(""))
            {
                resultado.Ok = false;
                resultado.Error = "Ingrese estado";
                return resultado;
            }


            var nt = new NotaPedido();
            nt.FechaEmision = comando.FechaEmision;
            nt.FechaEntrega = comando.FechaEntrega;
            nt.IdEmpleado = comando.IdEmpleado;
            nt.Flag = comando.Flag;



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
            if (comando.Flag.Equals(""))
            {
                resultado.Ok = false;
                resultado.Error = "Ingrese estado";
                return resultado;
            }

            var nt = db.NotaPedidos.Where(c => c.IdOrdenCompra == comando.IdOrdenCompra).FirstOrDefault();
            if (nt != null)
            {
                nt.FechaEmision = comando.FechaEmision;
                nt.FechaEntrega = comando.FechaEntrega;
                nt.IdEmpleado = comando.IdEmpleado;
                nt.Flag = comando.Flag;
                db.NotaPedidos.Update(nt);
                db.SaveChanges();
            }

            resultado.Ok = true;
            resultado.Return = db.NotaPedidos.ToList();

            return resultado;
        }

        [HttpPut]//PREGUNTAR SI DIRECTAMENTE SE PUEDE HACER EN EL PRIMER PUT O CREO COMANDO PARA LA FLAG
        [Route("[controller]/ActualizarFlagNotaPedido/{id}")]
        public ActionResult<ResultAPI> UpdateById(comandoFlag comando, int id)
        {
            var resultado = new ResultAPI();

            if (comando.Flag.Equals(""))
            {
                resultado.Ok = false;
                resultado.Error = "Ingrese flag";
                return resultado;
            }

            var cli= db.NotaPedidos.Where(c => c.IdOrdenCompra == id).FirstOrDefault();

            if (cli != null)
            {
                cli.Flag = comando.Flag;
                db.NotaPedidos.Update(cli);
                db.SaveChanges();
            }
            resultado.Ok = true;
            resultado.Return = db.NotaPedidos.ToList();

            return resultado;
        }

    }
}