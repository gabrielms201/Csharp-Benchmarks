```

BenchmarkDotNet v0.13.12, Windows 10 (10.0.19045.3324/22H2/2022Update)
AMD Ryzen 7 5800X3D, 1 CPU, 16 logical and 8 physical cores
.NET SDK 7.0.400
  [Host]     : .NET 7.0.10 (7.0.1023.36312), X64 RyuJIT AVX2 [AttachedDebugger]
  DefaultJob : .NET 7.0.10 (7.0.1023.36312), X64 RyuJIT AVX2


Here the main goal is to test empirically that lists are just simple arrays, and with we do not provide their capacity, we can have an overhead

General Performance Test
WithoutCapacity_NoHeap: Action: Populate a pre instantiated list with non defined capacity.
WithCapacity_NoHeap: Action: Populate a pre instantiated list with defined capacity.

Memory segmentation tests without Garbage Collector
WithoutCapacity_Heap: Action: Populate a pre instantiated list with non defined capacity, but adding some objects to the heap in order to make the reallocation process more expensive
WithCapacity_Heap: Action: Populate a pre instantiated list with defined capacity, but adding some objects to the heap in order to make the reallocation process more expensive

Memory segmentation tests with Garbage Collector
WithoutCapacity_Heap_CallGC: Action: Populate a pre instantiated list with non defined capacity, but adding some objects to the heap in order to make the reallocation process more expensive, but now calling our feared Garbage Collector
WithCapacity_Heap_CallGC: Action: Populate a pre instantiated list with defined capacity, but adding some objects to the heap in order to make the reallocation process more expensive, but now calling our feared Garbage Collector
```
| Method                      | Mean      | Error     | StdDev    | Gen0      | Gen1      | Gen2      | Allocated |
|---------------------------- |----------:|----------:|----------:|----------:|----------:|----------:|----------:|
| WithoutCapacity_NoHeap      |  3.778 ms | 0.0467 ms | 0.0437 ms | 1988.2813 | 1988.2813 | 1988.2813 |      8 MB |
| WithCapacity_NoHeap         |  2.218 ms | 0.0166 ms | 0.0156 ms |  996.0938 |  996.0938 |  996.0938 |   3.82 MB |
| WithoutCapacity_Heap        | 10.333 ms | 0.0794 ms | 0.0703 ms | 2000.0000 | 2000.0000 | 2000.0000 |  30.89 MB |
| WithCapacity_Heap           |  7.888 ms | 0.1518 ms | 0.1973 ms | 1000.0000 | 1000.0000 | 1000.0000 |   26.7 MB |
| WithoutCapacity_Heap_CallGC | 15.745 ms | 0.0874 ms | 0.0818 ms | 1984.3750 | 1984.3750 | 1984.3750 |  30.89 MB |
| WithCapacity_Heap_CallGC    |  7.810 ms | 0.1524 ms | 0.1871 ms |  984.3750 |  984.3750 |  984.3750 |   26.7 MB |
