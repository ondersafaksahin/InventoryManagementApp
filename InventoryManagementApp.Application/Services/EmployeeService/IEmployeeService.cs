using InventoryManagementApp.Application.DTOs.EmployeeDTOs;
using InventoryManagementApp.Domain.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementApp.Application.Services.EmployeeService
{
    public interface IEmployeeService:IBaseService<EmployeeCreateDTO,EmployeeUpdateDTO,EmployeeListDTO,EmployeeDTO,Employee,Guid>
    {
    }
}
