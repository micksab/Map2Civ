using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Map2CivilizationCtrl;
using Map2CivilizationCtrl.DataStructure;
using Map2CivilizationCtrl.Enumerations;
using Map2CivilizationCtrl.Listener;

namespace Map2CivilizationView.UserControls
{
    [TypeDescriptionProvider(typeof(AbstractControlDescriptionProvider<MapControlBase, UserControl>))]
    class MapControlProcessed : MapControlBase, IUiListenerProcessedMap
    {

        readonly ProcessedMapControlMode.Enumeration _currentMode = ProcessedMapControlMode.Enumeration.Unspecified;
        readonly ProcessedMapMenu _menu = new ProcessedMapMenu(ProcessedMapControlMode.Enumeration.Unspecified);

        

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
            base.BackgroundImage = null;
            BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            PictureBox.BackgroundImage = bitmap;


            if (!RegisteredListenersCtrl.PlotLocationListeners.Contains(this))
            {
                PictureBox.Size = bitmap.Size;
                PictureBox.Controls.Add(MarkerCtrl);
                MarkerCtrl.RepositionSelectedPlotPanel(new PlotId(0, 0));
                MarkerCtrl.BringToFront();
                RegisteredListenersCtrl.PlotLocationListeners.RegisterObserver(this);

                _menu.setMode(_currentMode);
            }
        }



        public void ShowSelectedColorsPlots(List<PlotId> plotCoordinatePairs)
        {
            PictureBox.Image = BitmapOperationsCtrl.CreateHighlightedColorsProcessedBitmap(plotCoordinatePairs);
        }


        #endregion




        #region Event handlers

         void MapControl_KeyDown(object sender, KeyEventArgs e)
        {

            TerrainType.Enumeration combDescr = TerrainType.Enumeration.NotDefined;
            
            if(_currentMode == ProcessedMapControlMode.Enumeration.ColorEditor)
            {
                if (e.KeyData == Map2Civilization.Properties.Settings.Default.KeyShrortcuts_EditRegion )
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
                    combDescr = TerrainType.Enumeration.Ocean;
                    PlotCollectionCtrl.UpdatePlotCombinedPlotDescriptors(CurrentPlotId, combDescr, true);

                }
                else if (e.KeyData == Map2Civilization.Properties.Settings.Default.KeyShrortcuts_AssignCoast)
                {
                    combDescr = TerrainType.Enumeration.Coast;
                    PlotCollectionCtrl.UpdatePlotCombinedPlotDescriptors(CurrentPlotId, combDescr, true);

                }
                else if (e.KeyData == Map2Civilization.Properties.Settings.Default.KeyShrortcuts_AssignFlat)
                {
                    combDescr = TerrainType.Enumeration.Flat;
                    PlotCollectionCtrl.UpdatePlotCombinedPlotDescriptors(CurrentPlotId, combDescr, true);

                }
                else if (e.KeyData == Map2Civilization.Properties.Settings.Default.KeyShrortcuts_AssignHill)
                {
                    combDescr = TerrainType.Enumeration.Hills;
                    PlotCollectionCtrl.UpdatePlotCombinedPlotDescriptors(CurrentPlotId, combDescr, true);

                }
                else if (e.KeyData == Map2Civilization.Properties.Settings.Default.KeyShrortcuts_AssignMountain)
                {
                    combDescr = TerrainType.Enumeration.Mountains;
                    PlotCollectionCtrl.UpdatePlotCombinedPlotDescriptors(CurrentPlotId, combDescr, true);
                }

            }

            
            
            
        }

         void Menu_RegionEditEvent(object sender, EventArgs e)
        {
            
            using (RegionEditForm editForm = new RegionEditForm(CurrentPlotId))
            {
                editForm.ShowDialog();
            }
        }

         void Menu_ColorEditEvent(object sender, EventArgs e)
        {
            string dominantColorHex = PlotCollectionCtrl.getDominantColorHex(CurrentPlotId);
            RegisteredListenersCtrl.DetectedColorsGridSetSelectedColor(dominantColorHex);
        }

         void Menu_PlotEditEvent(object sender, ProcessedMapMenu.CustomPlotMapMenuEventArgs e)
        {

            if(e.SourceMenuValue== TerrainType.Enumeration.Ocean || e.SourceMenuValue == TerrainType.Enumeration.Coast ||
                e.SourceMenuValue == TerrainType.Enumeration.Flat || e.SourceMenuValue == TerrainType.Enumeration.Hills ||
                e.SourceMenuValue == TerrainType.Enumeration.Mountains)
            {
                PlotCollectionCtrl.UpdatePlotCombinedPlotDescriptors(CurrentPlotId, e.SourceMenuValue, true);

            }

            if (e.SourceMenuValue == TerrainType.Enumeration.NotDefined)
            {
                PlotCollectionCtrl.UpdatePlotCombinedPlotDescriptors(CurrentPlotId, e.SourceMenuValue, false);

            }

        }



        protected new void MapControlBase_Closing(object sender, EventArgs e)
        {
            _menu.Dispose();
            RegisteredListenersCtrl.ProcessedMapListeners.DeregisterObserver(this);

        }

        #endregion


       

    }
}
