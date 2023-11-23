using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementApp.Domain.Enums
{
    public enum Status
    {
        Active=1,
        Passive=2,
        Deleted=4,
        Created,
        Approved, 
        Partially_Completed, 
        Completed
    }
}
