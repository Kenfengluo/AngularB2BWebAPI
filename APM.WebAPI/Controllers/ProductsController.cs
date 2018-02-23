using APM.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using System.Web.Http.OData;

namespace APM.WebAPI.Controllers
{
    [EnableCorsAttribute("http://localhost:60251", "*", "*")]  
    public class ProductsController : ApiController
    {
        // GET: api/Products
        [EnableQuery()]
        [ResponseType(typeof(Product))]
        public IHttpActionResult Get()
        {
            try
            {
                var repo = new ProductRepository();
                return Ok(repo.Retrieve().AsQueryable());
            }
            catch (Exception ex)
            {
                return InternalServerError(ex); 
            }
        }

        // GET: api/Products/5
        [ResponseType(typeof(Product))]
        public IHttpActionResult Get(int id)
        {
            try
            {
                //throw new ArgumentNullException("this is test");
                Product product;
                var repo = new ProductRepository();
                if (id > 0)
                {
                    var products = repo.Retrieve();
                    product = products.FirstOrDefault(p => p.ProductId == id);
                    if (product == null)
                    {
                        return NotFound();
                    }
                }
                else
                {
                    product = repo.Create();
                }
                return Ok(product);
            }
            catch (Exception ex)
            {             
               return InternalServerError(ex);
            }
        }

        // POST: api/Products
        [ResponseType(typeof(Product))]
        public IHttpActionResult Post([FromBody]Product value)
        {
            try
            {
                if (value == null)
                {
                    return BadRequest("saved product can not be null ");
                }
                var repo = new ProductRepository();
                var prodcut = repo.Save(value);
                if (prodcut == null)
                {
                    return Conflict();
                }
                return Created<Product>(Request.RequestUri + prodcut.ProductId.ToString(), prodcut);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // PUT: api/Products/5
        [ResponseType(typeof(Product))]
        public IHttpActionResult Put(int id, [FromBody]Product value)
        {
            try
            {
                if (value == null)
                {
                    return BadRequest("saved product can not be null ");
                }
                var repo = new ProductRepository();
                var updatedproduct = repo.Save(id, value);
                if (updatedproduct == null)
                {
                    return NotFound();
                }
                return Ok();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // DELETE: api/Products/5
        public void Delete(int id)
        {
        }
    }
}
