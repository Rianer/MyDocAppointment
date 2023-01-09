//using Microsoft.EntityFrameworkCore.Metadata.Builders;
//using Microsoft.EntityFrameworkCore;
//using MyDocAppointment.Business.Logistics.Internal;

//namespace MyDocAppointment.Infrastructure.Configurations
//{
//    internal class DrugConfiguration : IEntityTypeConfiguration<Drug>
//    {
//        public void Configure(EntityTypeBuilder<Drug> builder)
//        {
//            builder.HasKey(d => d.Id);
//            builder.Property(d => d.Name);
//            builder.Property(d => d.Vendor);
//            builder.Property(d => d.Category);
//            builder.Property(d => d.Price);
//            builder.HasMany(d => d.DrugStocks).WithOne(ds => ds.Item);
//        }
//    }
//}
