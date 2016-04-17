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


using Map2CivilizationCtrl.DataStructure;
using Map2CivilizationCtrl.Enumerations;
using Map2CivilizationModel;
using System;
using System.Collections.Generic;

namespace Map2CivilizationCtrl
{
    internal static class PlotListCtrl
    {
        public static string GetDominantColorHex(PlotId plotID)
        {
            PlotReliefMap plot = (PlotReliefMap)ModelCtrl.GetDataModel().PlotCollection.GetPlot(plotID);
            return plot.HexDominantColor;
        }

        public static void UpdatePlotPlotTerrain(PlotId plotID,
            TerrainTypeEnumWrapper.TerrainType descriptor, Boolean IsLocked)
        {
            Plot plot = PlotListCtrl.getPlot(plotID);
            plot.UpdatePlot(descriptor, IsLocked);

            List<PlotId> singleElementPlotList = new List<PlotId>();
            singleElementPlotList.Add(plotID);

            RegisteredListenersCtrl.ProcessedMapNotifyProcessedMapChanged(singleElementPlotList);
        }

        public static void ResetManuallyLockedPlot(PlotId plotID)
        {
            string dominantColor = GetDominantColorHex(plotID);
            TerrainTypeEnumWrapper.TerrainType terrain = DetectedColorListCtrl.GetCombinedDescriptorByColorID(dominantColor);
            UpdatePlotPlotTerrain(plotID, terrain, false);
        }

        internal static Plot getPlot(PlotId id)
        {
            return ModelCtrl.GetDataModel().PlotCollection.GetPlot(id);
        }

        

        public static TerrainTypeEnumWrapper.TerrainType getPlotCombinedTerrainDescriptor(PlotId plotID)
        {
            Plot toProc = getPlot(plotID);

            return toProc.TerrainDescriptor;
        }
    }
}