using System.Linq;
using System;
using API.Models;
using System.Collections.Generic;

namespace API.PersonData
{
    public interface IPerson
    {
        List<Person> GetPersons();

        List<Intresse> GetPerson(int id);
        
        Person GetPersonById(int id);

        List<Links> GetLinks(int personId);

        List<IntresseLinks> GetPersonSpecificInterest(int personId, int interestId);

        Person UpdatePersonInterest(Person user, Intresse interest);
        Person UpdatePersonLink(Person user, int interestId, Links link);
    }
}
