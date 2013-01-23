using AutoMapper;
using HappyPath.Service.Data.Context;
using HappyPath.Service.Models;
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
        IEnumerable<PersonViewModel> GetPeopleByName(string name);
    }

    public class PersonService : IPersonService
    {
        readonly IHappyPathSession _session;
        readonly IMappingEngine _mapper;

        public PersonService(IHappyPathSession session, IMappingEngine mapper)
        {
            _session = session;
            _mapper = mapper;
        }

        public IEnumerable<PersonViewModel> GetPeopleByName(string name)
        {
            name = name.ToUpper();

            var people = _session.All<Person>()
                .Where(x => x.FirstName.ToUpper().Contains(name)
                        || x.LastName.ToUpper().Contains(name));

            return _mapper.Map<IEnumerable<PersonViewModel>>(people);
        }
    }
}
