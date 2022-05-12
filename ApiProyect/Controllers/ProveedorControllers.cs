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
    public class ProveedorController : ControllerBase 
    {

        private readonly MEContext db = new MEContext();
        private readonly ILogger<ProveedorController> _logger;  

        public ProveedorController(ILogger<ProveedorController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("[controller]/ObtenerProveedor")]
        public ActionResult<ResultAPI> Get()
        {
            var resultado = new ResultAPI();
            resultado.Ok = true;
            resultado.Return = db.Proveedors.ToList(); 
            return resultado;
        }

        [HttpGet]
        [Route("[controller]/ObtenerProveedor/{id}")] 
        public ActionResult<ResultAPI> Get3(int id)
        {
            var resultado = new ResultAPI();
            try
            {

                var pro = db.Proveedors.Where(c => c.IdProveedor == id).FirstOrDefault();
                resultado.Ok = true;
                resultado.Return = pro;

                return resultado;
            }

            catch (Exception ex)
            {
                resultado.Ok = false;
                resultado.Error = "Proveedor no encontrado";

                return resultado;
            }
        }


        [HttpPost] 
        [Route("[controller]/AltaProveedor")]
        public ActionResult<ResultAPI> AltaProveedor([FromBody] comandoCrearProveedor comando)
        {
            var resultado = new ResultAPI();
            if (comando.RazonSocial.Equals(""))
            {
                resultado.Ok = false;
                resultado.Error = "ingrese nombre del proveedor";
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
                resultado.Error = "ingrese codigo de barrio";
                return resultado;
            }
            if (comando.Telefono.Equals(""))
            {
                resultado.Ok = false;
                resultado.Error = "ingrese telefono";//esto esta mal, reemplazar con direccion string
                return resultado;
            }
            if (comando.IdEstadoArticulo.Equals(""))
            {
                resultado.Ok = false;
                resultado.Error = "ingrese estado de articulo siendo 1 disponible, 2 no disponible y 3 proximamente";//esto esta mal, reemplazar con direccion string
                return resultado;
            }


            var pro = new Proveedor();
            pro.RazonSocial = comando.RazonSocial;
            pro.Documento = comando.Documento;
            pro.Direccion = comando.Direccion;
            pro.CodBarrio = comando.CodBarrio;
            pro.Telefono = comando.Telefono;
            pro.IdEstadoArticulo = comando.IdEstadoArticulo;



            db.Proveedors.Add(pro);
            db.SaveChanges(); //despues de un insert, update o delte hacer el SaveChanges()

            resultado.Ok = true;
            resultado.Return = db.Proveedors.ToList();

            return resultado;
        }

        [HttpPut]
        [Route("[controller]/UpdateProveedor")]
        public ActionResult<ResultAPI> UpdateProveedor([FromBody] comandoUpdateProveedor comando)
        {
            var resultado = new ResultAPI();         
            if (comando.RazonSocial.Equals(""))
            {
                resultado.Ok = false;
                resultado.Error = "ingrese nombre del proveedor";
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
                resultado.Error = "ingrese codigo de barrio";
                return resultado;
            }
            if (comando.Telefono.Equals(""))
            {
                resultado.Ok = false;
                resultado.Error = "ingrese telefono";//esto esta mal, reemplazar con direccion string
                return resultado;
            }
            if (comando.IdEstadoArticulo.Equals(""))
            {
                resultado.Ok = false;
                resultado.Error = "ingrese estado de articulo siendo 1 disponible, 2 no disponible y 3 proximamente";//esto esta mal, reemplazar con direccion string
                return resultado;
            }

            var pro = db.Proveedors.Where(c => c.IdProveedor == comando.IdProveedor).FirstOrDefault();
            if (pro != null)
            {
            pro.RazonSocial = comando.RazonSocial;
            pro.Documento = comando.Documento;
            pro.Direccion = comando.Direccion;
            pro.CodBarrio = comando.CodBarrio;
            pro.Telefono = comando.Telefono;
            pro.IdEstadoArticulo = comando.IdEstadoArticulo;
            db.Proveedors.Update(pro);
            db.SaveChanges();
            }

            resultado.Ok = true;
            resultado.Return = db.Proveedors.ToList();

            return resultado;
        }

        [HttpDelete]
        [Route("[controller]/EliminarProveedor/{id}")]
        public ActionResult<ResultAPI> deleteById(int id)
        {
            var resultado = new ResultAPI();
            var pro = db.Proveedors.Where(c => c.IdProveedor == id).FirstOrDefault();
            db.Proveedors.Remove(pro);
            db.SaveChanges();

            resultado.Ok = true;
            resultado.Return = db.Proveedors.ToList();
            return resultado;
        }

    }
}