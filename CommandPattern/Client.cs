using CommandPattern.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandPattern
{
    public class Client
    {
        Invoker invoker = new Invoker();
        CommandReceiver receiver = new CommandReceiver();

        public Client()
        {
            TestInsert();
            TestDelete();
            TestRead();
            TestUpdate();

            TestCommandsMix();
        }

        private void TestCommandsMix()
        {
            InsertCommand insert1 = new InsertCommand(receiver, "1");
            InsertCommand insert2 = new InsertCommand(receiver, "2");
            DeleteCommand delete1 = new DeleteCommand(receiver);
            UpdateCommand update1 = new UpdateCommand(receiver,0,"updated 1");
            ReadCommand read = new ReadCommand(receiver, 0);

            invoker.SetCommand(insert1);
            invoker.SetCommand(insert2);
            invoker.SetCommand(update1);
            invoker.SetCommand(delete1);
            invoker.SetCommand(read);

            invoker.ExecuteCommand();
            invoker.ExecuteCommand();
            invoker.UndoCommand();
            invoker.ExecuteCommand();
            invoker.RedoCommand();
            invoker.UndoCommand();
            invoker.ExecuteCommand();
            invoker.UndoCommand();
            invoker.RedoCommand();
            receiver.Print();
        }

        public void TestInsert()
        {
            InsertCommand insert = new InsertCommand(receiver, "1");

            invoker.SetCommand(insert);
            receiver.Print();
            invoker.ExecuteCommand();
            receiver.Print();
            invoker.UndoCommand();
            receiver.Print();
            invoker.RedoCommand();
            receiver.Print();

        }

        public void TestUpdate()
        {
            InsertCommand insert3 = new InsertCommand(receiver, "3");
            UpdateCommand updateCommand = new UpdateCommand(receiver,1,"updated string");

            invoker.SetCommand(insert3);
            invoker.ExecuteCommand();

            invoker.SetCommand(updateCommand);
            receiver.Print();
            invoker.ExecuteCommand();
            receiver.Print();
            invoker.UndoCommand();
            receiver.Print();
            invoker.RedoCommand();
            receiver.Print();

        }


        public void TestDelete()
        {
            InsertCommand insert3 = new InsertCommand(receiver, "2");
            DeleteCommand deleteCommand = new DeleteCommand(receiver);

            invoker.SetCommand(insert3);
            invoker.ExecuteCommand();

            invoker.SetCommand(deleteCommand);
            receiver.Print();
            invoker.ExecuteCommand();
            receiver.Print();
            invoker.UndoCommand();
            receiver.Print();
            invoker.RedoCommand();
            receiver.Print();

        }

        public void TestRead()
        {
            InsertCommand insert01 = new InsertCommand(receiver, "2");
            ReadCommand readCommand01 = new ReadCommand(receiver, 0);

            invoker.SetCommand(insert01);
            invoker.ExecuteCommand();

            invoker.SetCommand(readCommand01);
            receiver.Print();
            invoker.ExecuteCommand();
            receiver.Print();
            invoker.UndoCommand();
            receiver.Print();
            invoker.RedoCommand();
            receiver.Print();

        }

    }
}
