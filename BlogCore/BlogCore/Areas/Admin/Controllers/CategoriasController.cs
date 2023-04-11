using BlogCore.AccesoDatos.Data.Repository.IRepository;
using BlogCore.Data;
using Microsoft.AspNetCore.Mvc;

namespace BlogCore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoriasController : Controller
    {
        //en vez de usar el contexto de usa el contenedor de trabajo
        private readonly IContenedorTrabajo _contenedorTrabajo;
        private readonly ApplicationDbContext _context;
        public CategoriasController(IContenedorTrabajo contenedorTrabajo,ApplicationDbContext context)
        {
            _contenedorTrabajo = contenedorTrabajo;
            _context= context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        #region llamadas a la api
        [HttpGet]
        public IActionResult GetAll()
        {
            return Json(new { data = _contenedorTrabajo.Categoria.GetAll() });
        }
        #endregion
    }
}
