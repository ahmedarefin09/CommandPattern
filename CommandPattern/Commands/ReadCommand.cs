using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandPattern.Commands
{
    public class ReadCommand : ICommand
    {
        private CommandReceiver _commandReceiver;
        private int _position;
        

        public ReadCommand(CommandReceiver commandReceiver, int position)
        {
            _commandReceiver = commandReceiver;
            _position = position;
        }
        public void Execute()
        {
            _commandReceiver.Read(_position);
        }

        public void Redo()
        {
            Console.WriteLine("Redo not supported");
        }

        public void Undo()
        {
            Console.WriteLine("Undo not supported");
        }

        public string GetCommandDetails()
        {
            return "Read Command";
        }
    }
}
