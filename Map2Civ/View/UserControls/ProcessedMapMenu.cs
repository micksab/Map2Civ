using Map2Civilization.Properties;
using Map2CivilizationCtrl;
using Map2CivilizationCtrl.Enumerations;
using System;
using System.Windows.Forms;

namespace Map2CivilizationView.UserControls
{
    internal class ProcessedMapMenu : ContextMenuStrip
    {
        private ToolStripMenuItem _editPlotColorMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        private ToolStripMenuItem _editRegionMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        private ToolStripMenuItem _oceanStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        private ToolStripMenuItem _coastStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        private ToolStripMenuItem _flatStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        private ToolStripMenuItem _hillsStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        private ToolStripMenuItem _mountainStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        private ToolStripMenuItem _removeTerrainMenuItem = new System.Windows.Forms.ToolStripMenuItem();

        public event EventHandler RegionEditEvent;

        public event EventHandler ColorEditEvent;

        public event EventHandler<CustomPlotMapMenuEventArgs> PlotEditEvent;

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1303:Do not pass literals as localized parameters", MessageId = "System.Windows.Forms.ToolStripItem.set_Text(System.String)")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1303:Do not pass literals as localized parameters", MessageId = "System.Windows.Forms.ToolStripItem.set_Text(System.string)")]
        public ProcessedMapMenu(ProcessedMapControlMode.Enumeration mode)
        {
            Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            _editPlotColorMenuItem,
            _editRegionMenuItem,
            _oceanStripMenuItem,
            _coastStripMenuItem,
            _flatStripMenuItem,
            _hillsStripMenuItem,
            _mountainStripMenuItem,
            _removeTerrainMenuItem});
            Name = "contextMenu";
            Size = new System.Drawing.Size(203, 158);

            //
            // editPlotColorMenuItem
            //
            _editPlotColorMenuItem.Image = Resources.Palette_Image;
            _editPlotColorMenuItem.Name = "editPlotDataMenuItem";
            _editPlotColorMenuItem.Size = new System.Drawing.Size(202, 22);

            _editPlotColorMenuItem.Text = Resources.Str_ProcessedMapMenu_EditPlotColor_Text +
               VariousUtilityMethods.FormatKeyStringRepresentation(Settings.Default.KeyShrortcuts_EditPlotData) + ")";
            _editPlotColorMenuItem.Click += editPlotColorMenuItem_Click;
            //
            // editRegionMenuItem
            //
            _editRegionMenuItem.Image = global::Map2Civilization.Properties.Resources.Minimap_Image;
            _editRegionMenuItem.Name = "editRegionMenuItem";
            _editRegionMenuItem.Size = new System.Drawing.Size(202, 22);
            _editRegionMenuItem.Text = Resources.Str_ProcessedMapMenu_EditRegion_Text +
                VariousUtilityMethods.FormatKeyStringRepresentation(Settings.Default.KeyShrortcuts_EditRegion) + ")";
            _editRegionMenuItem.Click += editRegionMenuItem_Click;
            //
            // oceanStripMenuItem
            //
            _oceanStripMenuItem.Image = TerrainType.Singleton.OceanPlotBitmap;
            _oceanStripMenuItem.Name = TerrainType.Enumeration.Ocean.ToString();
            _oceanStripMenuItem.Size = new System.Drawing.Size(202, 22);
            _oceanStripMenuItem.Text = TerrainType.Singleton.GetEnumValueDescription(TerrainType.Enumeration.Ocean) + " (" +
               VariousUtilityMethods.FormatKeyStringRepresentation(Settings.Default.KeyShrortcuts_AssignOcean) + ")";
            _oceanStripMenuItem.Click += plotMenuStrip_Click;
            //
            // coastStripMenuItem
            //
            _coastStripMenuItem.Image = TerrainType.Singleton.CoastPlotBitmap;
            _coastStripMenuItem.Name = TerrainType.Enumeration.Coast.ToString();
            _coastStripMenuItem.Size = new System.Drawing.Size(202, 22);
            _coastStripMenuItem.Text = TerrainType.Singleton.GetEnumValueDescription(TerrainType.Enumeration.Coast) + " (" +
                VariousUtilityMethods.FormatKeyStringRepresentation(Settings.Default.KeyShrortcuts_AssignCoast) + ")";
            _coastStripMenuItem.Click += plotMenuStrip_Click;
            //
            // flatStripMenuItem
            //
            _flatStripMenuItem.Image = TerrainType.Singleton.FlatPlotBitmap;
            _flatStripMenuItem.Name = TerrainType.Enumeration.Flat.ToString();
            _flatStripMenuItem.Size = new System.Drawing.Size(202, 22);
            _flatStripMenuItem.Text = TerrainType.Singleton.GetEnumValueDescription(TerrainType.Enumeration.Flat) + " (" +
               VariousUtilityMethods.FormatKeyStringRepresentation(Settings.Default.KeyShrortcuts_AssignFlat) + ")";
            _flatStripMenuItem.Click += plotMenuStrip_Click;
            //
            // hillsStripMenuItem
            //
            _hillsStripMenuItem.Image = TerrainType.Singleton.HillPlotBitmap;
            _hillsStripMenuItem.Name = TerrainType.Enumeration.Hills.ToString();
            _hillsStripMenuItem.Size = new System.Drawing.Size(202, 22);
            _hillsStripMenuItem.Text = TerrainType.Singleton.GetEnumValueDescription(TerrainType.Enumeration.Hills) + "  (" +
               VariousUtilityMethods.FormatKeyStringRepresentation(Settings.Default.KeyShrortcuts_AssignHill) + ")";
            _hillsStripMenuItem.Click += plotMenuStrip_Click;
            //
            // mountainStripMenuItem
            //
            _mountainStripMenuItem.Image = TerrainType.Singleton.MountainPlotBitmap;
            _mountainStripMenuItem.Name = TerrainType.Enumeration.Mountains.ToString();
            _mountainStripMenuItem.Size = new System.Drawing.Size(202, 22);
            _mountainStripMenuItem.Text = TerrainType.Singleton.GetEnumValueDescription(TerrainType.Enumeration.Mountains) + " (" +
               VariousUtilityMethods.FormatKeyStringRepresentation(Settings.Default.KeyShrortcuts_AssignMountain) + ")";
            _mountainStripMenuItem.Click += plotMenuStrip_Click;
            //
            // mountainStripMenuItem
            //
            _removeTerrainMenuItem.Image = Resources.Cancel_Image;
            _removeTerrainMenuItem.Name = TerrainType.Enumeration.Mountains.ToString();
            _removeTerrainMenuItem.Size = new System.Drawing.Size(202, 22);
            _removeTerrainMenuItem.Text = Resources.Str_ProcessedMapMenu_DeAssign_Text + " (" +
               VariousUtilityMethods.FormatKeyStringRepresentation(Settings.Default.KeyShrortcuts_RepealAssignment) + ")";
            _removeTerrainMenuItem.Click += plotMenuStrip_Click;

            setMode(mode);
        }

        public void setMode(ProcessedMapControlMode.Enumeration mode)
        {
            if (mode == ProcessedMapControlMode.Enumeration.ColorEditor)
            {
                Visible = true;
                _editPlotColorMenuItem.Visible = true;
                _editRegionMenuItem.Visible = true;
                _oceanStripMenuItem.Visible = false;
                _coastStripMenuItem.Visible = false;
                _flatStripMenuItem.Visible = false;
                _hillsStripMenuItem.Visible = false;
                _mountainStripMenuItem.Visible = false;
                _removeTerrainMenuItem.Visible = false;
            }
            else if (mode == ProcessedMapControlMode.Enumeration.PlotEditor)
            {
                Visible = true;
                _editPlotColorMenuItem.Visible = false;
                _editRegionMenuItem.Visible = false;
                _oceanStripMenuItem.Visible = true;
                _coastStripMenuItem.Visible = true;
                _flatStripMenuItem.Visible = true;
                _hillsStripMenuItem.Visible = true;
                _mountainStripMenuItem.Visible = true;
                _removeTerrainMenuItem.Visible = true;
            }
            else
            {
                Visible = false;
                _editPlotColorMenuItem.Visible = false;
                _editRegionMenuItem.Visible = false;
                _oceanStripMenuItem.Visible = false;
                _coastStripMenuItem.Visible = false;
                _flatStripMenuItem.Visible = false;
                _hillsStripMenuItem.Visible = false;
                _mountainStripMenuItem.Visible = false;
                _removeTerrainMenuItem.Visible = false;
            }
        }

        #region event handlers that forward the event to any possible listeners

        private void plotMenuStrip_Click(object sender, EventArgs e)
        {
            if (PlotEditEvent != null)
            {
                CustomPlotMapMenuEventArgs evtArg = new CustomPlotMapMenuEventArgs();

                if (sender == _oceanStripMenuItem)
                {
                    evtArg.SourceMenuValue = TerrainType.Enumeration.Ocean;
                }
                else if (sender == _coastStripMenuItem)
                {
                    evtArg.SourceMenuValue = TerrainType.Enumeration.Coast;
                }
                else if (sender == _flatStripMenuItem)
                {
                    evtArg.SourceMenuValue = TerrainType.Enumeration.Flat;
                }
                else if (sender == _hillsStripMenuItem)
                {
                    evtArg.SourceMenuValue = TerrainType.Enumeration.Hills;
                }
                else if (sender == _mountainStripMenuItem)
                {
                    evtArg.SourceMenuValue = TerrainType.Enumeration.Mountains;
                }
                else if (sender == _removeTerrainMenuItem)
                {
                    evtArg.SourceMenuValue = TerrainType.Enumeration.NotDefined;
                }

                PlotEditEvent(this, evtArg);
            }
        }

        private void editRegionMenuItem_Click(object sender, EventArgs e)
        {
            if (RegionEditEvent != null)
            {
                RegionEditEvent(this, e);
            }
        }

        private void editPlotColorMenuItem_Click(object sender, EventArgs e)
        {
            if (ColorEditEvent != null)
            {
                ColorEditEvent(this, e);
            }
        }

        #endregion event handlers that forward the event to any possible listeners

        public class CustomPlotMapMenuEventArgs : EventArgs
        {
            private TerrainType.Enumeration sourceMenuValue = TerrainType.Enumeration.NotDefined;

            public TerrainType.Enumeration SourceMenuValue
            {
                get
                {
                    return sourceMenuValue;
                }

                set
                {
                    sourceMenuValue = value;
                }
            }
        }
    }
}