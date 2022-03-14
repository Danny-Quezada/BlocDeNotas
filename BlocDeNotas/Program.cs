using Autofac;
using BlocDeNotas.AppCore.IServices;
using BlocDeNotas.AppCore.Services;
using BlocDeNotas.Domain.Interfaces;
using BlocDeNotas.Forms;
using BlocDeNotas.Infraestructure.Repository.Streams;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlocDeNotas
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var builder = new ContainerBuilder();

            //builder.RegisterType<TasksListRepository>().As<ITaskRepository>();
            builder.RegisterType<DirectoryRepository>().As <IDirectoryRepository>();
            builder.RegisterType<DirectoryServices>().As<IDirectoryServices>();
            Application.EnableVisualStyles();
            var container = builder.Build();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmBloc(container.Resolve<IDirectoryServices>()));
        }
    }
}
