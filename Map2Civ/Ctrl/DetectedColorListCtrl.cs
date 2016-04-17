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
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Map2CivilizationCtrl
{
    internal static class DetectedColorListCtrl
    {
        public static void UpdateDetectedColorsAndRefreshProcessedMap(string[] colorIDs,
            TerrainTypeEnumWrapper.TerrainType descriptor)
        {
            List<PlotId> plotsToUpdate = new List<PlotId>();

            foreach (string colorID in colorIDs)
            {
                ModelCtrl.GetDataModel().DetectedColorCollection.UpdateDetectedColor(colorID, descriptor);
                List<PlotId> tempCollection = ModelCtrl.GetDataModel().DetectedColorCollection.GetColorByID(colorID).RelevantPlotIds;
                plotsToUpdate.AddRange(tempCollection);
            }

            RegisteredListenersCtrl.ProcessedMapNotifyProcessedMapChanged(plotsToUpdate);
        }

        public static List<string> GetDetectedColorIDsArray()
        {
            return ModelCtrl.GetDataModel().DetectedColorCollection.DetectedColorIds;
        }

        public static DetectedColor GetDetectedColor(string colorID)
        {
            return ModelCtrl.GetDataModel().DetectedColorCollection.GetColorByID(colorID);
        }

        

        public static TerrainTypeEnumWrapper.TerrainType GetCombinedDescriptorByColorID(string colorID)
        {
            DetectedColor detColor = GetDetectedColor(colorID);
            return detColor.TerrainDescriptor;
        }

        public static List<PlotId> GetDetectedColorPlotCoordinates(string colorID)
        {
            List<PlotId> toReturn = new List<PlotId>();
            DetectedColor detColor = GetDetectedColor(colorID);
            List<Plot> plots = detColor.RelevantPlots;

            foreach (Plot plot in plots)
            {
                toReturn.Add(plot.Id);
            }

            return toReturn;
        }
    }
}