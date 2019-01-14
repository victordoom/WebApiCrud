using System;
using System.Collections.Generic;
using System.Text;
using Entities;

namespace SLC
{
    public interface IService
    {
        Libro CreateProduct(Libro newLibro);
        Libro RetrieveLibroByID(int ID);
        bool UpdateLibro(Libro libroToUpdate);
        bool RemoveLibro(int ID);
        List<Libro> FilterLibroByGeneroID(int GeneroID);
        List<Libro> RetrieveAllLibro();


    }
}
