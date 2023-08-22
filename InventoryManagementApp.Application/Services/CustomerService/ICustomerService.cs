using InventoryManagementApp.Application.DTOs.CustomerDTOs;
using InventoryManagementApp.Domain.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementApp.Application.Services.CustomerService
{
    public interface ICustomerService:IBaseService<CustomerCreateDTO,CustomerUpdateDTO,CustomerListDTO,CustomerDTO,Customer,int>
    {
    }
}
