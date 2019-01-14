using System;
using System.Collections.Generic;
using System.Text;
using Entities;


namespace NViewModel
{
    public class Libro : ViewModelBase
    {
        public Libro()
        {
            InitializeViewModel();
        }

        void InitializeViewModel()
        {

          
                Libros = new List<Entities.Libro>();
                SearchLibroCommand = new CommandDelegate 
                    ((o) => { return true; },
                    (o) =>
                    {
                        var Proxy = new NProxyService.Proxy();
                        Libros = Proxy.FilterLibroByGeneroID(GeneroID);
                    });
                SearchLibroByIDCommand = new CommandDelegate
                    ((o) => { return true; },
                    (o) =>
                    {
                    //var Proxy = new NWindProxyService.Proxy();

                    if (LibroSelected.GeneroID != 0)
                        {
                            var Proxy = new NProxyService.Proxy();
                            var p = Proxy.RetrieveLibroByID(
                                LibroSelect.GeneroID);
                          
                        }
                    });


        }


      
        #region Propiedades
        public CommandDelegate SearchLibroCommand { get; set; }
        public CommandDelegate SearchLibroByIDCommand { get; set; }
        #endregion
    }
}
