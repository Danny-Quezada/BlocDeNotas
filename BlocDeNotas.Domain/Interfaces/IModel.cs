using System;
using System.Collections.Generic;
using System.Text;

namespace BlocDeNotas.Domain.Interfaces
{
    public interface IModel<T>
    {
        T Create(string t);
        string Read(string path);

        void OverWrite(string path,string text);
    }
}
