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


using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace Map2CivilizationCtrl.Analyzer
{
    public sealed class SourceReliefMapSettings : ISourceMapSettings, IDisposable
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
            System.Drawing.Drawing2D.CompositingQuality compositingQuality,
            System.Drawing.Drawing2D.SmoothingMode smoothingMode)
        {
            _originalMapBitmap = mapBitmap;
            _pixelFormat = pixelFormat;
            _interpolationMode = interpolationMode;
            _compositingQuality = compositingQuality;
            _smoothingMode = smoothingMode;
        }

        public void Dispose()
        {
            _originalMapBitmap.Dispose();
        }
    }
}