using BookStore.Domain.Models;
using BookStore.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStore.DAL.Configurations
{
    internal class BookConfiguratrions : IEntityTypeConfiguration<BookEntity> 
    {
        public void Configure(EntityTypeBuilder<BookEntity> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(b => b.Title)
                .HasMaxLength(Book.MAX_TITLE_LENGTH)
                .IsRequired();

            builder.Property(b => b.Description)
                .IsRequired();

            builder.Property(b => b.Price)
                .IsRequired();

            builder.Property(b => b.DateAdded)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .IsRequired();
        }
    }
}
