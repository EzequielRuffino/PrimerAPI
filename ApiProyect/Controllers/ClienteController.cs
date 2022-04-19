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
    
    public class ClienteController : ControllerBase 
    {

        private readonly MEContext db = new MEContext();
        private readonly ILogger<ClienteController> _logger;

        public ClienteController(ILogger<ClienteController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("[controller]/ObtenerCliente")]
        public ActionResult<ResultAPI> Get()
        {
            var resultado = new ResultAPI();
            resultado.Ok = true;
            resultado.Return = db.Clientes.ToList(); 
            return resultado;
        }

        [HttpGet]
        [Route("[controller]/ObtenerCliente/{id}")] 
        public ActionResult<ResultAPI> Get3(int id)
        {
            var resultado = new ResultAPI();
            try
            {

                var cli = db.Clientes.Where(c => c.IdCliente == id).FirstOrDefault();
                resultado.Ok = true;
                resultado.Return = cli;

                return resultado;
            }

            catch (Exception ex)
            {
                resultado.Ok = false;
                resultado.Error = "Cliente no encontrado";

                return resultado;
            }
        }

       /* [HttpGet] aca iria si a realizado o no devoluciones, ver si por cantidad o por si
        [Route("[controller]/ObtenerDevoluciones")]
        public ActionResult<ResultAPI> getDevoluciones()
        {
            var resultado = new ResultAPI();
            try
            {
                resultado.Ok = true;
                resultado.Return = db.Devoluciones.ToList();

                return resultado;
            }
            catch (Exception ex)
            {
                resultado.Ok = false;
                resultado.Error = "Error al encontrar devoluciones";

                return resultado;
            }
        }*/

        [HttpPost] 
        [Route("[controller]/AltaCliente")]
        public ActionResult<ResultAPI> AltaCliente([FromBody] comandoCrearCliente comando)
        {
            var resultado = new ResultAPI();
            if (comando.NombreCliente.Equals(""))
            {
                resultado.Ok = false;
                resultado.Error = "ingrese nombre del cliente";
                return resultado;
            }
            if (comando.Documento.Equals(""))
            {
                resultado.Ok = false;
                resultado.Error = "ingrese documento";
                return resultado;
            }
            if (comando.Direccion.Equals(""))//esta mal no es int es string
            {
                resultado.Ok = false;
                resultado.Error = "ingrese direccion";
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


            var cli = new Cliente();
            cli.NombreCliente = comando.NombreCliente;
            cli.Documento = comando.Documento;
            cli.Direccion = comando.Direccion;
            cli.CodBarrio = comando.CodBarrio;
            cli.Telefono = comando.Telefono;



            db.Clientes.Add(cli);
            db.SaveChanges(); //despues de un insert, update o delte hacer el SaveChanges()

            resultado.Ok = true;
            resultado.Return = db.Clientes.ToList();

            return resultado;
        }

        [HttpPut]
        [Route("[controller]/UpdateCliente")]
        public ActionResult<ResultAPI> UpdateCliente([FromBody] comandoUpdateCliente comando)
        {
            var resultado = new ResultAPI();         
           if (comando.NombreCliente.Equals(""))
            {
                resultado.Ok = false;
                resultado.Error = "ingrese nombre del cliente";
                return resultado;
            }
            if (comando.Documento.Equals(""))
            {
                resultado.Ok = false;
                resultado.Error = "ingrese documento";
                return resultado;
            }
            if (comando.Direccion.Equals(""))
            {
                resultado.Ok = false;
                resultado.Error = "ingrese direccion";
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

            var cli = db.Clientes.Where(c => c.IdCliente == comando.IdCliente).FirstOrDefault();
            if (cli != null)
            {
                cli.NombreCliente = comando.NombreCliente;
                cli.Documento = comando.Documento;
                cli.Direccion = comando.Direccion;
                cli.CodBarrio = comando.CodBarrio;
                cli.Telefono = comando.Telefono;
                db.Clientes.Update(cli);
                db.SaveChanges();
            }

            resultado.Ok = true;
            resultado.Return = db.Clientes.ToList();

            return resultado;
        }

    }
}