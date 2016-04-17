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

namespace Map2CivilizationCtrl.Enumerations
{
    public class GridTypeEnumWrapper : EnrichedEnumWrapper
    {
        public enum GridType
        {
            Square = 0,
            HexagonalPT = 1,
            Rhombus = 2
        }
        
        /// <summary>
        /// Used to store the single instance needed to perform any operation.
        /// </summary>
        private static Enumerations.GridTypeEnumWrapper _singleInstance;
        private static int _plotWidthPixelsSquarePlot;
        private static int _plotWidthPixelsHexagonalPt;
        private static int _plotWidthPixelsRhombus;

        #region Singleton methods

       

        /// <summary>
        ///  constructor
        /// </summary>
        private GridTypeEnumWrapper()
        {
            _plotWidthPixelsSquarePlot = Map2Civilization.Properties.Settings.Default.PlotWidthPixelsSquarePlot;
            _plotWidthPixelsHexagonalPt = Map2Civilization.Properties.Settings.Default.PlotWidthPixelsHexagonalP;
            _plotWidthPixelsRhombus = Map2Civilization.Properties.Settings.Default.PlotWidthPixelsRhombus;
        }

        public static GridTypeEnumWrapper Singleton
        {
            get
            {
                if (_singleInstance == null)
                {
                    _singleInstance = new Enumerations.GridTypeEnumWrapper();
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
                return typeof(GridType);
            }
        }




        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:Validate arguments of public methods", MessageId = "0")]
        override protected string GetEnumSpecificDescription(Enum value)
        {
            switch ((GridType)value)
            {
                case GridType.HexagonalPT:
                    return Resources.Str_GridType_GridTypeDescriptions_HexagonalPT;

                case GridType.Rhombus:
                    return Resources.Str_GridType_GridTypeDescriptions_Rhombus;

                case GridType.Square:
                    return Resources.Str_GridType_GridTypeDescriptions_Square;

                default:
                    throw new NotImplementedException(string.Concat("Handling not implemented for enum value ", value.ToString()));

            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:Validate arguments of public methods", MessageId = "0")]
        override protected bool GetEnumSpecificEnabledStatus(Enum value)
        {
            switch ((GridType)value)
            {
                case GridType.HexagonalPT:
                    return false;

                case GridType.Rhombus:
                    return false;

                case GridType.Square:
                    return true;

                default:
                    throw new NotImplementedException(string.Concat("Handling not implemented for enum value ", value.ToString()));

            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:Validate arguments of public methods", MessageId = "0")]
        override protected bool GetEnumSpecificDefaultStatus(Enum value)
        {
            switch ((GridType)value)
            {
                case GridType.HexagonalPT:
                    return false;

                case GridType.Rhombus:
                    return false;

                case GridType.Square:
                    return true;

                default:
                    throw new NotImplementedException(string.Concat("Handling not implemented for enum value ", value.ToString()));

            }
        }


        #endregion

        #region GridType helper methods

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic")]
        public double GetMapRatio(GridType enumValue, int widthPlots, int heightPlots)
        {
            switch (enumValue)
            {
                case GridType.Square:
                    return ((double)widthPlots) / ((double)heightPlots);

                case GridType.HexagonalPT:
                    //return (4 * Math.Sqrt(3) * (widthPlots + 0.5d)) / (6 * heightPlots);
                    return (4d * Math.Sqrt(3) * (widthPlots + 0.5d)) / (8d + 6d * (heightPlots - 1d));
                //return (Math.Sqrt(3) * (widthPlots + 0.5d)) / (2d + 6d * (heightPlots - 1d));

                case GridType.Rhombus:
                    throw new NotImplementedException("Not implemented option (Rhombus).");
                default:
                    throw new NotImplementedException(string.Concat("Handling not implemented for enum value ", enumValue.ToString()));
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic")]
        public float GetPlotWidthPixels(GridType gridTypeEnum)
        {
            switch (gridTypeEnum)
            {
                case GridType.Square:
                    return _plotWidthPixelsSquarePlot;

                case GridType.HexagonalPT:
                    return _plotWidthPixelsHexagonalPt;

                case GridType.Rhombus:
                    return _plotWidthPixelsRhombus;

                default:
                    throw new NotImplementedException(string.Concat("Handling not implemented for enum value ", gridTypeEnum.ToString()));

            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic")]
        public float GetPlotHeightPixels(GridType gridTypeEnum)
        {
            switch (gridTypeEnum)
            {
                case GridType.Square:
                    return _plotWidthPixelsSquarePlot;

                case GridType.HexagonalPT:
                    return (float)(_plotWidthPixelsHexagonalPt / (Math.Sqrt(3) / 2));

                case GridType.Rhombus:
                    throw new NotImplementedException();
                default:
                    throw new NotImplementedException(string.Concat("Handling not implemented for enum value ", gridTypeEnum.ToString()));

            }
        }

        #endregion GridType helper methods
    }
}