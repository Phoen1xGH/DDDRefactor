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
    internal class ContactConf : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.ComplexProperty(c => c.Email).Property(e => e.Address).HasColumnName("EmailAddress");
            builder.ComplexProperty(c => c.PhoneNumber).Property(n => n.Number).HasColumnName("PhoneNumber");
        }
    }
}
