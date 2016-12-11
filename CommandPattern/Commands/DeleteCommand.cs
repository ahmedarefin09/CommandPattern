using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandPattern.Commands
{
    public class DeleteCommand : ICommand
    {
        private CommandReceiver _commandReceiver;
        private string _text;
        

        public DeleteCommand(CommandReceiver commandReceiver)
        {
            _commandReceiver = commandReceiver;
        }
        public void Execute()
        {
            _text = _commandReceiver.Delete();
        }

        public string GetCommandDetails()
        {
            return "Delete Command";
        }

        public void Redo()
        {
            Execute();
        }

        public void Undo()
        {
            _commandReceiver.Insert(_text); ;
        }
    }
}
