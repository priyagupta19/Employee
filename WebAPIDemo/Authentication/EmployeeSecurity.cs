using EmployeeDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPIDemo.Authentication
{
    public class EmployeeSecurity
    {
        public static bool Login(string userName, string password)
        {
            using (EmployeeEntities entities = new EmployeeEntities())
            {
                return entities.Users.Any(x => x.UserName.Equals(userName, StringComparison.OrdinalIgnoreCase) && x.Password == password);
            }
        }
    }
}