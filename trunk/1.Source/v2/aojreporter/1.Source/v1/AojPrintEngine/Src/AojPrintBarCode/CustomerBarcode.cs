using System;
using System.Text;
using System.Text.RegularExpressions;

namespace AojReport.AojPrintEngine.AojPrintBarCode
{
    class AojPrintCustomerBarcode
    {
        //CC1:( CC2:) CC3:{ CC4:} CC5:[ CC6:] CC7:< CC8:>
        private const string index = "0123456789-(){}[]<>";

        private static string[] code = {"144",
                                        "114",
                                        "132",
                                        "312",
                                        "123",
                                        "141",
                                        "321",
                                        "213",
                                        "231",
                                        "411",
                                        "414",
                                        "324",
                                        "342",
                                        "234",
                                        "432",
                                        "243",
                                        "423",
                                        "441",
                                        "111"};

        private const string indexCustomer = "0123456789-ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        private static string[] codeCustomer = {"0",
                                                "1",
                                                "2",
                                                "3",
                                                "4",
                                                "5",
                                                "6",
                                                "7",
                                                "8",
                                                "9",
                                                "-",
                                                "(0",
                                                "(1",
                                                "(2",
                                                "(3",
                                                "(4",
                                                "(5",
                                                "(6",
                                                "(7",
                                                "(8",
                                                "(9",
                                                ")0",
                                                ")1",
                                                ")2",
                                                ")3",
                                                ")4",
                                                ")5",
                                                ")6",
                                                ")7",
                                                ")8",
                                                ")9",
                                                "{0",
                                                "{1",
                                                "{2",
                                                "{3",
                                                "{4",
                                                "{5"};


        internal static string Decode(string value, bool convert)
        {
            string barcodeValue = "";
            string barcodeChar = "";
            int checkAdder = 0;
            StringBuilder temp = new StringBuilder();

            if (String.IsNullOrEmpty(value))
            {
                return null;
            }

            if(value.Replace("-","").Length < 7){
                return null;
            }
            
            if (convert)
            {
                barcodeValue = ConvertCustomerBarcode(value);

                if (barcodeValue == null)
                {
                    return null;
                }
            }
            else
            {

                if (value.Length >= 7)
                {
                    barcodeValue = value;
                }
            }


            for (int i = 0; i < barcodeValue.Length; i++)
            {
                temp.Append(codeCustomer[indexCustomer.IndexOf(barcodeValue[i])]);
            }

            //20桁を超えていれば切り捨て、足りなければCC4で20桁まで埋める
            if (temp.Length > 20)
            {
                barcodeChar = temp.ToString().Substring(0, 20);
            }
            else
            {
                barcodeChar = temp.ToString().PadRight(20, '}');
            }

            temp.Length = 0;
            //バーコードデータへの変換と、チェックデジットの計算
            for (int i = 0; i < barcodeChar.Length; i++)
            {
                temp.Append(code[index.IndexOf(barcodeChar[i])]);
                checkAdder += index.IndexOf(barcodeChar[i]);
            }

            //合計が19の倍数になるようにチェックデジットをつける
            checkAdder = 19 - (checkAdder % 19);

            if (checkAdder == 19)
            {
                checkAdder = 0;
            }

            //スタート、ストップをつけてリターン
            return "13" + temp.ToString() + code[checkAdder] + "31";

        }

        //住所(郵便番号+方書)をカスタマーバーコードに変換する
        private static string ConvertCustomerBarcode(string value)
        {
            StringBuilder result = new StringBuilder();
            StringBuilder esc = new StringBuilder();
            string yubin;
            string analize = value;

            //郵便番号の切り出し
            //ハイフン混じりか確認
            if (analize.IndexOf('-') == 3)
            {
                yubin = analize.Substring(0, 3) + analize.Substring(4, 4);
                analize = analize.Substring(8);
            }
            else
            {
                yubin = analize.Substring(0, 7);
                analize = analize.Substring(7);
            }
            //郵便番号が数値で得られなければリターン
            if (!IsNumber(yubin))
            {
                return null;
            }

            result.Append(yubin);

            //抜き出しの基本ルール適用
            analize = ClearData(analize);
            
            //アルファベットが連続する場合には、ハイフンに置換
            analize = Regex.Replace(analize, "[A-Z][A-Z]+", "-");

            //ハイフンが連続する場合にはひとつにまとめる
            analize = Regex.Replace(analize, "-+", "-");

            //前後のハイフンを抜く
            analize = Regex.Replace(analize, "^-+|-+$", "");

            //アルファベットの前後のハイフンを取り除きつつ、リターン用オブジェクトに移動
            for (int i = 0; i < analize.Length; i++)
            {
                //ハイフンがきたら
                if (analize[i] == '-')
                {
                    //もし、前後いずれかに数値以外があれば、
                    if (i > 0)
                    {
                        if ("0123456789".IndexOf(analize[i - 1]) < 0)
                        {
                            continue;
                        }
                    }
                    if ((i + 1) < analize.Length)
                    {
                        if ("0123456789".IndexOf(analize[i + 1]) < 0)
                        {
                            continue;
                        }
                    }
                }

                result.Append(analize[i]);
            }

            return result.ToString();
        }

