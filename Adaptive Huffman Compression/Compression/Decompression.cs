using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace Compression
{
    public class Decompression : IHuffman
    {
        public bool Execute(Stream stream, ProgressBar progressBar = null, string fileName = null, string path = null)
        {
            return true;
        }
    }
}
