using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;

namespace Map2Civilization.Ctrl
{
    static class GZipCompression
    {

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2202:Do not dispose objects multiple times")]
        public static void CompressModelFile(MemoryStream memoryStream, string destinationFile)
        {
            FileInfo destinationFileInfo = new FileInfo(destinationFile);
            memoryStream.Position = 0;

            using (FileStream compressedFileStream = File.Create(destinationFileInfo.FullName))
            using (GZipStream compressionStream = new GZipStream(compressedFileStream, CompressionMode.Compress))
            {
                memoryStream.CopyTo(compressionStream);
            }

        }


        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2202:Do not dispose objects multiple times")]
        public static string DecompressModelFile(String sourceFile)
        {
            string toReturn = string.Empty;

            using(MemoryStream outMemoryStream = new MemoryStream())
            using (FileStream compressedFileStream = new FileStream(sourceFile, FileMode.Open))
            using (GZipStream decompressionStream = new GZipStream(compressedFileStream, CompressionMode.Decompress))
            {
                decompressionStream.CopyTo(outMemoryStream);
                outMemoryStream.Position = 0;
                StreamReader sr = new StreamReader(outMemoryStream);
                toReturn = sr.ReadToEnd();
            }

            


            return toReturn;

        }

    }
}
