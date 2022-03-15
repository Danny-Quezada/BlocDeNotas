using BlocDeNotas.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BlocDeNotas.Infraestructure.Repository.Streams
{
    public class DirectoryRepository : IDirectoryRepository
    {
        private BinaryReader streamReader;
        private StreamWriter streamWriter;

        public bool CheckRoute(string path)
        {
            if (Path.HasExtension(path))
            {
                return true;
            }
            return false;
        }

        public DirectoryInfo Create(string t)
        {
            DirectoryInfo info = new DirectoryInfo(t);
            return Directory.CreateDirectory(t);
        }

        public DirectoryInfo CreateFile(string path, string name)
        {

            using (FileStream fileStream = File.Create(path + @"\\" + name))
            {
                fileStream.Close();
            }
            DirectoryInfo info = Get(path + name);
            return info;
        }

        public void Delete(string t)
        {
            Directory.Delete(t);
        }

        public DirectoryInfo Get(string t)
        {
            return new DirectoryInfo(t);
        }

        public void OverWrite(string path, string text)
        {
            using (FileStream file = new FileStream(path, FileMode.Truncate, FileAccess.Write))
            {
                streamWriter = new StreamWriter(file);
                streamWriter.Write(text);
                streamWriter.Close();
                file.Close();
            }

        }

        public string Read(string path)
        {
            string words = "";
            using (FileStream file = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                
                streamReader = new BinaryReader(file);
                long length = streamReader.BaseStream.Length / sizeof(int);
                words = File.ReadAllText(path);
                streamReader.Close();
                file.Close();
            }

            return words;
        }
    }
}
