using System;
using System.Windows.Input;

namespace SpotifyHotkeys
{
    /// <summary>
    /// Generic version of <see cref="RelayCommand"/>. It has the same functionality with the added
    /// functionality of not having to cast the object parameters for the Actions and Predicates.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class RelayCommand<T> : ICommand
    {
        private const string ArgumentTypeException = "The type of the given argument does not match the type of T: ";

        /// <summary>Represents the method that will be called to check if the command can execute.</summary>
        private readonly Predicate<T> _canExecute;

        /// <summary>Represents the method that will be called upon execution.</summary>
        private readonly Action<T> _execute;

        /// <summary>
        /// Creates a new RelayCommand that will always execute without checking if it can.
        /// </summary>
        /// <param name="execute">The method that will be called upon execution.</param>
        public RelayCommand(Action<T> execute) : this(execute, null) { }

        /// <summary>
        /// Creates a new RelayCommand that will only execute if the given predicate canExecute returns true.
        /// </summary>
        /// <param name="execute">The method that will be called upon execution.</param>
        /// <param name="canExecute">The method that will be called to check if the command can execute.</param>
        public RelayCommand(Action<T> execute, Predicate<T> canExecute)
        {
            if (execute == null) throw new ArgumentNullException("execute");
            _canExecute = canExecute;
            _execute = execute;
        }

        public bool CanExecute(object parameter)
        {
            if (_canExecute == null)
            {
                return true;
            }
            if (parameter.GetType() == typeof(T))
            {
                return _canExecute((T)parameter);
            }

            throw new ArgumentException(ArgumentTypeException + typeof(T));
        }

        public event EventHandler CanExecuteChanged
        {
            add
            {
                if (_canExecute != null)
                {
                    CommandManager.RequerySuggested += value;
                }
            }
            remove
            {
                if (_canExecute != null)
                {
                    CommandManager.RequerySuggested -= value;
                }
            }
        }

        public void Execute(object parameter)
        {
            if (parameter.GetType() == typeof(T))
            {
                _execute((T)parameter);
            }
            else
            {
                throw new ArgumentException(ArgumentTypeException + typeof(T));
            }
        }
    }

    /// <summary>
    /// Non-generic version of <see cref="RelayCommand{T}"/>
    /// </summary>
    public class RelayCommand : ICommand
    {
        private readonly Predicate<object> _canExecute;

        private readonly Action<object> _execute;

        public RelayCommand(Action<object> execute) : this(execute, null) { }

        public RelayCommand(Action<object> execute, Predicate<object> canExecute)
        {
            _canExecute = canExecute;
            _execute = execute;
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute == null || _canExecute(parameter);
        }

        public event EventHandler CanExecuteChanged
        {
            add
            {
                if (_canExecute != null)
                {
                    CommandManager.RequerySuggested += value;
                }
            }
            remove
            {
                if (_canExecute != null)
                {
                    CommandManager.RequerySuggested -= value;
                }
            }
        }

        public void Execute(object parameter)
        {
            _execute(parameter);
        }
    }
}