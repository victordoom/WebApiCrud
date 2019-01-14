using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Newtonsoft.Json;
using SLC;

namespace NProxyService
{
    public class Proxy : IService
    {
        string BaseAddress = "http://localhost:52573/";
       
        #region Peticiones POST AND GET
      
        public async Task<T> SendPost<T, PostData>(string requestURI, PostData data)
        {
            T Result = default(T);
            using (var Client = new HttpClient())
            {
                try
                {
                  
                    requestURI = BaseAddress + requestURI;  http://localhost:785/api/products/cretepro
                    Client.DefaultRequestHeaders.Accept.Clear();
                    Client.DefaultRequestHeaders.Accept.Add(
                        new MediaTypeWithQualityHeaderValue("application/json"));

                    var JsonData = JsonConvert.SerializeObject(data);
                    HttpResponseMessage Response =
                        await Client.PostAsync(requestURI,
                        new StringContent(JsonData.ToString(),
                        Encoding.UTF8, "application/json"));
                    var ResultWebAPI = await Response.Content.ReadAsStringAsync();
                    Result = JsonConvert.DeserializeObject<T>(ResultWebAPI);

                }
                catch (Exception)
                {

                    throw;
                }
            }
            return Result;
        }

        // Peticiones GET
        public async Task<T> SendGet<T>(string requesURI)
        {
            T Result = default(T);
            using (var Client = new HttpClient())
            {
                try
                {
                    requesURI = BaseAddress + requesURI;

                    Client.DefaultRequestHeaders.Accept.Clear();
                    Client.DefaultRequestHeaders.Accept.Add(
                        new MediaTypeWithQualityHeaderValue("application/json"));

                    var ResultJSON = await Client.GetStringAsync(requesURI);
                    Result = JsonConvert.DeserializeObject<T>(ResultJSON);
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return Result;
        }
        #endregion

        public async Task<Libro> CreateLibroAsync(Libro newLibro)
        {
            return await SendPost<Libro, Libro>
                ("/api/libros/createlibro", newLibro);
        }

     
        public Libro CreateProduct(Libro newLibro)
        {
            Libro Result = null;
            Task.Run(async () => Result = await CreateLibroAsync(newLibro)).Wait();
            return Result;

        }

        public async Task<List<Libro>> FilterLibroByGeneroIDAsync(int ID)
        {
            return await SendGet<List<Libro>>
                ($"/api/products/FilterLibroByGeneroID/{ID}");
        }

        public List<Libro> FilterLibroByGeneroID(int GeneroID)
        {
            List<Libro> Result = null;
            Task.Run(async () => Result = await FilterLibroByGeneroIDAsync(GeneroID)).Wait();
            return Result;
        }

        public async Task<bool> RemoveLibroAsync(int ID)
        {
            return await SendGet<bool>($"/api/libros/removelibro/{ID}");
        }
        public bool RemoveLibro(int ID)
        {
            bool Result = false;
            Task.Run(async () => Result =
              await RemoveLibroAsync(ID)).Wait();
            return Result;
        }
        public async Task<List<Libro>> RetrieveAllLibroAsync()
        {
            return await SendGet<List<Libro>>(
                "/api/libros/RetrieveAllLibro");
        }
        public List<Libro> RetrieveAllLibro()
        {
            List<Libro> Result = null;
            Task.Run(async () => Result = await RetrieveAllLibroAsync()).Wait();
            return Result;
        }
        public async Task<Libro> RetrieveLibroByIDAsync(int ID)
        {
            return await SendGet<Libro>
                ($"/api/libros/RetrieveLibroByID/{ID}");
        }

        public Libro RetrieveLibroByID(int ID)
        {
            Libro Result = null;
            Task.Run(async () => Result = await
            RetrieveLibroByIDAsync(ID)).Wait();
            return Result;
        }

        public async Task<bool> UpdateLibroAsync(Libro libroToUpdate)
        {
            return await SendPost<bool, Libro>
                ("/api/libros/UpdateLibro", libroToUpdate);
        }

        public bool UpdateLibro(Libro libroToUpdate)
        {
            bool Result = false;
            Task.Run(async () => Result =
            await UpdateLibroAsync(libroToUpdate)).Wait();
            return Result;
        }

        public async Task<bool> DeleteLibroAsync(int ID)
        {
            return await SendGet<bool>($"/api/libros/DeleteLibro/");
        }
        public bool DeleteLibro(int ID)
        {
            bool Result = false;
            Task.Run(async () => Result = await DeleteLibroAsync(ID)).Wait();
            return Result;
        }
    }
}
