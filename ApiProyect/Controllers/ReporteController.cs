using System.ComponentModel.DataAnnotations;
using System;
using System.Linq;
using ApiProyect.Comands;
using ApiProyect.Models;
using ApiProyect.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using ApiProyect.Models.DTO;


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
                                            .Where(c => c.Cantidad <= 5)
                                            .OrderBy(c => c.IdArticulo)
                                            .ToList(); 
            return resultado;
        }

//stock disponible
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
                                            .Where(c => c.Cantidad >= 2 && c.Flag ==1)
                                            .OrderBy(c => c.IdArticulo)
                                            .ToList(); 
            return resultado;
        }

//listado de compras
        [HttpGet]
        [Route("[controller]/ObtenerListadoCompras")]
        public ActionResult<ResultAPI> Get5()
        {
            var resultado = new ResultAPI();
                resultado.Ok = true;
                var cli   = (from c in db.NotaPedidos
                join b in db.DetalleNotaPedidos on c.IdOrdenCompra equals b.NroOrdenCompra
                join a in db.Articulos on b.IdArticulo equals a.IdArticulo
                join u in db.Usuarios on c.IdEmpleado equals u.Legajo
                select new DTOListadoCompras
                {
                    IdOrdenCompra= c.IdOrdenCompra,
                    FechaEmision = c.FechaEmision,
                    FechaEntrega = c.FechaEntrega,
                    NombreCompleto = u.NombreCompleto,
                    Flag = c.Flag,
                    NombreArticulo = a.NombreArticulo,
                    Cantidad = b.Cantidad
                })
                .OrderBy(c => c.IdOrdenCompra)
                .ToList();
                resultado.Return = cli;
            return resultado;
        }

//listado de Insumos Recibidos
        [HttpGet]
        [Route("[controller]/ObtenerInsumoRecibido")]
        public ActionResult<ResultAPI> Get6()
        {
            var resultado = new ResultAPI();
                resultado.Ok = true;
                var cli   = (from c in db.IngresoPedidoProveedors
                join b in db.DetalleIngresoPedidos on c.IdIngresoPedido equals b.IdIngresoPedido
                join a in db.Articulos on b.IdArticulo equals a.IdArticulo
                join j in db.Proveedors on c.IdProveedor equals j.IdProveedor
                join u in db.Usuarios on c.IdEmpleado equals u.Legajo
                select new DTOListadoInsumosRecibidos
                {

                    IdIngresoPedido = c.IdIngresoPedido,
                    RazonSocial =j.RazonSocial, 
                    NombreCompleto =u.NombreCompleto,
                    NroRemitoPedido =c.NroRemitoPedido,
                    //ipoFactura { get; set; } aca va ir si esta o no pagado
                    Fecha = c.Fecha,
                    NroOrdenCompra = c.NroOrdenCompra, 
                    Cantidad = b.Cantidad, 
                    Precio =b.Precio, 
                    NombreArticulo=a.NombreArticulo, 
                    Flag = c.Flag
                })
                .OrderBy(c => c.IdIngresoPedido)
                .ToList();
                resultado.Return = cli;
            return resultado;
        }


