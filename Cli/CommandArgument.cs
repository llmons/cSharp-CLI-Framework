using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mycmd.Cli;

public class CommandArgument
{
    public CommandArgument()
    {
        Values = new List<string>();
    }

    public string? Name { get; set; }
    public string? Description { get; set; }
    public List<string> Values { get; }
    public bool MultipleValues { get; set; }

    public string? Value
        => Values.FirstOrDefault();
}
