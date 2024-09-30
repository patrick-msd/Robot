using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PSGM.Model.DbMain
{
    public class DbMain_WorkflowType_Configuration : IEntityTypeConfiguration<DbMain_WorkflowType>
    {
        public void Configure(EntityTypeBuilder<DbMain_WorkflowType> builder)
        {

            builder.ToTable("WorkflowType");
            //builder.Property(s => s.Age).IsRequired(false);
            //builder.Property(s => s.IsRegularStudent).HasDefaultValue(true);
            builder.HasData
            (
            #region Storage
            #endregion

            #region Database
            #endregion

            #region Storage & Database
                WorkflowType.StorageAndDatabase_Save_V1_0_0(),
            #endregion

            #region Vision 2D
                WorkflowType.Vision2D_GrabImage_V1_0_0(),
            #endregion

            #region Vision 3D
            #endregion

            #region Images
                WorkflowType.Image_HDR_V1_0_0(),
                WorkflowType.Image_Darktable_V1_0_0(),
                WorkflowType.Image_Resize_V1_0_0(),
                WorkflowType.Image_Crop_V1_0_0(),
                WorkflowType.Image_Rotate_V1_0_0(),
                WorkflowType.Image_Rotate_V2_0_0(),
                WorkflowType.Image_Sharpen_V1_0_0(),
                WorkflowType.Image_Sharpen_V2_0_0(),
            #endregion

            #region Images Quality
                WorkflowType.Image_SharpeningCheck_V1_0_0(),
                WorkflowType.Image_ImageExposureCheck_V1_0_0()
            #endregion

            #region Achive
            #endregion

            #region Data transfer
            #endregion
            );
        }
    }
}
