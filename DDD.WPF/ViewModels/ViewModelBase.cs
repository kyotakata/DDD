using Prism.Mvvm;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace DDD.WPF.ViewModels
{
    public abstract class ViewModelBase : BindableBase
    {
        public virtual DateTime GetDateTime()
        {
            return DateTime.Now;
        }
    }
}
