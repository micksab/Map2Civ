using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Map2CivilizationCtrl.Enumerations;

namespace Map2CivilizationModel
{

    public class DetectedColors
    {
        
        readonly Dictionary<string, DetectedColor> _collection;

        public  DetectedColors()
        {
            _collection = new Dictionary<string, DetectedColor>();
        }

       

        public void AddDetectedColor(DetectedColor color)
        {
            if (color!= null && !_collection.ContainsKey(color.ColorHex))
            {
                _collection.Add(color.ColorHex, color);

            }
        }

        public void AddDetectedColorPlot(DetectedColor color, Plot plot)
        {
            if (color != null && plot!=null)
            {
                _collection[color.ColorHex].AddRelevantPlot(plot);
            }
        }


        public string[] GetDetectedColorIds()
        {
            //DetectedColor[] toReturn = collection.Values.ToArray() as DetectedColor[];

            //return toReturn;

            string[] toReturn = _collection.Keys.ToArray<string>();

          
            return toReturn;
        }


        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate")]
        public Collection<DetectedColor> GetDetectedColors()
        {
            Collection<DetectedColor> toReturn = new Collection<DetectedColor>();

            foreach(DetectedColor toAdd in _collection.Values)
            {
                toReturn.Add(toAdd);
            }

            return toReturn;
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
