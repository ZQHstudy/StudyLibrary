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
        public int[] Select(int[]Nums)
        {
            return SortSelect.Sort(Nums);
        }
        public int[] Insert(int[]Nums)
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
        public static int[] Sort(int[]Nums)
        {
            for (int i = 0; i < Nums.Length-1; i++)
            {
                int flag = i + 1;
                for (int j = i; j >0; j--)
                {
                    if (Nums[j]>Nums[flag]&&(j==0||Nums[j-1]<Nums[flag]))
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


}
