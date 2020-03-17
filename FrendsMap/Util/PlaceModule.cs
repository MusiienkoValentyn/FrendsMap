using BLL.Interfaces;
using BLL.Services;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrendsMap.Util
{
    public class PlaceModule:NinjectModule
    {
        public override void Load()
        {
            Bind<IPlaceService>().To<PlaceService>();
        }
    }
}
