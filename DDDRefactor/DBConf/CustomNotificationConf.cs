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
    internal class CustomNotificationConf : IEntityTypeConfiguration<CustomNotification>
    {
        public void Configure(EntityTypeBuilder<CustomNotification> builder)
        {
            builder.HasMany(cn => cn.Emails).WithMany();
        }
    }
}
