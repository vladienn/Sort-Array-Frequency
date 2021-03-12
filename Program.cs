using System;
using System.Collections.Generic;
using System.Linq;

namespace SortArrayFrequency
{
    public class Program
    {
        public class SortByFrequency
        {
            private int[] arr;
            public SortByFrequency()
            {
            }

            public int[] FinalSort(int[] a)
            {
                this.arr = a;
                Array.Sort(arr);

                Dictionary<int, int> freq_table = new Dictionary<int, int>();
                Dictionary<int, int> same_freq = new Dictionary<int, int>();
                Dictionary<int, int> freq_table_final = new Dictionary<int, int>();

                fillFreqTable(arr, freq_table);
                freq_table = freq_table.OrderBy(x => x.Value).ToDictionary(x => x.Key, x => x.Value);

                //Взимане само на повтарящите се стойности
                same_freq = freq_table.Where(x => freq_table.Any(j => j.Key != x.Key && x.Value == j.Value))
                    .OrderByDescending(x => x.Key)
                    .ToDictionary(x => x.Key, x => x.Value);

                //Създаване на нов Dictionary от резултат смесването на предишните две
                foreach (KeyValuePair<int, int> ele in freq_table) {
                    if (same_freq.ContainsValue(ele.Value)) {
                        foreach (KeyValuePair<int, int> ele1 in same_freq) {
                            if (ele1.Value == ele.Value) {
                                freq_table_final[ele1.Key] = ele1.Value;
                            }
                        }
                    }
                    else {
                        freq_table_final[ele.Key] = ele.Value;
                    }
                }

                //Превръщането на подредените числа под формата на масив
                int z = 0;
                foreach (KeyValuePair<int, int> ele in freq_table_final) {
                    for (int i = 0; i <= ele.Value - 1; i++) {
                        arr[z++] = ele.Key;
                    }
                }
                return arr;
            }

            void fillFreqTable(int[] a, Dictionary<int, int> map)
            {
                int cnt = 1;
                for (int i = 0; i < a.Length - 1; i++) {
                    if (i == a.Length - 2) {
                        if (a[i + 1] == a[i]) {
                            cnt++;
                            map.Add(a[i], cnt);
                        }
                        else {
                            map.Add(a[i], cnt);
                            cnt = 1;
                            map.Add(a[i + 1], cnt);
                        }
                    }
                    else if (a[i + 1] == a[i]) {
                        cnt++;
                    }
                    else {
                        map.Add(a[i], cnt);
                        cnt = 1;
                    }
                }
            }

            void printArr(int[] a) {
                for (int i = 0; i < a.Length; i++) {
                    Console.Write(a[i] + ", ");
                }
            }

            void printMap(Dictionary<int, int> map){
                foreach (KeyValuePair<int, int> ele in map){
                    Console.WriteLine("{0} , {1}", ele.Key, ele.Value);
                }
            }

        }

        public static void Main()
        {
            void printArr(int[] a){
                for (int i = 0; i < a.Length; i++){
                    Console.Write(a[i] + ", ");
                }
            }

            int[] arr1 = { 3, 6, 3, 7, 9, 102, 3, 6, 6, 6, 102 };
            int[] arr2 = { 40, 15, 40, 7, 15, 6, 7, 7 };
            int[] arr3 = { 22, 53, 22, 6, -1, 999, 53, 8, 8, 8 };
            int[] arr4 = { 4, 4, 4, 2, 2, 2, 2, 3, 3, 1, 1, 6, 7, 5 };

            SortByFrequency sort = new SortByFrequency();
            Console.WriteLine("Sample Output 1");
            printArr(sort.FinalSort(arr1));
            Console.WriteLine("\nSample Output 2");
            printArr(sort.FinalSort(arr2));
            Console.WriteLine("\nSample Output 3");
            printArr(sort.FinalSort(arr3));
            Console.WriteLine("\nSample Output 4");
            printArr(sort.FinalSort(arr4));
        }
    }
}
