using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SLC
{
    public interface IService
    {
        Libro CreateLibro(Libro newLibro);
        // Libro RetrieveLibroByID(int ID);
        // bool UpdateLibro(int ID, Libro libroToUpdate);
        //bool RemoveLibro(int ID);
        // List<Libro> FilterLibrosByGeneroID(int generoID);
        List<Libro> RetrieveAllLibro();
    }
}
