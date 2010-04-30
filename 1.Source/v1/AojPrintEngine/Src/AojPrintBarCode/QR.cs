using System;
using System.Collections.Generic;
using System.Text;

namespace AojReport.AojPrintEngine.AojPrintBarCode
{
    class AojPrintQR
    {

        private const string index = @"0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ $%*+-./:";

        private const string indexBit = @"";

        private static int[] gx = new int[] { 0, 43, 139, 206, 78, 43, 239, 123, 206, 214, 147, 24, 99, 150, 39, 243, 163, 136 };

        private static int[] alphaToInt = new int[] {  1,2,4,8,16,32,64,128,29,58,
                                                116,232,205,135,19,38,76,152,45,90,
                                                180,117,234,201,143,3,6,12,24,48,
                                                96,192,157,39,78,156,37,74,148,53,
                                                106,212,181,119,238,193,159,35,70,140,
                                                5,10,20,40,80,160,93,186,105,210,
                                                185,111,222,161,95,190,97,194,153,47,
                                                94,188,101,202,137,15,30,60,120,240,
                                                253,231,211,187,107,214,177,127,254,225,
                                                223,163,91,182,113,226,217,175,67,134,
                                                17,34,68,136,13,26,52,104,208,189,
                                                103,206,129,31,62,124,248,237,199,147,
                                                59,118,236,197,151,51,102,204,133,23,
                                                46,92,184,109,218,169,79,158,33,66,
                                                132,21,42,84,168,77,154,41,82,164,
                                                85,170,73,146,57,114,228,213,183,115,
                                                230,209,191,99,198,145,63,126,252,229,
                                                215,179,123,246,241,255,227,219,171,75,
                                                150,49,98,196,149,55,110,220,165,87,
                                                174,65,130,25,50,100,200,141,7,14,
                                                28,56,112,224,221,167,83,166,81,162,
                                                89,178,121,242,249,239,195,155,43,86,
                                                172,69,138,9,18,36,72,144,61,122,
                                                244,245,247,243,251,235,203,139,11,22,
                                                44,88,176,125,250,233,207,131,27,54,
                                                108,216,173,71,142,1};

 
        private static int[] intToAlpha = new int[] {  0,0,1,25,2,50,26,198,3,223,
                                                51,238,27,104,199,75,4,100,224,14,
                                                52,141,239,129,28,193,105,248,200,8,
                                                76,113,5,138,101,47,225,36,15,33,
                                                53,147,142,218,240,18,130,69,29,181,
                                                194,125,106,39,249,185,201,154,9,120,
                                                77,228,114,166,6,191,139,98,102,221,
                                                48,253,226,152,37,179,16,145,34,136,
                                                54,208,148,206,143,150,219,189,241,210,
                                                19,92,131,56,70,64,30,66,182,163,
                                                195,72,126,110,107,58,40,84,250,133,
                                                186,61,202,94,155,159,10,21,121,43,
                                                78,212,229,172,115,243,167,87,7,112,
                                                192,247,140,128,99,13,103,74,222,237,
                                                49,197,254,24,227,165,153,119,38,184,
                                                180,124,17,68,146,217,35,32,137,46,
                                                55,63,209,91,149,188,207,205,144,135,
                                                151,178,220,252,190,97,242,86,211,171,
                                                20,42,93,158,132,60,57,83,71,109,
                                                65,162,31,45,67,216,183,123,164,118,
                                                196,23,73,236,127,12,111,246,108,161,
                                                59,82,41,157,85,170,251,96,134,177,
                                                187,204,62,90,203,89,95,176,156,169,
                                                160,81,11,245,22,235,122,117,44,215,
                                                79,174,213,233,230,231,173,232,116,214,
                                                244,234,168,80,88,175};


