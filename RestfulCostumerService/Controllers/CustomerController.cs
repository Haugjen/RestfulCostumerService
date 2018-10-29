using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassLibraryForCustomer.model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RestfulCostumerService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private static Customer c1 = new Customer(00, "Karl", "Jansen", 1990);
        private static Customer c2 = new Customer(01, "Lenny", "Kraven", 2000);
        private static Customer c3 = new Customer(02, "Maria", "Linden", 2010);

        private static List<Customer> cList = new List<Customer> { c1, c2, c3 };





        // GET: api/Customer
        [HttpGet]
        [Route("All")]
        public IEnumerable<Customer> Get()
        {
            return cList;
        }

        // GET: api/Customer/5
        [HttpGet("{id}", Name = "Get")]
        [Route("{id}")]
        public Customer Get(int id)
        {
            foreach (Customer c in cList)
            {
                if (c.Id == id)
                {
                    return c;
                }
            }
            return null;

            //  Dette kan gøres hvis service ligger på azure, men giver ikke mening i almindelig debug mode
            // throw new ArgumentException("invald id");
        }

        // POST: api/Customer
        [HttpPost]
        public void Post([FromBody] Customer obj)
        {
            cList.Add(obj);
        }

        // PUT: api/Customer/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Customer obj)
        {
            int firstHit()
            {
                for (int i = 0; i < cList.Count; i++)
                {
                    if (cList[i].Id == id)
                    {
                        return i;
                    }
                }
                return -1;
            }

            int hit = firstHit();
            

            if (hit != -1)
            {
                cList[hit] = obj;
            }

        }

        // DELETE: api/Customer/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            cList.RemoveAt(id);
        }
    }
}
