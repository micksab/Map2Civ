using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace Map2CivilizationCtrl.Analyzer
{
    public class SourceReliefMapSettings : ISourceMapSettings, IDisposable
    {
        private Bitmap _originalMapBitmap;
        private Bitmap _adjustedMapBitmap;
        private readonly PixelFormat _pixelFormat;
        private readonly InterpolationMode _interpolationMode;
        private readonly CompositingQuality _compositingQuality;
        private readonly SmoothingMode _smoothingMode;

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

        public Bitmap OriginalMapBitmap
        {
            get
            {
                return _originalMapBitmap;
            }

            set
            {
                _originalMapBitmap = value;
            }
        }

        public Bitmap AdjustedMapBitmap
        {
            get
            {
                return _adjustedMapBitmap;
            }

            set
            {
                _adjustedMapBitmap = value;
            }
        }

        public SourceReliefMapSettings(Bitmap mapBitmap, System.Drawing.Imaging.PixelFormat pixelFormat,
            System.Drawing.Drawing2D.InterpolationMode interpolationMode,
            System.Drawing.Drawing2D.CompositingQuality compositingQuallity,
            System.Drawing.Drawing2D.SmoothingMode smoothingMode)
        {
            _originalMapBitmap = mapBitmap;
            _pixelFormat = pixelFormat;
            _interpolationMode = interpolationMode;
            _compositingQuality = compositingQuallity;
            _smoothingMode = smoothingMode;
        }

        public void Dispose()
        {
            _originalMapBitmap.Dispose();
        }
    }
}