using System.Diagnostics;

public class WindowsMetrics : ISystemMetrics
{
# pragma warning disable CA1416 // disable "obsolete API" warning (PerformanceCounter is windows-only)

    private PerformanceCounter cpuCounter;
    private PerformanceCounter memoryCounter;

    public WindowsMetrics()
    {
        cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
        memoryCounter = new PerformanceCounter("Memory", "Available MBytes");
    }

    public float GetCpuUsage()
    {
        return cpuCounter.NextValue();
    }

    public float GetMemoryUsage()
    {
        return memoryCounter.NextValue();
    }

#pragma warning restore CA1416
}