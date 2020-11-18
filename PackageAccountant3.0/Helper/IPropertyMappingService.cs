using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PackageAccountant3._0.Helper
{
    public interface IPropertyMappingService
    {
        bool CheckFiles<TSource, TDestination>(TSource source);
    }
}
