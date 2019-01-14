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
        public Libro CreateLibro(Libro newLibro)
        {
            throw new NotImplementedException();
        }

        public List<Libro> RetrieveAllLibro()
        {
            throw new NotImplementedException();
        }
    }
}
