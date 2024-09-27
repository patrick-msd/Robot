using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PSGM.Helper;

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
                new DbMain_QrCodeType
                {
                    Id = QrCodeType_Id.Batch_V1_0_0,

                    Name = "Batch - V1.0.0",
                    Description = "Batch of documents ...",

                    //CreatedByUserIdExtAutoFill = Guid.Empty,
                    //CreatedDateTimeAutoFill = DateTime.Now,
                    //ModifiedByUserIdExtAutoFill = Guid.Empty,
                    //ModifiedDateTimeAutoFill = DateTime.Now,

                    // FK
                    QrCode = null,
                    QrCodeId = null,
                },

                new DbMain_QrCodeType
                {
                    Id = QrCodeType_Id.ScanUnit_V1_0_0,

                    Name = "Scan unit - V1.0.0",
                    Description = "Scan unit ...",

                    //CreatedByUserIdExtAutoFill = Guid.Empty,
                    //CreatedDateTimeAutoFill = DateTime.Now,
                    //ModifiedByUserIdExtAutoFill = Guid.Empty,
                    //ModifiedDateTimeAutoFill = DateTime.Now,

                    // FK
                    QrCode = null,
                    QrCodeId = null,
                },

                new DbMain_QrCodeType
                {
                    Id = QrCodeType_Id.ReplaceImage_V1_0_0,

                    Name = "Replace Image - V1.0.1",
                    Description = "Replace Image ...",

                    //CreatedByUserIdExtAutoFill = Guid.Empty,
                    //CreatedDateTimeAutoFill = DateTime.Now,
                    //ModifiedByUserIdExtAutoFill = Guid.Empty,
                    //ModifiedDateTimeAutoFill = DateTime.Now,

                    // FK
                    QrCode = null,
                    QrCodeId = null,
                },

                new DbMain_QrCodeType
                {
                    Id = QrCodeType_Id.IgnoreDoublePageSensor_V1_0_0,

                    Name = "Ignore Double Page Sensor - V1.0.0",
                    Description = "Ignore Double Page Sensor ...",

                    //CreatedByUserIdExtAutoFill = Guid.Empty,
                    //CreatedDateTimeAutoFill = DateTime.Now,
                    //ModifiedByUserIdExtAutoFill = Guid.Empty,
                    //ModifiedDateTimeAutoFill = DateTime.Now,

                    // FK
                    QrCode = null,
                    QrCodeId = null,
                }
            );
        }
    }
}
