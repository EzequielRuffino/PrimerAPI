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
    public class UsuarioController : ControllerBase 
    {

        private readonly MEContext db = new MEContext();
        private readonly ILogger<UsuarioController> _logger;  

        public UsuarioController(ILogger<UsuarioController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("[controller]/ObtenerUsuario")]
        public ActionResult<ResultAPI> Get()
        {
            var resultado = new ResultAPI();
            resultado.Ok = true;
            resultado.Return = db.Usuarios.Where(c => c.Flag == 1).ToList(); 
            return resultado;
        }

        [HttpGet]
        [Route("[controller]/ObtenerUsuario/{id}")] 
        public ActionResult<ResultAPI> Get3(int id)
        {
            var resultado = new ResultAPI();
            try
            {

                var emple = db.Usuarios.Where(c => c.Legajo == id).FirstOrDefault();
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


        [HttpPost] 
        [Route("[controller]/AltaUsuario")]
        public ActionResult<ResultAPI> AltaUsuario([FromBody] comandoCrearUsuario comando)
        {
            var resultado = new ResultAPI();
            if (comando.NombreCompleto.Equals(""))
            {
                resultado.Ok = false;
                resultado.Error = "ingrese nombre del Usuario";
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
            if (comando.IdTipoRol.Equals(""))
            {
                resultado.Ok = false;
                resultado.Error = "ingrese tipo rol";
                return resultado;
            }
            if (comando.Email.Equals(""))
            {
                resultado.Ok = false;
                resultado.Error = "ingrese numero de telefono";
                return resultado;
            }
            if (comando.Contraseña.Equals(""))
            {
                resultado.Ok = false;
                resultado.Error = "ingrese id estado articulo";
                return resultado;
            }
            if (comando.Flag.Equals(""))
            {
                resultado.Ok = false;
                resultado.Error = "ingrese flag";
                return resultado;
            }
            if (comando.Flag.Equals(""))
            {
                resultado.Ok = false;
                resultado.Error = "ingrese flag";
                return resultado;
            }
            var emp = new Usuario();
            emp.NombreCompleto = comando.NombreCompleto;
            emp.Documento = comando.Documento;
            emp.CodBarrio = comando.CodBarrio;
            emp.Telefono = comando.Telefono;
            emp.IdTipoRol = comando.IdTipoRol;
            emp.Email = comando.Email;
            emp.Contraseña = comando.Contraseña;
            emp.Flag=comando.Flag;




            db.Usuarios.Add(emp);
            db.SaveChanges(); //despues de un insert, update o delte hacer el SaveChanges()

            resultado.Ok = true;
            resultado.Return = db.Usuarios.ToList();

            return resultado;
        }

        [HttpPut]
        [Route("[controller]/UpdateUsuario")]
        public ActionResult<ResultAPI> UpdateUsuario([FromBody] comandoUpdateUsuario comando)
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
            if (comando.IdTipoRol.Equals(""))
            {
                resultado.Ok = false;
                resultado.Error = "ingrese tipo rol";
                return resultado;
            }
            if (comando.Email.Equals(""))
            {
                resultado.Ok = false;
                resultado.Error = "ingrese numero de telefono";
                return resultado;
            }
            if (comando.Contraseña.Equals(""))
            {
                resultado.Ok = false;
                resultado.Error = "ingrese id estado articulo";
                return resultado;
            }
            if (comando.Flag.Equals(""))
            {
                resultado.Ok = false;
                resultado.Error = "ingrese flag";
                return resultado;
            }

            var emp = db.Usuarios.Where(c => c.Legajo == comando.Legajo).FirstOrDefault();
            if (emp != null)
            {
            emp.NombreCompleto = comando.NombreCompleto;
            emp.Documento = comando.Documento;
            emp.CodBarrio = comando.CodBarrio;
            emp.Telefono = comando.Telefono;
            emp.IdTipoRol = comando.IdTipoRol;
            emp.Email = comando.Email;
            emp.Contraseña = comando.Contraseña;
            emp.Flag = comando.Flag;
            db.Usuarios.Update(emp);
            db.SaveChanges();
            }

            resultado.Ok = true;
            resultado.Return = db.Usuarios.ToList();

            return resultado;
        }

        [HttpPut]//PREGUNTAR SI DIRECTAMENTE SE PUEDE HACER EN EL PRIMER PUT O CREO COMANDO PARA LA FLAG
        [Route("[controller]/ActualizarFlagUsuarios/{id}")]
        public ActionResult<ResultAPI> UpdateById(comandoFlag comando, int id)
        {
            var resultado = new ResultAPI();

            if (comando.Flag.Equals(""))
            {
                resultado.Ok = false;
                resultado.Error = "Ingrese flag";
                return resultado;
            }

            var usu= db.Usuarios.Where(c => c.Legajo == id).FirstOrDefault();

            if (usu != null)
            {
                usu.Flag = comando.Flag;
                db.Usuarios.Update(usu);
                db.SaveChanges();
            }
            resultado.Ok = true;
            resultado.Return = db.Usuarios.ToList();

            return resultado;
        }

    }
}