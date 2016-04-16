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
using System;

namespace Map2CivilizationModel
{
    public abstract class Plot
    {
        private PlotId _id;

        private TerrainTypeEnumWrapper.TerrainType _terrainDescriptor =
            TerrainTypeEnumWrapper.TerrainType.NotDefined;

        private bool _isLocked = false;

        /// <summary>
        /// Constructor used when creating a new map
        /// </summary>
        /// <param name="plotX"></param>
        /// <param name="plotY"></param>
        protected Plot(int plotX, int plotY)
        {
            _id = new PlotId(plotX, plotY);
        }

        /// <summary>
        /// constructor used when loading the model from a save file
        /// </summary>
        /// <param name="id">The id of the plot</param>
        /// <param name="terrainDescriptor">The terrain assigned to the plot</param>
        /// <param name="isLocked">Marker indicating that the plot's terrain is locked (as defined by the user)</param>
        protected Plot(string id, TerrainTypeEnumWrapper.TerrainType terrainDescriptor,
             Boolean isLocked)
        {
            _id = new PlotId(id);
            _terrainDescriptor = terrainDescriptor;
            _isLocked = isLocked;
        }

        public PlotId Id
        {
            get
            {
                return _id;
            }
        }

        public bool IsLocked
        {
            get
            {
                return _isLocked;
            }
        }

        public TerrainTypeEnumWrapper.TerrainType TerrainDescriptor
        {
            get
            {
                return _terrainDescriptor;
            }

            set
            {
                _terrainDescriptor = value;
            }
        }

        public String IdString
        {
            get
            {
                return _id.Name;
            }
        }

        public void UpdatePlot(TerrainTypeEnumWrapper.TerrainType terrainDescriptor, Boolean isLocked)
        {
            _terrainDescriptor = terrainDescriptor;
            _isLocked = isLocked;
        }
    }
}