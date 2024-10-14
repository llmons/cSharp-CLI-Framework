using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnixLike.Cli;

public class CommandParsingException : Exception
{
    public CommandParsingException(CommandLineApplication command, string message)
        : base(message)
    {
        Command = command;
    }

    public CommandLineApplication Command { get; }
}
