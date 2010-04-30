using System;
using System.Text;

namespace AojReport.AojPrintEngine.AojPrintBarCode
{
    class AojPrintITF
    {
        private const string index = "0123456789";

        private static string[] code = {"11331",
                                        "31113",
                                        "13113",
                                        "33111",
                                        "11313",
                                        "31311",
                                        "13311",
                                        "11133",
                                        "31131",
                                        "13131"};

        internal static string Decode(string value, bool checkDigit)
        {

            StringBuilder result = new StringBuilder();
            int checkAdder = 0;
            int findIndex = 0;
            char[] temp = new char[10];

            if (String.IsNullOrEmpty(value))
            {
                return null;
            }
            if ((value.Length % 2) != 0)
            {
                if (!checkDigit)
                {
                    value = "0" + value;
                }
            }
            else
            {
                if (checkDigit)
                {
                    value = "0" + value;
                }
            }

            for (int i = 0; i < value.Length; i++)
            {

                findIndex = index.IndexOf(value[i]);

                if (findIndex < 0)
                {
                    return null;
                }
                else
                {
                    if ((i % 2) == 0)
                    {
                        for (int j = 0; j < code[findIndex].Length; j++)
                        {
                            temp[j * 2] = code[findIndex][j];
                            
                        }

                        if (checkDigit)
                        {
                            checkAdder += findIndex * 3;
                        }
                    }
                    else
                    {
                        for (int j = 0; j < code[findIndex].Length; j++)
                        {
                            temp[j * 2 + 1] = (char)((int)code[findIndex][j] - 1);
                        }
                        result.Append(new string(temp));

                        if (checkDigit)
                        {
                            checkAdder += findIndex;
                        }
                    }
                }
            }

            if (checkDigit)
            {
                checkAdder = checkAdder % 10;

                if (checkAdder != 0)
                {
                    checkAdder = 10 - checkAdder;
                }

                for (int j = 0; j < code[checkAdder].Length; j++)
                {
                    temp[j * 2 + 1] = (char)((int)code[checkAdder][j] - 1);
                }
                result.Append(new string(temp));
            }
            return "1010" + result.ToString() + "301";
        }
    }
}
