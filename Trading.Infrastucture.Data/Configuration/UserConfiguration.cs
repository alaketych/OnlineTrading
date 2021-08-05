namespace Trading.Infrastucture.Data.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Trading.Domain.Entities;

    public class UserConfiguration : IEntityTypeConfiguration<User>
	{
		public void Configure(EntityTypeBuilder<User> entity)
		{
            entity
                .HasKey(key => key.Id);

            entity
                .Property(property => property.FirstName)
                .HasMaxLength(50)
                .IsRequired();

            entity
                .Property(property => property.LastName)
                .HasMaxLength(50)
                .IsRequired();

            entity
                .Property(property => property.Email)
                .HasMaxLength(100)
                .IsRequired();

            entity.HasIndex(property => property.Email)
                .IsUnique();

            entity
                .Property(property => property.Phone)
                .HasMaxLength(30)
                .IsRequired();

            entity
                .Property(property => property.PasswordHash)
                .HasMaxLength(64)
                .IsFixedLength()
                .IsRequired();

            entity
                .Property(property => property.PasswordSalt)
                .HasMaxLength(128)
                .IsFixedLength()
                .IsRequired();
        }
	}
}