        //入力データの整形を行う
        private static string ClearData(string value)
        {
            StringBuilder result = new StringBuilder();

            for (int i = 0; i < value.Length; i++)
            {
                //フルスキャン
                switch (value[i])
                {

                    //データ内にあるアルファベットの小文字は大文字に置き換えます。
                    case 'Ａ':
                    case 'ａ':
                    case 'A':
                    case 'a':
                        result.Append('A');
                        break;
                    case 'Ｂ':
                    case 'ｂ':
                    case 'B':
                    case 'b':
                        result.Append('B');
                        break;
                    case 'Ｃ':
                    case 'ｃ':
                    case 'C':
                    case 'c':
                        result.Append('C');
                        break;
                    case 'Ｄ':
                    case 'ｄ':
                    case 'D':
                    case 'd':
                        result.Append('D');
                        break;
                    case 'Ｅ':
                    case 'ｅ':
                    case 'E':
                    case 'e':
                        result.Append('E');
                        break;
                    case 'Ｆ':
                    case 'ｆ':
                    case 'F':
                    case 'f':
                        //補足ルール
                        //数字の後のF(○○ビル2FのF)をハイフンに置換
                        if ((result.Length > 0) && (IsNumber(result[result.Length - 1])))
                        {
                            result.Append('-');
                        }
                        else
                        {
                            result.Append('F');
                        }
                        break;
                    case 'Ｇ':
                    case 'ｇ':
                    case 'G':
                    case 'g':
                        result.Append('G');
                        break;
                    case 'Ｈ':
                    case 'ｈ':
                    case 'H':
                    case 'h':
                        result.Append('H');
                        break;
                    case 'Ｉ':
                    case 'ｉ':
                    case 'I':
                    case 'i':
                        result.Append('I');
                        break;
                    case 'Ｊ':
                    case 'ｊ':
                    case 'J':
                    case 'j':
                        result.Append('J');
                        break;
                    case 'Ｋ':
                    case 'ｋ':
                    case 'K':
                    case 'k':
                        result.Append('K');
                        break;
                    case 'Ｌ':
                    case 'ｌ':
                    case 'L':
                    case 'l':
                        result.Append('L');
                        break;
                    case 'Ｍ':
                    case 'ｍ':
                    case 'M':
                    case 'm':
                        result.Append('M');
                        break;
                    case 'Ｎ':
                    case 'ｎ':
                    case 'N':
                    case 'n':
                        result.Append('N');
                        break;
                    case 'Ｏ':
                    case 'ｏ':
                    case 'O':
                    case 'o':
                        result.Append('O');
                        break;
                    case 'Ｐ':
                    case 'ｐ':
                    case 'P':
                    case 'p':
                        result.Append('P');
                        break;
                    case 'Ｑ':
                    case 'ｑ':
                    case 'Q':
                    case 'q':
                        result.Append('Q');
                        break;
                    case 'Ｒ':
                    case 'ｒ':
                    case 'R':
                    case 'r':
                        result.Append('R');
                        break;
                    case 'Ｓ':
                    case 'ｓ':
                    case 'S':
                    case 's':
                        result.Append('S');
                        break;
                    case 'Ｔ':
                    case 'ｔ':
                    case 'T':
                    case 't':
                        result.Append('T');
                        break;
                    case 'Ｕ':
                    case 'ｕ':
                    case 'U':
                    case 'u':
                        result.Append('U');
                        break;
                    case 'Ｖ':
                    case 'ｖ':
                    case 'V':
                    case 'v':
                        result.Append('V');
                        break;
                    case 'Ｗ':
                    case 'ｗ':
                    case 'W':
                    case 'w':
                        result.Append('W');
                        break;
                    case 'Ｘ':
                    case 'ｘ':
                    case 'X':
                    case 'x':
                        result.Append('X');
                        break;
                    case 'Ｙ':
                    case 'ｙ':
                    case 'Y':
                    case 'y':
                        result.Append('Y');
                        break;
                    case 'Ｚ':
                    case 'ｚ':
                    case 'Z':
                    case 'z':
                        result.Append('Z');
                        break;

                    case '1':
                    case '１':
                        result.Append('1');
                        break;
                    case '2':
                    case '２':
                        result.Append('2');
                        break;
                    case '3':
                    case '３':
                        result.Append('3');
                        break;
                    case '4':
                    case '４':
                        result.Append('4');
                        break;
                    case '5':
                    case '５':
                        result.Append('5');
                        break;
                    case '6':
                    case '６':
                        result.Append('6');
                        break;
                    case '7':
                    case '７':
                        result.Append('7');
                        break;
                    case '8':
                    case '８':
                        result.Append('8');
                        break;
                    case '9':
                    case '９':
                        result.Append('9');
                        break;
                    case '0':
                    case '０':
                        result.Append('0');
                        break;

                    //データ内にある"&"等の下記の文字は取り除き、後ろのデータを詰めます。
                    //(「&」(アンパサンド)、「/」(スラッシュ)、「・」(中グロ)、「.」(ピリオド))
                    case '&':
                    case '＆':
                    case '/':
                    case '／':
                    case '・':
                    case '.':
                        break;

                    //抜き出しの補足ルール
                    //１．漢数字が下記の特定文字の前にある場合は抜き出し対象とし、算用数字に変換して抜き出す。
                    //特定文字群(9種類) "丁目"　 "丁 "　"番地" 　"番"　 "号" 　"地割" 　"線"　 "の" 　"ノ" 
                    //丁目→丁に集約
                    //番地→番に集約
                    case '丁':
                    case '番':
                    case '号':
                    case '線':
                    case 'の':
                    case 'ノ':
                        //前の文字を数値に直しに行く
                        result.Append(ConvertJapaneseNumber(value, i));
                        break;
                    case '地':
                        //次の文字を見て、"地割"であるか、確認
                        if (value.Length > i + 1)
                        {
                            if (value[i + 1] == '割')
                            {
                                //前の文字を数値に直しに行く
                                result.Append(ConvertJapaneseNumber(value, i));
                            }
                        }
                        break;

                    //該当以外の文字は、ハイフンに置換
                    default:
                        result.Append("-");
                        break;

                }
            }

            return result.ToString();
        }

