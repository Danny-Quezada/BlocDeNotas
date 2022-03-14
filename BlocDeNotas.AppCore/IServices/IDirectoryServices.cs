using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BlocDeNotas.AppCore.IServices
{
    public interface IDirectoryServices: IServices<DirectoryInfo>
    {
        bool CheckRoute(string path);
        void Delete(string t);

        DirectoryInfo Get(string t);
        DirectoryInfo CreateFile(string path, string name);
    }
}
