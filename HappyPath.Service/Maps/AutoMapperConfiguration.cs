using AutoMapper;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyPath.Service.Maps
{
    public static class AutoMapperConfiguration
    {
        public static void Configure(IKernel kernel)
        {
            Mapper.Initialize(x =>
            {
                x.ConstructServicesUsing(type => kernel.Get(type));
                var profiles = GetProfiles();

                foreach (var profile in profiles)
                {
                    x.AddProfile(Activator.CreateInstance(profile) as Profile);
                }
            });
        }

        static IEnumerable<Type> GetProfiles()
        {
            foreach (var type in typeof(AutoMapperConfiguration).Assembly.GetTypes())
            {
                if (!type.IsAbstract && typeof(Profile).IsAssignableFrom(type))
                {
                    yield return type;
                }
            }
        }
    }
}
