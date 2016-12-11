using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandPattern.Commands
{
    public class Invoker
    {
        public Queue<ICommand> pendingCommandList = new Queue<ICommand>();
        public Stack<ICommand> undoCommandList = new Stack<ICommand>();
        public Stack<ICommand> redoCommandList = new Stack<ICommand>();

        public void SetCommand(ICommand command)
        {
            pendingCommandList.Enqueue(command);
            Console.WriteLine("Command Set:"+command.GetCommandDetails());
        }

        public void ExecuteCommand()
        {
            if (pendingCommandList.Count>0)
            {
                ICommand command = pendingCommandList.Dequeue();
                Console.WriteLine("Executing command. "+ command.GetCommandDetails());
                command.Execute();

                undoCommandList.Push(command);
            }
            else
            {
                Console.WriteLine("No commands to execute");
            }
        }

        public void UndoCommand()
        {
            if (undoCommandList.Count > 0)
            {
                ICommand command = undoCommandList.Pop();
                Console.WriteLine("Undoing command. " + command.GetCommandDetails() );
                command.Undo();
                redoCommandList.Push(command);
            }
            else
            {
                Console.WriteLine("No commands to execute");
            }
        }


        public void RedoCommand()
        {
            if (redoCommandList.Count > 0)
            {
                ICommand command = redoCommandList.Pop();
                Console.WriteLine("Redoing command. " + command.GetCommandDetails() );
                command.Redo();
                undoCommandList.Push(command);
            }
            else
            {
                Console.WriteLine("No commands to execute");
            }
        }

    }
}
