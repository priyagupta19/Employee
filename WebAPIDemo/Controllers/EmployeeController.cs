using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using EmployeeDataAccess;
using WebAPIDemo.Authentication;

namespace WebAPIDemo.Controllers
{
    [EnableCorsAttribute("*", "*", "*")]
    public class EmployeeController : ApiController
    {
        [BasicAuthentication]
        public IEnumerable<Person> Get()
        {
            using (EmployeeEntities entities = new EmployeeEntities())
            {
                return entities.People.ToList();
            }
        }

        public Person Get(int id)
        {
            using (EmployeeEntities entities = new EmployeeEntities())
            {
                return entities.People.FirstOrDefault(e => e.Id == id);
            }
        }
    }
}
