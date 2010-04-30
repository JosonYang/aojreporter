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

            //20���𒴂��Ă���ΐ؂�̂āA����Ȃ����CC4��20���܂Ŗ��߂�
            if (temp.Length > 20)
            {
                barcodeChar = temp.ToString().Substring(0, 20);
            }
            else
            {
                barcodeChar = temp.ToString().PadRight(20, '}');
            }

            temp.Length = 0;
            //�o�[�R�[�h�f�[�^�ւ̕ϊ��ƁA�`�F�b�N�f�W�b�g�̌v�Z
            for (int i = 0; i < barcodeChar.Length; i++)
            {
                temp.Append(code[index.IndexOf(barcodeChar[i])]);
                checkAdder += index.IndexOf(barcodeChar[i]);
            }

            //���v��19�̔{���ɂȂ�悤�Ƀ`�F�b�N�f�W�b�g������
            checkAdder = 19 - (checkAdder % 19);

            if (checkAdder == 19)
            {
                checkAdder = 0;
            }

            //�X�^�[�g�A�X�g�b�v�����ă��^�[��
            return "13" + temp.ToString() + code[checkAdder] + "31";

        }

        //�Z��(�X�֔ԍ�+����)���J�X�^�}�[�o�[�R�[�h�ɕϊ�����
        private static string ConvertCustomerBarcode(string value)
        {
            StringBuilder result = new StringBuilder();
            StringBuilder esc = new StringBuilder();
            string yubin;
            string analize = value;

            //�X�֔ԍ��̐؂�o��
            //�n�C�t�������肩�m�F
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
            //�X�֔ԍ������l�œ����Ȃ���΃��^�[��
            if (!IsNumber(yubin))
            {
                return null;
            }

            result.Append(yubin);

            //�����o���̊�{���[���K�p
            analize = ClearData(analize);
            
            //�A���t�@�x�b�g���A������ꍇ�ɂ́A�n�C�t���ɒu��
            analize = Regex.Replace(analize, "[A-Z][A-Z]+", "-");

            //�n�C�t�����A������ꍇ�ɂ͂ЂƂɂ܂Ƃ߂�
            analize = Regex.Replace(analize, "-+", "-");

            //�O��̃n�C�t���𔲂�
            analize = Regex.Replace(analize, "^-+|-+$", "");

            //�A���t�@�x�b�g�̑O��̃n�C�t������菜���A���^�[���p�I�u�W�F�N�g�Ɉړ�
            for (int i = 0; i < analize.Length; i++)
            {
                //�n�C�t����������
                if (analize[i] == '-')
                {
                    //�����A�O�ア���ꂩ�ɐ��l�ȊO������΁A
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

        //���̓f�[�^�̐��`���s��
        private static string ClearData(string value)
        {
            StringBuilder result = new StringBuilder();

            for (int i = 0; i < value.Length; i++)
            {
                //�t���X�L����
                switch (value[i])
                {

                    //�f�[�^���ɂ���A���t�@�x�b�g�̏������͑啶���ɒu�������܂��B
                    case '�`':
                    case '��':
                    case 'A':
                    case 'a':
                        result.Append('A');
                        break;
                    case '�a':
                    case '��':
                    case 'B':
                    case 'b':
                        result.Append('B');
                        break;
                    case '�b':
                    case '��':
                    case 'C':
                    case 'c':
                        result.Append('C');
                        break;
                    case '�c':
                    case '��':
                    case 'D':
                    case 'd':
                        result.Append('D');
                        break;
                    case '�d':
                    case '��':
                    case 'E':
                    case 'e':
                        result.Append('E');
                        break;
                    case '�e':
                    case '��':
                    case 'F':
                    case 'f':
                        //�⑫���[��
                        //�����̌��F(�����r��2F��F)���n�C�t���ɒu��
                        if ((result.Length > 0) && (IsNumber(result[result.Length - 1])))
                        {
                            result.Append('-');
                        }
                        else
                        {
                            result.Append('F');
                        }
                        break;
                    case '�f':
                    case '��':
                    case 'G':
                    case 'g':
                        result.Append('G');
                        break;
                    case '�g':
                    case '��':
                    case 'H':
                    case 'h':
                        result.Append('H');
                        break;
                    case '�h':
                    case '��':
                    case 'I':
                    case 'i':
                        result.Append('I');
                        break;
                    case '�i':
                    case '��':
                    case 'J':
                    case 'j':
                        result.Append('J');
                        break;
                    case '�j':
                    case '��':
                    case 'K':
                    case 'k':
                        result.Append('K');
                        break;
                    case '�k':
                    case '��':
                    case 'L':
                    case 'l':
                        result.Append('L');
                        break;
                    case '�l':
                    case '��':
                    case 'M':
                    case 'm':
                        result.Append('M');
                        break;
                    case '�m':
                    case '��':
                    case 'N':
                    case 'n':
                        result.Append('N');
                        break;
                    case '�n':
                    case '��':
                    case 'O':
                    case 'o':
                        result.Append('O');
                        break;
                    case '�o':
                    case '��':
                    case 'P':
                    case 'p':
                        result.Append('P');
                        break;
                    case '�p':
                    case '��':
                    case 'Q':
                    case 'q':
                        result.Append('Q');
                        break;
                    case '�q':
                    case '��':
                    case 'R':
                    case 'r':
                        result.Append('R');
                        break;
                    case '�r':
                    case '��':
                    case 'S':
                    case 's':
                        result.Append('S');
                        break;
                    case '�s':
                    case '��':
                    case 'T':
                    case 't':
                        result.Append('T');
                        break;
                    case '�t':
                    case '��':
                    case 'U':
                    case 'u':
                        result.Append('U');
                        break;
                    case '�u':
                    case '��':
                    case 'V':
                    case 'v':
                        result.Append('V');
                        break;
                    case '�v':
                    case '��':
                    case 'W':
                    case 'w':
                        result.Append('W');
                        break;
                    case '�w':
                    case '��':
                    case 'X':
                    case 'x':
                        result.Append('X');
                        break;
                    case '�x':
                    case '��':
                    case 'Y':
                    case 'y':
                        result.Append('Y');
                        break;
                    case '�y':
                    case '��':
                    case 'Z':
                    case 'z':
                        result.Append('Z');
                        break;

                    case '1':
                    case '�P':
                        result.Append('1');
                        break;
                    case '2':
                    case '�Q':
                        result.Append('2');
                        break;
                    case '3':
                    case '�R':
                        result.Append('3');
                        break;
                    case '4':
                    case '�S':
                        result.Append('4');
                        break;
                    case '5':
                    case '�T':
                        result.Append('5');
                        break;
                    case '6':
                    case '�U':
                        result.Append('6');
                        break;
                    case '7':
                    case '�V':
                        result.Append('7');
                        break;
                    case '8':
                    case '�W':
                        result.Append('8');
                        break;
                    case '9':
                    case '�X':
                        result.Append('9');
                        break;
                    case '0':
                    case '�O':
                        result.Append('0');
                        break;

                    //�f�[�^���ɂ���"&"���̉��L�̕����͎�菜���A���̃f�[�^���l�߂܂��B
                    //(�u&�v(�A���p�T���h)�A�u/�v(�X���b�V��)�A�u�E�v(���O��)�A�u.�v(�s���I�h))
                    case '&':
                    case '��':
                    case '/':
                    case '�^':
                    case '�E':
                    case '.':
                        break;

                    //�����o���̕⑫���[��
                    //�P�D�����������L�̓��蕶���̑O�ɂ���ꍇ�͔����o���ΏۂƂ��A�Z�p�����ɕϊ����Ĕ����o���B
                    //���蕶���Q(9���) "����"�@ "�� "�@"�Ԓn" �@"��"�@ "��" �@"�n��" �@"��"�@ "��" �@"�m" 
                    //���ځ����ɏW��
                    //�Ԓn���ԂɏW��
                    case '��':
                    case '��':
                    case '��':
                    case '��':
                    case '��':
                    case '�m':
                        //�O�̕����𐔒l�ɒ����ɍs��
                        result.Append(ConvertJapaneseNumber(value, i));
                        break;
                    case '�n':
                        //���̕��������āA"�n��"�ł��邩�A�m�F
                        if (value.Length > i + 1)
                        {
                            if (value[i + 1] == '��')
                            {
                                //�O�̕����𐔒l�ɒ����ɍs��
                                result.Append(ConvertJapaneseNumber(value, i));
                            }
                        }
                        break;

                    //�Y���ȊO�̕����́A�n�C�t���ɒu��
                    default:
                        result.Append("-");
                        break;

                }
            }

            return result.ToString();
        }

        //�w�肳�ꂽ�O�̕������ł�����萔���ɂ��ĕԂ�
        private static string ConvertJapaneseNumber(string value, int index)
        {

            //���Q�Ɨp�̃A�N�Z�X�|�C���g
            StringBuilder result;
            //1�`1000�܂�
            StringBuilder digit1 = new StringBuilder();
            //10000�`
            StringBuilder digit2 = new StringBuilder();
            //100000000�`
            StringBuilder digit3 = new StringBuilder();

            result = digit1;

            long carryer = 0;


            //�������Ƃ��Ĕ���ł���͈͂̕�����𔲂��o���B
            for (int i = index - 1; i >= 0; i--)
            {
                //��
                switch (value[i])
                {
                    case '�Z':
                        result.Insert(0, "0");
                        break;
                    case '��':
                        AddValue(result, 1, carryer);
                        carryer = 0;
                        break;
                    case '��':
                        AddValue(result, 2, carryer);
                        carryer = 0;
                        break;
                    case '�O':
                        AddValue(result, 3, carryer);
                        carryer = 0;
                        break;
                    case '�l':
                        AddValue(result, 4, carryer);
                        carryer = 0;
                        break;
                    case '��':
                        AddValue(result, 5, carryer);
                        carryer = 0;
                        break;
                    case '�Z':
                        AddValue(result, 6, carryer);
                        carryer = 0;
                        break;
                    case '��':
                        AddValue(result, 7, carryer);
                        carryer = 0;
                        break;
                    case '��':
                        AddValue(result, 8, carryer);
                        carryer = 0;
                        break;
                    case '��':
                        AddValue(result, 9, carryer);
                        carryer = 0;
                        break;
                    case '�\':
                        if (carryer != 0)
                        {
                            AddValue(result, 1, carryer);
                        }
                        carryer = 10;
                        break;
                    case '�S':
                        if (carryer != 0)
                        {
                            AddValue(result, 1, carryer);
                        }
                        carryer = 100;
                        break;
                    case '��':
                        if (carryer != 0)
                        {
                            AddValue(result, 1, carryer);
                        }
                        carryer = 1000;
                        break;
                    case '��':
                        if (carryer != 0)
                        {
                            AddValue(result, 1, carryer);
                        }
                        result = digit2;
                        break;
                    case '��':
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

            //�Ō�̌J��オ��
            if (carryer != 0)
            {
                AddValue(result, 1, carryer);
            }

            //��ʂ̌������݂���ꍇ�͌����߂���
            result = new StringBuilder();
            result.Append(digit3.ToString());
            //���̌������݂���ꍇ
            if (result.Length > 0)
            {
                result.Append(digit2.ToString().PadLeft(4, '0'));
            }
            else
            {
                result.Append(digit2.ToString());
            }
            //��ʂ̌������݂���ꍇ
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

        //���l�����Z����
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

        //���l�ł��邩���ʂ���
        private static bool IsNumber(char value)
        {
            return IsNumber(value.ToString());
        }

        //���l�ł��邩���ʂ���
        private static bool IsNumber(string value)
        {
            long result;
            return long.TryParse(value, out result);
        }


    }
}
