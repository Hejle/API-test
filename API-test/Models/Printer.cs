using System;
using System.Collections.Generic;
using System.Linq;
using System.Printing;
using System.Web;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Drawing;
using System.IO;
using System.Drawing.Printing;

namespace API_test.Models
{
    public class Printer
    {
        
        public string printerName { get; set; }
        private StreamReader streamToPrint;
        private Font printFont;


        public void PrintText(string text)
        {

           /* try
            {
                streamToPrint = new StreamReader("C:\\My Documents\\MyFile.txt");
                try
                {
                    printFont = new Font("Arial", 10);
                    PrintDocument pd = new PrintDocument();
                    pd.
                    pd.PrintPage += new PrintPageEventHandler(this.pd_PrintPage(, thtext));
                    pd.Print();
                }
                finally
                {
                    streamToPrint.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            } */

        }

        /*private void pd_PrintPage(object sender, string text)
        {
            float linesPerPage = 0;
            float yPos = 0;
            int count = 0;
            float leftMargin = ev.MarginBounds.Left;
            float topMargin = ev.MarginBounds.Top;
            string line = null;

            // Calculate the number of lines per page.
            linesPerPage = ev.MarginBounds.Height /
               printFont.GetHeight(ev.Graphics);

            // Print each line of the file.
            while (count < linesPerPage &&
               ((line = streamToPrint.ReadLine()) != null))
            {
                yPos = topMargin + (count *
                   printFont.GetHeight(ev.Graphics));
                ev.Graphics.DrawString(line, printFont, Brushes.Black,
                   leftMargin, yPos, new StringFormat());
                count++;
            }

            // If more lines exist, print another page.
            if (line != null)
                ev.HasMorePages = true;
            else
                ev.HasMorePages = false;
        } */



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