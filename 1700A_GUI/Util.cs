using ScottPlot.Drawing.Colormaps;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1700A_GUI
{
    public static class StringExtension
    {
        /// <summary>
        /// True if all characters in a string is IsDigit(true), False if not
        /// </summary>
        /// <param name="me"></param>
        /// <returns></returns>
        public static bool IsNumber(this string me)
        {
            foreach (char ch in me)
            {
                if (!Char.IsDigit(ch))
                    return false;
            }

            return true;
        }
    }
    public static class RichTextBoxExtensions
    {
        public static void AppendText(this RichTextBox box, string text, Color color)
        {
            box.SelectionStart = box.TextLength;
            box.SelectionLength = 0;

            box.SelectionColor = color;
            box.AppendText(text);
            box.SelectionColor = box.ForeColor;
        }
    }

    public static class Util
    {
        public static void showPopup(IWin32Window owner, string s)
        {
            Console.Write(s);
            var msg = new msgpopup();
            msg.msglabel.Text = s;
            msg.ShowDialog(owner);
        }
        public static string hex2binary(string hexvalue)
        {
            string s = Convert.ToString(Convert.ToInt32(hexvalue, 16), 2).PadLeft(8, '0'); ;
            return s;
        }

        public static byte[] OpenFile(string filename)
        {
            
            try
            {
                //Pass the file path and file name to the StreamReader constructor
                //StreamReader sr = new StreamReader(filename);

                //Read the first line of text
                //line = sr.ReadLine();
                ////Continue to read until you reach end of file
                //while (line != null)
                //{
                //    //write the line to console window
                //    Console.WriteLine(line);
                //    //Read the next line
                //    line = sr.ReadLine();
                //}
                ////close the file
                //sr.Close();
                byte[] fileContent = File.ReadAllBytes(filename);

                return fileContent;
                //Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
                return null;
            }
            finally
            {
                Console.WriteLine("Executing finally block.");
                
            }
        }
        public static byte[] HexToByte(string hex)
        {
            byte[] convert = new byte[hex.Length / 2];

            int length = convert.Length;
            for (int i = 0; i < length; i++)
            {
                convert[i] = Convert.ToByte(hex.Substring(i * 2), 16);
            }

            return convert;
        }

    }
}
