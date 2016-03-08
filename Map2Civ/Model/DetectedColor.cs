using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;

using System.Text;

using System.Xml.Serialization;

using System.Collections.ObjectModel;

using Map2CivilizationCtrl.Enumerations;
using Map2CivilizationCtrl;

namespace Map2CivilizationModel
{
    
    public class DetectedColor
    {

        private String _colorHex;
        private TerrainType.Enumeration _terrainDescriptor;
        private List<Plot> _relevantPlots;

        public string ColorHex
        {
            get
            {
                return _colorHex;
            }

            set
            {
                _colorHex = value;
            }
        }


        public Collection<Plot> RelevantPlots
        {
            get
            {
                return new Collection<Plot>(_relevantPlots);
            }

        }

        public TerrainType.Enumeration TerrainDescriptor
        {
            get
            {
                return _terrainDescriptor;
            }

          
        }

        public DetectedColor(String colorHexValue)
        {
            _colorHex = colorHexValue;
            _terrainDescriptor = TerrainType.Enumeration.NotDefined;
            _relevantPlots = new List<Plot>();
        }


        public DetectedColor(String hexColor, TerrainType.Enumeration terrainDescriptor)
        {
            _colorHex = hexColor;
            _terrainDescriptor  = terrainDescriptor;
           
        }


        public void UpdateDetectedColor(TerrainType.Enumeration terrainDescriptor)
        {
            _terrainDescriptor = terrainDescriptor;
            UpdateRelevantPlots();
        }


        public void AddRelevantPlot(Plot plot)
        {
            if (!_relevantPlots.Contains(plot))
            {
                _relevantPlots.Add(plot);
            }
        }


        private void UpdateRelevantPlots()
        {
            foreach(Plot plot in _relevantPlots)
            {
                

                if(!plot.IsLocked)
                {
                    plot.UpdatePlot(_terrainDescriptor, false);
                   
                }
                

            }
        }


        



        

       

        

    }
}
