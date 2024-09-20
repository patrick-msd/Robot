namespace PSGM.Helper
{
    public enum MetadataType : uint
    {
        Unknown = 0,

        ManualCreated = 10000,

        AiGenerated = 20000,
        AiGeneratedAndVerified = 20001,
        AiGeneratedAndVerifiedAndCorrected = 20002,


    }
}
