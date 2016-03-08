using Map2Civilization.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Map2CivilizationModel
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1812:AvoidUninstantiatedInternalClasses")]
    public class PlotGeoData : Plot
    {
        public PlotGeoData(int plotX, int plotY) : base(plotX, plotY)
        {
            throw new NotImplementedException(Resources.Str_PlotGeoData_NotSupported);
        }
    }
}
