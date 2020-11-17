using Priority_Queue;
using System;
using System.Collections.Generic;
using System.Text;

namespace Compression
{
    class HuffmanCodesGenerator
    {
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

        Dictionary<char, List<bool>> dictionary;
        private HuffmanNode GetRoot()
        {
            Dictionary<char, int> freq = new Dictionary<char, int>();
            SimplePriorityQueue<HuffmanNode, int> priorQueue = new SimplePriorityQueue<HuffmanNode, int>();

            for(int i = 0; i < 255;i++)
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
        private void Traversal(HuffmanNode ptr, List<bool> code)
        {
            if (ptr.levi == null && ptr.desni == null)
            {
                //BitConverter.GetBytes(0);
                
                //Moze da se gleda dubina stabla, da se zna kolko validnih bitova ima trenutno u byte
                //Dodajes novi byte kad naidjes na popunjen byte
                //Napisati fju za dodavanja bita u byte
                
                //Sta ako je kod manji od byte?
                //Sta ako je kod veci od byte?
                //Mozda da se koristi Pair<> len + code

                //Kako pisati samo bit 

                dictionary.Add(ptr.karakter.ToString().ToCharArray()[0], 
                    code);
            }
            else
            {
                if (ptr.levi != null)
                {
                    List<bool> left = new List<bool>(code);
                    left.Add(false);
                    Traversal(ptr.levi, left);
                }
                if (ptr.desni != null)
                {
                    List<bool> right = new List<bool>(code);
                    right.Add(true);
                    Traversal(ptr.desni, right);
                }
            }
        }
        public List<int> GetCodes()
        {


            return null;
        }

       /*byte AddBitToByte(byte B,bool b)
        {
           
            return (B << 4) | Convert.ToByte(b);
        }*/
    }
}
