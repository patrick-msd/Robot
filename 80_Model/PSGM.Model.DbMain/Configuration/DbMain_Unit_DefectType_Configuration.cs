using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PSGM.Model.DbMain
{
    public class DbMain_Unit_DefectType_Configuration : IEntityTypeConfiguration<DbMain_Unit_DefectType>
    {
        public void Configure(EntityTypeBuilder<DbMain_Unit_DefectType> builder)
        {
            builder.ToTable("Unit_DefectType");
            //builder.Property(s => s.Age).IsRequired(false);
            //builder.Property(s => s.IsRegularStudent).HasDefaultValue(true);
            builder.HasData
            (
                Unit_DefectType.Defect1_V1_0_0(),
                Unit_DefectType.Defect2_V1_0_0()
            );
        }
    }
}
