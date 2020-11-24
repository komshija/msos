using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Compression
{
    public class Table
    {
        #region Properties
        List<KeyValuePair<char, int>> symbolFreqTable;
        List<List<byte>> codeList;
        Dictionary<int, int> codeLengthIndexes;
        #endregion
        #region Constructors
        public Table()
        {
            InitializeTable();
            InitializeCodeLengthIndexes();
        }
        #endregion
        #region Methods
        /// <summary>
        /// Dodaje element u tabelu
        /// </summary>
        private void Add(char symbol, List<byte> code)
        {
            symbolFreqTable.Add(new KeyValuePair<char, int>(symbol, 0));
            codeList.Add(code);
        }
        /// <summary>
        /// Inicijalizuje tabelu sa pocetnim vrednostima
        /// </summary>
        private void InitializeTable()
        {
            HuffmanCodesGenerator generator = new HuffmanCodesGenerator();
            List<KeyValuePair<char, List<byte>>> symbolCodeTable = generator.GetCodes();
            symbolFreqTable = new List<KeyValuePair<char, int>>();
            codeList = new List<List<byte>>();

            foreach (var item in symbolCodeTable)
            {
                Add(item.Key, item.Value);
            }
        }
        /// <summary>
        /// Menja mesta elementa sa zadatim indeksom i prvim elementom koji ima manju frekvenciju od njega
        /// </summary>
        public void Swap(int index)
        {
            //symbolFreqTable.Sort((x, y) => y.Value.CompareTo(x.Value));

            int ind = symbolFreqTable.FindIndex(x => (symbolFreqTable[index].Value > x.Value || symbolFreqTable[index].Key == x.Key));
            KeyValuePair<char,int> temp = symbolFreqTable[index];
            symbolFreqTable[index] = symbolFreqTable[ind];
            symbolFreqTable[ind] = temp;
        }


        //public bool CodeExists(List<byte> code)
        //{
        //    var row = codeList.Where(codeFromList => codeFromList.SequenceEqual(code)).FirstOrDefault();
        //    if (row == null)
        //        return false;
        //    return true;
        //}

        /// <summary>
        /// Trazenje indeksa simbola na osnovu koda ukoliko postoji
        /// </summary>
        public int SearchByCode(List<byte> code,int length)
        {
            int indexStart = codeLengthIndexes[length];
            int indexEnd;
            if (codeLengthIndexes.ContainsKey(length + 1))
                indexEnd = codeLengthIndexes[length + 1];
            else
                indexEnd = symbolFreqTable.Count;
            List<byte> row = null ;

            for (int i = indexStart; i < indexEnd; i++)
                if(codeList[i].SequenceEqual(code))
                {
                    row = codeList[i];
                    break;
                }
            //Ovo za sad ovako stoji, treba da se napravi slucaj ako ne nadje index sta radi sledece
            //var row = codeList.Where(codeFromList => codeFromList.SequenceEqual(code)).FirstOrDefault();
            if (row == null)
                return -1;
            return  codeList.IndexOf(row);
        }
        /// <summary>
        /// Vraca se simbol po indeksu
        /// </summary>
        public char GetSymbolByIndex(int index)
        {
            return symbolFreqTable[index].Key;
        }
        /// <summary>
        /// Trazenje simbola na osnovu simbola
        /// </summary>
        public List<byte> SearchBySymbol(char symbol)
        {
            //Za sad ce ovo da radi, pa ce menjamo ako ima bolje resenje
            
            //int index; 
            //for (index = 0; index < symbolFreqTable.Count; index++)
            //    if (symbolFreqTable[index].Key.CompareTo(symbol) == 0)
            //        break;
            int index = symbolFreqTable.FindIndex(x => x.Key == symbol);
            var response = codeList[index];
            return response;
        }
        /// <summary>
        /// Inkrementira frekvenciju slova i sortira u opadajucem redosledu
        /// </summary>
        public void IncrementFreq(char symbol)
        {
            //int i;
            //for (i = 0; i < symbolFreqTable.Count; i++)
            //{
            //    if (symbolFreqTable[i].Key == symbol)
            //    {
            //        int value = symbolFreqTable[i].Value + 1;
            //        symbolFreqTable[i] = new KeyValuePair<char, int>(symbol, value);
            //        break;
            //    }
            //}

            int index = symbolFreqTable.FindIndex(x => x.Key == symbol);
            int value = symbolFreqTable[index].Value + 1;
            symbolFreqTable[index] = new KeyValuePair<char, int>(symbol, value);

            if (symbolFreqTable[index].Value == int.MaxValue)
                DivideAll();

            Swap(index);
        }
        /// <summary>
        /// Deli sva pojavljivanja brojeva sa dva
        /// </summary>
        public void DivideAll()
        {
            for (int i = 0; i < symbolFreqTable.Count; i++)
            {
                char key = symbolFreqTable[i].Key;
                int value = symbolFreqTable[i].Value;
                value /= 2;
                symbolFreqTable[i] = new KeyValuePair<char, int>(key, value);
            }
        }
        /// <summary>
        /// Vraca duzinu prvog koda u tabeli
        /// </summary>
        public int GetFirstCodelength()
        {
            return codeList[0].Count;
        }

        private int GetCodeIndexByLength(int length)
        {
            return codeList.FindIndex(x => x.Count == length);
        }
        /// <summary>
        /// Inicijalizuje tabelu sa indeksima prvih kodova za svaku duzinu kdoa
        /// </summary>
        private void InitializeCodeLengthIndexes()
        {
            codeLengthIndexes = new Dictionary<int, int>();
            int length = GetFirstCodelength();
            int index = 0;
            codeLengthIndexes.Add(length, index);
            while(true)
            {
                index = GetCodeIndexByLength(++length);
                if (index < 0)
                    break;
                codeLengthIndexes.Add(length, index);
            }
        }
        #endregion
    }
}
