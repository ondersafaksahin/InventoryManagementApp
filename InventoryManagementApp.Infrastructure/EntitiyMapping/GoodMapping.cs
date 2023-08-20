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
            builder.HasOne(x => x.Model).WithOne(x => x.Good).HasForeignKey<Good>(x => x.ModelId);
        }
    }


   
}
