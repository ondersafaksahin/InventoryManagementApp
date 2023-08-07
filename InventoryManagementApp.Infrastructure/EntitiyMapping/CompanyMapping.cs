using InventoryManagementApp.Domain.Entities.Abstract.Classes;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementApp.Infrastructure.EntitiyMapping
{
    public class CompanyMapping:BaseEntityMapping<Company,int>
	{
		public override void Configure(EntityTypeBuilder<Company> builder)
		{
			base.Configure(builder);

		}
	}
}
