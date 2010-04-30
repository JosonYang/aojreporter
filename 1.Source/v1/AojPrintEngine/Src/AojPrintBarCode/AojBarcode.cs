
using System;
using System.Drawing;

namespace AojReport.AojPrintEngine.AojPrintBarCode
{
    class Barcode
    {
        internal static bool Paint(Graphics g, Rectangle rect, string value, string barcodeWidth)
        {
            string kind;
            string barcodeValue;
            int index;
            bool isBarcode = true;

            if (string.IsNullOrEmpty(barcodeWidth))
            {
                barcodeWidth = "0.7";
            }

            string blockSize = "5";

            if (String.IsNullOrEmpty(value))
            {
                return false;
            }

            if (!value.StartsWith("%"))
            {
                return false;
            }
            index = value.IndexOf("%", 1);

            if(index < 0){
                return false;
            }

            
            kind = value.Substring(1, index - 1);
            barcodeValue = value.Substring(index + 1);

            switch(kind){
                //AojPrintITF
                case "AojPrintITF":
                    PrintBarcode(g, rect, AojPrintITF.Decode(barcodeValue, false), barcodeWidth);
                    break;

                //AojPrintITF
                case "ITFC":
                    PrintBarcode(g, rect, AojPrintITF.Decode(barcodeValue, true), barcodeWidth);
                    break;

                //AojPrintNW7
                case "AojPrintNW7":
                    PrintBarcode(g, rect, AojPrintNW7.Decode(barcodeValue, false), barcodeWidth);
                    break;

                //AojPrintNW7
                case "NW7C":
                    PrintBarcode(g, rect, AojPrintNW7.Decode(barcodeValue, true), barcodeWidth);
                    break;

                //AojPrintCODE39
                case "C39":
                    PrintBarcode(g, rect, AojPrintCODE39.Decode(barcodeValue, false), barcodeWidth);
                    break;

                //AojPrintCODE39
                case "C39C":
                    PrintBarcode(g, rect, AojPrintCODE39.Decode(barcodeValue, true), barcodeWidth);
                    break;

                //AojPrintCODE128
                case "AojPrintCODE128":
                //EAN128
                case "EAN128":
                    PrintBarcode128(g, rect, AojPrintCODE128.Decode(barcodeValue), barcodeWidth);
                    break;
                case "CB":
                    PrintBarcodeCustomer(g, rect, AojPrintCustomerBarcode.Decode(barcodeValue, true));
                    break;
                case "CBC":
                    PrintBarcodeCustomer(g, rect, AojPrintCustomerBarcode.Decode(barcodeValue, false));
                    break;
                case "QRL":
                    PrintQRCode(g, rect, AojPrintQR.Decode(barcodeValue, "L"), blockSize);
                    break;
                case "AojPrintQR":
                case "QRM":
                    PrintQRCode(g, rect, AojPrintQR.Decode(barcodeValue, "M"), blockSize);
                    break;
                case "QRQ":
                    PrintQRCode(g, rect, AojPrintQR.Decode(barcodeValue, "Q"), blockSize);
                    break;
                case "QRH":
                    PrintQRCode(g, rect, AojPrintQR.Decode(barcodeValue, "H"), blockSize);
                    break;
                default:
                    isBarcode = false;
                    break;
            }

            return isBarcode;
        }

        private static void PrintBarcode(Graphics g, Rectangle rect, string barcodeValue, string barcodeWidth)
        {
            if (barcodeValue == null)
            {
                return;
            }

            float bn = float.Parse(barcodeWidth);
            float bw = bn * 2.5f;

            float x = (float)rect.X + (float.Parse(barcodeWidth) * 10);
            float y = (float)rect.Y;
            float height = (float)rect.Height;

            for (int i = 0; i < barcodeValue.Length; i++)
            {

                switch (barcodeValue[i])
                {
                    case '1':
                        //BN
                        g.FillRectangle(Brushes.Black, x, y, bn, height);
                        break;

                    case '3':
                        //BW
                        g.FillRectangle(Brushes.Black, x, y, bw, height);
                        break;
                }

                switch (barcodeValue[i])
                {
                    case '0':
                    case '1':
                        x += bn;
                        break;
                    case '2':
                    case '3':
                        x += bw;
                        break;
                }
            }
        }

        //AojPrintCODE128
        private static void PrintBarcode128(Graphics g, Rectangle rect, string barcodeValue, string barcodeWidth)
        {
            if (barcodeValue == null)
            {
                return;
            }

            float b1 = float.Parse(barcodeWidth);
            float b2 = b1 * 2f;
            float b3 = b1 * 3f;
            float b4 = b1 * 4f;

            float x = (float)rect.X + (float.Parse(barcodeWidth) * 10);
            float y = (float)rect.Y;
            float height = (float)rect.Height;

            for (int i = 0; i < barcodeValue.Length; i++)
            {

                switch (barcodeValue[i])
                {
                    case '1':
                        //BN
                        g.FillRectangle(Brushes.Black, x, y, b1, height);
                        break;

                    case '3':
                        //BW
                        g.FillRectangle(Brushes.Black, x, y, b2, height);
                        break;
                    case '5':
                        //BW
                        g.FillRectangle(Brushes.Black, x, y, b3, height);
                        break;
                    case '7':
                        //BW
                        g.FillRectangle(Brushes.Black, x, y, b4, height);
                        break;
                }
                switch (barcodeValue[i])
                {
                    case '0':
                    case '1':
                        x += b1;
                        break;
                    case '2':
                    case '3':
                        x += b2;
                        break;
                    case '4':
                    case '5':
                        x += b3;
                        break;
                    case '6':
                    case '7':
                        x += b4;
                        break;
                }
            }
        }

        private static void PrintBarcodeCustomer(Graphics g, Rectangle rect, string barcodeValue)
        {

            if (barcodeValue == null)
            {
                return;
            }
            Console.WriteLine(g.DpiX);
            
            float bw = 1.7f;
            //float bh = 3f;

            //float x = (float)rect.X + (float.Parse(barcodeWidth) * 10);
            float x = (float)rect.X;
            float y = (float)rect.Y;

            for (int i = 0; i < barcodeValue.Length; i++)
            {

                switch (barcodeValue[i])
                {
                    case '1':
                        g.FillRectangle(Brushes.Black, x, y, bw, 9f);
                        break;
                    case '2':
                        g.FillRectangle(Brushes.Black, x, y, bw, 6f);
                        break;
                    case '3':
                        g.FillRectangle(Brushes.Black, x, y + 3f, bw, 6f);
                        break;
                    case '4':
                        g.FillRectangle(Brushes.Black, x, y + 3f, bw, 3f);
                        break;
                }
                x += bw * 2;
            }

        }

        private static void PrintQRCode(Graphics g, Rectangle rect, bool[,] matrix, string blockSize)
        {
            int height = matrix.GetLength(0);
            int width = matrix.GetLength(1);
            float size = float.Parse(blockSize);
            float startx = (float)rect.X + (size * 4);
            float starty = (float)rect.Y + (size * 4);

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    if (matrix[i, j])
                    {
                        g.FillRectangle(Brushes.Black, new RectangleF(size * j + startx, size * i + starty, size, size));
                    }
                }
            }
        }

    }
}
