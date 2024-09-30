using System.Diagnostics;
using System.Management;

namespace PSGM.Helper
{
    public static class ComputerInfo
    {
        public static Guid GetComputerUUID()
        {
            Guid uuid = Guid.Empty;

            // Erstellen Sie eine ManagementObjectSearcher-Instanz, um WMI-Abfragen durchzuführen
            var searcher = new ManagementObjectSearcher("SELECT UUID FROM Win32_ComputerSystemProduct");

            // Führen Sie die Abfrage aus und iterieren Sie durch die Ergebnisse
            foreach (ManagementObject wmi_ComputerSystemProduct in searcher.Get())
            {
                // Zugriff auf die Eigenschaft "UUID"
                uuid = Guid.Parse(wmi_ComputerSystemProduct["UUID"].ToString());
                Debug.WriteLine($"Machine UUID: {uuid}");
            }

            return uuid;
        }
    }
}
