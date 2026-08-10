using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLibraryB.Library.AmrControl.Package
{
    public interface IAmrControlPackage<T>
    {
        Dictionary<T, AmrControlPackage> Packages { get; set; }
    }
}
