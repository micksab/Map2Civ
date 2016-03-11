using System;
using Map2CivilizationCtrl.Enumerations;
using Map2CivilizationCtrl.DataStructure;

namespace Map2CivilizationCtrl.Analyzer
{
    public abstract class AnalyzerFactory
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope")]
        public static AnalyzerFactory GetAnalyzer(ISourceMapSettings settings, GridType.Enumeration gridTypeEnum, 
            MapDimension dimension, CivilizationVersion.Enumeration civilizationVersion)
        {
            if(settings == null)
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
