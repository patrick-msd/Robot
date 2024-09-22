namespace PSGM.Helper
{
    public enum FieldOfEmployment : int
    {
        Unknown = 0,

        ProjectManager = 10000,
        ProjectEmployee = 10000,

        QualityManager = 20000,
        QualityEmployee = 20001,
        QualityManagerForImages = 21000,
        QualityEmployeeForImages = 21001,
        QualityManagerForTranscription = 22000,
        QualityEmployeeForTranscription = 22001,

        ScanManager = 50000,
        ScanEmployee = 50001,
    }
}
