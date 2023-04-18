using BlogCore.AccesoDatos.Data.Repository.IRepository;
using BlogCore.Data;
using BlogCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace BlogCore.AccesoDatos.Data.Repository
{
    internal class ArticuloRepositoy : Repository<Articulo>, IArticuloRepository
    {
        private readonly ApplicationDbContext _db;
        public ArticuloRepositoy(ApplicationDbContext db):base(db)
        {
            _db = db;
        }
        

        public void Update(Articulo articulo)
        {
            var objDesdeDb = _db.Articulo.FirstOrDefault(c => c.Id == articulo.Id);
            if(objDesdeDb != null)
            {
                objDesdeDb.Nombre = articulo.Nombre;
                objDesdeDb.Descripcion = articulo.Descripcion;               
                objDesdeDb.UrlImage=articulo.UrlImage;
                objDesdeDb.CategoriaId = articulo.CategoriaId;
               

                //_db.SaveChanges();
            }
            

        }
    }
}
