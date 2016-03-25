﻿using System.Collections.Generic;
using System.Linq;
using Map2CivilizationCtrl.DataStructure;
using Map2CivilizationCtrl.Enumerations;

namespace Map2CivilizationModel
{
    class Plots
    {
        readonly Dictionary<PlotId, Plot> _plotCollectionList;

        public Plots()
        {
           _plotCollectionList = new Dictionary<PlotId, Plot>();
        }






        public void AddNewPlot(Plot plot)
        {
            _plotCollectionList.Add(plot.Id, plot);
        }

        public List<Plot> GetPlots()
        {
            return _plotCollectionList.Values.ToList<Plot>();
        }


        public List<PlotId> GetPlotIds()
        {
            List<PlotId> toReturn = new List<PlotId>();

            toReturn.AddRange(_plotCollectionList.Keys);

            return toReturn;
        }

        public Plot GetPlot(PlotId id)
        {
            Plot toReturn;
            if(_plotCollectionList.TryGetValue(id, out toReturn))
            {
                return toReturn;
            }
            else
            {
                return null;
            }
        }


        public double getAssignedPercentComplete()
        {
            int total = 0;
            int assigned = 0;

            foreach(KeyValuePair<PlotId, Plot> pair in _plotCollectionList)
            {
                Plot p = pair.Value;

                if(p.TerrainDescriptor!= TerrainType.Enumeration.NotDefined)
                {
                    assigned++;
                }
                total++;
            }

            return ((float)assigned / total) * 100;
        }





    }
}
