using HappyPath.Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyPath.Service.Services
{
    public interface IPersonService
    {
        PersonViewModel GetPersonByName(string name);
    }

    public class PersonService : IPersonService
    {
        public PersonViewModel GetPersonByName(string name)
        {
            //TODO: Entity framework code first

            return new PersonViewModel
            {
                Id = 1,
                FirstName = "Jason",
                LastName = "More",
                Birthday = DateTime.Parse("1/1/2012")
            };
        }
    }
}
