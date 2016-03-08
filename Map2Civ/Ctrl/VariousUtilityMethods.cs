using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Map2CivilizationCtrl
{
    public static class VariousUtilityMethods
    {

        public static String ExtractDisplayableModelFilePath(String currentFile)
        {
            String toReturn = String.Empty;

            if (!String.IsNullOrEmpty(currentFile))
            {
                //Get the filename
                String filename = System.IO.Path.GetFileName(currentFile);
                //Get the directory where the file resides at...
                String directory = System.IO.Path.GetDirectoryName(currentFile);
                //.. and keep just the name of the folder that the file resides at..
                String[] directories = directory.Split(new Char[] { '\\' });


                toReturn = String.Concat("...", directories.Last<String>(), "\\", filename);
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

    }
}
