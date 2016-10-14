using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class Tree
    {
        public int x;
        public Tree l;
        public Tree r;
    }
    public class TestClass
    {
        static List<int> distinctNums = new List<int>();
        static List<string> words=new List<string>();

        public delegate string myDelegate(string s);
        
        public static void Main()
        {
            int[] A = {1};

            //var mins = minimumSumOfNonAcjacentElements(A);
            
            var coi = ReverseCoin(A);
            var coi2 = Coins(A);
            var res = Solution("abc", "AbA");
            var res1 = Solution("a", "aa");
            var res2 = Solution("abc", "abc");
            var res3 = Solution("abc", "");
            //setting unhandled exception
            Func<object, int> myFunc = x=> 2;
            
            string a = "pratik";
            
            EventHandler<EventArgs> myEventHandler = (s, e) =>
            {
            
            };

            AppDomain.CurrentDomain.UnhandledException += (s, e) =>
            {
                
            };
            
            int n = 123;
            solution(123);
            string word = "dhkc";
            words.Add(word);
            GetGreatest(word, 0, word.Length-1);
            
            words.Sort();
            var index = words.IndexOf(word);
            try
            {
                Console.WriteLine(words[index+1]);
            }
            catch (Exception)
            {
                
                Console.WriteLine("no answer");
            }

        }

        public static int ReverseCoin(int[] A)
        {
            var maxAdj = 0;
            for (int i = 0; i < A.Length-1; i++)
            {
                if (A[i] == A[i + 1])
                    maxAdj++;
            }
            bool flipped = false;
            int k = 1;
            while (!flipped && k<=A.Length-1)
            {
                if (k==A.Length-1)
                {
                    if (A[k] != A[k - 1])
                    {
                        maxAdj = maxAdj + 1;
                        flipped = true;
                    }   
                }
                else if (A[k - 1] != A[k] && A[k] != A[k + 1])
                {
                    maxAdj = maxAdj + 2;
                    flipped = true;
                }
                
                k++;
            }

            return maxAdj;
        }

        public static int minimumSumOfNonAcjacentElements(int[] A)
        {
            
            int min = Int32.MaxValue;
            

            int minElement = A[1];

            int prevEle = A[2];
            int len = A.Length;
            for (int i = 3; i + 1 < len; i++)
            {
                int mySum = minElement + A[i];
                if (mySum < min)
                {
                    min = mySum;
                    
                }

                if (prevEle < minElement)
                {
                    minElement = prevEle;
                }
                prevEle = A[i];
            }

            return min ;
        }

        public static int Coins(int[] A)
        {
            int n = A.Length;
            int result = 0;
            for (int i = 0; i < n - 1; i++)
            {
                if (A[i] == A[i + 1])
                    result = result + 1;
            }
            int r = 0;
            
            for (int i = 0; i < n; i++)
            {
                int count = 0;
                if (i > 0)
                {
                    if (A[i - 1] != A[i])
                        count = count + 1;
                    else
                        count = count - 1;
                }
                if (i < n - 1)
                {
                    if (A[i + 1] != A[i])
                        count = count + 1;
                    else
                        count = count - 1;
                }
                r = Math.Max(r, count);
                
            }
            return result + r;
        }


        private static int Solution(Tree T)
        {
            if (T == null)
            {
                return -1;
            }

            var visibleNodes = 0;

            var customStack = new Stack<Tuple<int, Tree>>();
            customStack.Push(new Tuple<int, Tree>(T.x, T));

            while (customStack.Count > 0)
            {
                var n = customStack.Pop();
                if (n.Item1 <= n.Item2.x)
                {
                    ++visibleNodes;
                }
                var max = Math.Max(n.Item1, n.Item2.x);
                if (n.Item2.l != null)
                {
                    customStack.Push(new Tuple<int, Tree>(max, n.Item2.l));
                }
                if (n.Item2.r != null)
                {
                    customStack.Push(new Tuple<int, Tree>(max, n.Item2.r));
                }
            }

            return visibleNodes;
        }
        public static int Solution(string S1, string S2)
        {
            
            var res = String.Compare(S1, S2, StringComparison.CurrentCultureIgnoreCase);

            return res;
            
        }
        public static void GetGreatest(string word, int start, int end)
        {
            List<int> myList = new List<int> {1, 1, 2, 3, 4, 3};
            for (int i = 0; i < myList.Count; i++)
            {
                if (myList.IndexOf(myList[i])!=myList.LastIndexOf(myList[i]))
                {
                    myList.RemoveAt(i);
                }
            }

            
            if (start==end)
            {
                
            }
            else
            {
                var myCharArray = word.ToCharArray();
                char[] myaStrings = new char[word.Length];
                var first = myCharArray[start];
                for (int i = start + 1; i <= end; i++)
                {
                    myCharArray = word.ToCharArray();
                    var temp = myCharArray[i];
                    myCharArray[i] = first;
                    myCharArray[start] = temp;
                    if (!words.Contains(new string(myCharArray)))
                        words.Add(new string(myCharArray));
                }
                start = start + 1;
                GetGreatest(word, start, end);
                
            }
            
        }

        public static void Funcs()
        {
            
            //anonymous type
            var myanyType = new {name="pratik"};

            //anonymous method
            myDelegate mydel = (s) =>
            {
                s = s + "pratik";
                return s;
            };

            //inline anonymous method

            myDelegate mydel2 = (s) => s;

            //Action
            Action<int> myAction = (a) =>
            {
                a = 3;
            };

            //inline
            Action<int> myacAction = (a) => a=2;

            EventHandler<EventArgs> myevengHandler = (s, e) =>
            {

            };




        }
        public static void TestAc(Action<string> action)
        {
            action("pratik");
        }
        public static int solution(int N)
        {
            Func<string, string> myFunc = (x) => x.ToString();
            
            Action<String> myAction = x =>
            {
                x = "pratik";
                x = "temp";
            };
            TestAc((a)=> 
            { a = "pratik"; });
            
            var myString = 1213433.ToString();
            var myCharArray = myString.ToCharArray();
            int res = 0;
            try
            {
                GetPermutation(myCharArray, 0, myCharArray.Length - 1);
                return distinctNums.Count;
            }
            catch (Exception exception)
            {

                throw new Exception("Something Wrong Happened",exception);
            }
            
            
        }



        private static void GetPermutation(char[] intArr, int start, int end)
        {
            
            int j;
            
            if (start == end)
            {
                var newString = new string(intArr);
                int res = 0;
                var isaNum = Int32.TryParse(newString, out res);
                if (isaNum && !distinctNums.Contains(res))
                    distinctNums.Add(res);
                
            }   
            else
            {
                for (j = start; j <= end; j++)
                {
                    SwapInt(ref intArr[start], ref intArr[j]);
                    GetPermutation(intArr, start + 1, end);
                    SwapInt(ref intArr[start], ref intArr[j]); 
                }
            }
        }

        private static void SwapInt(ref char a, ref char b)
        {
            char temp;
            temp = a;
            a = b;
            b = temp;
        }


    }
}
