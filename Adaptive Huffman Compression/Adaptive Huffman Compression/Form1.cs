using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Compression;

namespace Adaptive_Huffman_Compression
{
    public partial class form_Glavna : Form
    {
        public form_Glavna()
        {
            InitializeComponent();
        }

        private void btn_compress_Click(object sender, EventArgs e)
        {

            if (dialog_open.ShowDialog() == DialogResult.OK)
            {
                var stream = dialog_open.OpenFile();
                if (stream != null)
                {
                    bool success = new Compression.Compression().Execute(stream,progressBar);
                    if(success)
                    {
                        MessageBox.Show("Uspesno ste kompresovali fajl!","Success",MessageBoxButtons.OK, icon: MessageBoxIcon.Information);
                    }
                }
                stream.Close();
            }

        }

        private void btn_decompress_Click(object sender, EventArgs e)
        {
            if (dialog_open.ShowDialog() == DialogResult.OK)
            {
                var stream = dialog_open.OpenFile();
                if (stream != null)
                {
                    bool success = new Compression.Decompression().Execute(stream,progressBar);
                    if(success)
                        MessageBox.Show("Uspesno ste dekompresovali fajl!", "Success", MessageBoxButtons.OK, icon: MessageBoxIcon.Information);
                }
                stream.Close();
            }

        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(text: 
                "Predmet: Metodi i sistemi za obradu signala\n" +
                "Projekat: Adaptivna Huffman Kompresija : A varijanta\n\n" +
                "Predmetni nastavnik: Miloš Radmanović\n" +
                "Asistent: Nenad Petrović\n\n" +
                "Autori projekta:\n" +
                "Stefan Sokolović\n" +
                "Milan Radosavljević\n", caption: "O projektu", buttons: MessageBoxButtons.OK,icon:MessageBoxIcon.Information);
        }
    }
}
