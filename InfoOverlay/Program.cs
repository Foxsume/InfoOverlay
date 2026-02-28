public class Program
{
    static void Main()
    {
        // Create the correct system metrics class based on the platform
        ISystemMetrics systemMetrics = SystemMetricsFactory.CreateSystemMetrics();

        // Get CPU and memory usage
        Console.WriteLine("CPU Usage: " + systemMetrics.GetCpuUsage() + "%");
        Console.WriteLine("Memory Usage: " + systemMetrics.GetMemoryUsage() + "MB");
    }
}