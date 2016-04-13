using Map2CivilizationCtrl.DataStructure;
using Map2CivilizationCtrl.Enumerations;
using System;

namespace Map2CivilizationModel
{
    public abstract class Plot
    {
        private PlotId _id;

        private TerrainType.Enumeration _terrainDescriptor =
            TerrainType.Enumeration.NotDefined;

        private bool _isLocked = false;

        /// <summary>
        /// Constructor used when creating a new map
        /// </summary>
        /// <param name="plotX"></param>
        /// <param name="plotY"></param>
        protected Plot(int plotX, int plotY)
        {
            _id = new PlotId(plotX, plotY);
        }

        /// <summary>
        /// constructor used when loading the model from a save file
        /// </summary>
        /// <param name="id">The id of the plot</param>
        /// <param name="terrainDescriptor">The terrain assigned to the plot</param>
        /// <param name="isLocked">Marker indicating that the plot's terrain is locked (as defined by the user)</param>
        protected Plot(string id, TerrainType.Enumeration terrainDescriptor,
             Boolean isLocked)
        {
            _id = new PlotId(id);
            _terrainDescriptor = terrainDescriptor;
            _isLocked = isLocked;
        }

        public PlotId Id
        {
            get
            {
                return _id;
            }
        }

        public bool IsLocked
        {
            get
            {
                return _isLocked;
            }
        }

        public TerrainType.Enumeration TerrainDescriptor
        {
            get
            {
                return _terrainDescriptor;
            }

            set
            {
                _terrainDescriptor = value;
            }
        }

        public String IdString
        {
            get
            {
                return _id.Name;
            }
        }

        public void UpdatePlot(TerrainType.Enumeration terrainDescriptor, Boolean isLocked)
        {
            _terrainDescriptor = terrainDescriptor;
            _isLocked = isLocked;
        }
    }
}