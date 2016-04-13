﻿using Map2CivilizationCtrl.Analyzer;
using Map2CivilizationCtrl.DataStructure;
using Map2CivilizationCtrl.Enumerations;
using System.ComponentModel;
using System.Windows.Forms;

namespace Map2CivilizationView.UserControls
{
    [TypeDescriptionProvider(typeof(AbstractControlDescriptionProvider<SourceSettingsControlBase, UserControl>))]
    public partial class SourceSettingsControlGeoData : SourceSettingsControlBase
    {
        private MapDimension _mapDimension;
        private GridType.Enumeration _gridTypeEnum;

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

        override public MapDimension SelectedMapDimension
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

        override public string SettingsAreComplete
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