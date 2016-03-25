using System;
using System.Collections.Generic;
using Map2CivilizationCtrl.DataStructure;
using Map2CivilizationCtrl.Enumerations;
using Map2CivilizationModel;

namespace Map2CivilizationCtrl
{
    static class PlotCollectionCtrl
    {

       

        public static string getDominantColorHex(PlotId plotID)
        {
            PlotReliefMap plot =  (PlotReliefMap)ModelCtrl.GetDataModel().PlotCollection.GetPlot(plotID);
            return plot.HexDominantColor;
        }

       


        public static void UpdatePlotCombinedPlotDescriptors(PlotId plotID, 
            TerrainType.Enumeration descriptor, Boolean IsLocked)
        {
            Plot plot = PlotCollectionCtrl.getPlot(plotID);
            plot.UpdatePlot(descriptor, IsLocked);

            List<PlotId> singleElementPlotList = new List<PlotId>();
            singleElementPlotList.Add(plotID);

            RegisteredListenersCtrl.ProcessedMapNotifyProcessedMapChanged(singleElementPlotList);



        }
        

        


        



        internal static Plot getPlot(PlotId id)
        {
            return ModelCtrl.GetDataModel().PlotCollection.GetPlot(id);
        }



        public static List<Plot> getPlots()
        {
            return ModelCtrl.GetDataModel().PlotCollection.GetPlots();
        }


        public static TerrainType.Enumeration getPlotCombinedTerrainDescriptor(PlotId plotID)
        {
            Plot toProc = getPlot(plotID);
           
            

            return toProc.TerrainDescriptor;
        }


        

    }
}
