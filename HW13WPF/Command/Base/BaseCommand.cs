﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace HW13WPF.Command.Base
{
    public abstract class BaseCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        public abstract bool CanExecute(object? parameter);


        public abstract void Execute(object? parameter);

    }
}
