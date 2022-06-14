using System;
using System.Linq;
using ApiProyect.Comands;
using ApiProyect.Models;
using ApiProyect.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;


namespace ApiProyect.Controllers
{
    [ApiController]
    public class ReporteController : ControllerBase 
    {

        private readonly MEContext db = new MEContext();
        private readonly ILogger<ReporteController> _logger;  

        public ReporteController(ILogger<ReporteController> logger)
        {
            _logger = logger;
        }

//consultar datos usuario por legajo
        [HttpGet]
        [Route("[controller]/ObtenerUsuario")]
        public ActionResult<ResultAPI> Get()
        {
            var resultado = new ResultAPI();
            resultado.Ok = true;
            resultado.Return = db.Usuarios.Include(c => c.CodBarrioNavigation)
                                            .Include(c => c.IdTipoRolNavigation)
                                            .OrderBy(c => c.Legajo)
                                            .ToList(); 
            return resultado;
        }

                [HttpGet]
        [Route("[controller]/ObtenerUsuario/{id}")] 
        public ActionResult<ResultAPI> Get3(int id)
        {
            var resultado = new ResultAPI();
            try
            {

                var emple = db.Usuarios.Include(c => c.CodBarrioNavigation)
                                        .Include(c => c.IdTipoRolNavigation)
                                        .Where(c => c.Legajo == id).FirstOrDefault();
                resultado.Ok = true;
                resultado.Return = emple;

                return resultado;
            }

            catch (Exception ex)
            {
                resultado.Ok = false;
                resultado.Error = "Usuario no encontrado";

                return resultado;
            }
        }

 //consultar faltantes

        [HttpGet]
        [Route("[controller]/ObtenerArticulo")]
        public ActionResult<ResultAPI> Get2()
        {
            var resultado = new ResultAPI();
            resultado.Ok = true;
            resultado.Return = db.Articulos.Include(c => c.IdEstadoArticuloNavigation)
                                            .Include(c => c.IdTalleNavigation)
                                            .Include(c => c.IdMarcaNavigation)
                                            .Include(c => c.IdTipoArticuloNavigation)
                                            .Where(c => c.Cantidad <= 5 && c.Flag ==1)
                                            .OrderBy(c => c.IdArticulo)
                                            .ToList(); 
            return resultado;
        }

        [HttpGet]
        [Route("[controller]/ObtenerArticuloDisponible")]
        public ActionResult<ResultAPI> Get4()
        {
            var resultado = new ResultAPI();
            resultado.Ok = true;
            resultado.Return = db.Articulos.Include(c => c.IdEstadoArticuloNavigation)
                                            .Include(c => c.IdTalleNavigation)
                                            .Include(c => c.IdMarcaNavigation)
                                            .Include(c => c.IdTipoArticuloNavigation)
                                            .Where(c => c.Cantidad >= 5 && c.Flag ==1)
                                            .OrderBy(c => c.IdArticulo)
                                            .ToList(); 
            return resultado;
        }



































































































































    }
}