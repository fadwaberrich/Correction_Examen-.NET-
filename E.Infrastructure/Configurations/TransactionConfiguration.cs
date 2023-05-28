using E.ApplicationCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E.Infrastructure.Configurations
{
    public class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            //3-a
            // config de 1-* compte et transaction

            builder.HasOne(p => p.Compte)
                .WithMany(p => p.Transactions)
                .HasForeignKey(p => p.CompteFk)
                .OnDelete(DeleteBehavior.Restrict);

            //config de 1 * DAB et Transaction


            builder.HasOne(p => p.DAB)
                    .WithMany(p => p.Transactions)
                    .HasForeignKey(p => p.DabFK)
                    .OnDelete(DeleteBehavior.Restrict);

            //3-b 
            builder.HasKey(p => new
            {

                p.DabFK,
                p.CompteFk,
                p.Date
            });
        }
    }
}
