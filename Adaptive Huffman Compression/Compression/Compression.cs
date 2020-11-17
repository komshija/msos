using System;
using System.Collections;
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
            HuffmanCodesGenerator generator = new HuffmanCodesGenerator();
            List<KeyValuePair<char,List<byte>>> symbolCodeTable = generator.GetCodes(); 

            return true;
        }
    }
}
