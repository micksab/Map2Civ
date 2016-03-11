using System;
using System.Drawing;
using Map2CivilizationCtrl.DataStructure;
using Map2CivilizationCtrl.Enumerations;

namespace Map2CivilizationModel
{
    public class DataModel
    {

        private MapDimension _selectedMapSize;
        private Bitmap _dataSourceImage;
        private GridType.Enumeration  _gridType;
        private MapDataSource.Enumeration _mapDataSource;
        private CivilizationVersion.Enumeration _civilizationVersion;
        private Plots _plotCollection = new Plots();
        private DetectedColors _detectedColorCollection = new DetectedColors();


        private String _modelFile = String.Empty;
       


       


        public MapDimension SelectedMapSize
        {
            set
            {
                _selectedMapSize = value;
            }
            get
            {
                return  _selectedMapSize;
            }
        }

        



        internal Plots PlotCollection
        {
            get
            {
                return _plotCollection;
            }
        }

        internal DetectedColors DetectedColorCollection
        {
            get
            {
                return _detectedColorCollection;
            }
        }



        

        public string ModelFile
        {
            get
            {
                return _modelFile;
            }

            set
            {
                _modelFile = value;
            }
        }

        public GridType.Enumeration GridType
        {
            get
            {
                return _gridType;
            }

            set
            {
                _gridType = value;
            }
        }

        public CivilizationVersion.Enumeration CivilizationVersion
        {
            get
            {
                return _civilizationVersion;
            }

            set
            {
                _civilizationVersion = value;
            }
        }

        public MapDataSource.Enumeration MapDataSource
        {
            get
            {
                return _mapDataSource;
            }

            set
            {
                _mapDataSource = value;
            }
        }

        public Bitmap DataSourceImage
        {
            get
            {
                return _dataSourceImage;
            }

            set
            {
                _dataSourceImage = value;
            }
        }
    }
}
