using System;
using System.Collections.Generic;
using System.Text;

namespace BlocDeNotas.AppCore.IServices
{
   public interface IServices<T>
    {
        T Create(string t);
        string Read(string path);

        void OverWrite(string path, string text);

    }
}
