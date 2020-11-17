using BinaryBitLib;
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
            table = new Table();
            string fileNamee = @"./test.bin";
            using (StreamReader reader = new StreamReader(stream))
            using (BinaryBitWriter binWriter = new BinaryBitWriter(new FileStream(fileNamee, FileMode.OpenOrCreate)))
            {
                
                string line;
                int readed = 0;
                while ((line = reader.ReadLine()) != null)
                {
                    for (int i = 0; i < line.Length; i++)
                        WriteCode(line[i], binWriter);
                    readed += line.Length;
                    progressBar.Value = Convert.ToInt32(Convert.ToDouble(readed) / Convert.ToDouble(stream.Length) * 100);
                }
            }
            progressBar.Value = 100;
            return true;
        }

        #region Properties
        Table table;
        #endregion
        #region Methods
        private void WriteCode(char symbol, BinaryBitWriter writer)
        {
            byte[] outputBits = table.SearchBySymbol(symbol).ToArray();
            writer.WriteBits(outputBits);
            table.IncrementFreq(symbol);
        }
        #endregion
    }
}
