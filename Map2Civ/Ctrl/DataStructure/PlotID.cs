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

namespace Map2CivilizationCtrl.DataStructure
{
    public struct PlotId : IEquatable<PlotId>
    {
        private readonly int _x;
        private readonly int _y;
        private readonly string _name;

        #region getters

        /// <summary>
        /// The X coordinate component of the plot id
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "X")]
        public int X
        {
            get
            {
                return _x;
            }
        }

        /// <summary>
        /// The Y coordinate component of the plot id
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Y")]
        public int Y
        {
            get
            {
                return _y;
            }
        }

        public string Name
        {
            get
            {
                return _name;
            }
        }

        #endregion getters

        public PlotId(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentException(string.Empty, "name");

            _name = name;
            char[] delimiterChar = { ',' };

            

            string[] components = name.Split(delimiterChar, StringSplitOptions.RemoveEmptyEntries);

            if (components.Length != 2)
                throw new ArgumentException(string.Empty, "name");

            _x = Convert.ToInt32(components[0], CultureInfo.InvariantCulture);
            _y = Convert.ToInt32(components[1], CultureInfo.InvariantCulture);
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "y")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "x")]
        public PlotId(int x, int y)
        {
            _x = x;
            _y = y;
            _name = string.Concat(x, ",", y);
        }

        public bool Equals(PlotId other)
        {
            if (X == other.X && Y == other.Y)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (obj.GetType() != typeof(PlotId)) return false;
            return Equals((PlotId)obj);
        }

        //Source: https://en.wikipedia.org/wiki/Pairing_function
        public override int GetHashCode()
        {
            unchecked
            {
                int uniqueInt = (1 / 2) * (_x + _y) * (_x + _y + 1) + _y;
                return uniqueInt.GetHashCode();
            }
        }

        public static bool operator ==(PlotId id1, PlotId id2)
        {
            return id1.Equals(id2);
        }

        public static bool operator !=(PlotId id1, PlotId id2)
        {
            return !id1.Equals(id2);
        }
    }
}