        //指定された前の文字をできる限り数字にして返す
        private static string ConvertJapaneseNumber(string value, int index)
        {

            //仮参照用のアクセスポイント
            StringBuilder result;
            //1～1000まで
            StringBuilder digit1 = new StringBuilder();
            //10000～
            StringBuilder digit2 = new StringBuilder();
            //100000000～
            StringBuilder digit3 = new StringBuilder();

            result = digit1;

            long carryer = 0;


            //漢数字として判定できる範囲の文字列を抜き出す。
            for (int i = index - 1; i >= 0; i--)
            {
                //億
                switch (value[i])
                {
                    case '〇':
                        result.Insert(0, "0");
                        break;
                    case '一':
                        AddValue(result, 1, carryer);
                        carryer = 0;
                        break;
                    case '二':
                        AddValue(result, 2, carryer);
                        carryer = 0;
                        break;
                    case '三':
                        AddValue(result, 3, carryer);
                        carryer = 0;
                        break;
                    case '四':
                        AddValue(result, 4, carryer);
                        carryer = 0;
                        break;
                    case '五':
                        AddValue(result, 5, carryer);
                        carryer = 0;
                        break;
                    case '六':
                        AddValue(result, 6, carryer);
                        carryer = 0;
                        break;
                    case '七':
                        AddValue(result, 7, carryer);
                        carryer = 0;
                        break;
                    case '八':
                        AddValue(result, 8, carryer);
                        carryer = 0;
                        break;
                    case '九':
                        AddValue(result, 9, carryer);
                        carryer = 0;
                        break;
                    case '十':
                        if (carryer != 0)
                        {
                            AddValue(result, 1, carryer);
                        }
                        carryer = 10;
                        break;
                    case '百':
                        if (carryer != 0)
                        {
                            AddValue(result, 1, carryer);
                        }
                        carryer = 100;
                        break;
                    case '千':
                        if (carryer != 0)
                        {
                            AddValue(result, 1, carryer);
                        }
                        carryer = 1000;
                        break;
                    case '万':
                        if (carryer != 0)
                        {
                            AddValue(result, 1, carryer);
                        }
                        result = digit2;
                        break;
                    case '億':
                        if (carryer != 0)
                        {
                            AddValue(result, 1, carryer);
                        }
                        result = digit3;
                        break;

                    default:
                        goto OutOfTarget;
                }
            }

            OutOfTarget:

            //最後の繰り上がり
            if (carryer != 0)
            {
                AddValue(result, 1, carryer);
            }

            //上位の桁が存在する場合は桁埋めする
            result = new StringBuilder();
            result.Append(digit3.ToString());
            //億の桁が存在する場合
            if (result.Length > 0)
            {
                result.Append(digit2.ToString().PadLeft(4, '0'));
            }
            else
            {
                result.Append(digit2.ToString());
            }
            //上位の桁が存在する場合
            if (result.Length > 0)
            {
                result.Append(digit1.ToString().PadLeft(4, '0'));
            }
            else
            {
                result.Append(digit1.ToString());
            }

            return result.ToString();

        }

        //数値を加算する
        private static void AddValue(StringBuilder result, long value, long carryer)
        {
            long temp;
            if (carryer == 0)
            {
                result.Insert(0, value);
            }
            else
            {
                long.TryParse(result.ToString(), out temp);
                result.Length = 0;
                result.Append(temp + (value * carryer));
            }
        }

        //数値であるか判別する
        private static bool IsNumber(char value)
        {
            return IsNumber(value.ToString());
        }

        //数値であるか判別する
        private static bool IsNumber(string value)
        {
            long result;
            return long.TryParse(value, out result);
        }


    }
}
