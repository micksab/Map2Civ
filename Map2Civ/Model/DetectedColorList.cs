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

using Map2CivilizationCtrl.Enumerations;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Map2CivilizationModel
{
    public class DetectedColorList
    {
        private readonly Dictionary<string, DetectedColor> _collection;

        public DetectedColorList()
        {
            _collection = new Dictionary<string, DetectedColor>();
        }

        public void AddDetectedColor(DetectedColor color)
        {
            if (color != null && !_collection.ContainsKey(color.ColorHex))
            {
                _collection.Add(color.ColorHex, color);
            }
        }

        public void AddDetectedColorPlot(DetectedColor color, Plot plot)
        {
            if (color != null && plot != null)
            {
                _collection[color.ColorHex].AddRelevantPlot(plot);
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1002:DoNotExposeGenericLists")]
        public List<string> DetectedColorIds
        {
            get
            {
                return _collection.Keys.ToList();
            }

        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1002:DoNotExposeGenericLists")]
        public List<DetectedColor> DetectedColors
        {
            get
            {
                return _collection.Values.ToList();
            }
        }

       

        public void UpdateDetectedColor(string colorHex, TerrainTypeEnumWrapper.TerrainType descriptor)
        {
            DetectedColor detColor = _collection[colorHex];

            detColor.UpdateDetectedColor(descriptor);
        }

        internal DetectedColor GetColorByID(string colorID)
        {
            return _collection[colorID];
        }
    }
}