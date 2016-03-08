using System;
using System.Collections.Generic;

using System.Text;
using System.Collections.ObjectModel;
using Map2CivilizationModel;

using System.ComponentModel;
using Map2CivilizationCtrl.Enumerations;
using Map2CivilizationCtrl.DataStructure;
using System.Drawing;

namespace Map2CivilizationCtrl
{
    static class DetectedColorCollectionCtrl
    {

       


        public static void UpdateDetectedColorsAndRefreshProcessedMap(String[] colorIDs,
            TerrainType.Enumeration descriptor)
        {

            foreach (String colorID in colorIDs)
            {
                ModelCtrl.GetDataModel().DetectedColorCollection.UpdateDetectedColor(colorID, descriptor);
            }

            RegisteredListenersCtrl.ProcessedMapNotifyProcessedMapChanged();
        }



        
        


        


        

        public static String[] getDetectedColorIDsArray()
        {
            return ModelCtrl.GetDataModel().DetectedColorCollection.GetDetectedColorIds();
        }

        public static DetectedColor getDetectedColor(String colorID)
        {
            return ModelCtrl.GetDataModel().DetectedColorCollection.GetColorByID(colorID);
        }

        public static Collection<DetectedColor> getDetectedColors()
        {
            return ModelCtrl.GetDataModel().DetectedColorCollection.GetDetectedColors();
        }


        


        public static TerrainType.Enumeration getCombinedDescriptorByColorID(String colorID)
        {
           
            DetectedColor detColor = getDetectedColor(colorID);
            return detColor.TerrainDescriptor;

        }

        public static List<PlotId> getDetectedColorPlotCoordinates(String colorID)
        {
            List<PlotId> toReturn = new List<PlotId>();
            DetectedColor detColor = getDetectedColor(colorID);
            Collection<Plot>  plots = detColor.RelevantPlots;

            foreach(Plot plot in plots)
            {
                toReturn.Add(plot.Id);
            }

            return toReturn;

        }

    }
}
