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


using System;
using System.Globalization;
using System.Linq;

namespace Map2CivilizationCtrl.DataStructure
{
    public struct MapDimension
    {
        private string _description;
        private int _widthPlots;
        private int _heightPlots;
        private bool _isDefault;

        #region getters

        public string Description
        {
            get
            {
                return _description;
            }
        }

        public int WidthPlots
        {
            get
            {
                return _widthPlots;
            }
        }

        public int HeightPlots
        {
            get
            {
                return _heightPlots;
            }
        }

        public bool IsDefault
        {
            get
            {
                return _isDefault;
            }
        }

        public override string ToString()
        {
            return string.Concat(_description, "#", _widthPlots, "#", _heightPlots, "#", _isDefault);
        }

        #endregion getters

        public MapDimension(string description, int widthPlots, int heightPlots, bool isDefault)
        {
            _description = description;
            _widthPlots = widthPlots;
            _heightPlots = heightPlots;
            _isDefault = isDefault;
        }

        public MapDimension(string elementsValue)
        {
            if (!string.IsNullOrEmpty(elementsValue))
            {
                string[] elements = elementsValue.Split('#');

                if (elements.Count() == 4)
                {
                    _description = elements[0];
                    _widthPlots = Convert.ToInt32(elements[1], CultureInfo.InvariantCulture);
                    _heightPlots = Convert.ToInt32(elements[2], CultureInfo.InvariantCulture);
                    _isDefault = Convert.ToBoolean(elements[3], CultureInfo.InvariantCulture);
                }
                else
                {
                    throw new ArgumentException("Invalid value from argument 'Elements' ");
                }
            }
            else
            {
                throw new ArgumentException("Invalid value from argument 'Elements' ");
            }
        }

        public override bool Equals(object obj)
        {
            if (!(obj is MapDimension))
                return false;

            return Equals((MapDimension)obj);
        }

        public bool Equals(MapDimension other)
        {
            return (_description.Equals(other.Description)
               && _widthPlots == other.WidthPlots
               && _heightPlots == other.HeightPlots
               && _isDefault == other.IsDefault);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public static bool operator ==(MapDimension dimension1, MapDimension dimension2)
        {
            return dimension1.Equals(dimension2);
        }

        public static bool operator !=(MapDimension dimension1, MapDimension dimension2)
        {
            return !dimension1.Equals(dimension2);
        }
    }
}