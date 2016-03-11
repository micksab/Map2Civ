using System;
using System.Linq;

namespace Map2CivilizationCtrl.DataStructure
{
    public struct PlotId : IEquatable<PlotId>
    {
        readonly int _x;
        readonly int _y;
        readonly string _name;

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

        #endregion

        

        public PlotId(int plotX, int plotY)
        {
            _x = plotX;
            _y = plotY;
            _name = string.Concat(plotX, ",", plotY);
        }

        /// <summary>
        /// Alternative constructor of PlotID that takes as an argument a string of the form "X,Y"
        /// where X and Y are the integer values of the X and Y plot coordinates of the plotID to be 
        /// created.
        /// </summary>
        /// <param name="uniqueName">A string of the form "X,Y", where X and Y are integer values.</param>
        public PlotId(string uniqueName)
        {
            if (string.IsNullOrEmpty(uniqueName) || (uniqueName.Split(',').Count() != 2))
            {
                throw new ArgumentException("Invalid value for argument unique name");
            }
            else
            {
                string[] components = uniqueName.Split(',');
                int xComponent = 0;
                int yComponent = 0;
                if ( (int.TryParse(components[0],out xComponent)) && (int.TryParse(components[1],out yComponent)) )
                {
                    _x = xComponent;
                    _y = yComponent;
                    _name = uniqueName;
                }
                else
                {
                    throw new ArgumentException("Invalid value for argument unique name");
                }
            }
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
