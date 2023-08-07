using InventoryManagementApp.Domain.Entities.Abstract.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryManagementApp.Domain.Enums;

namespace InventoryManagementApp.Infrastructure.EntitiyMapping
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T">Type of Entity</typeparam>
    /// <typeparam name="ID">Type of class ID</typeparam>
    public class BaseEntityMapping<T,ID> : IEntityTypeConfiguration<T> where T : class,IBaseEntity,IEntity<ID>
	{
		public virtual void Configure(EntityTypeBuilder<T> builder)
		{
			builder.HasKey(x => x.ID);
			builder.Property(x => x.Status).HasDefaultValue(Status.Active);
			builder.Property(x => x.CreatedDate).HasDefaultValue(DateTime.Now);
		}
	}
}
