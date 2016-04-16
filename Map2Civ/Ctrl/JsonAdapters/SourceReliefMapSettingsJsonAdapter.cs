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

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
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

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
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

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
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

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
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

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
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
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
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