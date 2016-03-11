using Map2Civilization.Properties;
using System;
using System.ComponentModel;
using System.Drawing;

namespace Map2CivilizationCtrl.Enumerations
{
    public class TerrainType : IEnrichedEnumWrapper
    {
        /// <summary>
        /// Used to store the single instance needed to perform any operation.
        /// </summary>
         static TerrainType _singleInstance;

        
        Bitmap _oceanPlotBitmap;
        Bitmap _coastPlotBitmap;
        Bitmap _flatPlotBitmap;
        Bitmap _hillPlotBitmap;
        Bitmap _mountainPlotBitmap;


        public enum Enumeration
        {
           
            NotDefined,
            Flat,
            Hills,
            Mountains,
            Coast,
            Ocean
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

        #endregion


        /// <summary>
        ///  constructor
        /// </summary>
         TerrainType() { }

        

        public static TerrainType Singleton
        {
            get
            {

                if (_singleInstance == null)
                {
                    _singleInstance = new TerrainType();
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

        public string GetEnumValueDescription(System.Enum value)
        {
            switch ((Enumeration)value)
            {
                case Enumeration.NotDefined:
                    return Resources.Str_TerrainType_Description_NotDefined;
                case Enumeration.Ocean:
                    return Resources.Str_TerrainType_Description_Ocean;
                case Enumeration.Coast:
                    return Resources.Str_TerrainType_Description_Coast;
                case Enumeration.Flat:
                    return Resources.Str_TerrainType_Description_Flat;
                case Enumeration.Hills:
                    return Resources.Str_TerrainType_Description_Hill;
                case Enumeration.Mountains:
                    return Resources.Str_TerrainType_Description_Mountain;
                default:
                    throw new InvalidEnumArgumentException("Non existing enumeration value.");
            }
        }

        public Boolean GetEnumValueEnabledStatus(System.Enum value)
        {
            switch ((Enumeration)value)
            {
                case Enumeration.NotDefined:
                    return true;
                case Enumeration.Ocean:
                    return true;
                case Enumeration.Coast:
                    return true;
                case Enumeration.Flat:
                    return true;
                case Enumeration.Hills:
                    return true;
                case Enumeration.Mountains:
                    return true;
                default:
                    throw new InvalidEnumArgumentException("Non existing enumeration value.");
            }
        }


        public Boolean GetEnumValueDefaultStatus(System.Enum value)
        {
            switch ((Enumeration)value)
            {
                case Enumeration.NotDefined:
                    return true;
                case Enumeration.Ocean:
                    return false;
                case Enumeration.Coast:
                    return false;
                case Enumeration.Flat:
                    return false;
                case Enumeration.Hills:
                    return false;
                case Enumeration.Mountains:
                    return false;
                default:
                    throw new InvalidEnumArgumentException("Non existing enumeration value.");
            }
        }

        #endregion

        protected internal void GenerateTerrainBitmaps()
        {
            //Get information about the current model
            GridType.Enumeration gridType = ModelCtrl.GetDataModel().GridType;
            float width = (int)GridType.Singleton.GetPlotWidthPixels(gridType);
            float height = (int)GridType.Singleton.GetPlotHeightPixels(gridType);

            _oceanPlotBitmap = BitmapOperationsCtrl.GetAssignedPlotBitmap(gridType, TerrainType.Enumeration.Ocean, width, height);
            _coastPlotBitmap = BitmapOperationsCtrl.GetAssignedPlotBitmap(gridType, TerrainType.Enumeration.Coast, width, height);
            _flatPlotBitmap = BitmapOperationsCtrl.GetAssignedPlotBitmap(gridType, TerrainType.Enumeration.Flat, width, height);
            _hillPlotBitmap = BitmapOperationsCtrl.GetAssignedPlotBitmap(gridType, TerrainType.Enumeration.Hills, width, height);
            _mountainPlotBitmap = BitmapOperationsCtrl.GetAssignedPlotBitmap(gridType, TerrainType.Enumeration.Mountains, width, height);

        }


    }
}
