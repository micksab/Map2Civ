using Map2CivilizationCtrl.Enumerations;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Map2CivilizationModel
{
    public class DetectedColors
    {
        private readonly Dictionary<string, DetectedColor> _collection;

        public DetectedColors()
        {
            _collection = new Dictionary<string, DetectedColor>();
        }

        public void AddDetectedColor(DetectedColor color)
        {
            if (color != null && !_collection.ContainsKey(color.ColorHex))
            {
                _collection.Add(color.ColorHex, color);
            }
        }

        public void AddDetectedColorPlot(DetectedColor color, Plot plot)
        {
            if (color != null && plot != null)
            {
                _collection[color.ColorHex].AddRelevantPlot(plot);
            }
        }

        public string[] GetDetectedColorIds()
        {
            string[] toReturn = _collection.Keys.ToArray<string>();

            return toReturn;
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate")]
        public Collection<DetectedColor> GetDetectedColors()
        {
            Collection<DetectedColor> toReturn = new Collection<DetectedColor>();

            foreach (DetectedColor toAdd in _collection.Values)
            {
                toReturn.Add(toAdd);
            }

            return toReturn;
        }

        public DetectedColor[] GetDetectedColorsArray()
        {
            return _collection.Values.ToArray<DetectedColor>();
        }

        public void UpdateDetectedColor(string colorHex, TerrainType.Enumeration descriptor)
        {
            DetectedColor detColor = _collection[colorHex];

            detColor.UpdateDetectedColor(descriptor);
        }

        internal DetectedColor GetColorByID(string colorID)
        {
            return _collection[colorID];
        }
    }
}