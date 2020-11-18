using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PackageAccountant3._0.Helper
{
    public class PropertyMappingService : IPropertyMappingService
    {
        public bool CheckFiles<TSource, TDestination>(TSource source)
        {
            var destinationPropertyInfos = typeof(TDestination).GetProperties();
            var sourcePropertyInfos = source.GetType().GetProperties();
             
            foreach (var property in sourcePropertyInfos)
            {
                var result = destinationPropertyInfos.Where(p => p.Name == property.Name).Where(p=>p.PropertyType==property.PropertyType).ToList();
                if (result.Count == 0)
                    return false;
            }
            return true;
        }
    }
}
