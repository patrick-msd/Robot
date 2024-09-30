namespace PSGM.Model.DbMain
{
    public static partial class Unit_DefectType
    {
        public static DbMain_Unit_DefectType Defect1_V1_0_0()
        {
            return new DbMain_Unit_DefectType
            {
                Id = new Guid("4acf4f73-42ad-433c-b8da-edee061ebb05"),

                Name_EN = "Defect1",
                Description_EN = "Defect1 Description",
                Name_DE = "Defect1",
                Description_DE = "Defect1 Description",
                Name_FR = "Defect1",
                Description_FR = "Defect1 Description",
                Name_SP = "Defect1",
                Description_SP = "Defect1 Description",
                Name_IT = "Defect1",
                Description_IT = "Defect1 Description",

                // FK
                UnitDefects = null
            };
        }

        public static DbMain_Unit_DefectType Defect2_V1_0_0()
        {
            return new DbMain_Unit_DefectType
            {
                Id = new Guid("09f48f33-224b-42ce-8226-e8e040a5bf6a"),

                Name_EN = "Defect2",
                Description_EN = "Defect2 Description",
                Name_DE = "Defect2",
                Description_DE = "Defect2 Description",
                Name_FR = "Defect2",
                Description_FR = "Defect2 Description",
                Name_SP = "Defect2",
                Description_SP = "Defect2 Description",
                Name_IT = "Defect2",
                Description_IT = "Defect2 Description",

                // FK
                UnitDefects = null
            };
        }
    }
}
