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


        #region Properties
        Table table;
        int counter;
        #endregion

        public bool Execute(Stream stream, ProgressBar progressBar = null, Stream outStream = null)
        {
            table = new Table();
            using (StreamReader reader = new StreamReader(stream))
            {
                string content = reader.ReadToEnd();
                using (BinaryBitWriter binWriter = new BinaryBitWriter(outStream))
                {
                    counter = 0;
                    int progressRead = 0;
                    foreach (var Char in content)
                    {
                        WriteCode(Char, binWriter);
                        progressRead++;
                        if (progressBar != null)
                            progressBar.Value = Convert.ToInt32(Convert.ToDouble(progressRead) / Convert.ToDouble(stream.Length) * 100);
                    }
                    if (counter != 0)
                    {
                        for (int i = 0; i < 8 - counter; i++)
                            binWriter.WriteBit(1);
                    }
                    binWriter.WriteChar('\0');
                    
                }
            }
            if (progressBar != null)
                progressBar.Value = 100;
            return true;
        }

        #region Methods
        private void WriteCode(char symbol, BinaryBitWriter writer)
        {
            byte[] outputBits = table.SearchBySymbol(symbol).ToArray();
            counter = (counter + outputBits.Length) % 8;
            writer.WriteBits(outputBits);
            table.IncrementFreq(symbol);
        }
        #endregion
    }
}
