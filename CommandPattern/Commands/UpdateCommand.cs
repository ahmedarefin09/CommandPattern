using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandPattern.Commands
{
    public class UpdateCommand : ICommand
    {
        private CommandReceiver _commandReceiver;
        private int _position;
        private string newVal;
        private string oldval;

        public UpdateCommand(CommandReceiver commandReceiver, int position,string newString)
        {
            _commandReceiver = commandReceiver;
            _position = position;
            newVal = newString;
        }
        public void Execute()
        {
            oldval = _commandReceiver.Read(_position,false);
            _commandReceiver.Update(_position,newVal);
        }

        public void Redo()
        {
            SwapValues();
        }

        public void SwapValues()
        {
            newVal = oldval;
            oldval = _commandReceiver.Read(_position, false);
            _commandReceiver.Update(_position, newVal);

        }

        public void Undo()
        {
            SwapValues();
        }
        public string GetCommandDetails()
        {
            return "Update Command";
        }
    }
}
