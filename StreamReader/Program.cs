using System;
using System.Text;

namespace StreamReader
{
    internal class Program
    {
        private static void Main()
        {
            var path = @"File_encode_ch866.txt";
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            using (var sr = new System.IO.StreamReader(path, Encoding.GetEncoding(866)))
            {
                while (sr.Read() != 0)
                {
                    string stringToRead;
                    while ((stringToRead = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(stringToRead);
                    }
                }
            }

            Console.ReadKey();
        }
    }
}
