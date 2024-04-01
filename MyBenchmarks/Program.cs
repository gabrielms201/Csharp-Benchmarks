using BenchmarkDotNet.Running;

class Program
{
    static void Main()
    {
        // List Capacity
        BenchmarkRunner.Run<ListCapacityTests>();
    }
}