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
            builder.HasOne(x => x.ProductionOrder).WithOne(x => x.Batch).HasForeignKey<ProductionOrder>(x => x.ID);
            builder.HasOne(x => x.GoodsReceiptDetail).WithOne(x => x.Batch).HasForeignKey<GoodsReceiptDetail>(x => x.ID);
            builder.HasKey(x => x.ID);
			builder.HasIndex(x => x.BatchCode).IsUnique();
		}
	}
}
