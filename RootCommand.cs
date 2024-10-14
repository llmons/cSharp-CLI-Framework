using UnixLike.ColorizeConsole;
using UnixLike.Cli;
using UnixLike.Command;

namespace UnixLike
{
    internal class RootCommand : CommandBase
    {

        public override void Configure(CommandLineApplication app)
        {
            base.Configure(app);
            app.FullName = "cli app";
            app.Description = "cli app by Jianghao Liang";
            app.Command("fib",new Fibonacci().Configure);
            app.OnExecute(Execute);
        }

        protected override int Execute(string[] args)
        {

            return 0;
        }
    }
}
