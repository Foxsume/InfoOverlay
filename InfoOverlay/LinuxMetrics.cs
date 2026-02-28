public class LinuxMetrics : ISystemMetrics
{
    public float GetCpuUsage()
    {
        string[] stats = File.ReadAllLines("/proc/stat");
        string[] cpuStats = stats[0].Split(' ');
        long user = long.Parse(cpuStats[1]);
        long nice = long.Parse(cpuStats[2]);
        long system = long.Parse(cpuStats[3]);
        long idle = long.Parse(cpuStats[4]);
        long iowait = long.Parse(cpuStats[5]);

        long total = user + nice + system + idle + iowait;
        long totalIdle = idle + iowait;

        return (float)(total - totalIdle) / total * 100;
    }

    public float GetMemoryUsage()
    {
        string[] stats = File.ReadAllLines("/proc/meminfo");
        string[] memFree = stats[1].Split(':');
        string[] memTotal = stats[0].Split(':');

        long totalMemory = long.Parse(memTotal[1].Trim().Split(' ')[0]);
        long freeMemory = long.Parse(memFree[1].Trim().Split(' ')[0]);

        return (float)(totalMemory - freeMemory) / totalMemory * 100;
    }
}