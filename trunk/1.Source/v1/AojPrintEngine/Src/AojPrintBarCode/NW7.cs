using System;
using System.Text;

namespace AojReport.AojPrintEngine.AojPrintBarCode
{
    class AojPrintNW7
    {
        private const string index = "0123456789-$:/.+";

        private static string[] code = {"1010123",
                                        "1010321",
                                        "1012103",
                                        "3210101",
                                        "1030121",
                                        "3010121",
                                        "1210103",
                                        "1210301",
                                        "1230101",
                                        "3012101",
                                        "1012301",
                                        "1032101",
                                        "3010303",
                                        "3030103",
                                        "3030301",
                                        "1030303"};

        private static string[] control = { "1032121", "1212103", "1012123", "1012321" };


     
        internal static string Decode(string value, bool checkDigit)
        {

            StringBuilder result = new StringBuilder();

            int checkAdder = 0;
            int findIndex = 0;

            string analysis = value;
            string startChar = "";
            string endChar = "";

            if (String.IsNullOrEmpty(analysis))
            {
                return null;
            }


            switch (value[0])
            {
                case 'A':
                    startChar = control[0];
                    checkAdder += 16;
                    break;
                case 'B':
                    startChar = control[1];
                    checkAdder += 17;
                    break;
                case 'C':
                    startChar = control[2];
                    checkAdder += 18;
                    break;
                case 'D':
                    startChar = control[3];
                    checkAdder += 19;
                    break;
                default:
                    analysis = "A" + analysis;
                    checkAdder += 16;
                    startChar = control[0];
                    break;
            }
   
            switch (value[value.Length - 1])
            {
                case 'A':
                    endChar = control[0];
                    checkAdder += 16;
                    break;
                case 'B':
                    endChar = control[1];
                    checkAdder += 17;
                    break;
                case 'C':
                    endChar = control[2];
                    checkAdder += 18;
                    break;
                case 'D':
                    endChar = control[3];
                    checkAdder += 19;
                    break;
                default:
                    analysis += "A";
                    checkAdder += 16;
                    endChar = control[0];
                    break;
            }

            for (int i = 1; i < analysis.Length - 1; i++)
            {

                findIndex = index.IndexOf(analysis[i]);

                if (findIndex < 0)
                {
                    return null;
                }
                else
                {
                    result.Append(code[findIndex]);
                   
                    result.Append("0");

                    
                    if (checkDigit)
                    {
                        checkAdder += findIndex;
                    }
                }
            }

            if (checkDigit)
            {
                checkAdder = checkAdder % 16;

                if (checkAdder != 0)
                {
                    checkAdder = 16 - checkAdder;
                }

           
                result.Append(code[checkAdder]);
                
                result.Append("0");
            }

            return  startChar + "0" + result.ToString() + endChar;
        }

    }
}
