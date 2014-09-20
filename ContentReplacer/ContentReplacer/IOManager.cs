using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ContentReplacer
{
    public class IOManager
    {
        public static string[] GetFilesFromDirectory(string klasor, string uzanti, bool recursive)
        {
            string[] files = Directory.GetFiles(
                klasor,
                "*." + uzanti,
                recursive == true ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly
            );

            return files;
        }

        public static string[] GelLinesFromFile(string filePath)
        {
            return File.ReadAllLines(filePath, Constants.AppEncoding);
        }
    }
}
