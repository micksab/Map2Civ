using Map2CivilizationCtrl.Analyzer;
using Newtonsoft.Json;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;

namespace Map2CivilizationCtrl.JsonAdapters
{
    internal class SourceReliefMapSettingsJsonAdapter
    {
        private byte[] _originalBitmapBytes;
        private PixelFormat _pixelFormat;
        private InterpolationMode _interpolationMode;
        private CompositingQuality _compositingQuality;
        private SmoothingMode _smoothingMode;

        #region public properties

        [JsonProperty("originalBytes")]
        public byte[] OriginalBitmapBytes
        {
            get
            {
                return _originalBitmapBytes;
            }

            set
            {
                _originalBitmapBytes = value;
            }
        }

        [JsonProperty("pixelFormat")]
        public PixelFormat PixelFormat
        {
            get
            {
                return _pixelFormat;
            }

            set
            {
                _pixelFormat = value;
            }
        }

        [JsonProperty("interpolation")]
        public InterpolationMode InterpolationMode
        {
            get
            {
                return _interpolationMode;
            }

            set
            {
                _interpolationMode = value;
            }
        }

        [JsonProperty("compositing")]
        public CompositingQuality CompositingQuality
        {
            get
            {
                return _compositingQuality;
            }

            set
            {
                _compositingQuality = value;
            }
        }

        [JsonProperty("smoothing")]
        public SmoothingMode SmoothingMode
        {
            get
            {
                return _smoothingMode;
            }

            set
            {
                _smoothingMode = value;
            }
        }

        #endregion public properties

        /// <summary>
        /// Constructor used to transform a SourceReliefMapSettings instance to SourceReliefMapSettingsJsonAdapter
        /// </summary>
        /// <param name="settings"></param>
        public SourceReliefMapSettingsJsonAdapter(SourceReliefMapSettings settings)
        {
            ImageConverter converter = new ImageConverter();
            _originalBitmapBytes = (byte[])converter.ConvertTo(settings.OriginalMapBitmap, typeof(byte[]));
            _pixelFormat = settings.PixelFormat;
            _interpolationMode = settings.InterpolationMode;
            _compositingQuality = settings.CompositingQuality;
            _smoothingMode = settings.SmoothingMode;
        }

        /// <summary>
        /// Constructor used to facilitate Json deserialization
        /// </summary>
        /// <param name="originalBytes"></param>
        /// <param name="pixelFormat"></param>
        /// <param name="interpolation"></param>
        /// <param name="compositing"></param>
        /// <param name="smoothing"></param>
        [JsonConstructor]
        public SourceReliefMapSettingsJsonAdapter(byte[] originalBytes, PixelFormat pixelFormat, InterpolationMode interpolation,
            CompositingQuality compositing, SmoothingMode smoothing)
        {
            _originalBitmapBytes = originalBytes;
            _pixelFormat = pixelFormat;
            _interpolationMode = interpolation;
            _compositingQuality = compositing;
            _smoothingMode = smoothing;
        }

        public SourceReliefMapSettings GetSourceReliefMapSettings()
        {
            Bitmap originalMapBitmap;

            using (MemoryStream ms = new MemoryStream(_originalBitmapBytes))
            {
                originalMapBitmap = (Bitmap)Image.FromStream(ms);
            }

            return new SourceReliefMapSettings(originalMapBitmap, _pixelFormat, _interpolationMode,
                _compositingQuality, _smoothingMode);
        }
    }
}