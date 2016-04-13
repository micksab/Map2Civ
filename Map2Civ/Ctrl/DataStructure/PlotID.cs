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
            _name = name;
            char[] delimiterChar = { ',' };

            if (string.IsNullOrEmpty(name.Trim()))
                throw new ArgumentException(string.Empty, "name");

            string[] components = name.Split(delimiterChar, StringSplitOptions.RemoveEmptyEntries);

            if (components.Length != 2)
                throw new ArgumentException(string.Empty, "name");

            _x = Convert.ToInt32(components[0], CultureInfo.InvariantCulture);
            _y = Convert.ToInt32(components[1], CultureInfo.InvariantCulture);
        }

        public PlotId(int X, int Y)
        {
            _x = X;
            _y = Y;
            _name = string.Concat(X, ",", Y);
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