using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Config
{
    public class SubscribeConfig : IEntityTypeConfiguration<Subscribe>
    {
        public void Configure(EntityTypeBuilder<Subscribe> builder)
        {
            builder.HasKey(e => e.SubscribeID);
            builder.Property(e => e.SubscribeEmail).IsRequired().HasMaxLength(100);
            builder.HasData(new Subscribe { SubscribeID = 1, SubscribeEmail = "kocak@gmail.com" },
                new Subscribe { SubscribeID = 2, SubscribeEmail = "kocak2@gmail.com" });
        }
    }
}
