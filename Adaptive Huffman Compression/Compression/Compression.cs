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

        public bool Execute(Stream stream, ProgressBar progressBar = null, string fileName = null, string path = null)
        {
            table = new Table();

            string fileNamee = @"./test.bin";
            using (StreamReader reader = new StreamReader(stream))
            {
                using (BinaryBitWriter binWriter = new BinaryBitWriter(new FileStream(fileNamee, FileMode.Create)))
                {
                    char symbol;
                    counter = 0;
                    int readed = 0;
                    while (!reader.EndOfStream)
                    {
                        symbol = (char)reader.Read();
                        WriteCode(symbol, binWriter);

                        if (progressBar != null)
                            progressBar.Value = Convert.ToInt32(Convert.ToDouble(readed) / Convert.ToDouble(stream.Length) * 100);
                    }
                    if (counter != 0)
                    {
                        List<byte> dopuna = new List<byte>();
                        for (int i = 0; i < 8 - counter; i++)
                            dopuna.Add(1);
                        binWriter.WriteBits(dopuna.ToArray());
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
