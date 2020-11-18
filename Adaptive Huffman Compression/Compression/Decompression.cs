using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Forms;
using BinaryBitLib;

namespace Compression
{
    public class Decompression : IHuffman
    {
        private Table table;
        public bool Execute(Stream stream, ProgressBar progressBar = null, string fileName = null, string path = null)
        {
            table = new Table();
            string fileNamee = @"./decompressed.txt";
            using(BinaryBitReader bitReader = new BinaryBitReader(stream))
            {
                using(StreamWriter sw = new StreamWriter(new FileStream(fileNamee, FileMode.Create)))
                {
                    List<byte> readedBits = new List<byte>();
                    byte bit;
                    while(bitReader.BytesRead != stream.Length+1)
                    {
                        bit = bitReader.ReadBit();
                        readedBits.Add(bit);
                        if (table.CodeExists(readedBits))
                        {
                            char outputChar = table.SearchByCode(readedBits);
                            sw.Write(outputChar);
                            table.IncrementFreq(outputChar);
                            readedBits.Clear();
                        }
                        if (progressBar != null)
                            progressBar.Value = Convert.ToInt32(bitReader.BytesRead / stream.Length) * 100;
                    }
                    progressBar.Value = 100;
                }
            }
            


            return true;
        }
    }
}
