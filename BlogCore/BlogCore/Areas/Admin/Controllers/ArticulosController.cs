using BlogCore.AccesoDatos.Data.Repository.IRepository;
using BlogCore.Data;
using BlogCore.Models;
using BlogCore.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BlogCore.Areas.Admin.Controllers
{
    [Area("Admin")] //importante agregar el area 
    public class ArticulosController : Controller
    { //en vez de usar el contexto de usa el contenedor de trabajo
        private readonly IContenedorTrabajo _contenedorTrabajo;
        private readonly ApplicationDbContext _context;
        public ArticulosController(IContenedorTrabajo contenedorTrabajo, ApplicationDbContext context)
        {
            _contenedorTrabajo = contenedorTrabajo;
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Create()
        {
            ArticuloVM articuloVM = new ArticuloVM() { 
                Articulo= new Articulo(),
                ListaCategorias= _contenedorTrabajo.Categoria.GetListaCategorias()
            };
            return View(articuloVM);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Articulo articulo)
        {
            if (ModelState.IsValid)
            {
                _contenedorTrabajo.Articulo.Add(articulo);
                _contenedorTrabajo.Save();
                return RedirectToAction(nameof(Index));
            }
            //si el modelo tiene algun error devuelvo a la vista los mismos datos del modelo.
            return View(articulo);
        }

        #region llamadas a la api
        [HttpGet]
        public IActionResult GetAll()
        {
            return Json(new { data = _contenedorTrabajo.Articulo.GetAll() });
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            Articulo objFromDb = new Articulo();
            objFromDb = _contenedorTrabajo.Articulo.Get(id);
            if (objFromDb == null)
            {
                return Json(new { succes = false, message = "Error borrado Articulo" });
            }
            _contenedorTrabajo.Articulo.Remove(objFromDb);
            _contenedorTrabajo.Save();
            return Json(new { success = true, message = "Borrado con Exito" });
        }
        #endregion
    }
}
