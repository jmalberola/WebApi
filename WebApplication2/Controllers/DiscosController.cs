using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class DiscosController : ApiController
    {
        // GET: api/Discos
        public IEnumerable<Disco> Get()
        {
            var repo = new DiscosRepository();
            List<Disco> discos = repo.Retrieve();
            return discos;
        }

        // GET: api/Discos?anyo=valor1&anyofin=valor2
        public IEnumerable<Disco> Get(int anyo,int anyofin)
        {
            var repo = new DiscosRepository();
            List<Disco> discos = repo.RetrievebyYear(anyo,anyofin);
            return discos;
        }                

        // GET: api/Discos/5        
        public Disco Get(int id)
        {

            /*var repo = new DiscosRepository();
            Disco d = repo.Retrieve();*/
            return null;

        }

        // POST: api/Discos
        public void Post([FromBody]Disco disco)
        {
            var repo = new DiscosRepository();
            repo.Save(disco);
        }

        // PUT: api/Discos/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Discos/5
        public void Delete(int id)
        {
        }
    }
}
