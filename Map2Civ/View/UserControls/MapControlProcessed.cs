using Map2CivilizationCtrl;
using Map2CivilizationCtrl.DataStructure;
using Map2CivilizationCtrl.Enumerations;
using Map2CivilizationCtrl.Listener;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Map2CivilizationView.UserControls
{
    [TypeDescriptionProvider(typeof(AbstractControlDescriptionProvider<MapControlBase, UserControl>))]
    internal class MapControlProcessed : MapControlBase, IUiListenerProcessedMap
    {
        private readonly ProcessedMapControlMode.Enumeration _currentMode = ProcessedMapControlMode.Enumeration.Unspecified;
        private readonly ProcessedMapMenu _menu = new ProcessedMapMenu(ProcessedMapControlMode.Enumeration.Unspecified);

        public MapControlProcessed(bool allowScroll, ProcessedMapControlMode.Enumeration mode)
        {
            _currentMode = mode;
            BackgroundImage = Map2Civilization.Properties.Resources.PenRulerLarge_Image;
            BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;

            //Add event handlers for the menu
            _menu.PlotEditEvent += Menu_PlotEditEvent;
            _menu.ColorEditEvent += Menu_ColorEditEvent;
            _menu.RegionEditEvent += Menu_RegionEditEvent;
            PictureBox.ContextMenuStrip = _menu;

            AllowScroll(allowScroll);

            RegisteredListenersCtrl.ProcessedMapListeners.RegisterObserver(this);

            HandleDestroyed += MapControlBase_Closing;
            KeyDown += MapControl_KeyDown;
        }

        #region IUIListener_ProcessedMap map interface implementation

        public void GetProcessedMap(Bitmap bitmap)
        {
            if (bitmap == null)
                throw new ArgumentNullException(nameof(bitmap));

            //Remove the decorative image
            if (base.BackgroundImage != bitmap)
            {
                base.BackgroundImage = null;
                BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                PictureBox.BackgroundImage = bitmap;
            }

            if (!RegisteredListenersCtrl.PlotLocationListeners.Contains(this))
            {
                PictureBox.Size = bitmap.Size;
                PictureBox.Controls.Add(MarkerCtrl);
                MarkerCtrl.RepositionSelectedPlotPanel(new PlotId(0, 0));
                MarkerCtrl.BringToFront();
                RegisteredListenersCtrl.PlotLocationListeners.RegisterObserver(this);

                _menu.setMode(_currentMode);
            }

            PictureBox.Update();
            PictureBox.Refresh();
        }

        public void ShowSelectedColorsPlots(List<PlotId> plotCoordinatePairs)
        {
            PictureBox.Image = BitmapOperationsCtrl.CreateHighlightedColorsProcessedBitmap(plotCoordinatePairs);
        }

        #endregion IUIListener_ProcessedMap map interface implementation

        #region Event handlers

        private void MapControl_KeyDown(object sender, KeyEventArgs e)
        {
            if (_currentMode == ProcessedMapControlMode.Enumeration.ColorEditor)
            {
                if (e.KeyData == Map2Civilization.Properties.Settings.Default.KeyShrortcuts_EditRegion)
                {
                    Menu_RegionEditEvent(this, new EventArgs());
                }
                else if (e.KeyData == Map2Civilization.Properties.Settings.Default.KeyShrortcuts_EditPlotData)
                {
                    Menu_ColorEditEvent(this, new EventArgs());
                }
            }
            else if (_currentMode == ProcessedMapControlMode.Enumeration.PlotEditor)
            {
                if (e.KeyData == Map2Civilization.Properties.Settings.Default.KeyShrortcuts_AssignOcean)
                {
                    PlotCollectionCtrl.UpdatePlotPlotTerrain(CurrentPlotId, TerrainType.Enumeration.Ocean, true);
                }
                else if (e.KeyData == Map2Civilization.Properties.Settings.Default.KeyShrortcuts_AssignCoast)
                {
                    PlotCollectionCtrl.UpdatePlotPlotTerrain(CurrentPlotId, TerrainType.Enumeration.Coast, true);
                }
                else if (e.KeyData == Map2Civilization.Properties.Settings.Default.KeyShrortcuts_AssignFlat)
                {
                    PlotCollectionCtrl.UpdatePlotPlotTerrain(CurrentPlotId, TerrainType.Enumeration.Flat, true);
                }
                else if (e.KeyData == Map2Civilization.Properties.Settings.Default.KeyShrortcuts_AssignHill)
                {
                    PlotCollectionCtrl.UpdatePlotPlotTerrain(CurrentPlotId, TerrainType.Enumeration.Hills, true);
                }
                else if (e.KeyData == Map2Civilization.Properties.Settings.Default.KeyShrortcuts_AssignMountain)
                {
                    PlotCollectionCtrl.UpdatePlotPlotTerrain(CurrentPlotId, TerrainType.Enumeration.Mountains, true);
                }
                else if (e.KeyData == Map2Civilization.Properties.Settings.Default.KeyShrortcuts_RepealAssignment)
                {
                    PlotCollectionCtrl.ResetManuallyLockedPlot(CurrentPlotId);
                }
            }
        }

        private void Menu_RegionEditEvent(object sender, EventArgs e)
        {
            using (RegionEditForm editForm = new RegionEditForm(CurrentPlotId))
            {
                editForm.ShowDialog();
            }
        }

        private void Menu_ColorEditEvent(object sender, EventArgs e)
        {
            string dominantColorHex = PlotCollectionCtrl.GetDominantColorHex(CurrentPlotId);
            RegisteredListenersCtrl.DetectedColorsGridSetSelectedColor(dominantColorHex);
        }

        private void Menu_PlotEditEvent(object sender, ProcessedMapMenu.CustomPlotMapMenuEventArgs e)
        {
            if (e.SourceMenuValue == TerrainType.Enumeration.Ocean || e.SourceMenuValue == TerrainType.Enumeration.Coast ||
                e.SourceMenuValue == TerrainType.Enumeration.Flat || e.SourceMenuValue == TerrainType.Enumeration.Hills ||
                e.SourceMenuValue == TerrainType.Enumeration.Mountains)
            {
                PlotCollectionCtrl.UpdatePlotPlotTerrain(CurrentPlotId, e.SourceMenuValue, true);
            }

            if (e.SourceMenuValue == TerrainType.Enumeration.NotDefined)
            {
                PlotCollectionCtrl.ResetManuallyLockedPlot(CurrentPlotId);
            }
        }

        protected new void MapControlBase_Closing(object sender, EventArgs e)
        {
            _menu.Dispose();
            RegisteredListenersCtrl.ProcessedMapListeners.DeregisterObserver(this);
        }

        #endregion Event handlers
    }
}