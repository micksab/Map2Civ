using Map2CivilizationCtrl.DataStructure;
using Map2CivilizationCtrl.Enumerations;
using Map2CivilizationModel;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Map2CivilizationCtrl
{
    internal static class DetectedColorCollectionCtrl
    {
        public static void UpdateDetectedColorsAndRefreshProcessedMap(string[] colorIDs,
            TerrainType.Enumeration descriptor)
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

        public static string[] getDetectedColorIDsArray()
        {
            return ModelCtrl.GetDataModel().DetectedColorCollection.GetDetectedColorIds();
        }

        public static DetectedColor getDetectedColor(string colorID)
        {
            return ModelCtrl.GetDataModel().DetectedColorCollection.GetColorByID(colorID);
        }

        public static Collection<DetectedColor> getDetectedColors()
        {
            return ModelCtrl.GetDataModel().DetectedColorCollection.GetDetectedColors();
        }

        public static TerrainType.Enumeration getCombinedDescriptorByColorID(string colorID)
        {
            DetectedColor detColor = getDetectedColor(colorID);
            return detColor.TerrainDescriptor;
        }

        public static List<PlotId> getDetectedColorPlotCoordinates(string colorID)
        {
            List<PlotId> toReturn = new List<PlotId>();
            DetectedColor detColor = getDetectedColor(colorID);
            List<Plot> plots = detColor.RelevantPlots;

            foreach (Plot plot in plots)
            {
                toReturn.Add(plot.Id);
            }

            return toReturn;
        }
    }
}