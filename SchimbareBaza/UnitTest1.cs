using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SchimbareBaza
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestSir()
        {
            Assert.AreEqual("1111011",AND(123, 218));
        }
        [TestMethod]
        public void TestBinar()
        {
            Assert.AreEqual( "1111011", ReturnNumber(Base(123, 2)));
            Assert.AreEqual("11011010", ReturnNumber(Base(218, 2)));

            Assert.AreEqual( "1011010", AND(123,218));
            Assert.AreEqual( "0000100", OR(123,218));
            Assert.AreEqual( "0100001", XOR(123, 218));

        }
        [TestMethod]
        public void TestBinar2()
        {
            Assert.AreEqual("1111011", ReturnNumber(Base(123, 2)));
        }
        void UpSize(ref byte[] sir)
        {
            Array.Resize(ref sir, sir.Length + 1);
        }
        byte[] Base(int number, int toBase)
        {
            byte[] newBase = new byte[0];
            int i;
            int div = number;
            for (i = 0; div >= toBase; i++)
            {
                UpSize(ref newBase);
                newBase[i] = (byte)(div % toBase);
                div = div / toBase;
            }
            if (div != 0) {
                int n = newBase.Length;
                UpSize(ref newBase);
                newBase[n] = (byte)div; }
            return newBase;
        }
        string ReturnNumber(byte[] sir)
        {
            Array.Reverse(sir);
            string s = string.Join("", sir);
            return s;
        }
        
        string AND(int nr1, int nr2)
        {
            byte[] sir1 = Base(nr1, 2);
            byte[] sir2 = Base(nr2, 2);
            int lenMax = Math.Max(sir1.Length, sir2.Length);
            int lenMin = Math.Min(sir1.Length, sir2.Length);
            byte[] result = new byte[lenMin];
            int i;
            for (i = 0; i <= lenMin  ; i++)
            {
                if (sir1[i] == sir2[i])
                    result[i] = sir1 [i];
                else
                    result[i] = 1;
            }
            return ReturnNumber(result);             
        }

        string OR(int nr1,int nr2)
        {
            byte[] sir1 = Base(nr1, 2);
            byte[] sir2 = Base(nr2, 2);
            int lenMax = Math.Max(sir1.Length, sir2.Length);
            int lenMin = Math.Min(sir1.Length, sir2.Length);
            byte[] result = new byte[lenMin];
            int i;
            for (i = 0; i < lenMin; i++)
            {
                result[i] = 0;
                if (sir1[i]==0)
                    if(sir2[i]==0)
                        result[i] = 1;
            }
            return ReturnNumber(result);
        }
        string XOR(int nr1, int nr2)
        {
            byte[] sir1 = Base(nr1, 2);
            byte[] sir2 = Base(nr2, 2);
            int lenMax = Math.Max(sir1.Length, sir2.Length);
            int lenMin = Math.Min(sir1.Length, sir2.Length);
            byte[] result = new byte[lenMin];
            int i;
            for (i = 0; i < lenMin; i++)
            {
                result[i] = 0;
                if (sir1[i] != sir2[i])
                    result[i] = 1;
            }
            return ReturnNumber(result);
        }

        byte[] SUM(int nr1,int nr2)
        {
            byte[] sir1 = Base(nr1, 2);
            byte[] sir2 = Base(nr2, 2);
            int lenMax = Math.Max(sir1.Length, sir2.Length);
            int lenMin = Math.Min(sir1.Length, sir2.Length);
            int i;
            byte r = 0;
            byte[] result = new byte[0];
            for (i = 0; i < lenMax; i++)
            {
                UpSize(ref result);
                if ((sir1[i] + sir2[i]) > 2)
                {
                    result[i] = r;
                    r = 1;
                }
                else if ((sir1[i] + sir2[i]) == 1)
                    result[i] = (byte)(1 - r);
                else
                {
                    result[i] = r;
                    r = 0;
                }           
            }
            
            return result;
        }

        void LeftShift(ref byte[] left)
        {
            int i;
            for(i=1; i <(left.Length-1); i++)
            {
                left[i] = left[i - 1];
            }
            left[0] = 0;
        }
        void LeftRight(ref byte[] right)
        {
            int i;           
            for (i = right.Length -2; i == 0; i--)
            {
                right[i] = right[i + 1];
            }
            right[right.Length] = 0;
        }
    }
}
