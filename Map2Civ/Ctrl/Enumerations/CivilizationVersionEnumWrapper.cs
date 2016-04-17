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


using Map2Civilization.Properties;
using Map2CivilizationCtrl.DataStructure;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Map2CivilizationCtrl.Enumerations
{
    public class CivilizationVersionEnumWrapper : EnrichedEnumWrapper
    {
        /// <summary>
        /// Enumeration that holds all Civilization Versions
        /// </summary>
        public enum CivilizationVersion
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
        private static CivilizationVersionEnumWrapper _singleInstance;

        /// <summary>
        ///  constructor
        /// </summary>
        private CivilizationVersionEnumWrapper()
        { }

        public static CivilizationVersionEnumWrapper Singleton
        {
            get
            {
                if (_singleInstance == null)
                {
                    _singleInstance = new CivilizationVersionEnumWrapper();
                }

                return _singleInstance;
            }
        }

        #endregion Singleton methods


        #region base abstract class implementations

        override public Type EnumType
        {
            get
            {
                return typeof(CivilizationVersion);
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:Validate arguments of public methods", MessageId = "0")]
        override protected string GetEnumSpecificDescription(System.Enum value)
        {

            switch ((CivilizationVersion)value)
            {
                case CivilizationVersion.Civilization1:
                    return "Civilization I";

                case CivilizationVersion.Civilization2:
                    return "Civilization II";

                case CivilizationVersion.Civilization3:
                    return "Civilization III";

                case CivilizationVersion.Civilization4:
                    return "Civilization IV";

                case CivilizationVersion.Civilization5:
                    return "Civilization V";

                case CivilizationVersion.CivilizationBE:
                    return "Civilization Beyond Earth";

                default:
                    throw new NotImplementedException(string.Concat("Handling not implemented for enum value ", value.ToString()));

            }
        }

        override protected bool GetEnumSpecificEnabledStatus(System.Enum value)
        {
            VerifyEnumTypeCompatible(value);


            switch ((CivilizationVersion)value)
            {
                case CivilizationVersion.Civilization1:
                    return false;

                case CivilizationVersion.Civilization2:
                    return false;

                case CivilizationVersion.Civilization3:
                    return false;

                case CivilizationVersion.Civilization4:
                    //return false;
                    /**** FOR TEST ONLY - REMEMBER TO REMOVE!***/
                    return true;
                /*******************************************/
                case CivilizationVersion.Civilization5:
                    return true;

                case CivilizationVersion.CivilizationBE:
                    return false;

                default:
                    throw new NotImplementedException(string.Concat("Handling not implemented for enum value ", value.ToString()));


            }
        }

        override protected bool GetEnumSpecificDefaultStatus(System.Enum value)
        {
            VerifyEnumTypeCompatible(value);


            switch ((CivilizationVersion)value)
            {
                case CivilizationVersion.Civilization1:
                    return false;

                case CivilizationVersion.Civilization2:
                    return false;

                case CivilizationVersion.Civilization3:
                    return false;

                case CivilizationVersion.Civilization4:
                    return false;

                case CivilizationVersion.Civilization5:
                    return true;

                case CivilizationVersion.CivilizationBE:
                    return false;

                default:
                    throw new NotImplementedException(string.Concat("Handling not implemented for enum value ", value.ToString()));

            }
        }


        #endregion

        #region CivilizationVersion specific utility methods

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic")]
        public Collection<MapDimension> GetVersionMapDimensions(CivilizationVersion version)
        {
            Collection<MapDimension> toReturn = new Collection<MapDimension>();

            switch (version)
            {
                case CivilizationVersion.Civilization1:
                    toReturn.Add(new MapDimension("Not Supported.", 0, 0, true));
                    return toReturn;

                case CivilizationVersion.Civilization2:
                    toReturn.Add(new MapDimension("Not Supported.", 0, 0, true));
                    return toReturn;

                case CivilizationVersion.Civilization3:
                    toReturn.Add(new MapDimension("Not Supported.", 0, 0, true));
                    return toReturn;

                case CivilizationVersion.Civilization4:
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

                case CivilizationVersion.Civilization5:
                    // Source: http://forums.civfanatics.com/showthread.php?t=389835
                    toReturn.Add(new MapDimension(Resources.Str_CivilizationVersion_Civilization5MapSizes_Duel, 40, 25, false));
                    toReturn.Add(new MapDimension(Resources.Str_CivilizationVersion_Civilization5MapSizes_Tiny, 56, 36, false));
                    toReturn.Add(new MapDimension(Resources.Str_CivilizationVersion_Civilization5MapSizes_Small, 66, 42, false));
                    toReturn.Add(new MapDimension(Resources.Str_CivilizationVersion_Civilization5MapSizes_Standard, 80, 52, false));
                    toReturn.Add(new MapDimension(Resources.Str_CivilizationVersion_Civilization5MapSizes_Large, 104, 64, false));
                    toReturn.Add(new MapDimension(Resources.Str_CivilizationVersion_Civilization5MapSizes_Huge, 128, 80, true));
                    toReturn.Add(new MapDimension(Resources.Str_CivilizationVersion_Civilization5MapSizes_Humongous, 300, 200, false));
                    return toReturn;

                case CivilizationVersion.CivilizationBE:
                    toReturn.Add(new MapDimension("Not Supported.", 0, 0, true));
                    return toReturn;

                default:
                    throw new InvalidEnumArgumentException("Non existing enumeration value.");
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic")]
        public GridTypeEnumWrapper.GridType GetVersionGridType(CivilizationVersion version)
        {
            switch (version)
            {
                case CivilizationVersion.Civilization1:
                    return GridTypeEnumWrapper.GridType.Rhombus;

                case CivilizationVersion.Civilization2:
                    return GridTypeEnumWrapper.GridType.Rhombus;

                case CivilizationVersion.Civilization3:
                    return GridTypeEnumWrapper.GridType.Rhombus;

                case CivilizationVersion.Civilization4:
                    return GridTypeEnumWrapper.GridType.Square;

                case CivilizationVersion.Civilization5:
                    return GridTypeEnumWrapper.GridType.HexagonalPT;

                case CivilizationVersion.CivilizationBE:
                    return GridTypeEnumWrapper.GridType.HexagonalPT;

                default:
                    throw new InvalidEnumArgumentException("Non existing enumeration value.");
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic")]
        public string GetSaveFileFilter(CivilizationVersion version)
        {
            switch (version)
            {
                case CivilizationVersion.Civilization1:
                    throw new NotImplementedException();
                case CivilizationVersion.Civilization2:
                    throw new NotImplementedException();
                case CivilizationVersion.Civilization3:
                    throw new NotImplementedException();
                case CivilizationVersion.Civilization4:
                    throw new NotImplementedException();
                case CivilizationVersion.Civilization5:
                    return "Civ 5 Map Files | *.Civ5Map";

                case CivilizationVersion.CivilizationBE:
                    throw new NotImplementedException();
                default:
                    throw new InvalidEnumArgumentException("Non existing enumeration value.");
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic")]
        public string GetSaveFileDefaultExtension(CivilizationVersion version)
        {
            switch (version)
            {
                case CivilizationVersion.Civilization1:
                    throw new NotImplementedException();
                case CivilizationVersion.Civilization2:
                    throw new NotImplementedException();
                case CivilizationVersion.Civilization3:
                    throw new NotImplementedException();
                case CivilizationVersion.Civilization4:
                    throw new NotImplementedException();
                case CivilizationVersion.Civilization5:
                    return "*.Civ5Map";

                case CivilizationVersion.CivilizationBE:
                    throw new NotImplementedException();
                default:
                    throw new InvalidEnumArgumentException("Non existing enumeration value.");
            }
        }

        #endregion CivilizationVersion specific utility methods
    }
}