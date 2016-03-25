using System;
using System.Collections.Generic;
using System.Linq;
using Wintellect.PowerCollections;

public class PersonCollection : IPersonCollection
{
    private Dictionary<string, Person> peopleByEmail = new Dictionary<string, Person>();
    private Dictionary<string, SortedSet<Person>> peopleByEmailDomain = new Dictionary<string, SortedSet<Person>>();
    private Dictionary<string, SortedSet<Person>> peopleByNameAndTown = new Dictionary<string, SortedSet<Person>>();
    private OrderedDictionary<int, SortedSet<Person>> peopleByAge = new OrderedDictionary<int, SortedSet<Person>>();
    private OrderedDictionary<string, OrderedDictionary<int, SortedSet<Person>>> peopleByTownAndAge = new OrderedDictionary<string, OrderedDictionary<int, SortedSet<Person>>>();

    public bool AddPerson(string email, string name, int age, string town)
    {
        if (this.FindPerson(email) != null)
        {
            return false;
        }

        var person = new Person
        {
            Name = name,
            Age = age,
            Email = email,
            Town = town
        };

        this.peopleByEmail.Add(email, person);
        this.peopleByEmailDomain.AppendValueToKey(email.Split('@')[1], person);
        this.peopleByNameAndTown.AppendValueToKey(string.Format("{0}-{1}", name, town), person);
        this.peopleByAge.AppendValueToKey(age, person);
        this.peopleByTownAndAge.EnsureKeyExists(town);
        this.peopleByTownAndAge[town].AppendValueToKey(age, person);

        return true;
    }

    public int Count
    {
        get
        {
            return this.peopleByEmail.Count;
        }
    }

    public Person FindPerson(string email)
    {
        if (!peopleByEmail.ContainsKey(email))
        {
            return null;
        }

        return this.peopleByEmail[email];
    }

    public bool DeletePerson(string email)
    {
        var person = this.FindPerson(email);
        if (person == null)
        {
            return false;
        }

        this.peopleByEmail.Remove(email);

        var emailDomain = email.Split('@')[1];
        this.peopleByEmailDomain[emailDomain].Remove(person);

        this.peopleByNameAndTown[string.Format("{0}-{1}", person.Name, person.Town)].Remove(person);

        this.peopleByAge[person.Age].Remove(person);

        this.peopleByTownAndAge[person.Town][person.Age].Remove(person);
        return true;
    }

    public IEnumerable<Person> FindPersons(string emailDomain)
    {
        return this.peopleByEmailDomain.GetValuesForKey(emailDomain);
    }

    public IEnumerable<Person> FindPersons(string name, string town)
    {
        return this.peopleByNameAndTown.GetValuesForKey(string.Format("{0}-{1}", name, town));
    }

    public IEnumerable<Person> FindPersons(int startAge, int endAge)
    {
        var people =  this.peopleByAge.Range(startAge, true, endAge, true);

        foreach (var peopleByAge in people)
        {
            foreach (var person in peopleByAge.Value)
            {
                yield return person;
            }
        }
    }

    public IEnumerable<Person> FindPersons(
        int startAge, int endAge, string town)
    {
        if (!this.peopleByTownAndAge.ContainsKey(town))
        {
            yield break;
        }
        var people = this.peopleByTownAndAge[town].Range(startAge, true, endAge, true);

        foreach (var peopleByAge in people)
        {
            foreach (var person in peopleByAge.Value)
            {
                yield return person;
            }
        }
    }
}
