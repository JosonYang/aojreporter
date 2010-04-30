
using System;
using System.Text;

namespace AojReport.AojPrintEngine.AojPrintBarCode
{
    class AojPrintCODE39
    {
        private const string index = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ-. $/+%";

        private static string[] code = {"101230301",
                                        "301210103",
                                        "103210103",
                                        "303210101",
                                        "101230103",
                                        "301230101",
                                        "103230101",
                                        "101210303",
                                        "301210301",
                                        "103210301",
                                        "301012103",
                                        "103012103",
                                        "303012101",
                                        "101032103",
                                        "301032101",
                                        "103032101",
                                        "101012303",
                                        "301012301",
                                        "103012301",
                                        "101032301",
                                        "301010123",
                                        "103010123",
                                        "303010121",
                                        "101030123",
                                        "301030121",
                                        "103030121",
                                        "101010323",
                                        "301010321",
                                        "103010321",
                                        "101030321",
                                        "321010103",
                                        "123010103",
                                        "323010101",
                                        "121030103",
                                        "321030101",
                                        "123030101",
                                        "121010303",
                                        "321010301",
                                        "123010301",
                                        "121212101",
                                        "121210121",
                                        "121012121",
                                        "101212121"};

        internal static string Decode(string value, bool checkDigit)
        {

            StringBuilder result = new StringBuilder();
            int checkAdder = 0;
            int findIndex = 0;

            if (String.IsNullOrEmpty(value))
            {
                return null;
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

                result.Append(code[checkAdder % 43]);

                result.Append("0");
            }

            return "1210303010" + result.ToString() + "121030301";
        }
    }
}