        private static int[,] type1 = new int[,]{{3,3,3,3,3,3,3,2,4,0,0,0,0,2,3,3,3,3,3,3,3},
                                        {3,2,2,2,2,2,3,2,4,0,0,0,0,2,3,2,2,2,2,2,3},
                                        {3,2,3,3,3,2,3,2,4,0,0,0,0,2,3,2,3,3,3,2,3},
                                        {3,2,3,3,3,2,3,2,4,0,0,0,0,2,3,2,3,3,3,2,3},
                                        {3,2,3,3,3,2,3,2,4,0,0,0,0,2,3,2,3,3,3,2,3},
                                        {3,2,2,2,2,2,3,2,4,0,0,0,0,2,3,2,2,2,2,2,3},
                                        {3,3,3,3,3,3,3,2,3,2,3,2,3,2,3,3,3,3,3,3,3},
                                        {2,2,2,2,2,2,2,2,4,0,0,0,0,2,2,2,2,2,2,2,2},
                                        {4,4,4,4,4,4,3,4,4,0,0,0,0,4,4,4,4,4,4,4,4},
                                        {0,0,0,0,0,0,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                                        {0,0,0,0,0,0,3,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                                        {0,0,0,0,0,0,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                                        {0,0,0,0,0,0,3,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                                        {2,2,2,2,2,2,2,2,3,0,0,0,0,0,0,0,0,0,0,0,0},
                                        {3,3,3,3,3,3,3,2,4,0,0,0,0,0,0,0,0,0,0,0,0},
                                        {3,2,2,2,2,2,3,2,4,0,0,0,0,0,0,0,0,0,0,0,0},
                                        {3,2,3,3,3,2,3,2,4,0,0,0,0,0,0,0,0,0,0,0,0},
                                        {3,2,3,3,3,2,3,2,4,0,0,0,0,0,0,0,0,0,0,0,0},
                                        {3,2,3,3,3,2,3,2,4,0,0,0,0,0,0,0,0,0,0,0,0},
                                        {3,2,2,2,2,2,3,2,4,0,0,0,0,0,0,0,0,0,0,0,0},
                                        {3,3,3,3,3,3,3,2,4,0,0,0,0,0,0,0,0,0,0,0,0}};


        internal static bool[,] Decode(string value, string level)
        {
            StringBuilder sb = new StringBuilder();
            int len = value.Length;
            Queue<int> q = new Queue<int>();


            analizeModeAndSize(value);

    
            sb.Append("0010");
  
            sb.Append(toBinary(len, 9));
            int first_code = 0;
            int second_code = 0;

    
            for (int i = 0; i < len; i += 2)
            {
                first_code = index.IndexOf(value[i]);

                if (first_code < 0)
                {
                    trace("first_code parse error");
                }

                if ((i + 1) < len)
                {
                    second_code = index.IndexOf(value[i + 1]);
                    if (second_code < 0)
                    {
                        trace("second_code parse error");
                    }
                    first_code *= 45;
                    sb.Append(toBinary(first_code + second_code, 11));
                }
                else
                {
                    sb.Append(toBinary(first_code, 6));
                }

            }


            sb.Append("0000");


            int pad = sb.Length % 8;
            if (pad != 0)
            {
                sb.Append(string.Format("{0:D" + (8 - pad) + "}", 0));
            }

            int padCount = 9 - (sb.Length / 8);

            for (int i = 0; i < padCount; i++)
            {
                if ((i % 2) == 0)
                {
                    sb.Append("11101100");
                }
                else
                {
                    sb.Append("00010001");
                }
            }

            trace(sb.ToString());

            string debugstr = sb.ToString();

            for (int i = 0; i < debugstr.Length; i += 8)
            {
                q.Enqueue(Convert.ToInt32(debugstr.Substring(i, 8), 2));
            }

            Queue<int> qt = new Queue<int>();
            galoisField(ref qt, q, q.Count - 1);

            trace("===dump===");

            while (qt.Count > 0)
            {
                trace(qt.Peek().ToString());
                sb.Append(toBinary(qt.Dequeue(), 8));
            }

            int[,] type = new int[type1.GetLength(0), type1.GetLength(1)];

            string codestr = sb.ToString();

            int x = type.GetLength(0) - 1;
            int y = type.GetLength(1) - 1;
            bool up = true;
            bool left = true;
            int codeindex = 0;

            for (int index = 0; index < type.Length; index++)
            {

                if (y < 0)
                {
                    y = 0;
                }

                trace(string.Format("x:{0} y:{1}", x, y));

                if (type1[x, y] == 0)
                {
                    if (codeindex < codestr.Length)
                    {
                        type[x, y] = charToInt(codestr[codeindex]);
                        codeindex++;
                    }
                }
                else
                {
                    type[x, y] = type1[x, y];
                }

    
                if (y == 6)
                {
                    left = false;
                }

       
                if (left)
                {
                    y--;
                    left = false;
                }
                else
                {
                    if (up)
                    {
                        if ((x - 1) < 0)
                        {
                            if (y == 6)
                            {
                                x = type.GetLength(0) - 1;
                            }
                            else
                            {
                                up = false;
                            }
                            y--;
                        }
                        else
                        {
                            x--;
                            if (y != 6)
                            {
                                y++;
                            }
                        }
                    }
                    else
                    {
                        if ((x + 1) > type.GetLength(0) - 1)
                        {
                            if (y == 6)
                            {
                                x = 0;
                            }
                            else
                            {
                                up = true;
                            }

                            y--;
                        }
                        else
                        {
                            x++;
                            if (y != 6)
                            {
                                y++;
                            }

                        }
                    }
                    left = true;

                }

                if (y == 6)
                {
                    left = false;
                }
            }


            bool[,] matrix = doMask(type, "011", "H");

            return matrix;

        }


        private static string analizeModeAndSize(string value)
        {
            Encoding shift_jis = Encoding.GetEncoding("Shift-JIS");
            byte[] analize = shift_jis.GetBytes(value);
            byte targetByte;
            int len = analize.Length;
            int stage = 0;

            for (int i = 0; i < len; i++)
            {
                targetByte = analize[i];
                trace(Convert.ToString(targetByte, 16));

             
                if ((stage == 0) && (0x30 <= targetByte) && (targetByte <= 0x39))
                {
                }
                //else if((stage <= 1) && ){
                //}
              
            }

            return null;
        }

        private static bool[,] doMask(int[,] type, string mode, string level)
        {

            bool[,] matrix = new bool[type.GetLength(0), type.GetLength(1)];
            bool temp;

            switch (mode)
            {
                //(i+j) mod 2 = 0 
                case "000":
                    for (int i = 0; i < type.GetLength(0); i++)
                    {
                        for (int j = 0; j < type.GetLength(1); j++)
                        {
                            temp = ((type[i, j] & 1) == 1);
                            switch (type[i, j])
                            {
                                case 0:
                                case 1:
                                    if (((i + j) % 2) == 0)
                                    {
                                        temp = !temp;
                                    }
                                    break;
                            }
                            matrix[i, j] = temp;
                        }
                    }
                    break;

                //(i+j) mod 3 = 0 
                case "011":
                    for (int i = 0; i < type.GetLength(0); i++)
                    {
                        for (int j = 0; j < type.GetLength(1); j++)
                        {
                            temp = ((type[i, j] & 1) == 1);
                            switch (type[i, j])
                            {
                                case 0:
                                case 1:
                                    if (((i + j) % 3) == 0)
                                    {
                                        temp = !temp;
                                    }
                                    break;
                            }
                            matrix[i, j] = temp;
                        }
                    }
                    break;
            }

            string formatData = BoseChaudhuriHocquenghem(mode, level);

            for (int i = 0; i < formatData.Length; i++)
            {
                if (formatData[i] == '1')
                {
                    switch (i)
                    {
                        case 0:
                            matrix[8, 0] = true;
                            matrix[20, 8] = true;
                            break;
                        case 1:
                            matrix[8, 1] = true;
                            matrix[19, 8] = true;
                            break;
                        case 2:
                            matrix[8, 2] = true;
                            matrix[18, 8] = true;
                            break;
                        case 3:
                            matrix[8, 3] = true;
                            matrix[17, 8] = true;
                            break;
                        case 4:
                            matrix[8, 4] = true;
                            matrix[16, 8] = true;
                            break;
                        case 5:
                            matrix[8, 5] = true;
                            matrix[15, 8] = true;
                            break;
                        case 6:
                            matrix[8, 7] = true;
                            matrix[14, 8] = true;
                            break;
                        case 7:
                            matrix[8, 8] = true;
                            matrix[8, 13] = true;
                            break;
                        case 8:
                            matrix[7, 8] = true;
                            matrix[8, 14] = true;
                            break;
                        case 9:
                            matrix[5, 8] = true;
                            matrix[8, 15] = true;
                            break;
                        case 10:
                            matrix[4, 8] = true;
                            matrix[8, 16] = true;
                            break;
                        case 11:
                            matrix[3, 8] = true;
                            matrix[8, 17] = true;
                            break;
                        case 12:
                            matrix[2, 8] = true;
                            matrix[8, 18] = true;
                            break;
                        case 13:
                            matrix[1, 8] = true;
                            matrix[8, 19] = true;
                            break;
                        case 14:
                            matrix[0, 8] = true;
                            matrix[8, 20] = true;
                            break;
                    }
                }
            }

            return matrix;

        }

        //Bose-Chaudhuri-Hocquenghem(15,5)
        private static string BoseChaudhuriHocquenghem(string mode, string level)
        {
            string result = "";
            switch (level + mode)
            {
                case "H011":
                    result = "001100111010000";
                    break;

            }

            return result;
        }

        private static int charToInt(char value)
        {
            int rest = 0;
            switch (value)
            {
                case '1':
                    rest = 1;
                    break;
            }
            return rest;
        }

        //GaloisField‚ÌŒvŽZ
        private static void galoisField(ref Queue<int> qrest, Queue<int> qin, int cascade)
        {

            if (cascade < 0)
            {
                qrest = qin;
                return;
            }

      
            int alpha = intToAlpha[qin.Dequeue()];
            int temp;

            Queue<int> qtemp = new Queue<int>();

            for (int i = 1; i < gx.Length; i++)
            {
                temp = gx[i] + alpha;
                if (temp >= 255)
                {
                    temp -= 255;
                }

                temp = alphaToInt[temp];

                if (qin.Count > 0)
                {
                 
                    temp ^= qin.Dequeue();
                }
                qtemp.Enqueue(temp);

                if (i == 1)
                {
                    trace("===cascade:" + cascade + "===");
                    trace(temp.ToString());
                }
            }

        
            galoisField(ref qrest, qtemp, cascade - 1);
        }

        private static string toBinary(int value)
        {
            return Convert.ToString(value, 2);
        }

        private static string toBinary(int value, int pad)
        {
            return toBinary(value).PadLeft(pad, '0');
        }

        private static void trace(string msg)
        {
      
        }
    }
}
