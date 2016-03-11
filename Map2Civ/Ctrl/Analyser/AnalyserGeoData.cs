using System;
using Map2CivilizationCtrl.DataStructure;
using Map2CivilizationCtrl.Enumerations;

namespace Map2CivilizationCtrl.Analyzer
{
    class AnalyserGeoData : AnalyzerFactory
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA1801:ReviewUnusedParameters", MessageId = "gridType")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA1801:ReviewUnusedParameters", MessageId = "settings")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA1801:ReviewUnusedParameters", MessageId = "dimension")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA1801:ReviewUnusedParameters", MessageId = "civilizationVersion")]
        public AnalyserGeoData(SourceGeoDataSettings settings, GridType.Enumeration gridType,
            MapDimension dimension, CivilizationVersion.Enumeration civilizationVersion)
        {
            throw new NotImplementedException();
        }

        public override void AnalyzeData()
        {
            throw new NotImplementedException();
        }
    }
}
