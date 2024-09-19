using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;

namespace Benchmarks;

[SimpleJob(RunStrategy.ColdStart, iterationCount: 10)]
[MemoryDiagnoser]
public class AggregateBenchmarks
{
    [Params(5_000, 100_000, 500_000, 1_000_000)]
    public int PeopleCount { get; set; } = 100;

    private IList<Person> _peopleList;
    private IEnumerable<Person> _peopleIEnumerable;

    public AggregateBenchmarks()
    {
        var generatedPeople = GetPeople();
        _peopleList = generatedPeople.ToList();
        _peopleIEnumerable = generatedPeople;
    }

    [Benchmark]
    public int IEnumerable_Count()
    {
        return _peopleIEnumerable.Count();
    }

    [Benchmark]
    public double IEnumerable_Average()
    {
        return _peopleIEnumerable.Average(c => c.Age);
    }

    [Benchmark]
    public int IEnumerable_Min()
    {
        return _peopleIEnumerable.Min(c => c.Age);
    }

    [Benchmark]
    public int IEnumerable_Max()
    {
        return _peopleIEnumerable.Max(c => c.Age);
    }

    [Benchmark]
    public int IList_Count()
    {
        return _peopleList.Count();
    }

    [Benchmark]
    public double IList_Average()
    {
        return _peopleList.Average(c => c.Age);
    }

    [Benchmark]
    public int IList_Min()
    {
        return _peopleList.Min(c => c.Age);
    }

    [Benchmark]
    public int IList_Max()
    {
        return _peopleList.Max(c => c.Age);
    }

    private IEnumerable<Person> GetPeople()
    {
        var random = new Random();
        for (var i = 0; i < PeopleCount; i++)
        {
            yield return new Person
            {
                Id = i,
                Name = "Person" + i,
                Age = random.Next(18, 65),
                Email = "person" + i + "@gmail.com",
                PhoneNumber = "555-555-5555"
            };
        }
    }

}