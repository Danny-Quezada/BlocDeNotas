using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BlocDeNotas.Domain.Interfaces
{
    public interface IDirectoryRepository: IModel<DirectoryInfo>
    {
        bool CheckRoute(string path);
        void Delete(string path);

        DirectoryInfo Get(string path);

        DirectoryInfo CreateFile(string path,string name);
    }
}
