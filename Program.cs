global using static UnixLike.ColorizeConsole.AnsiConstants;
using UnixLike;
using UnixLike.Cli;

var app = new CommandLineApplication(throwOnUnexpectedArg: false)
{
    Name = "erp"
};

new RootCommand().Configure(app);

return app.Execute(args);