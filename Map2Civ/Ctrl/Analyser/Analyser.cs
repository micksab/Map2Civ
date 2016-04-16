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

using Map2CivilizationCtrl.DataStructure;
using Map2CivilizationCtrl.Enumerations;
using System;

namespace Map2CivilizationCtrl.Analyzer
{
    public abstract class AnalyzerFactory
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope")]
        public static AnalyzerFactory GetAnalyzer(ISourceMapSettings settings, GridTypeEnumWrapper.GridType gridTypeEnum,
            MapDimension dimension, CivilizationVersionEnumWrapper.CivilizationVersion civilizationVersion)
        {
            if (settings == null)
            {
                throw new ArgumentNullException(nameof(settings), "Invalid or empty parameter value.");
            }

            if (settings.GetType().Equals(typeof(SourceReliefMapSettings)))
            {
                return new AnalyserReliefMap((SourceReliefMapSettings)settings, gridTypeEnum, dimension, civilizationVersion);
            }
            else if (settings.GetType().Equals(typeof(SourceGeoDataSettings)))
            {
                return new AnalyserGeoData((SourceGeoDataSettings)settings, gridTypeEnum, dimension, civilizationVersion);
            }
            else
            {
                throw new ArgumentException("Unknown type for parameter 'settings'.");
            }
        }

        public abstract void AnalyzeData();
    }
}