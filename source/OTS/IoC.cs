using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Aspose.Cells;
using Aspose.Cells.Rendering;
using Castle.Windsor;
using Castle.Windsor.Installer;
using OTS;
using Remotion.Logging;
using License = Aspose.Words.License;

namespace OTS
{
    public static class IoC
    {
        internal static WindsorContainer _container;

        public static T Get<T>()
        {
            return _container.Resolve<T>();
        }

        public static IEnumerable<T> GetAll<T>()
        {
            return _container.ResolveAll<T>();
        }
    }
}
