using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PSGM.Helper;

namespace PSGM.Model.DbMain
{
    public class DbMain_WorkflowType_Configuration : IEntityTypeConfiguration<DbMain_WorkflowType>
    {
        public void Configure(EntityTypeBuilder<DbMain_WorkflowType> builder)
        {
            builder.ToTable("WorkflowItem");
            //builder.Property(s => s.Age).IsRequired(false);
            //builder.Property(s => s.IsRegularStudent).HasDefaultValue(true);
            builder.HasData
            (
                #region Storage
                #endregion

                #region Database
                #endregion

                #region Storage & Database
                // Save object to S3 storage or filesystem and add entity to database - V1.0.0
                new DbMain_WorkflowType
                {
                    Id = WorkflowItem_Id.StorageAndDatabase_Save_V1_0_0,

                    Name = "Save object to S3 storage or filesystem and add entity to database - V1.0.0",
                    Description = "Save object (depending on storage configuration in project parameters) to specified S3 storage or filesystem and add the file entity to the database...",
                    
                    WorkflowApplyLevel = WorkflowApplyLevel.File,
                    WorkflowExecutionLevel = WorkflowExecutionLevel.ManuallyAndAutomatically,

                    //CreatedByUserIdExtAutoFill = Guid.Empty,
                    //CreatedDateTimeAutoFill = DateTime.Now,
                    //ModifiedByUserIdExtAutoFill = Guid.Empty,
                    //ModifiedDateTimeAutoFill = DateTime.Now,

                    // FK
                    WorkflowItemLinks = null,
                },
                #endregion

                #region Vision 2D
                // Grab image - V1.0.0
                new DbMain_WorkflowType
                {
                    Id = WorkflowItem_Id.Vision2D_GrabImage_V1_0_0,

                    Name = "Grab image - V1.0.0",
                    Description = "Grab image with specified camera ...",

                    WorkflowApplyLevel = WorkflowApplyLevel.File,
                    WorkflowExecutionLevel = WorkflowExecutionLevel.Automatically,

                    //CreatedByUserIdExtAutoFill = Guid.Empty,
                    //CreatedDateTimeAutoFill = DateTime.Now,
                    //ModifiedByUserIdExtAutoFill = Guid.Empty,
                    //ModifiedDateTimeAutoFill = DateTime.Now,

                    // FK
                    WorkflowItemLinks = null,
                },
                #endregion

                #region Vision 3D
                #endregion

                #region Images
                // Calculate HDR image - V1.0.0
                new DbMain_WorkflowType
                {
                    Id = WorkflowItem_Id.Image_HDR_V1_0_0,

                    Name = "Calculate HDR image - V1.0.0",
                    Description = "Calculate HDR image with OpenCV (mergeMertens) ...",

                    WorkflowApplyLevel = WorkflowApplyLevel.File,
                    WorkflowExecutionLevel = WorkflowExecutionLevel.ManuallyAndAutomatically,

                    //CreatedByUserIdExtAutoFill = Guid.Empty,
                    //CreatedDateTimeAutoFill = DateTime.Now,
                    //ModifiedByUserIdExtAutoFill = Guid.Empty,
                    //ModifiedDateTimeAutoFill = DateTime.Now,

                    // FK
                    WorkflowItemLinks = null,
                },

                // Calculate darktable image - V1.0.0
                new DbMain_WorkflowType()
                {
                    Id = WorkflowItem_Id.Image_Darktable_V1_0_0,

                    Name = "Calculate darktable image - V1.0.0",
                    Description = "Calculate darktable image according to the sidecar file ...",

                    WorkflowApplyLevel = WorkflowApplyLevel.File,
                    WorkflowExecutionLevel = WorkflowExecutionLevel.ManuallyAndAutomatically,

                    //CreatedByUserIdExtAutoFill = Guid.Empty,
                    //CreatedDateTimeAutoFill = DateTime.Now,
                    //ModifiedByUserIdExtAutoFill = Guid.Empty,
                    //ModifiedDateTimeAutoFill = DateTime.Now,

                    // FK
                    WorkflowItemLinks = null,
                },

                // Resize image - V1.0.0
                new DbMain_WorkflowType
                {
                    Id = WorkflowItem_Id.Image_Resize_V1_0_0,

                    Name = "Resize image - V1.0.0",
                    Description = "Resize image to specified size...",

                    WorkflowApplyLevel = WorkflowApplyLevel.File,
                    WorkflowExecutionLevel = WorkflowExecutionLevel.ManuallyAndAutomatically,

                    //CreatedByUserIdExtAutoFill = Guid.Empty,
                    //CreatedDateTimeAutoFill = DateTime.Now,
                    //ModifiedByUserIdExtAutoFill = Guid.Empty,
                    //ModifiedDateTimeAutoFill = DateTime.Now,

                    // FK
                    WorkflowItemLinks = null,
                },

                // Crop image - V1.0.0
                new DbMain_WorkflowType
                {
                    Id = WorkflowItem_Id.Image_Crop_V1_0_0,

                    Name = "Crop image - V1.0.0",
                    Description = "Crop image to specified size...",

                    WorkflowApplyLevel = WorkflowApplyLevel.File,
                    WorkflowExecutionLevel = WorkflowExecutionLevel.ManuallyAndAutomatically,

                    //CreatedByUserIdExtAutoFill = Guid.Empty,
                    //CreatedDateTimeAutoFill = DateTime.Now,
                    //ModifiedByUserIdExtAutoFill = Guid.Empty,
                    //ModifiedDateTimeAutoFill = DateTime.Now,

                    // FK
                    WorkflowItemLinks = null,
                },

                // Rotate image - V1.0.0
                new DbMain_WorkflowType
                {
                    Id = WorkflowItem_Id.Image_Rotate_V1_0_0,

                    Name = "Rotate image - V1.0.0",
                    Description = "Rotate image ...",

                    WorkflowApplyLevel = WorkflowApplyLevel.File,
                    WorkflowExecutionLevel = WorkflowExecutionLevel.ManuallyAndAutomatically,

                    //CreatedByUserIdExtAutoFill = Guid.Empty,
                    //CreatedDateTimeAutoFill = DateTime.Now,
                    //ModifiedByUserIdExtAutoFill = Guid.Empty,
                    //ModifiedDateTimeAutoFill = DateTime.Now,

                    // FK
                    WorkflowItemLinks = null,
                },

                // Rotate image - V2.0.0
                new DbMain_WorkflowType
                {
                    Id = WorkflowItem_Id.Image_Rotate_V2_0_0,

                    Name = "Rotate image - V2.0.0",
                    Description = "Rotate image ...",

                    WorkflowApplyLevel = WorkflowApplyLevel.File,
                    WorkflowExecutionLevel = WorkflowExecutionLevel.ManuallyAndAutomatically,

                    //CreatedByUserIdExtAutoFill = Guid.Empty,
                    //CreatedDateTimeAutoFill = DateTime.Now,
                    //ModifiedByUserIdExtAutoFill = Guid.Empty,
                    //ModifiedDateTimeAutoFill = DateTime.Now,

                    // FK
                    WorkflowItemLinks = null,
                },

                // Sharpen image - V1.0.0
                new DbMain_WorkflowType
                {
                    Id = WorkflowItem_Id.Image_Sharpen_V1_0_0,

                    Name = "Sharpen image - V1.0.0",
                    Description = "Sharpen image ...",

                    WorkflowApplyLevel = WorkflowApplyLevel.File,
                    WorkflowExecutionLevel = WorkflowExecutionLevel.ManuallyAndAutomatically,

                    //CreatedByUserIdExtAutoFill = Guid.Empty,
                    //CreatedDateTimeAutoFill = DateTime.Now,
                    //ModifiedByUserIdExtAutoFill = Guid.Empty,
                    //ModifiedDateTimeAutoFill = DateTime.Now,

                    // FK
                    WorkflowItemLinks = null,
                },

                // Sharpen image - V2.0.0
                new DbMain_WorkflowType
                {
                    Id = WorkflowItem_Id.Image_Sharpen_V2_0_0,

                    Name = "Sharpen image - V2.0.0",
                    Description = "Sharpen image ...",

                    WorkflowApplyLevel = WorkflowApplyLevel.File,
                    WorkflowExecutionLevel = WorkflowExecutionLevel.ManuallyAndAutomatically,

                    //CreatedByUserIdExtAutoFill = Guid.Empty,
                    //CreatedDateTimeAutoFill = DateTime.Now,
                    //ModifiedByUserIdExtAutoFill = Guid.Empty,
                    //ModifiedDateTimeAutoFill = DateTime.Now,

                    // FK
                    WorkflowItemLinks = null,
                }
                #endregion

                #region Achive
                #endregion

                #region Data transfer
                #endregion
            );
        }
    }
}
