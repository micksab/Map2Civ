using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Map2CivilizationCtrl.Analyzer;
using Map2CivilizationCtrl.DataStructure;
using Map2CivilizationCtrl.Enumerations;

namespace Map2CivilizationView.UserControls
{
    [TypeDescriptionProvider(typeof(AbstractControlDescriptionProvider<SourceSettingsControlBase, UserControl>))]
    public partial class SourceSettingsControlGeoData :  SourceSettingsControlBase
    {
        MapDimension _mapDimension;
        GridType.Enumeration _gridTypeEnum;

        public SourceSettingsControlGeoData()
        {
            InitializeComponent();
        }

        override public GridType.Enumeration SelectedGridType
        {
            set
            {
                _gridTypeEnum = value;
            }
            get
            {
                return _gridTypeEnum;
            }
        }

        override public  MapDimension SelectedMapDimension
        {
            set
            {
                _mapDimension = value;
            }
            get
            {
                return _mapDimension;
            }
            
        }

        override public String SettingsAreComplete
        {
            get
            {
                throw new System.NotSupportedException("Not implemented.");
            }
        }

        override public ISourceMapSettings Settings
        {
            get
            {
                throw new System.NotSupportedException("Not implemented.");
            }
        }

        
    }
}
