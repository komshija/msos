using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Compression
{
    public class Compression : IHuffman
    {
        public bool Execute(Stream stream, ProgressBar progressBar = null, string fileName = null, string path = null)
        {
            return true;
        }
    }
}
