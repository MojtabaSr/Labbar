
using System;
using API.Models;
using System.Collections.Generic;
using System.Linq;

namespace API.PersonData
{
    public class SqlPerson : IPerson
    {
        private  APIContext _apiContext;

        public SqlPerson(APIContext apiContext)
        {
            _apiContext = apiContext;
        }

        public List<Links> GetLinks(int personId)
        {
            var links= _apiContext.Persons.Where(x=>x.PersonId==personId)
                .SelectMany(p=>p.PersonIntresse)
                .SelectMany(i=>i.Intresse.IntresseLinks)
                .Select(l=>l.Links).ToList();

            return links;
        }

        public List<Intresse> GetPerson(int id)
        {
            var intresse = _apiContext.Intresse.Where(x => x.PersonIntresse.Any(p => p.person.PersonId == id)).ToList();


            return intresse;
        }

        public Person GetPersonById(int personId)
        {
           return _apiContext.Persons.FirstOrDefault(x => x.PersonId == personId);

        }

        public List<Person> GetPersons()
        {
            return _apiContext.Persons.ToList();
        }
        public Person UpdatePersonInterest(Person user, Intresse interest)
        {

            var result = _apiContext.Persons.Find(user.PersonId);

            var newPersonInterest = new PersonIntresse()
            {
                Intresse = new Intresse()
                {
                    Titel = interest.Titel,
                    Description = interest.Description,
                }
            };
            

            if (result != null)
            {
                user.PersonIntresse = new List<PersonIntresse>();

                user.PersonIntresse.Add(newPersonInterest);
                _apiContext.Persons.Update(user);
                _apiContext.SaveChanges();
            }

            return user;

        }

        public List<IntresseLinks> GetPersonSpecificInterest(int personId, int interestId)
        {
            var links = _apiContext.Persons.Where(x => x.PersonId == personId)
                .SelectMany(p => p.PersonIntresse)
                .SelectMany(k => k.Intresse.IntresseLinks)
                .Where(i => i.IntresseId == interestId).ToList();

            return links;
        }

        public Person UpdatePersonLink(Person user,  int interestId, Links link)
        {

            var listIntresse = _apiContext.PersonIntresse.Where(x => (x.PersonId == user.PersonId) && (x.IntresseId == interestId))
                .SelectMany(x => x.Intresse.IntresseLinks)
                .Select(x => x.Intresse).ToList();

            var result = GetPersonSpecificInterest(user.PersonId, interestId);

            var intresseLinks =new IntresseLinks()
            {
                Links = new Links()
                {
                    WebLink = link.WebLink,
                }
            };


            
            if (result != null)
            {
                listIntresse.First().IntresseLinks.Add(intresseLinks);
                //listIntresseLink.Add(links);
                _apiContext.Persons.Update(user);
                _apiContext.SaveChanges();
            }

            return user;

            /*
            var listIntresseLink = _apiContext.PersonIntresse.Where(x => (x.PersonId == user.PersonId) && (x.IntresseId == interestId))
                .SelectMany(x=>x.Intresse.IntresseLinks)
                .Select(x=>x.Links).ToList(); 

            
            var result = GetPersonSpecificInterest(user.PersonId, interestId);

            var links = new Links()
            {
                WebLink = link.WebLink,
            };

            if (result != null)
            {
                result[0].Links = links;

                //listIntresseLink.Add(links);
                _apiContext.Persons.Update(user);
                _apiContext.SaveChanges();
            }

            return user;*/


        }

    }
}
