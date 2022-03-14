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
        private BinaryWriter streamWriter;

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
            using (FileStream file = new FileStream(path, FileMode.Append, FileAccess.Write))
            {
                streamWriter = new BinaryWriter(file);
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
                streamReader.BaseStream.Seek(0, SeekOrigin.Begin);
                words = File.ReadAllText(path);
                //while (streamReader.BaseStream.Position < length)
                //{
                //    words += streamReader.ReadString();
                //}

                streamReader.Close();
                file.Close();
            }

            return words;
        }
    }
}
