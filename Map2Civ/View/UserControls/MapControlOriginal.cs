﻿using System;
using System.Collections.Generic;

using System.Text;

using Map2CivilizationCtrl.Listener;

using Map2CivilizationCtrl;
using Map2CivilizationView.UserControls;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using Map2CivilizationCtrl.Enumerations;
using Map2CivilizationCtrl.DataStructure;

namespace Map2CivilizationView.UserControls
{
    [TypeDescriptionProvider(typeof(AbstractControlDescriptionProvider<MapControlBase, UserControl>))]
    public class MapControlOriginal : MapControlBase, IUiListenerOriginalMap
    {
        


        public MapControlOriginal(bool allowScroll)
        {
            RegisteredListenersCtrl.OriginalMapListeners.RegisterObserver(this);
            BackgroundImage = Map2Civilization.Properties.Resources.WorldMapLarge_Image;
            BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;

            AllowScroll(allowScroll);

            HandleDestroyed += MapControlBase_Closing;
        }


        #region IUIListener_Original map interface implementation

        public void ReloadMap(Bitmap bmp)
        {
            if (bmp == null)
                throw new ArgumentNullException(nameof(bmp));

            //Remove the decorative backgroud image
            base.BackgroundImage = null;
            PictureBox.BackgroundImage = bmp;
            

            if (!RegisteredListenersCtrl.PlotLocationListeners.Contains(this))
            {
                PictureBox.Size = bmp.Size;
                PictureBox.Controls.Add(MarkerCtrl);
                MarkerCtrl.RepositionSelectedPlotPanel(new PlotId(0,0));
                MarkerCtrl.BringToFront();
                RegisteredListenersCtrl.PlotLocationListeners.RegisterObserver(this);
            }



            PictureBox.Refresh();
            PictureBox.Update();
        }


        #endregion


        #region Event handlers

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        protected new void MapControlBase_Closing(object sender, EventArgs e)
        {
            //base.MapControlBase_Closing(sender, e);
            RegisteredListenersCtrl.OriginalMapListeners.DeregisterObserver(this);
            
        }

        #endregion

        
    }
}