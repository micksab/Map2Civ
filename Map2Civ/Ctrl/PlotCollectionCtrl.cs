﻿using System;
using System.Collections.Generic;

using System.Text;

using Map2CivilizationModel;


using System.Drawing;
using Map2CivilizationCtrl.Enumerations;
using Map2CivilizationCtrl.DataStructure;

namespace Map2CivilizationCtrl
{
    static class PlotCollectionCtrl
    {

       

        public static String getDominantColorHex(PlotId plotID)
        {
            PlotReliefMap plot =  (PlotReliefMap)ModelCtrl.GetDataModel().PlotCollection.getPlot(plotID);
            return plot.HexDominantColor;
        }

       


        public static void UpdatePlotCombinedPlotDescriptors(PlotId plotID, 
            TerrainType.Enumeration descriptor, Boolean IsLocked)
        {
            Plot plot = PlotCollectionCtrl.getPlot(plotID);
           
            plot.UpdatePlot(descriptor, IsLocked);

            RegisteredListenersCtrl.ProcessedMapNotifyProcessedMapChanged();



        }
        

        


        



        internal static Plot getPlot(PlotId id)
        {
            return ModelCtrl.GetDataModel().PlotCollection.getPlot(id);
        }



        public static List<Plot> getPlots()
        {
            return ModelCtrl.GetDataModel().PlotCollection.getPlots();
        }


        public static TerrainType.Enumeration getPlotCombinedTerrainDescriptor(PlotId plotID)
        {
            Plot toProc = getPlot(plotID);
           
            

            return toProc.TerrainDescriptor;
        }


        

    }
}