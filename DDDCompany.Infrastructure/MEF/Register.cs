using System;
using System.Collections.Generic;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DDDCompany.Infrastructure.MEF
{
   public  class Register
    {
       public static CompositionContainer regisgter()
       {
           try
           {
               AggregateCatalog aggregatecatalog = new AggregateCatalog();
               string path = AppDomain.CurrentDomain.BaseDirectory;
               var thisAssembly = new DirectoryCatalog(path, "*.dll");
               if (thisAssembly.Count() == 0)
               {
                   path = path + "bin\\";
                   thisAssembly = new DirectoryCatalog(path, "*.dll");
               }
               aggregatecatalog.Catalogs.Add(thisAssembly);
               var _container = new CompositionContainer(aggregatecatalog);
               return _container;

       
       
            }
            catch (Exception ex)
            {
                return null;
            }
       }
    }
}
