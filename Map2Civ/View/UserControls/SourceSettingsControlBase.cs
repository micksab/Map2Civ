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
    public abstract class SourceSettingsControlBase : UserControl
    {
        public abstract GridTypeEnumWrapper.GridType SelectedGridType { set; get; }

        /// <summary>
        /// Property where the container of the control should update whenever a change of the selected map
        /// size occurs.
        /// </summary>
        /// <param name="dimension">The MapDimension instance holding the information
        /// of the selected map dimension</param>
        public abstract MapDimension SelectedMapDimension { set; get; }

        /// <summary>
        /// Property that verifies if all the required settings of the source data are valid.
        /// </summary>
        /// <returns>Empty string if everything is OK, an error message string if not.</returns>
        public abstract string SettingsAreComplete { get; }

        /// <summary>
        /// Property that returns to the caller the currently selected settigs
        /// </summary>
        /// <returns></returns>
        public abstract ISourceMapSettings Settings { get; }

        /// <summary>
        /// Used just for compatibility with the VS designer
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledCode")]
        private void InitializeComponent()
        {
            this.SuspendLayout();
            //
            // SourceSettingsControlBase
            //
            this.Name = "SourceSettingsControlBase";
            this.ResumeLayout(false);
        }
    }
}