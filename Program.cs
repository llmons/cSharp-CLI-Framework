global using static mycmd.ColorizeConsole.AnsiConstants;
using mycmd;
using mycmd.Cli;

var app = new CommandLineApplication(throwOnUnexpectedArg: false)
{
    Name = "erp"
};

new RootCommand().Configure(app);

return app.Execute(args);