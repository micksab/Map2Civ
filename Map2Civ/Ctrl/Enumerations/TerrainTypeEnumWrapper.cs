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
using System;
using System.ComponentModel;
using System.Drawing;

namespace Map2CivilizationCtrl.Enumerations
{
    public class TerrainTypeEnumWrapper : EnrichedEnumWrapper
    {
        /// <summary>
        /// Used to store the single instance needed to perform any operation.
        /// </summary>
        private static TerrainTypeEnumWrapper _singleInstance;

        private Bitmap _oceanPlotBitmap;
        private Bitmap _coastPlotBitmap;
        private Bitmap _flatPlotBitmap;
        private Bitmap _hillPlotBitmap;
        private Bitmap _mountainPlotBitmap;

        public enum TerrainType
        {
            NotDefined = 0,
            Flat = 1,
            Hills = 2,
            Mountains = 3,
            Coast = 4,
            Ocean = 5
        }

        #region Singleton methods

        #region properties

        public Bitmap OceanPlotBitmap
        {
            get
            {
                return _oceanPlotBitmap;
            }
        }

        public Bitmap CoastPlotBitmap
        {
            get
            {
                return _coastPlotBitmap;
            }
        }

        public Bitmap FlatPlotBitmap
        {
            get
            {
                return _flatPlotBitmap;
            }
        }

        public Bitmap HillPlotBitmap
        {
            get
            {
                return _hillPlotBitmap;
            }
        }

        public Bitmap MountainPlotBitmap
        {
            get
            {
                return _mountainPlotBitmap;
            }
        }

        #endregion properties

        /// <summary>
        ///  constructor
        /// </summary>
        private TerrainTypeEnumWrapper()
        { }

        public static TerrainTypeEnumWrapper Singleton
        {
            get
            {
                if (_singleInstance == null)
                {
                    _singleInstance = new TerrainTypeEnumWrapper();
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
                return typeof(TerrainType);
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:Validate arguments of public methods", MessageId = "0")]
        override protected internal string GetEnumSpecificDescription(System.Enum value)
        {
            switch ((TerrainType)value)
            {
                case TerrainType.NotDefined:
                    return Resources.Str_TerrainType_Description_NotDefined;

                case TerrainType.Ocean:
                    return Resources.Str_TerrainType_Description_Ocean;

                case TerrainType.Coast:
                    return Resources.Str_TerrainType_Description_Coast;

                case TerrainType.Flat:
                    return Resources.Str_TerrainType_Description_Flat;

                case TerrainType.Hills:
                    return Resources.Str_TerrainType_Description_Hill;

                case TerrainType.Mountains:
                    return Resources.Str_TerrainType_Description_Mountain;

                default:
                    throw new NotImplementedException(string.Concat("Handling not implemented for enum value ", value.ToString()));

            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:Validate arguments of public methods", MessageId = "0")]
        override protected internal bool GetEnumSpecificEnabledStatus(System.Enum value)
        {
            switch ((TerrainType)value)
            {
                case TerrainType.NotDefined:
                    return true;

                case TerrainType.Ocean:
                    return true;

                case TerrainType.Coast:
                    return true;

                case TerrainType.Flat:
                    return true;

                case TerrainType.Hills:
                    return true;

                case TerrainType.Mountains:
                    return true;

                default:
                    throw new NotImplementedException(string.Concat("Handling not implemented for enum value ", value.ToString()));

            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:Validate arguments of public methods", MessageId = "0")]
        override protected internal bool GetEnumSpecificDefaultStatus(System.Enum value)
        {
            switch ((TerrainType)value)
            {
                case TerrainType.NotDefined:
                    return true;

                case TerrainType.Ocean:
                    return false;

                case TerrainType.Coast:
                    return false;

                case TerrainType.Flat:
                    return false;

                case TerrainType.Hills:
                    return false;

                case TerrainType.Mountains:
                    return false;

                default:
                    throw new NotImplementedException(string.Concat("Handling not implemented for enum value ", value.ToString()));

            }
        }


        #endregion

        protected internal void GenerateTerrainBitmaps()
        {
            //Get information about the current model
            GridTypeEnumWrapper.GridType gridType = ModelCtrl.GetDataModel().GridType;
            float width = (int)GridTypeEnumWrapper.Singleton.GetPlotWidthPixels(gridType);
            float height = (int)GridTypeEnumWrapper.Singleton.GetPlotHeightPixels(gridType);

            _oceanPlotBitmap = BitmapOperationsCtrl.GetAssignedPlotBitmap(gridType, TerrainTypeEnumWrapper.TerrainType.Ocean, width, height);
            _coastPlotBitmap = BitmapOperationsCtrl.GetAssignedPlotBitmap(gridType, TerrainTypeEnumWrapper.TerrainType.Coast, width, height);
            _flatPlotBitmap = BitmapOperationsCtrl.GetAssignedPlotBitmap(gridType, TerrainTypeEnumWrapper.TerrainType.Flat, width, height);
            _hillPlotBitmap = BitmapOperationsCtrl.GetAssignedPlotBitmap(gridType, TerrainTypeEnumWrapper.TerrainType.Hills, width, height);
            _mountainPlotBitmap = BitmapOperationsCtrl.GetAssignedPlotBitmap(gridType, TerrainTypeEnumWrapper.TerrainType.Mountains, width, height);
        }
    }
}