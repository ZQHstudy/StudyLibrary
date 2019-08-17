using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary
{
    /// <summary>
    /// 排序算法
    /// </summary>
    class Sort
    {
        /// <summary>
        /// 归并
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int[] GuiBing(int[] nums)
        {
            return SortGuiBing.Sort(nums);
        }
        public int[] MaoPao(int[] Nums)
        {
            return SortMaoPao.Sort(Nums);
        }
        public int[] Select(int[] Nums)
        {
            return SortSelect.Sort(Nums);
        }
        public int[] Insert(int[] Nums)
        {
            return SortInsert.Sort(Nums);
        }
    }
    /// <summary>
    /// 归并排序
    /// </summary>
    public class SortGuiBing
    {
        public static int[] Sort(int[] Nums)
        {
            if (Nums.Length < 2)
            {
                return Nums;
            }

            int[] Left = GetInts(Nums, true);
            int[] Right = GetInts(Nums, false);

            return Bing(Sort(Left), Sort(Right));
        }
        static int[] GetInts(int[] nums, bool flag)
        {
            int[] Ns;
            if (flag)
            {
                Ns = new int[(nums.Length) / 2];
                for (int i = 0; i < Ns.Length; i++)
                {
                    Ns[i] = nums[i];
                }
            }
            else
            {
                if (nums.Length % 2 == 1)
                {
                    Ns = new int[(nums.Length) / 2 + 1];
                }
                else
                {
                    Ns = new int[(nums.Length) / 2];
                }
                for (int i = 0; i < Ns.Length; i++)
                {
                    Ns[i] = nums[nums.Length / 2 + i];
                }
            }
            return Ns;
        }
        static int[] Bing(int[] Ns, int[] Ms)
        {
            int[] Nums = new int[Ns.Length + Ms.Length];
            int N = Ns.Length, M = Ms.Length;
            int i = 0;
            while (N > 0 && M > 0)
            {
                if (Ns[Ns.Length - N] < Ms[Ms.Length - M])
                {
                    Nums[i] = Ns[Ns.Length - N];
                    N--;
                }
                else
                {
                    Nums[i] = Ms[Ms.Length - M];
                    M--;
                }
                i++;
            }
            if (N > 0)
            {
                for (; N > 0; N--, i++)
                {
                    Nums[i] = Ns[Ns.Length - N];
                }
            }
            if (M > 0)
            {
                for (; M > 0; M--, i++)
                {
                    Nums[i] = Ms[Ms.Length - M];
                }
            }
            return Nums;
        }
    }

    /// <summary>
    /// 冒泡排序
    /// </summary>
    public class SortMaoPao
    {
        public static int[] Sort(int[] Nums)
        {
            for (int i = 0; i < Nums.Length - 1; i++)
            {
                for (int j = i; j < Nums.Length - 1 - i; j++)
                {
                    if (Nums[j] > Nums[j + 1])
                    {
                        swap(Nums, j, j + 1);
                    }
                }
            }
            return Nums;
        }
        static void swap(int[] Nums, int a, int b)
        {
            Nums[a] = Nums[a] ^ Nums[b];
            Nums[b] = Nums[a] ^ Nums[b];
            Nums[a] = Nums[a] ^ Nums[b];
        }
    }
    /// <summary>
    /// 选择排序
    /// </summary>
    public class SortSelect
    {
        public static int[] Sort(int[] Nums)
        {
            int Max = 0;
            for (int i = 0; i < Nums.Length - 1; i++)
            {
                Max = 0;
                for (int j = 0; j < Nums.Length - 1 - i; j++)
                {
                    if (Nums[j] > Nums[Max])
                    {
                        Max = j;
                    }
                }
                swap(Nums, Max, Nums.Length - 1 - i);
            }
            return Nums;
        }
        static void swap(int[] Nums, int a, int b)
        {
            Nums[a] = Nums[a] ^ Nums[b];
            Nums[b] = Nums[a] ^ Nums[b];
            Nums[a] = Nums[a] ^ Nums[b];
        }
    }
    /// <summary>
    /// 插入排序
    /// </summary>
    public class SortInsert
    {
        public static int[] Sort(int[] Nums)
        {
            for (int i = 0; i < Nums.Length - 1; i++)
            {
                int flag = i + 1;
                for (int j = i; j > 0; j--)
                {
                    if (Nums[j] > Nums[flag] && (j == 0 || Nums[j - 1] < Nums[flag]))
                    {
                        flag = j;
                    }
                }
                swap(Nums, i, flag);
            }
            return Nums;
        }
        static void swap(int[] Nums, int a, int b)
        {
            Nums[a] = Nums[a] ^ Nums[b];
            Nums[b] = Nums[a] ^ Nums[b];
            Nums[a] = Nums[a] ^ Nums[b];
        }
    }

    public class SortDui
    {
        public static int[] Sort(int[] Nums)
        {
            //Build
            return new int[1];
        }
        /// <summary>  
        /// The program.  
        /// </summary>  
        public static class Program
        {
            /// <summary>  
            /// 程序入口点。  
            /// </summary>  
            public static void Main()
            {
                int[] a = { 1, 14, 6, 2, 8, 66, 9, 3, 0, 10, 5, 34, 76, 809, 4, 7 };
                Console.WriteLine("Before Heap Sort...");
                foreach (int i in a)
                {
                    Console.Write(i + " ");
                }

                Console.WriteLine("\r\n--------------------");
                Console.WriteLine("In Heap Sort...");
                HeapSort(a);
                Console.WriteLine("--------------------");
                Console.WriteLine("After Heap Sort...");
                foreach (int i in a)
                {
                    Console.Write(i + " ");
                }

                Console.WriteLine(string.Empty);
            }

            /// <summary>  
            /// 堆排序方法。  
            /// </summary>  
            /// <param name="a">  
            /// 待排序数组。  
            /// </param>  
            private static void HeapSort(int[] a)
            {
                BuildMaxHeap(a); // 建立大根堆。  
                Console.WriteLine("Build max heap:");
                foreach (int i in a)
                {
                    Console.Write(i + " "); // 打印大根堆。  
                }

                Console.WriteLine("\r\nMax heap in each iteration:");
                for (int i = a.Length - 1; i > 0; i--)
                {
                    Swap(ref a[0], ref a[i]); // 将堆顶元素和无序区的最后一个元素交换。  
                    MaxHeaping(a, 0, i); // 将新的无序区调整为大根堆。  

                    // 打印每一次堆排序迭代后的大根堆。  
                    for (int j = 0; j < i; j++)
                    {
                        Console.Write(a[j] + " ");
                    }

                    Console.WriteLine(string.Empty);
                }
            }

            /// <summary>  
            /// 由底向上建堆。由完全二叉树的性质可知，叶子结点是从index=a.Length/2开始，所以从index=(a.Length/2)-1结点开始由底向上进行大根堆的调整。  
            /// </summary>  
            /// <param name="a">  
            /// 待排序数组。  
            /// </param>  
            private static void BuildMaxHeap(int[] a)
            {
                for (int i = (a.Length / 2) - 1; i >= 0; i--)
                {
                    MaxHeaping(a, i, a.Length);
                }
            }

            /// <summary>  
            /// 将指定的结点调整为堆。  
            /// </summary>  
            /// <param name="a">  
            /// 待排序数组。  
            /// </param>  
            /// <param name="i">  
            /// 需要调整的结点。  
            /// </param>  
            /// <param name="heapSize">  
            /// 堆的大小，也指数组中无序区的长度。  
            /// </param>  
            private static void MaxHeaping(int[] a, int i, int heapSize)
            {
                int left = (2 * i) + 1; // 左子结点。  
                int right = 2 * (i + 1); // 右子结点。  
                int large = i; // 临时变量，存放大的结点值。  

                // 比较左子结点。  
                if (left < heapSize && a[left] > a[large])
                {
                    large = left;
                }

                // 比较右子结点。  
                if (right < heapSize && a[right] > a[large])
                {
                    large = right;
                }

                // 如有子结点大于自身就交换，使大的元素上移；并且把该大的元素调整为堆以保证堆的性质。  
                if (i != large)
                {
                    Swap(ref a[i], ref a[large]);
                    MaxHeaping(a, large, heapSize);
                }
            }

            /// <summary>  
            /// 交换两个整数的值。  
            /// </summary>  
            /// <param name="a">整数a。</param>  
            /// <param name="b">整数b。</param>  
            private static void Swap(ref int a, ref int b)
            {
                int tmp = a;
                a = b;
                b = tmp;
            }
        }
    }


}
