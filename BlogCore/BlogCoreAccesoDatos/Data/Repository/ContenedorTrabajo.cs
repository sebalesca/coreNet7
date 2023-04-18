using BlogCore.AccesoDatos.Data.Repository.IRepository;
using BlogCore.Data;
using BlogCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogCore.AccesoDatos.Data.Repository
{
    public class ContenedorTrabajo : IContenedorTrabajo
    {
        private readonly ApplicationDbContext _db;
        public ContenedorTrabajo(ApplicationDbContext db)
        {
            _db = db;
            Categoria = new CategoriaRepositoy (_db);
            Articulo = new ArticuloRepositoy(_db);
        }
        public ICategoriaRepository Categoria { get; private set; } //private set significa que solo puede ser seteada dentro de la clase
        public IArticuloRepository Articulo { get; private set; } //private set significa que solo puede ser seteada dentro de la clase

        public void Dispose()
        {
            _db.Dispose(); //libera recursos
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
