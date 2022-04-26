using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank
{
    public class FileReader : IDisposable
    {
        public string FileName { get; }

        public FileReader(string fileName)
        {
            FileName = fileName;

            // throw new FileNotFoundException();
            Console.WriteLine("Abrindo arquivo: " + fileName);
        }

        public string ReadNextLine()
        {
            Console.WriteLine("Lendo linha. . .");

            // throw new IOException();
            return "Linha do arquivo";
        }

        public void Dispose()
        {
            Console.WriteLine("Fechando arquivo.");
        }
    }
}
