using BlocDeNotas.AppCore.IServices;
using BlocDeNotas.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BlocDeNotas.AppCore.Services
{
    public class DirectoryServices : BaseServices<DirectoryInfo>, IDirectoryServices
    {
        IDirectoryRepository repository;
        public DirectoryServices(IDirectoryRepository cRepository) : base(cRepository)
        {
            this.repository = cRepository;
        }

        public bool CheckRoute(string path)
        {
            return repository.CheckRoute(path);
        }

        public DirectoryInfo CreateFile(string path, string name)
        {
            return repository.CreateFile(path, name);
        }

        public void Delete(string t)
        {
            repository.Delete(t);
        }

        public DirectoryInfo Get(string t)
        {
            return repository.Get(t);
        }
    }
}
