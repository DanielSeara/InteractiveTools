
using System.Windows.Input;

namespace NDSoft.WPF;
/// <summary>
/// Generic Command for WPF actions
/// </summary>
/// <seealso cref="System.Windows.Input.ICommand" />
public class RelayCommand : ICommand
{
   private Action _execute;
   private Func<bool> _canExecute;

   public RelayCommand(Action execute, Func<bool> canExecute)
   {
      _execute = execute ?? throw new ArgumentNullException(nameof(execute));
      _canExecute = canExecute;
   }

   public RelayCommand(Action execute)
       : this(execute, null) { }

   /// <summary>
   /// Occurs when changes occur that affect whether or not the command should execute.
   /// </summary>
   public event EventHandler CanExecuteChanged;

   /// <summary>
   /// Defines the method that determines whether the command can execute in its current state.
   /// </summary>
   /// <param name="parameter">Data used by the command.  If the command does not require data to be passed, this object can be set to <see langword="null" />.</param>
   /// <returns>
   ///   <see langword="true" /> if this command can be executed; otherwise, <see langword="false" />.
   /// </returns>
   public bool CanExecute(object parameter) => _canExecute?.Invoke() ?? true;
   /// <summary>
   /// Defines the method to be called when the command is invoked.
   /// </summary>
   /// <param name="parameter">Data used by the command.  If the command does not require data to be passed, this object can be set to <see langword="null" />.</param>
   public void Execute(object parameter) => _execute();
   /// <summary>
   /// Raises the can execute changed event.
   /// </summary>
   public void RaiseCanExecuteChanged() => CanExecuteChanged?.Invoke(this, EventArgs.Empty);
}
