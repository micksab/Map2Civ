/************************************************************************************/
//
//      This file is part of Map2Civilization.
//      Map2Civilization is free software: you can redistribute it and/or modify
//      it under the terms of the GNU General Public License as published by
//      the Free Software Foundation, either version 3 of the License, or
//      (at your option) any later version.
//
//      Map2Civilization is distributed in the hope that it will be useful,
//      but WITHOUT ANY WARRANTY; without even the implied warranty of
//      MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.See the
//      GNU General Public License for more details.
//
//      You should have received a copy of the GNU General Public License
//      along with Map2Civilization.  If not, see http://www.gnu.org/licenses/.
//
/************************************************************************************/

using Map2CivilizationCtrl.Analyzer;
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
        private GridTypeEnumWrapper.GridType _gridTypeEnum;

        public SourceSettingsControlGeoData()
        {
            InitializeComponent();
        }

        override public GridTypeEnumWrapper.GridType SelectedGridType
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