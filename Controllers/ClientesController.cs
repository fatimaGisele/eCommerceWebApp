using appPDWebMVC.Models;
using AspNetCoreGeneratedDocument;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace appPDWebMVC.Controllers
{
    public class ClientesController : Controller
    {

        private readonly MydbContext _dbContext;

        public ClientesController(MydbContext mydb)
        {
            _dbContext = mydb;
        }

        //Primero el cliente se loguea
        public IActionResult Login(Cliente c)
        {
            var usuario = _dbContext.Clientes.FirstOrDefault(e=>e.Usuario==c.Usuario);

            if (usuario != null) { 
                if( usuario.Contraseña == c.Contraseña)
                {
                    HttpContext.Session.SetInt32("UsuarioID", usuario.ID);
                    return RedirectToAction("Index","Home");
                }
            }
            return RedirectToAction("Error");
        }

        // GET: ClientesController
        public async Task<IActionResult> Index()
        {
            if(_dbContext.Clientes != null)
            {
                return View(await _dbContext.Clientes.ToListAsync());
            }
            else
            {
                return Problem("Entity set 'MydbContext.Clientes'  is null.");
            }
        }

        // GET: ClientesController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var c = await _dbContext.Clientes.FirstOrDefaultAsync(m=>m.ID==id);
            if(c!= null)
            {
                return View(c);
            }
            return NotFound();
        }


        // GET: ClientesController/Create
        public ActionResult Create()
        {
            return View();
        }


        // POST: ClientesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind("ID,Nombre,Apellido,Mail,Usuario,Contraseña,Telefono,Rol")] Cliente c)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _dbContext.Clientes.Add(c);
                    await _dbContext.SaveChangesAsync();
                    return View(c);
                }
                return View("Error");
            }
            catch
            {
                return RedirectToAction(nameof(Index)); 
            }
        }

        

        // GET: ClientesController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var c = await _dbContext.Clientes.FindAsync(id);
            if (c != null) {
                return View(c);
            }
            return NotFound();
        }


        
        // POST: ClientesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Nombre,Apellido,Mail,Usuario,Contraseña,Telefono,Rol")] Cliente c)
        {
            if (id != c.ID)
            {
                return NotFound();
            }
            try
            {
                if (ModelState.IsValid) {
                    _dbContext.Update(c);
                    await _dbContext.SaveChangesAsync();
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return NotFound();
            }
        }

        // GET: ClientesController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var cliente = await _dbContext.Clientes.FirstOrDefaultAsync(m => m.ID == id);
            if (cliente != null) {
                _dbContext.Remove(cliente);
                await _dbContext.SaveChangesAsync();
                return NotFound();
            }
            return View(cliente);
        }

        // POST: ClientesController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteC(int id)
        {
            var cliente = await _dbContext.Clientes.FirstOrDefaultAsync(m => m.ID == id);
            try
            {
                if (cliente != null) {
                    _dbContext.Remove(cliente);
                    await _dbContext.SaveChangesAsync();
                    return NotFound();
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View("Error");
            }
        }
    }
}
