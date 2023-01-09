//using Microsoft.EntityFrameworkCore.Metadata.Builders;
//using Microsoft.EntityFrameworkCore;

//namespace MyDocAppointment.Infrastructure.Configurations
//{
//    internal class DrugStockConfiguration : IEntityTypeConfiguration<DrugStock>
//    {
//        public void Configure(EntityTypeBuilder<DrugStock> builder)
//        {
//            builder.HasKey(d => d.Id);
//            builder.HasOne(d => d.Item).WithMany(d => d.DrugStocks);
//            builder.Property(d => d.Quantity);
//            builder.Property(d => d.IsRestricted);
//        }
//    }
//}
