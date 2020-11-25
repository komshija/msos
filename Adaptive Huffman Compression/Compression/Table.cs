using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Compression
{
    public class Table
    {
        class KeyValues
        {
            public List<byte> Code { get; set; }
            public int Count { get; set; }

            public KeyValues(List<byte> code,int count)
            {
                Code = code;
                Count = count;
            }
        }
        #region Properties
        Dictionary<char, KeyValues> symbols;
        Dictionary<List<byte>, char> codes;
        #endregion
        #region Constructors
        public Table()
        {
            InitializeTable();
            //InitializeCodeLengthIndexes();
        }
        #endregion
        #region Methods
        /// <summary>
        /// Dodaje element u tabelu
        /// </summary>
        private void Add(char symbol, List<byte> code)
        {
            symbols.Add(symbol, new KeyValues(code, 0));
            codes.Add(code, symbol);
        }
        /// <summary>
        /// Inicijalizuje tabelu sa pocetnim vrednostima
        /// </summary>
        private void InitializeTable()
        {
            HuffmanCodesGenerator generator = new HuffmanCodesGenerator();
            List<KeyValuePair<char, List<byte>>> symbolCodeTable = generator.GetCodes();
            symbols = new Dictionary<char, KeyValues>();
            codes = new Dictionary<List<byte>, char>();

            foreach (var item in symbolCodeTable)
            {
                Add(item.Key, item.Value);
            }
        }
        /// <summary>
        /// Menja mesta elementa sa zadatim indeksom i prvim elementom koji ima manju frekvenciju od njega
        /// </summary>
        public void Swap(char symbol1)
        {
            for(int i=0;i<codes.Count;i++)
            {
                char symbol2 = codes.ElementAt(i).Value;
                if (symbols[symbol1].Count > symbols[symbol2].Count)
                {
                    SwapTwoElements(symbol1, symbol2);
                    break;
                }

            }
        }

        private void SwapTwoElements(char sym1,char sym2)
        {
            List<byte> tmpCode = symbols[sym1].Code;

            symbols[sym1].Code = symbols[sym2].Code;
            symbols[sym2].Code = tmpCode;

            codes[symbols[sym1].Code] = sym1;
            codes[symbols[sym2].Code] = sym2;
        }

        /// <summary>
        /// Trazenje indeksa simbola na osnovu koda ukoliko postoji
        /// </summary>
        public String SearchByCode(List<byte> code)
        {
            //int indexStart = codeLengthIndexes[length];
            //int indexEnd;
            //if (codeLengthIndexes.ContainsKey(length + 1))
            //    indexEnd = codeLengthIndexes[length + 1];
            //else
            //    indexEnd = symbolFreqTable.Count;
            //List<byte> row = null ;

            //for (int i = indexStart; i < indexEnd; i++)
            //    if(codeList[i].SequenceEqual(code))
            //    {
            //        row = codeList[i];
            //        break;
            //    }
            ////Ovo za sad ovako stoji, treba da se napravi slucaj ako ne nadje index sta radi sledece
            ////var row = codeList.Where(codeFromList => codeFromList.SequenceEqual(code)).FirstOrDefault();
            //if (row == null)
            //    return -1;
            //return  codeList.IndexOf(row);
            String result = null;
            if (codes.ContainsKey(code))
                result = Char.ToString(codes[code]);
            return result;

        }
        /// <summary>
        /// Vraca se simbol po indeksu
        /// </summary>
        //public char GetSymbolByIndex(int index)
        //{
        //    return symbolFreqTable[index].Key;
        //}
        /// <summary>
        /// Trazenje simbola na osnovu simbola
        /// </summary>
        public List<byte> SearchBySymbol(char symbol)
        {
            return symbols[symbol].Code;
        }
        /// <summary>
        /// Inkrementira frekvenciju slova i sortira u opadajucem redosledu
        /// </summary>
        public void IncrementFreq(char symbol)
        {
            symbols[symbol].Count++;
            if (symbols[symbol].Count == int.MaxValue)
                DivideAll();

            Swap(symbol);
        }
        /// <summary>
        /// Deli sva pojavljivanja brojeva sa dva
        /// </summary>
        public void DivideAll()
        {
            foreach (var symbol in symbols)
            {
                symbol.Value.Count /= 2;
            }
        }
        /// <summary>
        /// Vraca duzinu prvog koda u tabeli
        /// </summary>
        public int GetFirstCodelength()
        {
            return codes.ElementAt(0).Key.Count;
        }

        //private int GetCodeIndexByLength(int length)
        //{
        //    return codeList.FindIndex(x => x.Count == length);
        //}
        /// <summary>
        /// Inicijalizuje tabelu sa indeksima prvih kodova za svaku duzinu kdoa
        /// </summary>
        //private void InitializeCodeLengthIndexes()
        //{
        //    codeLengthIndexes = new Dictionary<int, int>();
        //    int length = GetFirstCodelength();
        //    int index = 0;
        //    codeLengthIndexes.Add(length, index);
        //    while(true)
        //    {
        //        index = GetCodeIndexByLength(++length);
        //        if (index < 0)
        //            break;
        //        codeLengthIndexes.Add(length, index);
        //    }
        //}
        #endregion
    }
}
