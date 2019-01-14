using Biblio.Service.Models;
using DAL;
using Entities;
using SLC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Biblio.Service.Controllers
{

    public class LibrosController : ApiController, IService
    {
        private UsuarioDAL UsuarioDAL = new UsuarioDAL();

        [HttpPost]
        public Libro CreateLibro(Libro newLibro)
        {
            var Libro = UsuarioDAL.CreateLibro(newLibro);
            return Libro;
        }

        [HttpGet]
        public List<Libro> RetrieveAllLibro()
        {
            return UsuarioDAL.GetLibros();
        }
    }
}
