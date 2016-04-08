using System;
using Map2Civilization.Properties;
using Map2CivilizationCtrl.Enumerations;

namespace Map2CivilizationModel
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1812:AvoidUninstantiatedInternalClasses")]
    public class PlotGeoData : Plot
    {
        public PlotGeoData(int plotX, int plotY) : base(plotX, plotY)
        {
            throw new NotImplementedException(Resources.Str_PlotGeoData_NotSupported);
        }

        public PlotGeoData(string id, TerrainType.Enumeration terrainDescriptor, bool isLocked) : base( id, terrainDescriptor, isLocked)
        {
            throw new NotImplementedException(Resources.Str_PlotGeoData_NotSupported);
        }
    }
}
