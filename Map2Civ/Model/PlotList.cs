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
using System.Collections.Generic;
using System.Linq;
using System;

namespace Map2CivilizationModel
{
    public class PlotList
    {
        private readonly Dictionary<PlotId, Plot> _plotCollectionList;

        public PlotList()
        {
            _plotCollectionList = new Dictionary<PlotId, Plot>();
        }

        /// <summary>
        /// Constructor used to facilitate instance creation from Json
        /// </summary>
        /// <param name="plots"></param>
        public PlotList(Plot[] plots)
        {
            if (plots == null)
                throw new ArgumentNullException(nameof(plots));

            _plotCollectionList = new Dictionary<PlotId, Plot>();

            foreach (Plot tempPlot in plots)
            {
                AddNewPlot(tempPlot);
            }
        }

        public void AddNewPlot(Plot plot)
        {
            if (plot == null)
                throw new ArgumentNullException(nameof(plot));


            _plotCollectionList.Add(plot.Id, plot);
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1002:DoNotExposeGenericLists")]
        public List<Plot> Plots
        {
            get
            {
                return _plotCollectionList.Values.ToList<Plot>();
            }
            
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1002:DoNotExposeGenericLists")]
        public List<PlotId> PlotIds
        {
            get
            {
                return _plotCollectionList.Keys.ToList();
            }
        }

        public Plot GetPlot(PlotId id)
        {
            Plot toReturn;
            if (_plotCollectionList.TryGetValue(id, out toReturn))
            {
                return toReturn;
            }
            else
            {
                return null;
            }
        }

        public double AssignedPercent
        {

            get
            {
                int total = 0;
                int assigned = 0;

                foreach (KeyValuePair<PlotId, Plot> pair in _plotCollectionList)
                {
                    Plot p = pair.Value;

                    if (p.TerrainDescriptor != TerrainTypeEnumWrapper.TerrainType.NotDefined)
                    {
                        assigned++;
                    }
                    total++;
                }

                return ((float)assigned / total) * 100;
            }
           
        }
    }
}