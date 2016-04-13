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