using Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DAL
{
    public class UsuarioDAL
    {
        private List<Libro> Libros = new List<Libro>();
        private readonly string connectionString = "Server=CDS1UNIVO27\\SQLEXPRESS;Database=Libro;Trusted_Connection=True;";

        public UsuarioDAL()
        {

        }

        public Libro CreateLibro(Libro newLibro)
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                var query = new SqlCommand("INSERT INTO Libro(Nombre, Descripcion, GeneroID) VALUES (@p0, @p1, @p2)", sqlConnection);

                query.Parameters.AddWithValue("@p0", newLibro.Nombre);
                query.Parameters.AddWithValue("@p1", newLibro.Descripcion);
                query.Parameters.AddWithValue("@p2", newLibro.GeneroID);

                query.ExecuteNonQuery();

                return newLibro;

            }

        }

        public List<Libro> GetLibros()
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                var query = new SqlCommand("select * from Libro", sqlConnection);

                using (var dr = query.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        // Usuario
                        var libro = new Libro
                        {
                            ID = Convert.ToInt32(dr["ID"]),
                            Nombre = dr["Nombre"].ToString(),
                            Descripcion = dr["Descripcion"].ToString(),
                            GeneroID = Convert.ToInt32(dr["GeneroID"]),
                        };

                        Libros.Add(libro);

                    }
                }
            }
            return Libros;
        }

        public bool UpdateLibro(Libro updatelibro)
        {
            bool Result = false;

            using (var sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                var query = new SqlCommand("UPDATE Libro SET Nombre = @p0, Descripcion = @p1, GeneroID = @p2) WHERE ID = @p3", sqlConnection);

                query.Parameters.AddWithValue("@p0", updatelibro.Nombre);
                query.Parameters.AddWithValue("@p1", updatelibro.Descripcion);
                query.Parameters.AddWithValue("@p2", updatelibro.GeneroID);
                query.Parameters.AddWithValue("@p3", updatelibro.ID);

                query.ExecuteNonQuery();

                Result = true;
                return Result; 

            }
        }

        public bool DeleteLibro(int id)
        {
            bool Result = false;

            using(var sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();

                var query = new SqlCommand("DELETE FROM Libro WHERE ID = @p0", sqlConnection);
                query.Parameters.AddWithValue("@p0", id);
                query.ExecuteNonQuery();

                Result = true;
                return Result;
            }
        }

    }
}
