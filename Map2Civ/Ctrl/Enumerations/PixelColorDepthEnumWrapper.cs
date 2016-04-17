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
using System.Drawing.Imaging;

namespace Map2CivilizationCtrl.Enumerations
{
    public class PixelColorDepthEnumWrapper : EnrichedEnumWrapper
    {
        /// <summary>
        /// Enumeration that holds image color-depth options
        /// </summary>
        public enum PixelColorDepth
        {
            OneBit = 0,
            FourBit = 1,
            EightBit = 2,
            SixteenBit = 3,
            TwentyFourBit = 4,
            ThirtyTwoBit = 5,
            FortyEightBit = 6,
            SixtyFourBit = 7
        }

        #region Singleton methods

        /// <summary>
        /// Used to store the single instance needed to perform any operation.
        /// </summary>
        private static PixelColorDepthEnumWrapper _singleInstance;

        /// <summary>
        ///  constructor
        /// </summary>
        private PixelColorDepthEnumWrapper()
        { }

        public static PixelColorDepthEnumWrapper Singleton
        {
            get
            {
                if (_singleInstance == null)
                {
                    _singleInstance = new PixelColorDepthEnumWrapper();
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
                return typeof(PixelColorDepth);
            }
        }

        override protected bool GetEnumSpecificDefaultStatus(Enum value)
        {
            OperatingSystem os = Environment.OSVersion;

            switch ((PixelColorDepth)value)
            {
                case PixelColorDepth.OneBit:
                    return false;

                case PixelColorDepth.FourBit:
                    return false;

                case PixelColorDepth.EightBit:
                    //If the OS version is smaler than Vista/Server2008
                    if (os.Version.CompareTo(new Version(6, 0)) < 0)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }

                case PixelColorDepth.SixteenBit:
                    //If the OS version is smaler than Vista/Server2008
                    if (os.Version.CompareTo(new Version(6, 0)) < 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case PixelColorDepth.TwentyFourBit:
                    return false;

                case PixelColorDepth.ThirtyTwoBit:
                    return false;

                case PixelColorDepth.FortyEightBit:
                    return false;

                case PixelColorDepth.SixtyFourBit:
                    return false;

                default:
                    throw new ArgumentException("Invalid enum value.", nameof(value));
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:Validate arguments of public methods", MessageId = "0")]
        override protected string GetEnumSpecificDescription(Enum value)
        {
            switch ((PixelColorDepth)value)
            {
                case PixelColorDepth.OneBit:
                    return "1-Bit Per Pixel";

                case PixelColorDepth.FourBit:
                    return "4-Bits Per Pixel";

                case PixelColorDepth.EightBit:
                    return "8-Bits Per Pixel";

                case PixelColorDepth.SixteenBit:
                    return "16-Bits Per Pixel";

                case PixelColorDepth.TwentyFourBit:
                    return "24-Bits Per Pixel";

                case PixelColorDepth.ThirtyTwoBit:
                    return "32-Bits Per Pixel";

                case PixelColorDepth.FortyEightBit:
                    return "48-Bits Per Pixel";

                case PixelColorDepth.SixtyFourBit:
                    return "64-Bits Per Pixel";

                default:
                    throw new NotImplementedException(string.Concat("Handling not implemented for enum value ", value.ToString()));

            }
        }

        override protected bool GetEnumSpecificEnabledStatus(Enum value)
        {
            OperatingSystem os = Environment.OSVersion;

            //If the OS is newer than Windows XP and Windows Server 2003
            if (os.Version.CompareTo(new Version(6, 0)) < 0)
            {
                switch ((PixelColorDepth)value)
                {
                    case PixelColorDepth.OneBit:
                        return false;

                    case PixelColorDepth.FourBit:
                        return false;

                    case PixelColorDepth.EightBit:
                        return false;

                    default:
                        return true;
                }
            }

            return true;
        }


        #endregion

        public static PixelFormat GetPixelFormat(PixelColorDepth value)
        {
            switch ((PixelColorDepth)value)
            {
                case PixelColorDepth.OneBit:
                    return PixelFormat.Format1bppIndexed;

                case PixelColorDepth.FourBit:
                    return PixelFormat.Format4bppIndexed;

                case PixelColorDepth.EightBit:
                    return PixelFormat.Format8bppIndexed;

                case PixelColorDepth.SixteenBit:
                    return PixelFormat.Format16bppRgb555;

                case PixelColorDepth.TwentyFourBit:
                    return PixelFormat.Format24bppRgb;

                case PixelColorDepth.ThirtyTwoBit:
                    return PixelFormat.Format32bppRgb;

                case PixelColorDepth.FortyEightBit:
                    return PixelFormat.Format48bppRgb;

                case PixelColorDepth.SixtyFourBit:
                    return PixelFormat.Format64bppArgb;

                default:
                    throw new NotImplementedException(string.Concat("Handling not implemented for enum value ", value.ToString()));

            }
        }
    }
}