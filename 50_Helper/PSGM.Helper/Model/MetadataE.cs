namespace PSGM.Helper
{
    public enum MetadataType : int
    {
        Unknown = 0,

        ManualCreated = 10000,

        AiGenerated = 20000,
        AiGeneratedAndVerified = 20001,
        AiGeneratedAndVerifiedAndCorrected = 20002,
    }

    public enum MetadataPermissions : int
    {
        Unknown = 0,

        Hidden = 10000,

        Private = 20000,

        Organization = 30000,
        Project = 30001,

        Public = 90000,
    }
}
