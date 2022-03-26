using LanitaeShop.DomainModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace LanitaeShop.DataAccess.Mapping
{
    public class PersonMap : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.ToTable("Person");

            builder.Property(pr => pr.ID)
                   .HasColumnName("ID")
                   .HasColumnType("int")
                   .ValueGeneratedOnAdd()
                   .IsRequired(true);

            builder.HasKey(pr => pr.ID);

            builder.Property(pr => pr.PersonName)
                   .HasColumnName("Person_Name")
                   .HasColumnType("varchar")
                   .HasMaxLength(200)
                   .IsRequired(true);

            builder.Property(pr => pr.PersonSurname)
                   .HasColumnName("Person_Surname")
                   .HasColumnType("varchar")
                   .HasMaxLength(200)
                   .IsRequired(true);

            builder.Property(pr => pr.PersonAddress)
                   .HasColumnName("Person_Adress")
                   .HasColumnType("varchar")
                   .HasMaxLength(200)
                   .IsRequired(true);

            builder.HasMany<Sale>(pr => pr.Sale)
                   .WithOne(sl => sl.Person)
                   .HasForeignKey(sl => sl.PersonID)
                   .IsRequired(true)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
