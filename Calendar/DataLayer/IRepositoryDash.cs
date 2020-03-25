using Calendar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calendar.DataLayer
{
    public interface IRepositoryDash
    {

        List<Employee> GetEmployees();
    }
}
