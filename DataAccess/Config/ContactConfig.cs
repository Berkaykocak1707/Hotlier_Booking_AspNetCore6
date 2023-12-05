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
    public class ContactConfig : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.HasKey(e => e.ContactID);
            builder.Property(e => e.ContactName).IsRequired().HasMaxLength(100);
            builder.Property(e => e.ContactEmail).IsRequired().HasMaxLength(100);
            builder.Property(e => e.ContactSubject).IsRequired().HasMaxLength(200);
            builder.HasData(new Contact { ContactID = 1, ContactName = "Ali Cabbar", ContactEmail = "Sevdigimkiz@hotmail.com", ContactSubject = "Askere gidiyorum", ContactMessage = "Haberi köye düştü" },
            new Contact { ContactID = 2, ContactName = "Ali Cabbara", ContactEmail = "Sevdigimkiza@hotmail.com", ContactSubject = "Askere gidiyoruma", ContactMessage = "Haberi köye düştü la" }
                );
        }
    }
}
