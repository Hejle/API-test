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
        private Font printFont = new Font("Times New Roman", 12, FontStyle.Regular, GraphicsUnit.Millimeter));
        private StreamReader streamToPrint;


        public void PrintText(string text)
        {
            
            PrintDocument p = new PrintDocument();
            p.DefaultPageSettings.PaperSize = new PaperSize("210 x 297 mm", 300, 300);
            p.DefaultPageSettings.Margins.Left = 50;
            float leftMargin = p.DefaultPageSettings.Margins.Left;
            float topMargin = p.DefaultPageSettings.Margins.Top;
            float productLength = 200;
            float margin = 20;
            string[] a = { "Mælk", "Ost", "Æbler", "FladPandeÆblekugleFormerMaskineSkrællerDimsedut"};
            string[] priser = {"7.95", "35.50", "2.00", "99,95"};
            Graphics g = p.PrinterSettings.CreateMeasurementGraphics();

            p.PrintPage += delegate (object sender1, PrintPageEventArgs e1)
            {
                for (int i = 0; i < a.Length; i++)
                {
                     
                    var ypos = topMargin + (i * printFont.Height);
                    e1.Graphics.DrawString(a[i], printFont, new SolidBrush(Color.Black), leftMargin, ypos);

                    e1.Graphics.DrawString(priser[i], printFont, new SolidBrush(Color.Black), leftMargin + productLength + margin, ypos);
                }

                /*
                foreach (string element in a)
                {
                    e1.Graphics.DrawString(element, printFont, new SolidBrush(Color.Black),
                    new RectangleF(0, 0, p.DefaultPageSettings.PrintableArea.Width, p.DefaultPageSettings.PrintableArea.Height));
                }*/

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