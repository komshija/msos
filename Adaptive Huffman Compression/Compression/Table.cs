using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Compression
{
        #region Classes
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
        public class ListArrayComparer : IEqualityComparer<List<byte>>
        {
            public bool Equals(List<byte> x, List<byte> y)
            {
                if (x.SequenceEqual(y))
                    return true;
                return false;

            }

            public int GetHashCode(List<byte> obj)
            {
                    var result = 0;
                    foreach (byte b in obj)
                        result = (result * 31) ^ b;
                    return result;
            }
        }
        #endregion
        #region Properties
        Dictionary<char, KeyValues> symbols;
        Dictionary<List<byte>, char> codes;
        #endregion
        #region Constructors
        public Table()
        {
            InitializeTable();
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
            codes = new Dictionary<List<byte>, char>(new ListArrayComparer());

            foreach (var item in symbolCodeTable)
            {
                Add(item.Key, item.Value);
            }
        }
        /// <summary>
        /// Menja mesta odgovarajucih elemenata
        /// </summary>
        public void Swap(char symbol1)
        {
            for(int i=0;i<codes.Count;i++)
            {
                char symbol2 = codes.ElementAt(i).Value;
                if (symbol1 == symbol2)
                    break;
                if (symbols[symbol1].Count > symbols[symbol2].Count)
                {
                    SwapTwoElements(symbol1, symbol2);
                    break;
                }

            }
        }
        /// <summary>
        /// Menja mesta dva prosledjena simbola
        /// </summary>
        private void SwapTwoElements(char sym1,char sym2)
        {
            List<byte> tmpCode = symbols[sym1].Code;

            symbols[sym1].Code = symbols[sym2].Code;
            symbols[sym2].Code = tmpCode;

            codes[symbols[sym1].Code] = sym1;
            codes[symbols[sym2].Code] = sym2;
        }

        /// <summary>
        /// Trazenje simbola na osnovu koda ukoliko postoji
        /// </summary>
        public String SearchByCode(List<byte> code)
        {
            String result = null;
            if (codes.ContainsKey(code))
                result = Char.ToString(codes[code]);
            return result;

        }
        /// <summary>
        /// Trazenje simbola na osnovu koda
        /// </summary>
        public List<byte> SearchBySymbol(char symbol)
        {
            return symbols[symbol].Code;
        }
        /// <summary>
        /// Inkrementira frekvenciju slova i radi swap
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
        #endregion
    }
}
