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

Linked List:
Test_Using_Freaking_Linked_List: Action: Same test as the first and second, but now using freaking linked list
```
| Method                          | Mean      | Error     | StdDev    | Median    | Gen0      | Gen1      | Gen2      | Allocated |
|-------------------------------- |----------:|----------:|----------:|----------:|----------:|----------:|----------:|----------:|
| WithoutCapacity_NoHeap          |  3.607 ms | 0.0340 ms | 0.0318 ms |  3.594 ms | 1992.1875 | 1992.1875 | 1992.1875 |      8 MB |
| WithCapacity_NoHeap             |  2.373 ms | 0.0472 ms | 0.0749 ms |  2.383 ms |  996.0938 |  996.0938 |  996.0938 |   3.82 MB |
| WithoutCapacity_Heap            | 10.466 ms | 0.0546 ms | 0.0511 ms | 10.464 ms | 2000.0000 | 2000.0000 | 2000.0000 |  30.89 MB |
| WithCapacity_Heap               |  7.728 ms | 0.1517 ms | 0.2127 ms |  7.843 ms | 1000.0000 | 1000.0000 | 1000.0000 |   26.7 MB |
| WithoutCapacity_Heap_CallGC     | 15.664 ms | 0.1735 ms | 0.1622 ms | 15.719 ms | 1968.7500 | 1968.7500 | 1968.7500 |  30.89 MB |
| WithCapacity_Heap_CallGC        |  7.502 ms | 0.1435 ms | 0.1535 ms |  7.502 ms |  984.3750 |  984.3750 |  984.3750 |   26.7 MB |
| Test_Using_Freaking_Linked_List | 29.488 ms | 0.2755 ms | 0.2442 ms | 29.549 ms |  937.5000 |  875.0000 |         - |  45.78 MB |
