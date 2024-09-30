using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PSGM.Model.DbMain
{
    public class DbMain_QrCodeType_Configuration : IEntityTypeConfiguration<DbMain_QrCodeType>
    {
        public void Configure(EntityTypeBuilder<DbMain_QrCodeType> builder)
        {
            builder.ToTable("QrCodeType");
            //builder.Property(s => s.Age).IsRequired(false);
            //builder.Property(s => s.IsRegularStudent).HasDefaultValue(true);
            builder.HasData
            (
                QrCodeType.Batch_V1_0_0(),
                QrCodeType.ScanUnit_V1_0_0(),

                QrCodeType.IgnoreDoublePageSensor_V1_0_0(),
                QrCodeType.ReplaceImage_V1_0_0()
            );
        }
    }
}
