using System;
using System.Drawing;
using Map2CivilizationCtrl.DataStructure;
using Map2CivilizationCtrl.Enumerations;

namespace Map2CivilizationModel
{
    public sealed class DataModel : IDisposable
    {

         MapDimension _selectedMapSize;
         Bitmap _dataSourceImage;
         Bitmap _processedBitmap;
         GridType.Enumeration  _gridType;
         MapDataSource.Enumeration _mapDataSource;
         CivilizationVersion.Enumeration _civilizationVersion;
         Plots _plotCollection = new Plots();
         DetectedColors _detectedColorCollection = new DetectedColors();


         string _modelFile = string.Empty;
       


       


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

                if (value != null)
                {
                    _processedBitmap = new Bitmap(value.Width, value.Height);

                    using (Graphics g = Graphics.FromImage(_processedBitmap))
                    {
                        g.Clear(Color.Black);
                    }
                }
                
            }
        }

        public Bitmap ProcessedBitmap
        {
            get
            {
                return _processedBitmap;
            }
        }

        public void Dispose()
        {
            
            _dataSourceImage.Dispose();
            _processedBitmap.Dispose();
        }
    }
}
