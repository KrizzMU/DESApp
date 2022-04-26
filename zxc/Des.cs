using System;
using System.Text;

namespace zxc
{
    class Des 
    {
        private string input;
        private string dInput = "";
        private string dKey = "";
        private string key;
        private string[] inputMas;
        public Des(string Input, string Key)
        {
            input = Input;
            key = Key;
            while (input.Length % 8 != 0)
            {
                input += " ";
            }
            int n = input.Length / 8;
            inputMas = new String[n];
            for (int i = 0; i < n; i++) // заполняю блоки
            {
                inputMas[i] = input.Substring(0, 8);
                input = input.Remove(0, 8);                
            }
            for (int j = 0; j < n; j++) // каждый блок в двоичную систему
            {
                dInput = "";
                byte[] a = Encoding.GetEncoding(1251).GetBytes(inputMas[j]);

                for (int i = 0; i < 8; i++)
                {
                    string binary = Convert.ToString(a[i], 2);                    
                    while (binary.Length != 8)
                    {
                        binary = "0" + binary;                       
                    }

                    dInput += binary;
                }
                inputMas[j] = dInput;  
            }
            for (int j = 0; j < 8; j++) // ключ в двоичную
            {
                byte[] a = Encoding.GetEncoding(1251).GetBytes(key);
                string dd = "";
                for (int i = 0; i < 8; i++)
                {
                    string binary = Convert.ToString(a[i], 2);
                    while (binary.Length != 8)
                    {
                        binary = "0" + binary;
                    }

                    dd += binary;
                }
                dKey += dd;               
            }


        }
        public string Encription()
        {
            string ex = "";
            for (int t = 0; t < inputMas.Length; t++)
            {
                dInput = inputMas[t];
                dInput = IPer(dInput);
                string LdInput = dInput.Substring(0, 32);
                string RdInput = dInput.Remove(0, 32);
                string[] KeysMassive = keyExp(dKey);
                for (int i = 0; i < 16; i++)
                {
                    string y = RdInput;
                    RdInput = XOR(Feishtel(RdInput, KeysMassive[i]), LdInput);
                    LdInput = y;
                }
                dInput = RdInput + LdInput;
                string h = "";
                for (int i = 0; i < 64; i++)
                {
                    h += dInput[Permutation.Fp[i]-1];                    
                }
                dInput = h;                
                dInput = StringFromBinaryToNormalFormat(dInput);
                inputMas[t] = dInput;
                ex += dInput;
            }

            return ex;
        }

        public string Dencription()
        {
            string ex = "";
            for (int t = 0; t < inputMas.Length-1; t++)
            {
                dInput = inputMas[t];
                string h = "";
                for (int i = 1; i < 65; i++)
                {
                    h += dInput[Array.IndexOf(Permutation.Fp, i)];
                }
                dInput = h;
                string RdInput = dInput.Substring(0, 32);
                string LdInput = dInput.Remove(0, 32);
                string[] KeysMassive = keyExp(dKey);
                for (int i = 15; i >= 0; i--)
                {
                    string y = RdInput;
                    RdInput = LdInput;
                    LdInput = XOR(Feishtel(RdInput, KeysMassive[i]), y);
                }
                dInput = LdInput + RdInput;

                h = "";
                for (int i = 1; i < 65; i++)
                {
                    h += dInput[Array.IndexOf(Permutation.Pi, i)];
                }
                dInput = h;
                dInput = StringFromBinaryToNormalFormat(dInput);
                ex += dInput;
                inputMas[t] = dInput;
            }
            return ex;
        }

