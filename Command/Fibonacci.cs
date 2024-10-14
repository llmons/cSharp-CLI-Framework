using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnixLike.Cli;

namespace UnixLike.Command
{
    internal class Fibonacci : CommandBase
    {
        private CommandOption? N { get; set; }

        public override void Configure(CommandLineApplication app)
        {
            base.Configure(app); // 加一句，即可默认添加 -h和-v 参数
            app.FullName = "Fibonacci";
            app.Description = "Get fibonacci by param";
            N = app.Option("-n:<value>", "n的值，根据该值返回fib值，该值大于等于1");
            app.OnExecute(Execute);
        }

        protected override int Execute(string[] args)
        {
            if(!int.TryParse(N!.Value(),out var n))Console.WriteLine("param n need");

            Console.WriteLine(Fib(n));

            return 0;

            int Fib(int paramN)=> paramN switch
            {
                1 => 1,
                2 => 1,
                _ => Fib(paramN - 1) + Fib(paramN - 2)
            };
        }
    }
}