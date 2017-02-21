using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityManagment.Common.Utilities
{
    public class WriteFile
    {
        private string path;

        private StreamWriter FichFile;

        public WriteFile(string userPath, Encoding encoding)
        {
            if (!File.Exists(userPath))
            {
                StreamWriter newFile = File.CreateText(userPath);
                newFile.Close();
            }

            this.path = userPath;
            FichFile = new StreamWriter(this.path, true, encoding);
        }

        public bool write(string line)
        {
            FichFile.WriteLine(line);
            return true;
        }

        public bool writeNotAllowEmpty(string line)
        {
            if (String.IsNullOrEmpty(line) == false)
            {
                if (String.IsNullOrEmpty(line.Trim()) == false)
                {
                    FichFile.WriteLine(line);
                    return true;
                }
            }
            return false;
        }

        public bool close()
        {
            FichFile.Close();
            return true;
        }
    }
}
