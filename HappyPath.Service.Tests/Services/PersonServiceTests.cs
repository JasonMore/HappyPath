using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HappyPath.Service.Services;
using AutoMapper;
using HappyPath.Service.Data.Context;
using NSubstitute;
using HappyPath.Service.Data.Storage.InMemory;
using HappyPath.Service.Models;
using System.Collections.Generic;
using HappyPath.Service.ViewModels;
using System.Linq;

namespace HappyPath.Service.Tests.Services
{
    [TestClass]
    public class PersonServiceTests
    {
        IHappyPathSession _session;
        IMappingEngine _mappingEngine;
        PersonService _personService;

        [TestInitialize]
        public void Setup()
        {
            _session = new HappyPathInMemorySession();
            _mappingEngine = Substitute.For<IMappingEngine>();

            _personService = new PersonService(_session, _mappingEngine);
        }

        [TestMethod]
        public void GetPeople()
        {
            // Arrange
            _session.Add(new Person { FirstName = "Bob", LastName = "Jones" });
            _session.Add(new Person { FirstName = "Bobert", LastName = "Smith" });
            _session.Add(new Person { FirstName = "Jason", LastName = "More" });
            _session.Add(new Person { FirstName = "Joan", LastName = "Bobertson" });

            _mappingEngine.Map<IEnumerable<PersonViewModel>>(Arg.Any<Person>())
                .ReturnsForAnyArgs(x =>
                {
                    var persons = x.Arg<IEnumerable<Person>>();
                    return persons.Select(person =>  new PersonViewModel
                    {
                        FirstName = person.FirstName,
                        LastName = person.LastName
                    });
                });

            // Act
            var people = _personService.GetPeopleByName("Bob");

            // Assert
            Assert.AreEqual(3, people.Count());
        }
    }
}
