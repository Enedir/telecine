using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TopCine.WebApi.Mappings
{
    public class AutoMapperInitializer
    {
        public IEnumerable<Type> GetAutoMapperProfilesFromAllAssemblies()
        {
            foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                foreach (var aType in assembly.GetTypes())
                {
                    if (aType.IsClass && !aType.IsAbstract && aType.IsSubclassOf(typeof(Profile)))
                        yield return aType;
                }
            }
        }
    }
}
