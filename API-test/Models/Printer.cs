using System.Printing;
using System;
using System.IO;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace API_test.Models
{
    public class Printer
    {
        
        public string printerName { get; set; }
        private Font printFont = new Font("Times New Roman", 12, FontStyle.Regular, GraphicsUnit.Millimeter);
        private StreamReader streamToPrint;


        public void PrintReceipt(Receipt receipt)
        {
            
            PrintDocument p = new PrintDocument();
            p.DefaultPageSettings.PaperSize = new PaperSize("210 x 297 mm", 800, 800);
            p.DefaultPageSettings.Margins.Left = 50;
            float leftMargin = p.DefaultPageSettings.Margins.Left;
            float topMargin = p.DefaultPageSettings.Margins.Top;
            float productLength = 250;
            float margin = 20;
            string[] a = { "Mælk", "Ost", "Æbler", "FladPandeÆblekugleFormerMaskineSkrællerDimsedut"};
            string[] priser = {"7.95", "35.50", "2.00", "99,95"};
            Graphics g = p.PrinterSettings.CreateMeasurementGraphics();
            var list = receipt.getProducts();
            p.PrintPage += delegate (object sender1, PrintPageEventArgs e1)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    var price = list[i].Product.Price * receipt.getProducts()[i].Quantity;
                    var productText = list[i].Product.ProductName;
                    string truncatedProductText = TruncateText(productText, printFont, productLength, false, g);
                    var ypos = topMargin + (i * printFont.Height);
                    e1.Graphics.DrawString(productText, printFont, new SolidBrush(Color.Black), leftMargin, ypos);

                    e1.Graphics.DrawString(String.Format("{0:0.00}", price), printFont, new SolidBrush(Color.Black), leftMargin + productLength + margin, ypos);
                }

            };


            try
            {
                p.Print();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //throw new Exception("Exception Occured While Printing", ex);
            }
        }


        /// <summary>
        /// Truncates the string to be smaller than the desired width.
        /// </summary>
        /// <param name="font">The font used to determine the size of the string.</param>
        /// <param name="width">The maximum size the string should be after truncating.</param>
        /// <param name="direction">The direction of the truncation. True for left (…ext), False for right(Tex…).</param>
        private string TruncateText(string text, Font font, float width, bool direction, Graphics g)
        {
            string truncatedText, returnText;
            int charIndex = 0;
            bool truncated = false;
            //When the user is typing and the truncation happens in a TextChanged event, already typed text could get lost.
            //Example: Imagine that the string "Hello Worl" would truncate if we add 'd'. Depending on the font the output 
            //could be: "Hello Wor…" (notice the 'l' is missing). This is an undesired effect.
            //To prevent this from happening the ellipsis is included in the initial sizecheck.
            //At this point, the direction is not important so we place ellipsis behind the text.
            truncatedText = text + "…";

            //Get the size of the string in milimeters.
            SizeF size = g.MeasureString(truncatedText, font);

            //Do while the string is bigger than the desired width.
            while (size.Width > width)
            {
                //Go to next char
                charIndex++;

                //If the character index is larger than or equal to the length of the text, the truncation is unachievable.
                if (charIndex >= text.Length)
                {
                    //Truncation is unachievable!

                    //Throw exception so the user knows what's going on.
                    throw new IndexOutOfRangeException("The desired width of the string is too small to truncate to.");
                }
                else
                {
                    //Truncation is still applicable!

                    //Raise the flag, indicating that text is truncated.
                    truncated = true;

                    //Check which way to text should be truncated to, then remove one char and add an ellipsis.
                    if (direction)
                    {
                        //Truncate to the left. Add ellipsis and remove from the left.
                        truncatedText = "…" + text.Substring(charIndex);
                    }
                    else
                    {
                        //Truncate to the right. Remove from the right and add the ellipsis.
                        truncatedText = text.Substring(0, text.Length - charIndex) + "…";
                    }

                    //Measure the string again.
                    size = g.MeasureString(truncatedText, font);
                }
            }
            //If the text got truncated, change the return value to the truncated text.
            if (truncated) returnText = truncatedText;
            else returnText = text;
            //Return the desired text.
            return returnText;
        }


        private PrintQueue FindPrinter(string printerName)
        {
            var printers = new PrintServer().GetPrintQueues();
            foreach (var printer in printers)
            {
                if (printer.FullName == printerName)
                {
                    return printer;
                }
            }
            return LocalPrintServer.GetDefaultPrintQueue();
        }
    
    
    
    }   
}