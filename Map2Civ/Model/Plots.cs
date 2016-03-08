﻿using System;
using System.Collections.Generic;

using System.Text;

using System.Collections;


using Map2CivilizationCtrl;
using System.Linq;
using Map2CivilizationCtrl.Enumerations;
using Map2CivilizationCtrl.DataStructure;

namespace Map2CivilizationModel
{
    class Plots
    {
        private Dictionary<PlotId, Plot> _plotCollectionList;

        public Plots()
        {
           _plotCollectionList = new Dictionary<PlotId, Plot>();
        }

       

        


        public void AddNewPlot(Plot plot)
        {
            _plotCollectionList.Add(plot.Id, plot);
        }

        public List<Plot> getPlots()
        {
            return _plotCollectionList.Values.ToList<Plot>();
        }


        public Plot getPlot(PlotId id)
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
