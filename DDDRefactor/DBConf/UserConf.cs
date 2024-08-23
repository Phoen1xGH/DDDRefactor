using DDDRefactor.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDDRefactor.DBConf
{
    internal class UserConf : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ComplexProperty(u => u.PhoneNumber).Property(e => e.Number).HasColumnName("PhoneNumber");
            builder.ComplexProperty(u => u.AccessRights).Property(u => u.Rights).HasColumnName("Rights");
        }
    }
}
