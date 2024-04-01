```

BenchmarkDotNet v0.13.12, Windows 10 (10.0.19045.3324/22H2/2022Update)
AMD Ryzen 7 5800X3D, 1 CPU, 16 logical and 8 physical cores
.NET SDK 7.0.400
  [Host]     : .NET 7.0.10 (7.0.1023.36312), X64 RyuJIT AVX2 [AttachedDebugger]
  DefaultJob : .NET 7.0.10 (7.0.1023.36312), X64 RyuJIT AVX2


```
| Method                      | Mean      | Error     | StdDev    | Gen0      | Gen1      | Gen2      | Allocated |
|---------------------------- |----------:|----------:|----------:|----------:|----------:|----------:|----------:|
| WithoutCapacity_NoHeap      |  3.617 ms | 0.0506 ms | 0.0473 ms | 1980.4688 | 1980.4688 | 1980.4688 |      8 MB |
| WithCapacity_NoHeap         |  2.264 ms | 0.0290 ms | 0.0272 ms |  996.0938 |  996.0938 |  996.0938 |   3.82 MB |
| WithoutCapacity_Heap        | 10.719 ms | 0.1101 ms | 0.1030 ms | 2000.0000 | 2000.0000 | 2000.0000 |  30.89 MB |
| WithCapacity_Heap           |  8.077 ms | 0.1144 ms | 0.1070 ms | 1500.0000 | 1500.0000 | 1500.0000 |  34.33 MB |
| WithoutCapacity_Heap_CallGC | 15.499 ms | 0.0841 ms | 0.0702 ms | 1984.3750 | 1984.3750 | 1984.3750 |  30.89 MB |
| WithCapacity_Heap_CallGC    |  7.951 ms | 0.1545 ms | 0.1717 ms |  984.3750 |  984.3750 |  984.3750 |   26.7 MB |
