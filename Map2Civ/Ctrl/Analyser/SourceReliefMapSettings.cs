using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;

namespace Map2CivilizationCtrl.Analyzer
{
    class SourceReliefMapSettings : ISourceMapSettings
    {
        private Bitmap _mapBitmap;
        readonly PixelFormat _pixelFormat;
        readonly InterpolationMode _interpolationMode;
        readonly CompositingQuality _compositingQuality;
        readonly SmoothingMode _smoothingMode;

        

        public PixelFormat PixelFormat
        {
            get
            {
                return _pixelFormat;
            }
        }

       

        public InterpolationMode InterpolationMode
        {
            get
            {
                return _interpolationMode;
            }
        }

        public CompositingQuality CompositingQuality
        {
            get
            {
                return _compositingQuality;
            }
        }

        public SmoothingMode SmoothingMode
        {
            get
            {
                return _smoothingMode;
            }
        }

        public Bitmap MapBitmap
        {
            get
            {
                return _mapBitmap;
            }

            set
            {
                _mapBitmap = value;
            }
        }

        public SourceReliefMapSettings(Bitmap mapBitmap, System.Drawing.Imaging.PixelFormat pixelFormat,
            System.Drawing.Drawing2D.InterpolationMode interpolationMode,
            System.Drawing.Drawing2D.CompositingQuality compositingQuallity,
            System.Drawing.Drawing2D.SmoothingMode smoothingMode)
        {
            _mapBitmap = mapBitmap;
            _pixelFormat = pixelFormat;
            _interpolationMode = interpolationMode;
            _compositingQuality = compositingQuallity;
            _smoothingMode = smoothingMode;
        }

    }

   

}
