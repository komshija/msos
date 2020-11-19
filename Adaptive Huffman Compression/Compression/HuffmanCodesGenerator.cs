using Priority_Queue;
using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.IO;
using System.Linq;
using BinaryBitLib;


namespace Compression
{
    class HuffmanCodesGenerator
    {
        /// <summary>
        /// Klasa koja predstavlja Node u stablu
        /// </summary>
        class HuffmanNode
        {
            public int freq;
            public char karakter;
            public HuffmanNode levi;
            public HuffmanNode desni;

            public HuffmanNode(char karakter, int freq)
            {
                this.freq = freq;
                this.karakter = karakter;
                levi = null;
                desni = null;
            }
            public HuffmanNode(HuffmanNode hn1, HuffmanNode hn2)
            {
                karakter = '0';
                levi = hn1;
                desni = hn2;
                freq = hn1.freq + hn2.freq;
            }
        }
        #region Properties
        Dictionary<char, List<byte>> dictionary;
        HuffmanNode root;
        #endregion
        #region Constructors
        /// <summary>
        /// Konstruktor inicijalizuje celu tablicu od 256 karaktera
        /// </summary>
        public HuffmanCodesGenerator()
        {
            dictionary = new Dictionary<char, List<byte>>();
            root = GetRoot();
            Traversal(root, new List<byte>());
        }
        #endregion
        #region Methods
        /// <summary>
        /// Metoda koja generise kodove na osnovu verovatnoca
        /// </summary>
        /// <returns>Vraca koren stabla koj</returns>
        private HuffmanNode GetRoot()
        {
            Dictionary<char, int> freq = new Dictionary<char, int>();
            SimplePriorityQueue<HuffmanNode, int> priorQueue = new SimplePriorityQueue<HuffmanNode, int>();

            for(int i = 0; i < 256;i++)
            {
                freq.Add((char)i, i);
            }

            foreach (var node in freq)
                priorQueue.Enqueue(new HuffmanNode(node.Key, node.Value), node.Value);
            freq.Clear();
            freq = null;

            HuffmanNode t1, t2;
            while (priorQueue.Count != 1)
            {
                t1 = priorQueue.Dequeue();
                t2 = priorQueue.Dequeue();
                priorQueue.Enqueue(new HuffmanNode(t1, t2), t1.freq + t2.freq);
            }

            return priorQueue.Dequeue();
        }
        /// <summary>
        /// Metoda obilazi celo stablo, gde mu se prosledjuje root node i generise kodove
        /// na osnovu pojavljivanja.
        /// </summary>
        /// <param name="ptr">Proslediti root node</param>
        /// <param name="code">Proslediti praznu listu byte-ova</param>
        private void Traversal(HuffmanNode ptr, List<byte> code)
        {
            if (ptr.levi == null && ptr.desni == null)
            {
                dictionary.Add(ptr.karakter.ToString().ToCharArray()[0], code);
            }
            else
            {
                if (ptr.levi != null)
                {
                    List<byte> left = new List<byte>(code);
                    left.Add(0);
                    Traversal(ptr.levi, left);
                }
                if (ptr.desni != null)
                {
                    List<byte> right = new List<byte>(code);
                    right.Add(1);
                    Traversal(ptr.desni, right);
                }
            }
        }
        /// <summary>
        /// Sortira po duzini kodova
        /// </summary>
        /// <returns>Funkcija vraca listu sa KeyValuePair strukturom gde je Key char a Value lista bajtova.</returns>
        public List<KeyValuePair<char,List<byte>>> GetCodes()
        {
            return dictionary.OrderBy(row => row.Value.Count).ToList();
        }
        /// <summary>
        /// Stampa tablicu u formatu [Simbol Kod] u fajl text.txt 
        /// </summary>
        public void PrintCodesAsCharactersToFile()
        {
            using (FileStream fs = new FileStream("codes.txt", FileMode.OpenOrCreate))
            {
                using (BinaryBitWriter bbw = new BinaryBitWriter(fs))
                {
                    foreach (var row in dictionary.OrderBy(row => row.Value.Count))
                    {
                        bbw.WriteChar(row.Key);
                        bbw.WriteChar(' ');
                        foreach (var bit in row.Value)
                        {
                            if (bit == 0)
                            {
                                bbw.WriteChar('0');
                            }
                            else
                            {
                                bbw.WriteChar('1');
                            }
                        }
                        bbw.WriteChar('\n');
                        bbw.Flush();
                    }
                }
            }
        }
        /// <summary>
        /// Metoda cisti celu klasu
        /// </summary>
        public void CleanIt()
        {
            dictionary.Clear();
            RemovePointers(this.root);
        }
        /// <summary>
        /// Sklanja pokazivace sa svakog Huffman Noda
        /// </summary>
        /// <param name="node"></param>
        private void RemovePointers(HuffmanNode node)
        {
            if (node == null)
                return;
            if(node.levi == null && node.desni == null)
                return;
            else
            {
                if(node.levi != null)
                    RemovePointers(node.levi);
                if(node.desni != null)
                    RemovePointers(node.desni);
                node.levi = null;
                node.desni = null;
            }
        }
        #endregion
    }
}
