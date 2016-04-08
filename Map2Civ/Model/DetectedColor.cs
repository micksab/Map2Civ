using System.Collections.Generic;
using Map2CivilizationCtrl.Enumerations;
using Map2CivilizationCtrl.DataStructure;


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


        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1002:DoNotExposeGenericLists")]
        public List<Plot> RelevantPlots
        {
            get
            {
                return _relevantPlots;
            }

        }


        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1002:DoNotExposeGenericLists")]
        public List<PlotId> RelevantPlotIds
        {
            get
            {
                List<PlotId> toReturn = new List<PlotId>();

                foreach(Plot plot in _relevantPlots)
                {
                    toReturn.Add(plot.Id);
                }

                return toReturn;
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="hexColor">The string representation of the color (eg. #99CCFF) </param>
        /// <param name="terrainDescriptor">The terrain value assigned to the color</param>
        public DetectedColor(string hexColor, TerrainType.Enumeration terrainDescriptor)
        {
            _colorHex = hexColor;
            _terrainDescriptor  = terrainDescriptor;
            _relevantPlots = new List<Plot>();
           
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
