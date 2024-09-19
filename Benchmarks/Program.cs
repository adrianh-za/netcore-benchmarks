using BenchmarkDotNet.Running;
using Benchmarks;

//Uncomment out the benchmarks to run
BenchmarkRunner.Run<AggregateBenchmarks>();
//BenchmarkRunner.Run<EnumerationBenchmarks>();

//Pause the output terminal
Console.ReadLine();