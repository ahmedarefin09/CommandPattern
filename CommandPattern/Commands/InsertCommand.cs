using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandPattern.Commands
{
    public class InsertCommand : ICommand
    {
        private CommandReceiver _commandReceiver;
        private string _text;
        

        public InsertCommand(CommandReceiver commandReceiver, string text)
        {
            _commandReceiver = commandReceiver;
            _text = text;
        }
        public void Execute()
        {
            _commandReceiver.Insert(_text); 
        }

        public void Redo()
        {
            Execute();
        }

        public void Undo()
        {
            _commandReceiver.Delete();
        }

        public string GetCommandDetails()
        {
            return "Insert Command";
        }
    }
}
