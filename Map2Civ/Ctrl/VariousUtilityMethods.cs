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


using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Forms;

namespace Map2CivilizationCtrl
{
    public static class VariousUtilityMethods
    {
        public static string ExtractDisplayableModelFilePath(string currentFile)
        {
            string toReturn = string.Empty;

            if (!string.IsNullOrEmpty(currentFile))
            {
                //Get the filename
                string filename = System.IO.Path.GetFileName(currentFile);
                //Get the directory where the file resides at...
                string directory = System.IO.Path.GetDirectoryName(currentFile);
                //.. and keep just the name of the folder that the file resides at..
                string[] directories = directory.Split(new Char[] { '\\' });

                toReturn = string.Concat("...", directories.Last<string>(), "\\", filename);
            }

            return toReturn;
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1002:DoNotExposeGenericLists")]
        public static Collection<T> ListToCollection<T>(List<T> list)
        {
            Collection<T> toReturn = new Collection<T>();
            if (list != null)
            {
                foreach (T t in list)
                {
                    toReturn.Add(t);
                }
            }

            return toReturn;
        }

        public static string FormatKeyStringRepresentation(Keys keyValue)
        {
            string toReturn = String.Empty;

            if (keyValue.HasFlag(Keys.Control))
                toReturn = "Ctrl+";

            if (keyValue.HasFlag(Keys.Alt))
                toReturn = toReturn + "Alt+";

            if (keyValue.HasFlag(Keys.Shift))
                toReturn = toReturn + "Shift+";

            toReturn = toReturn + (keyValue & ~Keys.Control & ~Keys.Shift & ~Keys.Alt).ToString();

            return toReturn;
        }
    }
}