using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandPattern.Commands
{
    public class CommandReceiver
    {
        public List<string> commandTextList = new List<string>();
        
        public void Print()
        {
            Console.WriteLine("----------- Start of Printing List--------------");
            foreach (string str in commandTextList)
                Console.WriteLine(str);
            Console.WriteLine("----------- End of Printing List--------------");
        }
        

        internal string Read(int position,bool print = true)
        {
            string readString = string.Empty;
            if (commandTextList.Count > position)
            {
                readString = commandTextList[position];
                if(print)
                    Console.WriteLine(string.Format("Read text at position {0}: {1}",position, readString));
            }
            else
            {
                Console.WriteLine("Error in reading");
            }
            return readString;
        }

        internal string Delete()
        {
            string deletedText = null;
            if (commandTextList.Count > 0)
            {
                deletedText = commandTextList.LastOrDefault();
                commandTextList.RemoveAt(commandTextList.Count-1);
                Console.WriteLine("Deleted text: " + deletedText);
            }
            else
            {
                Console.WriteLine("No items to delete");
            }
            return deletedText;
        }

        internal void Update(int position, string newVal)
        {
            if(commandTextList.Count> position)
            {
                string oldValue = commandTextList[position];
                commandTextList[position] = newVal;
                Console.WriteLine(string.Format("Updated text from {0}, to {1}" ,oldValue, newVal));
            }
            else
            {
                Console.WriteLine("Cannot read.Position out of bound");
            }
        }

        internal void Insert(string text)
        {
            commandTextList.Add(text);
            Console.WriteLine("Inserted text: " + text);
        }
    }
}
