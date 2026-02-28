using System.Diagnostics;

public class MacMetrics : ISystemMetrics
{
    public float GetCpuUsage()
    {
        var process = new Process();
        process.StartInfo.FileName = "sysctl";
        process.StartInfo.Arguments = "vm.proc_stat";
        process.StartInfo.RedirectStandardOutput = true;
        process.Start();
        string output = process.StandardOutput.ReadToEnd();
        process.WaitForExit();

        // Parse sysctl output and return the CPU usage
        return ExtractCpuUsage(output); // Custom method to extract CPU usage from sysctl output
    }

    public float GetMemoryUsage()
    {
        var process = new Process();
        process.StartInfo.FileName = "sysctl";
        process.StartInfo.Arguments = "hw.memsize";
        process.StartInfo.RedirectStandardOutput = true;
        process.Start();
        string output = process.StandardOutput.ReadToEnd();
        process.WaitForExit();

        // Convert the memory from bytes to MB
        return Convert.ToSingle(output.Trim()) / 1024 / 1024;
    }

    private float ExtractCpuUsage(string output)
    {
        // Logic to extract CPU usage from the output of sysctl
        return 40.5f; // Example, should be implemented with real parsing
    }
}