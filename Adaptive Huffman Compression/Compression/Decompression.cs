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
            using (BinaryBitReader bitReader = new BinaryBitReader(stream))
            {
                List<byte> readedBits = new List<byte>();
                byte bit;
                int progressRead = 0;
                int minimumLength = table.GetFirstCodelength();
                StringBuilder content = new StringBuilder();
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
                        content.Append(outputChar);
                        table.IncrementFreq(outputChar);
                        readedBits.Clear();
                        progressRead++;
                    }

                    if (progressBar != null)
                        progressBar.Value = Convert.ToInt32(progressRead / stream.Length) * 100;

                }
                using (StreamWriter sw = new StreamWriter(outStream))
                {
                    sw.Write(content);
                    if(progressBar != null)
                        progressBar.Value = 100;
                }
            }
            return true;
        }

    }
}
