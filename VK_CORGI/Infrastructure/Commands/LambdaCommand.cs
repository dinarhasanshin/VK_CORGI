using System;
using System.Collections.Generic;
using System.Text;
using VK_CORGI.Infrastructure.Commands.Base;

namespace VK_CORGI.Infrastructure.Commands
{
    internal class LambdaCommand : Command
    {
        private readonly Action<object> _Execute;
        private readonly Func<object, bool> _CanExecute;

        public LambdaCommand(Action<object> Execute, Func<object, bool> CanExecute = null)
        {
            _Execute = Execute ?? throw new ArgumentNullException(nameof(Execute));//Проверка на передачу в Execute данных.
            _CanExecute = CanExecute;
        }
        /// <summary>
        /// Проверка, может ли выполниться команда
        /// </summary>
        /// <param name="Параметр команды"></param>
        /// <returns></returns>
        public override bool CanExecute(object parameter) => _CanExecute?.Invoke(parameter) ?? true;


        /// <summary>
        /// Действия выполняемые командой
        /// </summary>
        /// <param name="Параметр команды"></param>
        public override void Execute(object parameter) => _Execute(parameter);
    }
}
