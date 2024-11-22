using BookWise.Core.ValueObjects;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookWise.Infrastructure.Persistence.Configurations;

public class AddressConfiguration
{
    public static void ConfigureOwnedType<T>(OwnedNavigationBuilder<T, Address> builder) where T : class
    {
        builder.Property(a => a.Street).HasMaxLength(200).IsRequired();
        builder.Property(a => a.City).HasMaxLength(100).IsRequired();
        builder.Property(a => a.State).HasMaxLength(50).IsRequired();
        builder.Property(a => a.ZipCode).HasMaxLength(20).IsRequired();
        builder.Property(a => a.Country).HasMaxLength(100).IsRequired();
    }
}