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
            try
            {
                dialog_open.DefaultExt = "txt";
                dialog_open.Filter = "Text Files|*.txt";

                if (dialog_open.ShowDialog() == DialogResult.OK)
                {
                    var stream = dialog_open.OpenFile();

                    if (stream != null)
                    {
                        MessageBox.Show("Molimo vas izaberite gde ce kompresovan fajl biti smesten.", "Upozorenje", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Warning);

                        dialog_save.DefaultExt = "sim";
                        dialog_save.Filter = "SIM Files|*.sim";

                        if (dialog_save.ShowDialog() == DialogResult.OK)
                        {
                            var outStream = dialog_save.OpenFile();
                            if (outStream == null)
                                return;
                            bool success = new Compression.Compression().Execute(stream, progressBar, outStream);
                            if (success)
                            {
                                MessageBox.Show("Uspesno ste kompresovali fajl!", "Success", MessageBoxButtons.OK, icon: MessageBoxIcon.Information);
                            }
                        }
                    }
                    stream.Close();
                }

            }
            catch (Exception exc)
            {
                MessageBox.Show("Doslo je do greske!", "Greska! \n\n" + exc.ToString(), buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
            }

        }

        private void btn_decompress_Click(object sender, EventArgs e)
        {
            try
            {
                dialog_open.DefaultExt = "sim";
                dialog_open.Filter = "SIM Files|*.sim";

                if (dialog_open.ShowDialog() == DialogResult.OK)
                {
                    var stream = dialog_open.OpenFile();
                    if (stream != null)
                    {
                        MessageBox.Show("Molimo vas izaberite gde ce dekompresovan fajl biti smesten.", "Upozorenje", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Warning);

                        dialog_save.DefaultExt = "txt";
                        dialog_save.Filter = "Text Files|*.txt";

                        if (dialog_save.ShowDialog() == DialogResult.OK)
                        {
                            var outStream = dialog_save.OpenFile();
                            if (outStream == null)
                                return;
                            bool success = new Compression.Decompression().Execute(stream, progressBar, outStream);
                            if (success)
                                MessageBox.Show("Uspesno ste dekompresovali fajl!", "Success", MessageBoxButtons.OK, icon: MessageBoxIcon.Information);
                        }

                    }
                    stream.Close();
                }

            }
            catch (Exception exc)
            {
                MessageBox.Show("Doslo je do greske!", "Greska! \n\n" + exc.ToString(), buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
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
                "Milan Radosavljević\n", caption: "O projektu", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Information);
        }
    }
}
