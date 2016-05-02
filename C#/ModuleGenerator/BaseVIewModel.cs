using System;
using System.ComponentModel;

namespace ModuleGenerator
{
    abstract class BaseViewModel<ViewType, ModelType> : INotifyPropertyChanged, IDisposable where ViewType : IWindow where ModelType : IModel
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private readonly ViewType view;
        private readonly ModelType model;

        public ViewType View
        {
            get
            {
                return this.view;
            }
        }

        public ModelType Model
        {
            get
            {
                return this.model;
            }
        }

        public BaseViewModel(ViewType view, ModelType model)
        {
            this.view = view;
            this.model = model;

            this.View.DataContext = this;
        }

        public void Notify(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void Dispose()
        {

        }
    }
}
