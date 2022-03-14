using BlocDeNotas.AppCore.IServices;
using BlocDeNotas.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlocDeNotas.AppCore.Services
{
    public abstract class BaseServices<T> : IServices<T>
    {
        private IModel<T> model;
        protected BaseServices(IModel<T> cModel)
        {
            this.model = cModel;
        }
        public T Create(string t)
        {
            return model.Create(t);
        }

        public void OverWrite(string path, string text)
        {
            model.OverWrite(path, text);
        }

        public String Read(string path)
        {
            return model.Read(path);
        }
    }
}
