using InventoryManagementApp.Domain.Entities.Concrete;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementApp.Infrastructure.EntitiyMapping
{
	public class BatchMapping : BaseEntityMapping<Batch, int>
	{
		public override void Configure(EntityTypeBuilder<Batch> builder)
		{
			base.Configure(builder);
			builder.HasKey(x => x.ID);
			builder.HasOne(x => x.Product).WithMany(x => x.Batches).HasForeignKey(x => x.ProductID);
		}
	}
}
