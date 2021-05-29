using Prism.Mvvm;
using Prism.Navigation;

using System.Diagnostics;

namespace Skymly.JyGameStudio.Wpf.Core.Mvvm
{
    public abstract class ViewModelBase : BindableBase, IDestructible
    {

        public string Title { get; set; }

        protected ViewModelBase()
        {
            Title = this.GetType().Name;
        }

        public virtual void Destroy()
        {
            Debug.WriteLine($"{GetType().Name} {nameof(Destroy)}");
        }
    }
}
