using System;
using System.Globalization;
using System.Linq;

namespace Map2CivilizationCtrl.DataStructure
{
    public struct MapDimension
    {
         string _description;
         int _widthPlots;
         int _heightPlots;
         bool _isDefault;

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

        #endregion

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
