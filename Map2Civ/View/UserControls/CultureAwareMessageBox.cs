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


using System.Windows.Forms;

namespace Map2CivilizationView.UserControls
{
    public static class CultureAwareMessageBox
    {
        public static DialogResult Show(string text, string caption, MessageBoxButtons buttons,
            MessageBoxIcon icon, MessageBoxDefaultButton defaultButton)
        {

            MessageBoxOptions options = 0;


            if (System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.IsRightToLeft)
            {


                options |= MessageBoxOptions.RtlReading |
                MessageBoxOptions.RightAlign;

            }
           

            return MessageBox.Show(text, caption, buttons, icon, defaultButton, options);

        }
    }
}