        private string IPer(string s)
        {
            string newInput = "";
            for (int i = 0; i < 64; i++)
            {
                newInput += s[Permutation.Pi[i]-1];                
            }

            return newInput;
        }
        private string Eper(string s)
        {
            string newInput = "";
            for (int i = 0; i < 48; i++)
            {
                newInput += s[Permutation.Ep[i]-1];                
            }
            return newInput;
        }
        private string Pper(string s)
        {
            string newInput = "";
            for (int i = 0; i < 32; i++)
            {
                newInput += s[Permutation.Pp[i]-1];                
            }
            return newInput;
        }
        private string Displacement(string a, int shift)
        {
            for (int i = 0; i < shift; i++)
            {
                a = a[a.Length - 1] + a;
                a = a.Remove(a.Length - 1);
            }
            return a;
        }
        private string ADisplacement(string a, int shift)
        {
            for (int i = 0; i < shift; i++)
            {
                a = a + a[0];
                a = a.Remove(0, 1);
            }
            return a;
        }
        private string StringFromBinaryToNormalFormat(string input)
        {
            string output = "";
            while (input.Length > 0)
            {
                string char_binary = input.Substring(0, 8);
                input = input.Remove(0, 8);                
                int a = 0;
                int degree = char_binary.Length - 1;

                foreach (char c in char_binary)
                {
                    a += Convert.ToInt32(Convert.ToString(c)) * (int)Math.Pow(2, degree);
                    degree--;
                }
                byte[] aa = { (byte)a };
                output += Encoding.GetEncoding(1251).GetString(aa);
            }
            return output;
        }
        private int BinaryToDecimal(string Number)
        {
            int exponent = 0;
            int result = 0;
            for (int i = Number.Length - 1; i >= 0; i--)
            {
                if (Number[i] == '1')
                {
                    result += Convert.ToInt32(Math.Pow(2, exponent));
                }
                exponent++;
            }

            return result;
        }
        private string Feishtel(string input, string Key)
        {
            input = Eper(input);
            string xor = XOR(input, Key);
            string h = "";
            string[] S = new String[8];
            for (int i = 0; i < 8; i++)
            {
                S[i] = xor.Substring(0, 6);
                xor = xor.Remove(0, 6);
                S[i] = sBox(S[i], i);
                h += S[i];
            }
            h = Pper(h);
            return h;
        }
        private string sBox(string e, int i)
        {
            string pp = "";
            pp += e[0] + e[e.Length-1];           
            e = e.Remove(0, 1);
            e = e.Remove(e.Length - 1);            
            int a = BinaryToDecimal(pp);
            int b = BinaryToDecimal(e);
            int c = Permutation.S[i, a, b];
            e = Convert.ToString(c, 2);
            while (e.Length != 4)
            {
                e = "0" + e;
            }
            return e;
        }
        private string XOR(string s1, string s2)
        {
            string result = "";
            for (int i = 0; i < s1.Length; i++)
            {
                bool a = Convert.ToBoolean(Convert.ToInt32(s1[i].ToString()));
                bool b = Convert.ToBoolean(Convert.ToInt32(s2[i].ToString()));

                if (a ^ b)
                    result += "1";
                else
                    result += "0";
            }
            return result;
        }
        private string[] keyExp(string Key)
        {
            string[] KeyMas = new string[16];
            string k1 = "", k2 = "";
            for (int i = 0; i < 28; i++)
            {
                k1 += Key[Permutation.Pkey1[i]-1];
                k2 += Key[Permutation.Pkey2[i]-1];                
            }

            for (int i = 0; i < 16; i++)
            {
                if (i == 0 || i == 1 || i == 8 || i == 15)
                {
                    k1 = ADisplacement(k1, 1);
                    k2 = ADisplacement(k2, 1);
                }
                else
                {
                    k1 = ADisplacement(k1, 2);
                    k2 = ADisplacement(k2, 2);
                }                
                KeyMas[i] = k1 + k2;                
                string kk = "";
                for (int j = 0; j < 48; j++)
                {                    
                    kk += KeyMas[i][Permutation.Cp[j]-1];
                }
                KeyMas[i] = kk;
            }
            return KeyMas;
        }
    }
}
