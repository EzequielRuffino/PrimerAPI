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
            var resultado = new ResultAPI();
            resultado.Ok = true;
            resultado.Return = db.DetalleNotaPedidos.Include(c=> c.IdArticuloNavigation)
                                                        .Where(c => c.Flag == 1)
            .OrderBy(c=> c.NroOrdenCompra)
                                                    .ToList(); 
            return resultado;
            


        }

        [HttpGet]
        [Route("[controller]/ObtenerDetalleOrdenCompra/{id}")] 
        public ActionResult<ResultAPI> Get3(int id)
        {
            var resultado = new ResultAPI();
            try
            {

                var art = db.DetalleNotaPedidos.Where(c => c.NroDetalleOrdenCompra == id && c.Flag == 1).FirstOrDefault();
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
            if (comando.Flag.Equals(""))
            {
                resultado.Ok = false;
                resultado.Error = "Ingrese estado";
                return resultado;
            }


            var nt = new DetalleNotaPedido();
            nt.NroOrdenCompra = comando.NroOrdenCompra;
            nt.Cantidad = comando.Cantidad;
            nt.IdArticulo = comando.IdArticulo;
            nt.Flag = comando.Flag;




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
            if (comando.Flag.Equals(""))
            {
                resultado.Ok = false;
                resultado.Error = "Ingrese estado";
                return resultado;
            }

            var nt = db.DetalleNotaPedidos.Where(c => c.NroDetalleOrdenCompra == comando.NroDetalleOrdenCompra).FirstOrDefault();
            if (nt != null)
            {
                nt.NroOrdenCompra = comando.NroOrdenCompra;
                nt.Cantidad = comando.Cantidad;
                nt.IdArticulo = comando.IdArticulo;
                nt.Flag = comando.Flag;
                db.DetalleNotaPedidos.Update(nt);
                db.SaveChanges();
            }

            resultado.Ok = true;
            resultado.Return = db.DetalleNotaPedidos.ToList();

            return resultado;
        }

        [HttpPut]//PREGUNTAR SI DIRECTAMENTE SE PUEDE HACER EN EL PRIMER PUT O CREO COMANDO PARA LA FLAG
        [Route("[controller]/ActualizarFlagDetalleNotaPedido/{id}")]
        public ActionResult<ResultAPI> UpdateById(comandoFlag comando, int id)
        {
            var resultado = new ResultAPI();

            if (comando.Flag.Equals(""))
            {
                resultado.Ok = false;
                resultado.Error = "Ingrese flag";
                return resultado;
            }

            var cli= db.DetalleNotaPedidos.Where(c => c.NroDetalleOrdenCompra == id).FirstOrDefault();

            if (cli != null)
            {
                cli.Flag = comando.Flag;
                db.DetalleNotaPedidos.Update(cli);
                db.SaveChanges();
            }
            resultado.Ok = true;
            resultado.Return = db.DetalleNotaPedidos.ToList();

            return resultado;
        }

    }
}