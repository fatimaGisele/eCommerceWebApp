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

        public IActionResult Index() //muestra una lista de productos en el inicio...no anda...revisar
        {
            var productos = new List<Indumentarium>();
            try
            {
                int id = 1933;
                for (var i = 1; i <= 5; i++)
                {
                    var producto = _dbContext.Indumentaria.FirstOrDefault(p => p.ID == id);
                    if (producto != null)
                    {
                        productos.Add(producto);
                    }
                    id += i;
                    Console.WriteLine(id);
                    Console.WriteLine(i);
                }

                var sessionId = HttpContext.Session.GetInt32("UserId");

                ViewBag.SessionId = sessionId;
            }
            catch (Exception)
            {
                return View("Error");
            }


            return View(productos);
        }

        public IActionResult LogOut()
        {
            HttpContext.Session.Remove("UserId");
            return RedirectToAction("Login", "Clientes");
        }

        public IActionResult Indumentarias()//?
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Cliente c)//Register
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