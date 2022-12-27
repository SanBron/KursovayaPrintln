using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace KursovayaPrintLn
{
    public enum SearchMode
    {
        AhoCorasick,
        RabinaKarpa,
        KMP,
        BM,
    }
    public delegate void AlgoritmSearch(string text, string search);
    public partial class Method : Form1, WorkMethod
    {
        const string AHO_CORASICK = "Ахо-Корасик";
        const string RABINA_KARPA = "Рабина-Карпа";
        const string KMP = "Кнута-Морриса-Пратта";
        const string BM = "Бойера-Мура";

        static List<int> idWordsInSourceText = new List<int>();
        static List<int> idFoundWords = new List<int>();
        static int textLen = 0;
        static int stringSearchLen = 0;

        public Model Work(
            SearchMode searchMode,
            HashSet<string> searchStrings,
            System.Windows.Forms.ListBox listBox)
        {
            DateTime start = DateTime.Now;
            string name = "";

            AlgoritmSearch algoritmSearch = null;
            List<string> tittles = new List<string>();
            List<int> results = new List<int>();

            foreach (string str in listBox.Items)
            {
                string text = File.ReadAllText(@"data\" + str + ".txt");
                textLen = text.Length;
                switch (searchMode)
                {
                    case SearchMode.AhoCorasick:
                        name = AHO_CORASICK;
                        SearchAhoCorasick(text, searchStrings.ToArray<String>());
                        AddIdWordInSourceText(text);
                        break;
                    default:
                        if (searchMode == SearchMode.BM)
                        {
                            name = BM;
                            AddIdWordInSourceTextWithoutSymb(text);
                            algoritmSearch = SearchBM;
                        }
                        else AddIdWordInSourceText(text);
                        if (searchMode == SearchMode.KMP)
                        {
                            name = KMP;
                            algoritmSearch = SearchKMP;
                        }
                        if (searchMode == SearchMode.RabinaKarpa)
                        {
                            name = RABINA_KARPA;
                            algoritmSearch = SearchRabinaKarpa;
                        }
                        foreach (string searchString in searchStrings)
                        {
                            algoritmSearch?.Invoke(text, searchString);
                        }
                        break;
                }

                int res = FoundDublicate();

                int result = 0;
                if (stringSearchLen != 0) result = res * 100 / stringSearchLen;
                if (result > 100) result = 100;
                results.Add(result);
                tittles.Add(str);
                ClearValue();
            }
            DateTime end = DateTime.Now;
            Model model = new Model(tittles.ToList(), results.ToList(), name, (end - start).ToString());
            algoritmSearch = null;
            return model;
        }

        void AddIdWordInSourceText(string text)
        {
            Boolean flag = true;
            for (int i = 0; i < text.Length; i++)
            {
                if ((Char.IsDigit(text[i]) || Char.IsLetter(text[i])) && flag)
                {
                    flag = false;
                    idWordsInSourceText.Add(i);
                    continue;
                }
                if (text[i] == ' ')
                {
                    flag = true;
                }
            }
        }

        void AddIdWordInSourceTextWithoutSymb(string text)
        {
            Boolean flag = true;
            for (int i = 0; i < text.Length; i++)
            {
                if ((Char.IsDigit(text[i]) || Char.IsLetter(text[i])) && flag
                    && (Char.IsDigit(text[i + 1]) || Char.IsLetter(text[i + 1])))
                {
                    flag = false;
                    idWordsInSourceText.Add(i);
                    continue;
                }
                if (text[i] == ' ')
                {
                    flag = true;
                }
            }
        }

        int FoundDublicate()
        {
            var idFoundWordsSortDist = idFoundWords.Distinct().OrderBy(t => t);
            Boolean flagFirst = false;
            Boolean flagSecond = false;
            int j = 0, res = 0;
            foreach (int id in idFoundWordsSortDist)
            {
                while (idWordsInSourceText[j] < id)
                {
                    flagFirst = false;
                    flagSecond = false;
                    j++;
                    if (j >= idWordsInSourceText.Count) break;
                }
                if (j >= idWordsInSourceText.Count) break;
                if (idWordsInSourceText[j] == id)
                {
                    if (flagFirst)
                    {
                        if (!flagSecond)
                        {
                            flagSecond = true;
                            res++;
                        }
                        res++;
                    }
                    flagFirst = true;
                    j++;
                    if (j >= idWordsInSourceText.Count) break;
                }
            }
            return res;
        }

        void AddId(int id)
        {
            idFoundWords.Add(id);
        }

        void ClearValue()
        {
            textLen = 0;
            stringSearchLen = 0;
            idWordsInSourceText.Clear();
            idFoundWords.Clear();
        }

        void SearchBM(string str, string search)
        {
            int m = search.Length;
            if (m < 2)
            {
                return;
            }
            stringSearchLen++;
            int n = str.Length;
            int[] P = new int[m];

            int k = 1;
            Boolean flag;

            for (int i = m - 2; i >= 0; i--)
            {
                flag = true;
                for (int j = m - 2; j > i; j--)
                {
                    if (search[i] == search[j])
                    {
                        P[i] = P[j];
                        flag = false;
                    }
                }
                if (flag) P[i] = k;
                k++;
            }
            flag = true;
            for (int j = m - 2; j > 0; j--)
            {
                if (search[m - 1] == search[j])
                {
                    P[m - 1] = P[j];
                    flag = false;
                }
            }
            if (flag) P[m - 1] = m;

            int position = m - 1;
            while (position < n)
            {
                int check = m - 1;
                while (check > 0 && search[check] == str[position - m + check + 1]) check--;
                if (check <= 0)
                {
                    int id = position - m + 1;

                    if (id + m >= textLen)
                    {
                        AddId(id);
                        break;
                    }
                    if (!Char.IsDigit(str[id + m]) && !Char.IsLetter(str[id + m]))
                    {
                        AddId(id);
                    }
                    position++;
                }
                else
                {
                    int l = m;
                    for (int i = m - 1; i >= 0; i--)
                    {
                        if (str[position] == search[i])
                        {
                            l = P[i];
                            break;
                        }
                    }
                    position += l;
                }

            }
        }

        void SearchKMP(String str, String search)
        {
            stringSearchLen++;

            int m = search.Length;
            int len = 0;
            int k = 1;
            int[] P = new int[m];
            P[0] = 0;
            if (m > str.Length) return;
            while (k < m)
            {
                if (search[k] == search[len])
                {
                    len++;
                    P[k] = len;
                    k++;
                }
                else
                {
                    if (len != 0)
                    {
                        len = P[len - 1];
                    }
                    else
                    {
                        P[k] = len;
                        k++;
                    }
                }
            }

            int stringIndex = 0;
            int searchIndex = 0;
            int foundIndexes;

            while (stringIndex < str.Length)
            {
                if (search[searchIndex] == str[stringIndex])
                {
                    searchIndex++;
                    stringIndex++;
                }
                if (searchIndex == search.Length)
                {
                    foundIndexes = stringIndex - searchIndex;

                    AddId(foundIndexes);

                    searchIndex = 0;
                }

                else if (stringIndex < str.Length && search[searchIndex] != str[stringIndex])
                {
                    if (searchIndex != 0)
                        searchIndex = P[searchIndex - 1];
                    else
                        stringIndex++;
                }
            }

        }

        void SearchRabinaKarpa(string str, string search)
        {
            stringSearchLen++;

            int q = 101;
            int d = 256;

            int hashPattern = 0;
            int hashText = 0;
            int h = 1;


            for (int i = 0; i < search.Length - 1; i++)
                h = (h * d) % q;

            for (int i = 0; i < search.Length && i < str.Length; i++)
            {
                hashPattern = (d * hashPattern + search[i]) % q;
                hashText = (d * hashText + str[i]) % q;
            }

            for (int i = 0; i <= str.Length - search.Length; i++)
            {

                if (hashPattern == hashText)
                {
                    int j;
                    for (j = 0; j < search.Length; j++)
                    {
                        if (str[i + j] != search[j])
                            break;
                    }

                    if (j == search.Length)
                    {
                        if (i + j >= textLen)
                        {
                            AddId(i);
                            break;
                        }
                        if (!Char.IsDigit(str[i + j]) && !Char.IsLetter(str[i + j]))
                        {
                            AddId(i);
                        }
                    }
                }
                if (i < str.Length - search.Length)
                {
                    hashText = (d * (hashText - str[i] * h) + str[i + search.Length]) % q;

                    if (hashText < 0)
                        hashText = (hashText + q);
                }
            }
        }

        public static int MAXS = 10000;
        public static int MAXC = 10000;
        static int[] outt = new int[MAXS];
        static int[] f = new int[MAXS];
        static int[,] g = new int[MAXS, MAXC];
        int BuildMatchingMachine(String[] arr, int k)
        {
            for (int i = 0; i < MAXS; i++)
            {
                for (int j = 0; j < MAXC; j++)
                    g[i, j] = -1;
                outt[i] = 0;
            }

            int states = 1;

            for (int i = 0; i < k; ++i)
            {
                String word = arr[i];
                int currentState = 0;

                for (int j = 0; j < word.Length; ++j)
                {
                    int ch = Math.Abs(word[j] - 'а');

                    if (g[currentState, ch] == -1)
                        g[currentState, ch] = states++;

                    currentState = g[currentState, ch];
                }

                outt[currentState] |= (1 << i);
            }

            for (int ch = 0; ch < MAXC; ++ch)
                if (g[0, ch] == -1)
                    g[0, ch] = 0;

            for (int i = 0; i < MAXC; i++)
                f[i] = 0;

            Queue<int> q = new Queue<int>();

            for (int ch = 0; ch < MAXC; ++ch)
            {
                if (g[0, ch] != 0)
                {
                    f[g[0, ch]] = 0;
                    q.Enqueue(g[0, ch]);
                }
            }

            while (q.Count != 0)
            {

                int state = q.Peek();
                q.Dequeue();

                for (int ch = 0; ch < MAXC; ++ch)
                {

                    if (g[state, ch] != -1)
                    {

                        int failure = f[state];

                        while (g[failure, ch] == -1)
                            failure = f[failure];

                        failure = g[failure, ch];
                        f[g[state, ch]] = failure;

                        outt[g[state, ch]] |= outt[failure];

                        q.Enqueue(g[state, ch]);
                    }
                }
            }
            return states;
        }

        int FindNextState(int currentState, char nextInput)
        {
            int answer = currentState;
            int ch = Math.Abs(nextInput - 'а');

            while (g[answer, ch] == -1) answer = f[answer];

            return g[answer, ch];
        }

        void SearchAhoCorasick(String text, String[] arr)
        {
            int k = arr.Length;
            stringSearchLen = k;
            BuildMatchingMachine(arr, k);

            int currentState = 0;

            for (int i = 0; i < text.Length; ++i)
            {
                currentState = FindNextState(currentState, text[i]);

                if (outt[currentState] == 0)
                    continue;

                for (int j = 0; j < k; ++j)
                {
                    if ((outt[currentState] & (1 << j)) > 0)
                    {
                        int id = i - arr[j].Length + 1;
                        if (i + 1 >= textLen)
                        {
                            AddId(id);
                        }
                        else if (!Char.IsDigit(text[i + 1]) && !Char.IsLetter(text[i + 1])) AddId(id);
                    }
                }
            }
        }
    }
}
