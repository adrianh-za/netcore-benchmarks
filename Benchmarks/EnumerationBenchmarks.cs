using System.Collections.ObjectModel;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;

namespace Benchmarks;

[SimpleJob(RunStrategy.ColdStart, iterationCount: 10)]
[MemoryDiagnoser]
public class EnumerationBenchmarks
{
    [Params(100, 1_000, 5_000)]
    public int LoopCount { get; set; }

    [Params(5_000, 10_000, 25_000)]
    public int PeopleCount { get; set; }

    private IEnumerable<Person> _peopleIEnumerable;
    private readonly List<Person> _peopleList;
    private readonly Collection<Person> _peopleCollection;
    private readonly ReadOnlyCollection<Person> _peopleReadOnlyCollection;
    private readonly Person[] _peopleArray;

    public EnumerationBenchmarks()
    {
        var generatedPeople = GetPeople();

        _peopleIEnumerable = generatedPeople;
        _peopleList = generatedPeople.ToList();
        _peopleCollection = new Collection<Person>(_peopleList);
        _peopleReadOnlyCollection = new ReadOnlyCollection<Person>(_peopleList);
        _peopleArray = _peopleList.ToArray();
    }


    [Benchmark]
    public void IEnumerable_ForEachCount()
    {
        IterationsSupport.IteratePeople_AsIEnumerable(_peopleIEnumerable, LoopCount);
    }

    [Benchmark]
    public void IList_ForEachCount()
    {
        IterationsSupport.IteratePeople_AsIList(_peopleList, LoopCount);
    }

    [Benchmark]
    public void List_ForEachCount()
    {
        IterationsSupport.IteratePeople_AsList(_peopleList, LoopCount);
    }

    [Benchmark]
    public void ICollection_ForEachCount()
    {
        IterationsSupport.IteratePeople_AsICollection(_peopleCollection, LoopCount);
    }

    [Benchmark]
    public void Collection_ForEachCount()
    {
        IterationsSupport.IteratePeople_AsCollection(_peopleCollection, LoopCount);
    }

    [Benchmark]
    public void Array_ForEachCount()
    {
        IterationsSupport.IteratePeople_AsArray(_peopleArray, LoopCount);
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

public static class IterationsSupport
{
    public static void IteratePeople_AsIEnumerable(IEnumerable<Person> people, int loopCount)
    {
        var outerCount = 0;
        while (outerCount < loopCount)
        {
            foreach (var person in people)
            {
                var id = person.Id;
            }
            outerCount++;
        }
    }

    public static void IteratePeople_AsList(List<Person> people, int loopCount)
    {
        var outerCount = 0;
        while (outerCount < loopCount)
        {
            foreach (var person in people)
            {
                var id = person.Id;
            }
            outerCount++;
        }
    }

    public static void IteratePeople_AsIList(IList<Person> people, int loopCount)
    {
        var outerCount = 0;
        while (outerCount < loopCount)
        {
            foreach (var person in people)
            {
                var id = person.Id;
            }
            outerCount++;
        }
    }

    public static void IteratePeople_AsArray(Person[] people,int loopCount)
    {
        var outerCount = 0;
        while (outerCount < loopCount)
        {
            foreach (var person in people)
            {
                var id = person.Id;
            }
            outerCount++;
        }
    }

    public static void IteratePeople_AsCollection(Collection<Person> people, int loopCount)
    {
        var outerCount = 0;
        while (outerCount < loopCount)
        {
            foreach (var person in people)
            {
                var id = person.Id;
            }
            outerCount++;
        }
    }

    public static void IteratePeople_AsICollection(ICollection<Person> people, int loopCount)
    {
        var outerCount = 0;
        while (outerCount < loopCount)
        {
            foreach (var person in people)
            {
                var id = person.Id;
            }
            outerCount++;
        }
    }
}