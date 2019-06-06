using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FX_Exchange.Helpers
{
    public class DataWriter : IDataWriter
    {
        public void WriteData(string input)
        {
            Console.WriteLine(input);
        }

        public void WriteError(string error)
        {
            Console.WriteLine($"Error: {error}");
            Console.WriteLine();
        }

        public void WriteResult(decimal? input)
        {
            Console.WriteLine($"Result: {input}");
            Console.WriteLine();
        }

        void IDataWriter.WriteInstructions()
        {
            Console.WriteLine("FX exchange console Application");
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("Enter currency pairs and amount. ");
            Console.WriteLine("Type - Exchange <currency>/<currency> <amount>");
            Console.WriteLine("Example - Exchange EUR/DKK 1");
            Console.WriteLine();
        }
    }

    public interface IDataWriter
    {
        void WriteResult(decimal? input);
        void WriteData(string input);
        void WriteInstructions();
        void WriteError(string error);
    }
}
