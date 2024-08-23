using DDDRefactor.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDDRefactor.DBConf
{
    internal class RequestMemberCOnf : IEntityTypeConfiguration<RequestMember>
    {
        public void Configure(EntityTypeBuilder<RequestMember> builder)
        {
            builder.HasOne(rm => rm.Specification).WithOne(s => s.RequestMember).HasForeignKey<Specification>(s => s.RequestMemberId);
            builder.HasOne(rm => rm.Agreement)
                .WithOne(a => a.RequestMember)
                .HasForeignKey<Agreement>(a => a.RequestMemberId);
        }
    }
}
