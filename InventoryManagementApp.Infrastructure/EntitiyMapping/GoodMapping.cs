using InventoryManagementApp.Domain.Entities.Concrete;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementApp.Infrastructure.EntitiyMapping
{
    public class GoodMapping:BaseEntityMapping<Good, int>
    {

        public override void Configure(EntityTypeBuilder<Good> builder)
        {
            base.Configure(builder);
            builder.HasKey(x => x.ID);
            builder.HasOne(x => x.BillOfMaterial).WithOne(x => x.Product).HasForeignKey<Good>(x => x.BillOfMaterialID);
            builder.HasOne(x => x.Brand).WithMany(x => x.Goods).HasForeignKey(x => x.BrandId);
            builder.HasIndex(x => x.Code).IsUnique();
            builder.Property(x => x.Code).HasMaxLength(40);
        }
    }


   
}
