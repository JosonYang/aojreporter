
using System;
using System.Text;

namespace AojReport.AojPrintEngine.AojPrintBarCode
{
    class AojPrintCODE128
    {

        private const string indexa = @" !/#$%&`()*+'-./0123456789:;<=>?@ABCDEFGHIJKLMNOPQRSTUVWXYZ[\]^_";
        private const string indexb = @" !/#$%&`()*+'-./0123456789:;<=>?@ABCDEFGHIJKLMNOPQRSTUVWXYZ[\]^_`abcdefghijklmnopqrstuvwxyz{|}~";
        private const string indexc = @"00-01-02-03-04-05-06-07-08-09-10-11-12-13-14-15-16-17-18-19-20-21-22-23-24-25-26-27-28-29-30-31-32-33-34-35-36-37-38-39-40-41-42-43-44-45-46-47-48-49-50-51-52-53-54-55-56-57-58-59-60-61-62-63-64-65-66-67-68-69-70-71-72-73-74-75-76-77-78-79-80-81-82-83-84-85-86-87-88-89-90-91-92-93-94-95-96-97-98-99-CB-CA-F1";

        private static string[] code = {"303232",
                                        "323032",
                                        "323230",
                                        "121234",
                                        "121432",
                                        "141232",
                                        "123214",
                                        "123412",
                                        "143212",
                                        "321214",
                                        "321412",
                                        "341212",
                                        "103252",
                                        "123052",
                                        "123250",
                                        "105232",
                                        "125032",
                                        "125230",
                                        "325210",
                                        "321052",
                                        "321250",
                                        "305212",
                                        "325012",
                                        "503050",
                                        "501232",
                                        "521032",
                                        "521230",
                                        "503212",
                                        "523012",
                                        "523210",
                                        "303034",
                                        "303430",
                                        "343030",
                                        "101434",
                                        "141034",
                                        "141430",
                                        "103414",
                                        "143014",
                                        "143410",
                                        "301414",
                                        "341014",
                                        "341410",
                                        "103054",
                                        "103450",
                                        "143050",
                                        "105034",
                                        "105430",
                                        "145030",
                                        "505030",
                                        "301450",
                                        "341050",
                                        "305014",
                                        "305410",
                                        "305050",
                                        "501034",
                                        "501430",
                                        "541030",
                                        "503014",
                                        "503410",
                                        "543010",
                                        "507010",
                                        "321610",
                                        "741010",
                                        "101236",
                                        "101632",
                                        "121036",
                                        "121630",
                                        "161032",
                                        "161230",
                                        "103216",
                                        "103612",
                                        "123016",
                                        "123610",
                                        "163012",
                                        "163210",
                                        "361210",
                                        "321016",
                                        "705010",
                                        "361012",
                                        "147010",
                                        "101272",
                                        "121072",
                                        "121270",
                                        "107212",
                                        "127012",
                                        "127210",
                                        "701212",
                                        "721012",
                                        "721210",
                                        "303070",
                                        "307030",
                                        "703030",
                                        "101074",
                                        "101470",
                                        "141070",
                                        "107014",
                                        "107410",
                                        "701014",
                                        "701410",
                                        "105070",
                                        "107050",
                                        "501070",
                                        "701050"};

        internal static string Decode(string value)
        {

            StringBuilder result = new StringBuilder();
            int checkAdder = 0;
            int findIndex = 0;
            string index;
            bool isCodeC = false;
            int degitIndex = 1;

            if (String.IsNullOrEmpty(value))
            {
                return null;
            }

            switch(value[0]){
                case '‚`':
                    result.Append("301612");
                    index = indexa;
                    checkAdder = 103;
                    break;
                case '‚a':
                    result.Append("301216");
                    index = indexb;
                    checkAdder = 104;
                    break;
                case '‚b':
                    result.Append("301252");
                    index = indexc;
                    checkAdder = 105;
                    isCodeC = true;
                    break;
                default:
                    result.Append("301252");
                    value = "‚b" + value;
                    index = indexc;
                    checkAdder = 105;
                    isCodeC = true;
                    break;
            }


            for (int i = 1; i < value.Length; i++)
            {

                if (isCodeC)
                {
                    if ((i + 1) < value.Length)
                    {
                        findIndex = index.IndexOf(value.Substring(i,2));
                    }
                    else
                    {
                        findIndex = index.IndexOf(value[i] + "0");
                    }
                    if (findIndex != -1)
                    {
                        findIndex /= 3;
                        i++;
                    }
                }
                else
                {
                    findIndex = index.IndexOf(value[i]);
                }

                if (findIndex < 0)
                {
                    switch (value[i])
                    {
                        case '‚`':
                            result.Append("501070");
                            index = indexa;
                            isCodeC = false;
                            checkAdder = 101 * degitIndex;
                            break;
                        case '‚a':
                            result.Append("107050");
                            index = indexb;
                            isCodeC = false;
                            checkAdder = 100 * degitIndex;
                            break;
                        case '‚b':
                            result.Append("105070");
                            index = indexc;
                            isCodeC = true;
                            checkAdder = 99 * degitIndex;
                            break;
                        default:
                            return null;
                    }
                }
                else
                {
                    result.Append(code[findIndex]);

                    checkAdder += (findIndex * degitIndex);
                }
                degitIndex++;
            }
            result.Append(code[checkAdder % 103]);

            return result.ToString() + "3450103";
        }

    }
}
