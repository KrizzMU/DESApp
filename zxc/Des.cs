using System;
using System.Text;

namespace DesApp
{
    sealed class Des : Permutation
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
            int nBox = input.Length / 8; // количество блоков
            inputMas = new String[nBox];
            for (int i = 0; i < nBox; i++) // заполняю массив блоков
            {                
                inputMas[i] = input.Substring(0, 8);
                input = input.Remove(0, 8);                
            }
            for (int j = 0; j < nBox; j++) // каждый блок в двоич.
            {                              
                inputMas[j] = toBynaryFirst(inputMas[j]);
            }           
            dKey += toBynaryFirst(key); // ключ в двоич.                          
        }
        private string toBynaryFirst(string str)
        {
            byte[] a = Encoding.GetEncoding(1251).GetBytes(str); // перекадировка строки в win-1251
            string fByn = "";
            for (int i = 0; i < 8; i++)
            {
                string binary = Convert.ToString(a[i], 2);
                while (binary.Length != 8)
                {
                    binary = "0" + binary;
                }
                fByn += binary;
            }
            return fByn;
        }
        public string Encription() //блок шифрование
        {
            string en = "";
            for (int t = 0; t < inputMas.Length; t++)
            {
                dInput = inputMas[t];                
                dInput = Permut(dInput, Pi);
                string LdInput = dInput.Substring(0, 32);
                string RdInput = dInput.Remove(0, 32);
                string[] KeysMassive = keyExp(dKey); // получение ключей
                for (int i = 0; i < 16; i++) //сам алгоритм
                {
                    string buf = RdInput;
                    RdInput = XOR(Feishtel(RdInput, KeysMassive[i]), LdInput); 
                    LdInput = buf;
                }
                dInput = RdInput + LdInput; // в конце левая и правая часть не меняются                
                dInput = Permut(dInput, Fp);
                dInput = StringFromBinaryToNormalFormat(dInput);                
                en += dInput;
            }
            return en;
        }
        public string Dencription() //блок расшифровки
        {
            string den = "";
            for (int t = 0; t < inputMas.Length; t++)
            {
                dInput = inputMas[t];                
                dInput = Depermut(dInput, Fp);
                string RdInput = dInput.Substring(0, 32);
                string LdInput = dInput.Remove(0, 32);
                string[] KeysMassive = keyExp(dKey);
                for (int i = 15; i >= 0; i--)
                {
                    string buf = RdInput;
                    RdInput = LdInput;
                    LdInput = XOR(Feishtel(RdInput, KeysMassive[i]), buf);
                }
                dInput = LdInput + RdInput;               
                dInput = Depermut(dInput, Pi);
                dInput = StringFromBinaryToNormalFormat(dInput);
                den += dInput;                
            }
            return den;
        }
        private string Depermut(string str, int[] p) // обратная перестановка
        {
            string newInput = "";
            for (int i = 1; i < 65; i++)
            {
                newInput += str[Array.IndexOf(p, i)];
            }
            return newInput;
        }
        private string Permut(string str, int[] p)
        {
            string newInput = "";
            for (int i = 0; i < p.Length; i++)
            {
                newInput += str[p[i] - 1]; 
            }
            return newInput;
        }       
        private string StringFromBinaryToNormalFormat(string input)
        {
            string output = "";
            while (input.Length > 0)
            {
                string charBinary = input.Substring(0, 8);
                input = input.Remove(0, 8);                                               
                int a = BinaryToDecimal(charBinary);
                byte[] ans = { (byte)a };
                output += Encoding.GetEncoding(1251).GetString(ans);
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
            input = Permut(input, Ep);
            string xorstr = XOR(input, Key);
            string h = "";
            string[] S = new String[8];
            for (int i = 0; i < 8; i++)
            {
                S[i] = xorstr.Substring(0, 6);
                xorstr = xorstr.Remove(0, 6);
                S[i] = sBox(S[i], i);
                h += S[i];
            }
            h = Permut(h, Dp);          
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
            int c = S[i, a, b];
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
                k1 += Key[Pkey1[i]-1];
                k2 += Key[Pkey2[i]-1];                
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
                    kk += KeyMas[i][Cp[j]-1];
                }
                KeyMas[i] = kk;
            }
            return KeyMas;
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
    }
}
