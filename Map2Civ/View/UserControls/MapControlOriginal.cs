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


using Map2CivilizationCtrl;
using Map2CivilizationCtrl.DataStructure;
using Map2CivilizationCtrl.Listener;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

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
                MarkerCtrl.RepositionSelectedPlotPanel(new PlotId(0, 0));
                MarkerCtrl.BringToFront();
                RegisteredListenersCtrl.PlotLocationListeners.RegisterObserver(this);
            }

            PictureBox.Refresh();
            PictureBox.Update();
        }

        #endregion IUIListener_Original map interface implementation

        #region Event handlers

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        protected new void MapControlBase_Closing(object sender, EventArgs e)
        {
            //base.MapControlBase_Closing(sender, e);
            RegisteredListenersCtrl.OriginalMapListeners.DeregisterObserver(this);
        }

        #endregion Event handlers
    }
}