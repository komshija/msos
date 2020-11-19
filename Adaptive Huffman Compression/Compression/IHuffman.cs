using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Compression
{
    interface IHuffman
    {
        bool Execute(Stream stream, ProgressBar progressBar = null, Stream outStream = null);
    }
}
