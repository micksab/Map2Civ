/************************************************************************************/
//
//      This file is part of Map2Civilization.
//      Map2Civilization is free software: you can redistribute it and/or modify
//      it under the terms of the GNU General Public License as published by
//      the Free Software Foundation, either version 3 of the License, or
//      (at your option) any later version.
//
//      Map2Civilization is distributed in the hope that it will be useful,
//      but WITHOUT ANY WARRANTY; without even the implied warranty of
//      MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.See the
//      GNU General Public License for more details.
//
//      You should have received a copy of the GNU General Public License
//      along with Map2Civilization.  If not, see http://www.gnu.org/licenses/.
//
/************************************************************************************/

using Map2Civilization.Properties;
using Map2CivilizationCtrl.Enumerations;
using System;

namespace Map2CivilizationModel
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1812:AvoidUninstantiatedInternalClasses")]
    public class PlotGeoData : Plot
    {
        public PlotGeoData(int plotX, int plotY) : base(plotX, plotY)
        {
            throw new NotImplementedException(Resources.Str_PlotGeoData_NotSupported);
        }

        public PlotGeoData(string id, TerrainTypeEnumWrapper.TerrainType terrainDescriptor, bool isLocked) : base(id, terrainDescriptor, isLocked)
        {
            throw new NotImplementedException(Resources.Str_PlotGeoData_NotSupported);
        }
    }
}