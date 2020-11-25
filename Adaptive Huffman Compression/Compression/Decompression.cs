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
        public bool Execute(Stream stream, ProgressBar progressBar = null, Stream outStream = null)
        {
            table = new Table();
           // string fileNamee = @"./decompressed.txt";
            using (BinaryBitReader bitReader = new BinaryBitReader(stream))
            {
                using (StreamWriter sw = new StreamWriter(outStream))
                {
                    List<byte> readedBits = new List<byte>();
                    byte bit;
                    int progressRead = 0;
                    int minimumLength = table.GetFirstCodelength();
                    while (bitReader.BytesRead != stream.Length)
                    {
                        bit = bitReader.ReadBit();
                        readedBits.Add(bit);
                        if (readedBits.Count >= minimumLength)
                        {
                            String result = table.SearchByCode(readedBits);
                            if (result == null)
                                continue;
                            char outputChar = char.Parse(result);
                            sw.Write(outputChar);
                            table.IncrementFreq(outputChar);
                            readedBits.Clear();
                            progressRead++;
                        }

                        if (progressBar != null)
                            progressBar.Value = Convert.ToInt32(progressRead / stream.Length) * 100;

                        //if (progressRead == int.MaxValue)
                        //    table.DivideAll();
                    }

                    if(progressBar != null)
                        progressBar.Value = 100;
                }
            }
            return true;
        }

    }
}