//consultar informacion clientes
        [HttpGet]
        [Route("[controller]/ObtenerCliente")]
        public ActionResult<ResultAPI> Get7()
        {
            var resultado = new ResultAPI();

            resultado.Ok = true;
            resultado.Return = db.Clientes.Include(c => c.CodBarrioNavigation)
                                         //.Where(c => c.Flag == 1)
                                         .OrderBy(c => c.IdCliente)
                                         .ToList(); 
            return resultado;
        }

        [HttpGet]
        [Route("[controller]/ObtenerCliente/{id}")] 
        public ActionResult<ResultAPI> Get8(int id)
        {
            var resultado = new ResultAPI();
            try
            {

                var cli = db.Clientes.Include(c => c.CodBarrioNavigation)
                                      .Where(c => c.IdCliente == id).FirstOrDefault();
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

//listado de Pago Proveedores
        [HttpGet]
        [Route("[controller]/ObtenerPago")]
        public ActionResult<ResultAPI> Get9()
        {
            var resultado = new ResultAPI();
                resultado.Ok = true;
                var cli   = (from c in db.IngresoPedidoProveedors
                join b in db.DetalleIngresoPedidos on c.IdIngresoPedido equals b.IdIngresoPedido
                join a in db.Articulos on b.IdArticulo equals a.IdArticulo
                join j in db.Proveedors on c.IdProveedor equals j.IdProveedor
                join u in db.Usuarios on c.IdEmpleado equals u.Legajo
                select new DTOPagoProveedor
                {

                    IdIngresoPedido = c.IdIngresoPedido,
                    RazonSocial =j.RazonSocial, 
                    NombreCompleto =u.NombreCompleto,
                    NroRemitoPedido =c.NroRemitoPedido,
                    Pago = c.Pago,
                    Fecha = c.Fecha,
                    NroOrdenCompra = c.NroOrdenCompra, 
                    Cantidad = b.Cantidad, 
                    Precio =b.Precio, 
                    NombreArticulo=a.NombreArticulo, 
                   //Flag = c.Flag
                })
                .Where(c => c.Pago == "Abonado")
                .OrderBy(c => c.IdIngresoPedido)
                .ToList();
                resultado.Return = cli;
            return resultado;
        }

//Consultar Devoluciones
        [HttpGet]
        [Route("[controller]/ObtenerDevoluciones")]
        public ActionResult<ResultAPI> Get10()
        {
            var resultado = new ResultAPI();
                resultado.Ok = true;
                var cli   = (from c in db.Venta
               // join b in db.DetalleVenta on c.IdVenta equals b.IdVenta
                join a in db.Clientes on c.IdCliente equals a.IdCliente
                join j in db.Usuarios on c.IdEmpleado equals j.Legajo
                join u in db.FormaPagos on c.IdFormaPago equals u.IdFormaPago
                join p in db.Devolucion on c.IdVenta equals p.IdVenta
                join l in db.DetalleDevolucion on p.IdDevolucion equals l.IdDevolucion
                join t in db.Articulos on l.IdArticulo equals t.IdArticulo
                join q in db.MotivoDevolucions on l.IdMotivo equals q.IdMotivo
                select new DTODevolucion
                {

        IdVenta = c.IdVenta,
        FechaVenta = c.FechaVenta,
        NombreCliente = a.NombreCliente,
        NombreCompleto = j.NombreCompleto,
        Descripcion = u.Descripcion,
        NombreArticulo = t.NombreArticulo,
        IdDevolucion = l.IdDevolucion,
        FechaDevolucion = p.FechaDevolucion,
        Descripcion2 = q.Descripcion, //motivo devolucion
        Cantidad = l.Cantidad
                   //Flag = c.Flag
                })
                .OrderBy(c => c.IdVenta)
                .ToList();
                resultado.Return = cli;
            return resultado;
        }


//Consultar cliente mas compras
       [HttpGet]
        [Route("[controller]/ObtenerClienteMasCompras")]
        public ActionResult<ResultAPI> Get11()
        {
            var resultado = new ResultAPI();
                resultado.Ok = true;
                var cli   = (from c in db.Venta
                join b in db.DetalleVenta on c.IdVenta equals b.IdVenta
                join a in db.Clientes on c.IdCliente equals a.IdCliente
                select new DTOClienteMasCompra
                {

                    IdVenta = c.IdVenta,
                    FechaVenta = c.FechaVenta,
                    NombreCliente = a.NombreCliente,
                    Cantidad = b.Cantidad
                   //Flag = c.Flag
                })
                .Where(c => c.Cantidad <= 5)
                .OrderBy(b => b.Cantidad)
                .ToList ();
                resultado.Return = cli;
            return resultado;
        }


/*select c.id_cliente, c.nombre_cliente, count(distinct v.id_venta)
from venta v 

    inner join detalle_venta dv
    on v.id_venta = dv.id_venta
    
    inner join cliente c
    on v.id_cliente = c.id_cliente

group by c.id_cliente, c.nombre_cliente
order by count(v.id_venta)
limit 10


            /*var resultado = new ResultAPI();
                resultado.Ok = true;
                var cli   = from c in db.Venta
                join b in db.DetalleVenta on c.IdVenta equals b.IdVenta
                join a in db.Clientes on c.IdCliente equals a.IdCliente
                .GroupBy(x=> new{x.b.IdVenta })
                .Select(g=> new{
                    g.key.IdVenta,
                    Count = g.Count()  
                })
                .ToList();
                resultado.Return = cli;
            return resultado;*/





















































































































    }
}