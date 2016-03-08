using Map2Civilization.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Map2CivilizationCtrl.Enumerations
{
    public class MapDataSource : IEnrichedEnumWrapper
    {
        public enum Enumeration
        {
            ReliefMapImage,
            GeoDataProvider
        }


        #region Singleton methods

        /// <summary>
        /// Used to store the single instance needed to perform any operation.
        /// </summary>
        private static MapDataSource _singleInstance;

        /// <summary>
        /// Private constructor
        /// </summary>
        private MapDataSource() { }

        


        public static MapDataSource Singleton
        {
            get
            {
                if (_singleInstance == null)
                {
                    _singleInstance = new MapDataSource();
                }

                return _singleInstance;
            }
        }


        public Type EnumType
        {
            get
            {
                return typeof(Enumeration);
            }
        }

        public String GetEnumValueDescription(System.Enum value)
        {
            switch ((Enumeration)value)
            {
                case Enumeration.GeoDataProvider:
                    return Resources.Str_MapDataSource_Description_GeoData;
                case Enumeration.ReliefMapImage:
                    return Resources.Str_MapDataSource_Description_ReliefMapImage;
                default:
                    throw new InvalidEnumArgumentException("Non existing enumeration value.");
            }
        }

        public Boolean GetEnumValueEnabledStatus(System.Enum value)
        {
            switch ((Enumeration)value)
            {
                case Enumeration.GeoDataProvider:
                    return false;
                case Enumeration.ReliefMapImage:
                    return true;
                default:
                    throw new InvalidEnumArgumentException("Non existing enumeration value.");
            }
        }


        public Boolean GetEnumValueDefaultStatus(System.Enum value)
        {
            switch ((Enumeration)value)
            {
                case Enumeration.GeoDataProvider:
                    return false;
                case Enumeration.ReliefMapImage:
                    return true;
                default:
                    throw new InvalidEnumArgumentException("Non existing enumeration value.");
            }
        }

        #endregion


    }
}
