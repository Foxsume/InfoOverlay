using System.Runtime.InteropServices;

public class SystemMetricsFactory
{
    public static ISystemMetrics CreateSystemMetrics()
    {
        if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
        {
            return new WindowsMetrics();
        }
        else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
        {
            return new LinuxMetrics();
        }
        else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
        {
            return new MacMetrics();
        }
        else
        {
            throw new NotSupportedException("Unsupported OS");
        }
    }
}