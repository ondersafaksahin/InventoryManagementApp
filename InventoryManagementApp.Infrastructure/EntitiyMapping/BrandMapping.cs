using InventoryManagementApp.Domain.Entities.Concrete;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementApp.Infrastructure.EntitiyMapping
{
	public class BrandMapping:BaseEntityMapping<Brand,int>
	{
		public override void Configure(EntityTypeBuilder<Brand> builder)
		{
			base.Configure(builder);
			builder.HasKey(x => x.ID);
		}
	}
}
