using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SpotifyHotkeys.ViewModels
{
    /// <summary>
    /// A base class that handles boilerplate code for invoking setting a property and invoking PropertyChanged.
    /// </summary>
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        /// <summary>The handler for the event PropertyChanged. This will be invoked whenever SetProperty, or OnPropertyChanged, is called.</summary>
        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        /// <summary>
        /// Sets the value of the given property and calls PropertyChanged on the given property.
        /// </summary>
        /// <typeparam name="T">The type of property and value.</typeparam>
        /// <param name="property">The property whose value should be replaced with the given value.</param>
        /// <param name="value">The value that should be set on the property.</param>
        /// <param name="propertyName">The name of the property. Note that this parameter can be excluded from the call, given [CallerMemberName], if the compiler
        /// supports [CallerMemberName].</param>
        /// <returns>True if the value was new and false if it was the same as the old one.</returns>
        protected virtual bool SetProperty<T>(ref T property, T value, [CallerMemberName] string propertyName = "")
        {
            if (!IsObjectNull(property) && property.Equals(value))
            {
                return false;
            }

            property = value;
            OnPropertyChanged(propertyName);

            return true;
        }

        /// <summary>
        /// Invokes PropertyChanged with the given property name.
        /// </summary>
        /// <param name="propertyName">The property name that should be used for the PropertyChangedEventArgs.</param>
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        private bool IsObjectNull<T>(T obj)
        {
            return !typeof(T).IsValueType && obj == null;
        }
    }
}