using System;
using System.ComponentModel;
using System.Windows.Forms;
using Map2CivilizationCtrl.Analyzer;
using Map2CivilizationCtrl.DataStructure;
using Map2CivilizationCtrl.Enumerations;

namespace Map2CivilizationView.UserControls
{
    [TypeDescriptionProvider(typeof(AbstractControlDescriptionProvider<SourceSettingsControlBase, UserControl>))]
    public abstract class SourceSettingsControlBase : UserControl
    {

        public abstract GridType.Enumeration SelectedGridType { set; get; }
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
        public abstract String SettingsAreComplete { get; }

        /// <summary>
        /// Property that returns to the caller the currently selected settigs
        /// </summary>
        /// <returns></returns>
        public abstract ISourceMapSettings Settings { get; }

        /// <summary>
        /// Used just for compatibility with the VS designer
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
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
