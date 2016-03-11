using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

using Map2CivilizationCtrl.Enumerations;

namespace Map2CivilizationModel
{

    public class DetectedColor
    {

        string _colorHex;
        TerrainType.Enumeration _terrainDescriptor;
        readonly List<Plot> _relevantPlots;

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

        public DetectedColor(string colorHexValue)
        {
            _colorHex = colorHexValue;
            _terrainDescriptor = TerrainType.Enumeration.NotDefined;
            _relevantPlots = new List<Plot>();
        }


        public DetectedColor(string hexColor, TerrainType.Enumeration terrainDescriptor)
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


         void UpdateRelevantPlots()
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
