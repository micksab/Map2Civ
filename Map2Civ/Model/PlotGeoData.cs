using System;
using Map2Civilization.Properties;

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
