using appPDWebMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using Microsoft.AspNetCore.Http;

namespace appPDWebMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly MydbContext _dbContext;

        public HomeController(MydbContext mydb)
        {
            _dbContext = mydb;
        }

        public IActionResult Index() //muestra una lista de productos en el inicio...revisar
        {
            var productos = new List<Indumentarium>();
            try
            {
                int iid = 1934;
                for (var i = 1; i <= 5; i++)
                {
                    iid += i;

                    var producto = _dbContext.Indumentaria.FirstOrDefault(p => p.ID == iid);
                    if (producto != null)
                    {
                        productos.Add(producto);
                    }
                }

                var sessionId = HttpContext.Session.GetInt32("UserId");

                ViewBag.SessionId = sessionId;
            }


            return View(productos);
        }

        public IActionResult LogOut()
        {
            HttpContext.Session.Remove("UserId");
            return RedirectToAction("Login", "Clientes");
        }


        [HttpGet]
        public IActionResult Register()//?
        {
            return View();
        }
        public IActionResult Indumentarias()//?
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Cliente c)
        {
            if (ModelState.IsValid) {
                var nuevoCliente = new Cliente
                {
                    Nombre = c.Nombre,
                    Apellido = c.Apellido,
                    Mail = c.Mail,
                    Usuario = c.Usuario,
                    Contraseña = c.Contraseña,
                    Telefono = c.Telefono,
                    Rol = c.Rol
                };
                _dbContext.Add(nuevoCliente);
                _dbContext.SaveChanges();
                return View(c);
            }
            return View(c);

        }

        public IActionResult Carritos() //por ...
        {

            var sessionId = HttpContext.Session.GetInt32("UserId");

            ViewBag.SessionId = sessionId;

            return View();
        }

    }
}