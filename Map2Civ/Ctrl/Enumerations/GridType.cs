using Map2Civilization.Properties;
using System;
using System.ComponentModel;

namespace Map2CivilizationCtrl.Enumerations
{
    public class GridType : IEnrichedEnumWrapper
    {
        public enum Enumeration
        {
            Square,
            HexagonalPT,
            Rhombus
        }


        #region Singleton methods

        /// <summary>
        /// Used to store the single instance needed to perform any operation.
        /// </summary>
        private static GridType _singleInstance;
        private static int _plotWidthPixelsSquarePlot;
        private static int _plotWidthPixelsHexagonalPt;
        private static int _plotWidthPixelsRhombus;
        

        /// <summary>
        /// Private constructor
        /// </summary>
        private GridType()
        {

            _plotWidthPixelsSquarePlot = Map2Civilization.Properties.Settings.Default.PlotWidthPixelsSquarePlot;
            _plotWidthPixelsHexagonalPt = Map2Civilization.Properties.Settings.Default.PlotWidthPixelsHexagonalP;
            _plotWidthPixelsRhombus = Map2Civilization.Properties.Settings.Default.PlotWidthPixelsRhombus;


        }

        


        public static GridType Singleton
        {
            get
            {
                if (_singleInstance == null)
                {
                    _singleInstance = new GridType();
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
                case Enumeration.HexagonalPT:
                    return Resources.Str_GridType_GridTypeDescriptions_HexagonalPT;
                case Enumeration.Rhombus:
                    return Resources.Str_GridType_GridTypeDescriptions_Rhombus;
                case Enumeration.Square:
                    return Resources.Str_GridType_GridTypeDescriptions_Square;
                default:
                    throw new InvalidEnumArgumentException("Non existing enumeration value.");
            }
        }

        public Boolean GetEnumValueEnabledStatus(System.Enum value)
        {
            switch ((Enumeration)value)
            {
                case Enumeration.HexagonalPT:
                    return false;
                case Enumeration.Rhombus:
                    return false;
                case Enumeration.Square:
                    return true;
                default:
                    throw new InvalidEnumArgumentException("Non existing enumeration value.");
            }
        }


        public Boolean GetEnumValueDefaultStatus(System.Enum value)
        {
            switch ((Enumeration)value)
            {
                case Enumeration.HexagonalPT:
                    return false;
                case Enumeration.Rhombus:
                    return false;
                case Enumeration.Square:
                    return true;
                default:
                    throw new InvalidEnumArgumentException("Non existing enumeration value.");
            }
        }

        #endregion

        #region GridType helper methods

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic")]
        public double GetMapRatio(GridType.Enumeration enumValue, int widthPlots, int heightPlots)
        {
            switch (enumValue)
            {
                case Enumeration.Square:
                    return ((double)widthPlots) / ((double)heightPlots);
                case Enumeration.HexagonalPT:
                    //return (4 * Math.Sqrt(3) * (widthPlots + 0.5d)) / (6 * heightPlots);
                    return (4d*Math.Sqrt(3)*(widthPlots + 0.5d)) / (8d + 6d*(heightPlots - 1d));
                    //return (Math.Sqrt(3) * (widthPlots + 0.5d)) / (2d + 6d * (heightPlots - 1d));

                case Enumeration.Rhombus:
                    throw new NotImplementedException("Not implemented option (Rhombus).");
                default:
                    throw new InvalidEnumArgumentException("Non existing enumeration value.");
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic")]
        public float GetPlotWidthPixels(GridType.Enumeration gridTypeEnum)
        {
            switch(gridTypeEnum)
            {
                case Enumeration.Square:
                    return GridType._plotWidthPixelsSquarePlot;
                case Enumeration.HexagonalPT:
                    return GridType._plotWidthPixelsHexagonalPt;
                case Enumeration.Rhombus:
                    return GridType._plotWidthPixelsRhombus;
                default:
                    throw new InvalidEnumArgumentException("Unexpected value for param GridType");
            }
        }


        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic")]
        public float GetPlotHeightPixels(GridType.Enumeration gridTypeEnum)
        {
            switch (gridTypeEnum)
            {
                case Enumeration.Square:
                    return GridType._plotWidthPixelsSquarePlot;
                case Enumeration.HexagonalPT:
                    return (float)(GridType._plotWidthPixelsHexagonalPt / (Math.Sqrt(3) / 2));
                case Enumeration.Rhombus:
                    throw new NotImplementedException();
                default:
                    throw new InvalidEnumArgumentException("Unexpected value for param GridType");
            }
        }

        

        


        #endregion
    }
}
