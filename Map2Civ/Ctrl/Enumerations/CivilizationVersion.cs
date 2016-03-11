using System;
using System.ComponentModel;
using Map2CivilizationCtrl.DataStructure;
using Map2Civilization.Properties;
using System.Collections.ObjectModel;

namespace Map2CivilizationCtrl.Enumerations
{
    public class CivilizationVersion : IEnrichedEnumWrapper
    {
       

        /// <summary>
        /// Enumeration that holds all Civilization Versions
        /// </summary>
        public enum Enumeration
        {
            Civilization1 = 0,
            Civilization2 = 1,
            Civilization3 = 2,
            Civilization4 = 3,
            Civilization5 = 4,
            CivilizationBE = 5
        }

        #region Singleton methods

        /// <summary>
        /// Used to store the single instance needed to perform any operation.
        /// </summary>
        private static CivilizationVersion _singleInstance;

        /// <summary>
        /// Private constructor
        /// </summary>
        private CivilizationVersion() { }

        

        public static  CivilizationVersion Singleton
        {
            get
            {
                if (_singleInstance == null)
                {
                    _singleInstance = new CivilizationVersion();
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
                case Enumeration.Civilization1:
                    return "Civilization I";
                case Enumeration.Civilization2:
                    return "Civilization II";
                case Enumeration.Civilization3:
                    return "Civilization III";
                case Enumeration.Civilization4:
                    return "Civilization IV";
                case Enumeration.Civilization5:
                    return "Civilization V";
                case Enumeration.CivilizationBE:
                    return "Civilization Beyond Earth";
                default:
                    throw new InvalidEnumArgumentException("");
            }
        }

        public  Boolean GetEnumValueEnabledStatus(System.Enum value)
        {
            switch ((Enumeration)value)
            {
                case Enumeration.Civilization1:
                    return false;
                case Enumeration.Civilization2:
                    return false;
                case Enumeration.Civilization3:
                    return false;
                case Enumeration.Civilization4:
                    //return false;
                    /**** FOR TEST ONLY - REMEMBER TO REMOVE!***/
                    return true;
                    /*******************************************/
                case Enumeration.Civilization5:
                    return true;
                case Enumeration.CivilizationBE:
                    return false;
                default:
                    throw new InvalidEnumArgumentException("Non existing enumeration value.");
            }
        }


        public  Boolean GetEnumValueDefaultStatus(System.Enum value)
        {
            switch ((Enumeration)value)
            {
                case Enumeration.Civilization1:
                    return false;
                case Enumeration.Civilization2:
                    return false;
                case Enumeration.Civilization3:
                    return false;
                case Enumeration.Civilization4:
                    return false;
                case Enumeration.Civilization5:
                    return true;
                case Enumeration.CivilizationBE:
                    return false;
                default:
                    throw new InvalidEnumArgumentException("Non existing enumeration value.");
            }
        }

        #endregion


        #region CivilizationVersion specific utility methods

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic")]
        public Collection<MapDimension> GetVersionMapDimensions(Enumeration version)
        {
            Collection<MapDimension> toReturn = new Collection<MapDimension>();

            switch (version)
            {
                case Enumeration.Civilization1:
                    toReturn.Add(new MapDimension("Not Supported.", 0, 0, true));
                    return toReturn;
                case Enumeration.Civilization2:
                    toReturn.Add(new MapDimension("Not Supported.", 0, 0, true));
                    return toReturn;
                case Enumeration.Civilization3:
                    toReturn.Add(new MapDimension("Not Supported.", 0, 0, true));
                    return toReturn;
                case Enumeration.Civilization4:
                    //toReturn.Add(new MapDimension("Not Supported.", 0, 0, true));
                    /****** INVALID VALUES - FOR TEST PURPOSES ONLY  *****/
                    toReturn.Add(new MapDimension(Resources.Str_CivilizationVersion_Civilization5MapSizes_Duel, 40, 25, false));
                    toReturn.Add(new MapDimension(Resources.Str_CivilizationVersion_Civilization5MapSizes_Tiny, 56, 36, false));
                    toReturn.Add(new MapDimension(Resources.Str_CivilizationVersion_Civilization5MapSizes_Small, 66, 42, false));
                    toReturn.Add(new MapDimension(Resources.Str_CivilizationVersion_Civilization5MapSizes_Standard, 80, 52, false));
                    toReturn.Add(new MapDimension(Resources.Str_CivilizationVersion_Civilization5MapSizes_Large, 104, 64, false));
                    toReturn.Add(new MapDimension(Resources.Str_CivilizationVersion_Civilization5MapSizes_Huge, 128, 80, true));
                    toReturn.Add(new MapDimension(Resources.Str_CivilizationVersion_Civilization5MapSizes_Humongous, 300, 200, false));
                    /********************************************************/
                    return toReturn;
                case Enumeration.Civilization5:
                    // Source: http://forums.civfanatics.com/showthread.php?t=389835
                    toReturn.Add(new MapDimension(Resources.Str_CivilizationVersion_Civilization5MapSizes_Duel, 40, 25, false));
                    toReturn.Add(new MapDimension(Resources.Str_CivilizationVersion_Civilization5MapSizes_Tiny, 56, 36, false));
                    toReturn.Add(new MapDimension(Resources.Str_CivilizationVersion_Civilization5MapSizes_Small, 66, 42, false));
                    toReturn.Add(new MapDimension(Resources.Str_CivilizationVersion_Civilization5MapSizes_Standard, 80, 52, false));
                    toReturn.Add(new MapDimension(Resources.Str_CivilizationVersion_Civilization5MapSizes_Large, 104, 64, false));
                    toReturn.Add(new MapDimension(Resources.Str_CivilizationVersion_Civilization5MapSizes_Huge, 128, 80, true));
                    toReturn.Add(new MapDimension(Resources.Str_CivilizationVersion_Civilization5MapSizes_Humongous, 300, 200, false));
                    return toReturn;
                case Enumeration.CivilizationBE:
                    toReturn.Add(new MapDimension("Not Supported.", 0, 0, true));
                    return toReturn;
                default:
                    throw new InvalidEnumArgumentException("Non existing enumeration value.");

            }
        }


        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic")]
        public GridType.Enumeration GetVersionGridType(Enumeration version)
        {
            switch (version)
            {
                case Enumeration.Civilization1:
                    return GridType.Enumeration.Rhombus;
                case Enumeration.Civilization2:
                    return GridType.Enumeration.Rhombus;
                case Enumeration.Civilization3:
                    return GridType.Enumeration.Rhombus;
                case Enumeration.Civilization4:
                    return GridType.Enumeration.Square;
                case Enumeration.Civilization5:
                    return GridType.Enumeration.HexagonalPT;
                case Enumeration.CivilizationBE:
                    return GridType.Enumeration.HexagonalPT;
                default:
                    throw new InvalidEnumArgumentException("Non existing enumeration value.");

            }
        }



        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic")]
        public string GetSaveFileFilter(Enumeration version)
        {
            switch (version)
            {
                case Enumeration.Civilization1:
                    throw new NotImplementedException();
                case Enumeration.Civilization2:
                    throw new NotImplementedException();
                case Enumeration.Civilization3:
                    throw new NotImplementedException();
                case Enumeration.Civilization4:
                    throw new NotImplementedException();
                case Enumeration.Civilization5:
                    return "Civ 5 Map Files | *.Civ5Map";
                case Enumeration.CivilizationBE:
                    throw new NotImplementedException();
                default:
                    throw new InvalidEnumArgumentException("Non existing enumeration value.");

            }
        }


        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic")]
        public string GetSaveFileDefaultExtension(Enumeration version)
        {
            switch (version)
            {
                case Enumeration.Civilization1:
                    throw new NotImplementedException();
                case Enumeration.Civilization2:
                    throw new NotImplementedException();
                case Enumeration.Civilization3:
                    throw new NotImplementedException();
                case Enumeration.Civilization4:
                    throw new NotImplementedException();
                case Enumeration.Civilization5:
                    return "*.Civ5Map";
                case Enumeration.CivilizationBE:
                    throw new NotImplementedException();
                default:
                    throw new InvalidEnumArgumentException("Non existing enumeration value.");

            }
        }



        #endregion

    }
}
