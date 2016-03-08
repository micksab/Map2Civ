using System;
using System.Collections.Generic;

using System.Text;
using System.Collections.ObjectModel;
using System.Xml.Serialization;
using Map2CivilizationCtrl;


using System.Linq;
using Map2CivilizationCtrl.Enumerations;

namespace Map2CivilizationModel
{
    
    public class DetectedColors
    {
        
        private Dictionary<String, DetectedColor> _collection;

        public  DetectedColors()
        {
            _collection = new Dictionary<String, DetectedColor>();
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


        public String[] GetDetectedColorIds()
        {
            //DetectedColor[] toReturn = collection.Values.ToArray() as DetectedColor[];

            //return toReturn;

            String[] toReturn = _collection.Keys.ToArray<String>();

          
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


        public void UpdateDetectedColor(String colorHex, TerrainType.Enumeration descriptor)
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
