using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PSGM.Helper;

namespace PSGM.Model.DbWorkflow
{
    public class DbWorkflow_WorkflowItemConfiguration : IEntityTypeConfiguration<DbWorkflow_WorkflowItem>
    {
        public void Configure(EntityTypeBuilder<DbWorkflow_WorkflowItem> builder)
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
                new DbWorkflow_WorkflowItem
                {
                    Id = Workflow_DbMain_RootDirectories.StorageAndDatabase_Save_V1_0_0,

                    Name = "Save object to S3 storage or filesystem and add entity to database - V1.0.0",
                    Description = "Save object (depending on storage configuration in project parameters) to specified S3 storage or filesystem and add the file entity to the database...",

                    ApplyLevel = ApplyLevel.File,

                    Configuration = string.Empty,

                    // FK
                    WorkflowItemLinks = null,
                },
                #endregion

                #region Vision 2D
                // Grab image - V1.0.0
                new DbWorkflow_WorkflowItem
                {
                    Id = Workflow_DbMain_RootDirectories.Vision2D_GrabImage_V1_0_0,

                    Name = "Grab image - V1.0.0",
                    Description = "Grab image with specified camera ...",

                    ApplyLevel = ApplyLevel.File,

                    Configuration = string.Empty,

                    // FK
                    WorkflowItemLinks = null,
                },
                #endregion

                #region Images
                // Calculate HDR image - V1.0.0
                new DbWorkflow_WorkflowItem
                {
                    Id = Workflow_DbMain_RootDirectories.Image_HDR_V1_0_0,

                    Name = "Calculate HDR image - V1.0.0",
                    Description = "Calculate HDR image with OpenCV (mergeMertens) ...",

                    ApplyLevel = ApplyLevel.File,

                    Configuration = string.Empty,

                    // FK
                    WorkflowItemLinks = null,
                },

                // Calculate darktable image - V1.0.0
                new DbWorkflow_WorkflowItem()
                {
                    Id = Workflow_DbMain_RootDirectories.Image_Darktable_V1_0_0,

                    Name = "Calculate darktable image - V1.0.0",
                    Description = "Calculate darktable image according to the sidecar file ...",

                    ApplyLevel = ApplyLevel.File,

                    Configuration = string.Empty,

                    // FK
                    WorkflowItemLinks = null,
                },

                // Resize image - V1.0.0
                new DbWorkflow_WorkflowItem
                {
                    Id = Workflow_DbMain_RootDirectories.Image_Resize_V1_0_0,

                    Name = "Resize image - V1.0.0",
                    Description = "Resize image to specified size...",

                    ApplyLevel = ApplyLevel.File,

                    Configuration = string.Empty,

                    // FK
                    WorkflowItemLinks = null,
                },

                // Crop image - V1.0.0
                new DbWorkflow_WorkflowItem
                {
                    Id = Workflow_DbMain_RootDirectories.Image_Crop_V1_0_0,

                    Name = "Crop image - V1.0.0",
                    Description = "Crop image to specified size...",

                    ApplyLevel = ApplyLevel.File,

                    Configuration = string.Empty,

                    // FK
                    WorkflowItemLinks = null,
                },

                // Rotate image - V1.0.0
                new DbWorkflow_WorkflowItem
                {
                    Id = Workflow_DbMain_RootDirectories.Image_Rotate_V1_0_0,

                    Name = "Rotate image - V1.0.0",
                    Description = "Rotate image ...",

                    ApplyLevel = ApplyLevel.File,

                    Configuration = string.Empty,

                    // FK
                    WorkflowItemLinks = null,
                },

                // Rotate image - V2.0.0
                new DbWorkflow_WorkflowItem
                {
                    Id = Workflow_DbMain_RootDirectories.Image_Rotate_V2_0_0,

                    Name = "Rotate image - V2.0.0",
                    Description = "Rotate image ...",

                    ApplyLevel = ApplyLevel.File,

                    Configuration = string.Empty,

                    // FK
                    WorkflowItemLinks = null,
                },

                // Sharpen image - V1.0.0
                new DbWorkflow_WorkflowItem
                {
                    Id = Workflow_DbMain_RootDirectories.Image_Sharpen_V1_0_0,

                    Name = "Sharpen image - V1.0.0",
                    Description = "Sharpen image ...",

                    ApplyLevel = ApplyLevel.File,

                    Configuration = string.Empty,

                    // FK
                    WorkflowItemLinks = null,
                },

                // Sharpen image - V2.0.0
                new DbWorkflow_WorkflowItem
                {
                    Id = Workflow_DbMain_RootDirectories.Image_Sharpen_V2_0_0,

                    Name = "Sharpen image - V2.0.0",
                    Description = "Sharpen image ...",

                    ApplyLevel = ApplyLevel.File,

                    Configuration = string.Empty,

                    // FK
                    WorkflowItemLinks = null,
                }
                #endregion
            );
        }
    }
}
