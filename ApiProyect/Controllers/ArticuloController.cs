using System;
using System.Linq;
using ApiProyect.Comands;
using ApiProyect.Models;
using ApiProyect.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ApiProyect.Controllers
{
    [ApiController]
    
    public class ArticuloController : ControllerBase 
    {

        private readonly MEContext db = new MEContext();
        private readonly ILogger<ArticuloController> _logger;

        public ArticuloController(ILogger<ArticuloController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("[controller]/ObtenerArticulo")]
        public ActionResult<ResultAPI> Get()
        {
            var resultado = new ResultAPI();
            resultado.Ok = true;
            resultado.Return = db.Articulos.Where(c => c.Flag == 1).ToList(); 
            return resultado;
        }

        [HttpGet]
        [Route("[controller]/ObtenerArticulo/{id}")] 
        public ActionResult<ResultAPI> Get3(int id)
        {
            var resultado = new ResultAPI();
            try
            {

                var art = db.Articulos.Where(c => c.IdArticulo == id && c.Flag == 1).FirstOrDefault();
                resultado.Ok = true;
                resultado.Return = art;

                return resultado;
            }

            catch (Exception ex)
            {
                resultado.Ok = false;
                resultado.Error = "Articulo no encontrado";

                return resultado;
            }
        }


        [HttpPost] 
        [Route("[controller]/AltaCliente")]
        public ActionResult<ResultAPI> AltaArticulo([FromBody] comandoCrearArticulo comando)
        {
            var resultado = new ResultAPI();
            if (comando.NombreArticulo.Equals(""))
            {
                resultado.Ok = false;
                resultado.Error = "ingrese nombre del articulo";
                return resultado;
            }
            if (comando.Descripcion.Equals(""))
            {
                resultado.Ok = false;
                resultado.Error = "ingrese descripcion";
                return resultado;
            }
            if (comando.IdTipoArticulo.Equals(""))
            {
                resultado.Ok = false;
                resultado.Error = "ingrese tipo de articulo";
                return resultado;
            }
            if (comando.PrecioVenta.Equals(""))
            {
                resultado.Ok = false;
                resultado.Error = "ingrese precio";
                return resultado;
            }
            if (comando.IdTalle.Equals(""))
            {
                resultado.Ok = false;
                resultado.Error = "ingrese talle";
                return resultado;
            }
            if (comando.IdMarca.Equals(""))
            {
                resultado.Ok = false;
                resultado.Error = "ingrese marca";
                return resultado;
            }
            if (comando.Cantidad.Equals(""))
            {
                resultado.Ok = false;
                resultado.Error = "ingrese cantidad";
                return resultado;
            }
            if (comando.FechaModificicacion.Equals(""))
            {
                resultado.Ok = false;
                resultado.Error = "ingrese fecha";
                return resultado;
            }
            if (comando.IdEstadoArticulo.Equals(""))
            {
                resultado.Ok = false;
                resultado.Error = "ingrese estado del articulo";
                return resultado;
            }
             if (comando.Flag.Equals(""))
            {
                resultado.Ok = false;
                resultado.Error = "ingrese flag";
                return resultado;
            }
            

            var art = new Articulo();
            art.NombreArticulo = comando.NombreArticulo;
            art.Descripcion = comando.Descripcion;
            art.IdTipoArticulo = comando.IdTipoArticulo;
            art.PrecioVenta = comando.PrecioVenta;
            art.IdTalle = comando.IdTalle;
            art.IdMarca = comando.IdMarca;
            art.Cantidad = comando.Cantidad;
            art.FechaModificicacion = comando.FechaModificicacion;
            art.IdEstadoArticulo = comando.IdEstadoArticulo;
            art.Flag = comando.Flag;




            db.Articulos.Add(art);
            db.SaveChanges(); //despues de un insert, update o delte hacer el SaveChanges()

            resultado.Ok = true;
            resultado.Return = db.Articulos.ToList();

            return resultado;
        }

        [HttpPut]
        [Route("[controller]/UpdateArticulo")]
        public ActionResult<ResultAPI> UpdateArticulo([FromBody] comandoUpdateArticulo comando)
        {
            var resultado = new ResultAPI();         
            if (comando.NombreArticulo.Equals(""))
            {
                resultado.Ok = false;
                resultado.Error = "ingrese nombre del articulo";
                return resultado;
            }
            if (comando.Descripcion.Equals(""))
            {
                resultado.Ok = false;
                resultado.Error = "ingrese descripcion";
                return resultado;
            }
            if (comando.IdTipoArticulo.Equals(""))
            {
                resultado.Ok = false;
                resultado.Error = "ingrese tipo de articulo";
                return resultado;
            }
            if (comando.PrecioVenta.Equals(""))
            {
                resultado.Ok = false;
                resultado.Error = "ingrese precio";
                return resultado;
            }
            if (comando.IdTalle.Equals(""))
            {
                resultado.Ok = false;
                resultado.Error = "ingrese talle";
                return resultado;
            }
            if (comando.IdMarca.Equals(""))
            {
                resultado.Ok = false;
                resultado.Error = "ingrese marca";
                return resultado;
            }
            if (comando.Cantidad.Equals(""))
            {
                resultado.Ok = false;
                resultado.Error = "ingrese cantidad";
                return resultado;
            }
            if (comando.FechaModificicacion.Equals(""))
            {
                resultado.Ok = false;
                resultado.Error = "ingrese fecha";
                return resultado;
            }
            if (comando.IdEstadoArticulo.Equals(""))
            {
                resultado.Ok = false;
                resultado.Error = "ingrese estado del articulo";
                return resultado;
            }
            if (comando.Flag.Equals(""))
            {
                resultado.Ok = false;
                resultado.Error = "ingrese flag";
                return resultado;
            }

            var art = db.Articulos.Where(c => c.IdArticulo == comando.IdArticulo).FirstOrDefault();
            if (art != null)
            {
            art.NombreArticulo = comando.NombreArticulo;
            art.Descripcion = comando.Descripcion;
            art.IdTipoArticulo = comando.IdTipoArticulo;
            art.PrecioVenta = comando.PrecioVenta;
            art.IdTalle = comando.IdTalle;
            art.IdMarca = comando.IdMarca;
            art.Cantidad = comando.Cantidad;
            art.FechaModificicacion = comando.FechaModificicacion;
            art.IdEstadoArticulo = comando.IdEstadoArticulo;   
            art.Flag = comando.Flag;

            db.Articulos.Update(art);
            db.SaveChanges();
            }

            resultado.Ok = true;
            resultado.Return = db.Articulos.ToList();

            return resultado;
        }

        [HttpPut]//PREGUNTAR SI DIRECTAMENTE SE PUEDE HACER EN EL PRIMER PUT/UPDATE O CON EL COMANDO FLAG
        [Route("[controller]/ActualizarFlagArticulo/{id}")]
        public ActionResult<ResultAPI> UpdateById(comandoFlag comando, int id)
        {
            var resultado = new ResultAPI();

            if (comando.Flag.Equals(""))
            {
                resultado.Ok = false;
                resultado.Error = "ingrese flag";
                return resultado;
            }

            var art= db.Articulos.Where(c => c.IdArticulo == id).FirstOrDefault();

            if (art != null)
            {
                art.Flag = comando.Flag;
                db.Articulos.Update(art);
                db.SaveChanges();
            }
            resultado.Ok = true;
            resultado.Return = db.Articulos.ToList();

            return resultado;
        }

    }
}