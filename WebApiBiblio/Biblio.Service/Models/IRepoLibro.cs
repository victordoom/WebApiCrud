using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblio.Service.Models
{
    public interface IRepoLibro
    {
        Libro CreateLibro(Libro newLibro);
        List<Libro> GetLibros();
        Libro GetLibro(int id);
        bool RemoveLibro(int id);
        bool UpdateLibro(Libro libroToUpdate);
    }
}
