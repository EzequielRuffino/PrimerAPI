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
    public class EmpleadoController : ControllerBase 
    {

        private readonly MEContext db = new MEContext();
        private readonly ILogger<EmpleadoController> _logger;  

        public EmpleadoController(ILogger<EmpleadoController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("[controller]/ObtenerEmpleado")]
        public ActionResult<ResultAPI> Get()
        {
            var resultado = new ResultAPI();
            resultado.Ok = true;
            resultado.Return = db.Empleados.ToList(); 
            return resultado;
        }

        [HttpGet]
        [Route("[controller]/ObtenerEmpleado/{id}")] 
        public ActionResult<ResultAPI> Get3(int id)
        {
            var resultado = new ResultAPI();
            try
            {

                var emple = db.Empleados.Where(c => c.Legajo == id).FirstOrDefault();
                resultado.Ok = true;
                resultado.Return = emple;

                return resultado;
            }

            catch (Exception ex)
            {
                resultado.Ok = false;
                resultado.Error = "Empleado no encontrado";

                return resultado;
            }
        }


        [HttpPost] 
        [Route("[controller]/AltaEmpleado")]
        public ActionResult<ResultAPI> AltaEmpleado([FromBody] comandoCrearEmpleado comando)
        {
            var resultado = new ResultAPI();
            if (comando.NombreCompleto.Equals(""))
            {
                resultado.Ok = false;
                resultado.Error = "ingrese nombre del empleado";
                return resultado;
            }
            if (comando.Documento.Equals(""))
            {
                resultado.Ok = false;
                resultado.Error = "ingrese documento";
                return resultado;
            }
            if (comando.CodBarrio.Equals(""))
            {
                resultado.Ok = false;
                resultado.Error = "ingrese codigo del barrio";
                return resultado;
            }
            if (comando.Telefono.Equals(""))
            {
                resultado.Ok = false;
                resultado.Error = "ingrese numero de telefono";
                return resultado;
            }
            if (comando.IdEstadoArticulo.Equals(""))
            {
                resultado.Ok = false;
                resultado.Error = "ingrese id estado articulo";//esto esta mal, reemplazar con direccion string
                return resultado;
            }


            var emp = new Empleado();
            emp.NombreCompleto = comando.NombreCompleto;
            emp.Documento = comando.Documento;
            emp.CodBarrio = comando.CodBarrio;
            emp.Telefono = comando.Telefono;
            emp.IdEstadoArticulo = comando.IdEstadoArticulo;



            db.Empleados.Add(emp);
            db.SaveChanges(); //despues de un insert, update o delte hacer el SaveChanges()

            resultado.Ok = true;
            resultado.Return = db.Empleados.ToList();

            return resultado;
        }

        [HttpPut]
        [Route("[controller]/UpdateEmpleado")]
        public ActionResult<ResultAPI> UpdateEmpleado([FromBody] comandoUpdateEmpleado comando)
        {
            var resultado = new ResultAPI();         
            if (comando.NombreCompleto.Equals(""))
            {
                resultado.Ok = false;
                resultado.Error = "ingrese nombre del empleado";
                return resultado;
            }
            if (comando.Documento.Equals(""))
            {
                resultado.Ok = false;
                resultado.Error = "ingrese documento";
                return resultado;
            }
            if (comando.CodBarrio.Equals(""))
            {
                resultado.Ok = false;
                resultado.Error = "ingrese codigo del barrio";
                return resultado;
            }
            if (comando.Telefono.Equals(""))
            {
                resultado.Ok = false;
                resultado.Error = "ingrese numero de telefono";
                return resultado;
            }
            if (comando.IdEstadoArticulo.Equals(""))
            {
                resultado.Ok = false;
                resultado.Error = "ingrese id estado articulo";//esto esta mal, reemplazar con direccion string
                return resultado;
            }

            var emp = db.Empleados.Where(c => c.Legajo == comando.Legajo).FirstOrDefault();
            if (emp != null)
            {
            emp.NombreCompleto = comando.NombreCompleto;
            emp.Documento = comando.Documento;
            emp.CodBarrio = comando.CodBarrio;
            emp.Telefono = comando.Telefono;
            emp.IdEstadoArticulo = comando.IdEstadoArticulo;
            db.Empleados.Update(emp);
            db.SaveChanges();
            }

            resultado.Ok = true;
            resultado.Return = db.Empleados.ToList();

            return resultado;
        }

    }
}