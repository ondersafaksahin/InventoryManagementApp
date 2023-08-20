using InventoryManagementApp.Domain.Entities.Concrete;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementApp.Infrastructure.EntitiyMapping
{
	public class BillOfMaterialMapping:BaseEntityMapping<BillOfMaterial,int>
	{
		public override void Configure(EntityTypeBuilder<BillOfMaterial> builder)
		{
			base.Configure(builder);
			builder.HasKey(x => x.ID);
			builder.HasOne(x => x.Product).WithOne(x => x.BillOfMaterial).HasForeignKey<Good>(x => x.ID);
			
        }
	}
}
