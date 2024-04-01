using BenchmarkDotNet.Attributes;
using System.ComponentModel;

public record DataModel(int value);

[MemoryDiagnoser]
[Description("Here the main goal is to test empirically that lists are just simple arrays, and with we do not provide their capacity, we can have an overhead")]
public class ListCapacityTests
{
    [Benchmark]
    [Description("Action: Populate a pre instantiated list with non defined capacity.")]
    public void WithoutCapacity_NoHeap()
    {
        var list = new List<int>();
        for (int i = 0; i < 1000000; i++)
            list.Add(i);
    }

    [Benchmark]
    [Description("Action: Populate a pre instantiated list with defined capacity.")]

    public void WithCapacity_NoHeap()
    {
        var list = new List<int>(1000000);
        for (int i = 0; i < 1000000; i++)
            list.Add(i);
    }


    [Description("Action: Populate a pre instantiated list with non defined capacity, but adding some objects to the heap in order to make the reallocation process more expensive")]
    [Benchmark]
    public void WithoutCapacity_Heap()
    {
        GC.Collect();
        GC.WaitForPendingFinalizers();
        var list = new List<int>();
        for (int i = 0; i < 1000000; i++)
        {
            var Datamodel = new DataModel(i);
            list.Add(1);
        }
    }

    [Benchmark]
    [Description("Action: Populate a pre instantiated list with defined capacity, but adding some objects to the heap in order to make the reallocation process more expensive")]
    public void WithCapacity_Heap()
    {
        GC.Collect();
        GC.WaitForPendingFinalizers();
        var list = new List<int>(1000000);
        for (int i = 0; i < 1000000; i++)
        {
            var Datamodel = new DataModel(i);
            list.Add(1);
        }
    }

    [Benchmark]
    [Description("Action: Populate a pre instantiated list with non defined capacity, but adding some objects to the heap in order to make the reallocation process more expensive, but now calling our feared Garbage Collector")]
    public void WithoutCapacity_Heap_CallGC()
    {
        var list = new List<int>();
        for (int i = 0; i < 1000000; i++)
        {
            var Datamodel = new DataModel(i);
            list.Add(1);
        }
    }

    [Benchmark]
    [Description("Action: Populate a pre instantiated list with defined capacity, but adding some objects to the heap in order to make the reallocation process more expensive, but now calling our feared Garbage Collector")]
    public void WithCapacity_Heap_CallGC()
    {
        var list = new List<int>(1000000);
        for (int i = 0; i < 1000000; i++)
        {
            var Datamodel = new DataModel(i);
            list.Add(1);
        }
    }


    [Benchmark]
    [Description("Action: Same test as the first and second, but now using freaking linked list")]
    public void Test_Using_Freaking_Linked_List()
    {
        var list = new LinkedList<int>();
        for (int i = 0; i < 1000000; i++)
            list.AddLast(i);
    }
}
