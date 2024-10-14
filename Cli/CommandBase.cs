using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace mycmd.Cli
{
    public abstract class CommandBase
    {
#pragma warning disable CS8618 // 在退出构造函数时，不可为 null 的字段必须包含非 null 值。请考虑添加 "required" 修饰符或声明为可为 null。
        protected CommandLineApplication app;
        private CommandOption help;
        private CommandOption version;
#pragma warning restore CS8618 // 在退出构造函数时，不可为 null 的字段必须包含非 null 值。请考虑添加 "required" 修饰符或声明为可为 null。
        private List<string> args = [];
        private List<string> applicationArgs = [];

        public virtual void Configure(CommandLineApplication app)
        {
            this.app = app;
            app.FullName = Production;

            help = app.HelpOption("-h|--help");
            version = VersionOption();
            args = app.RemainingArguments;
            applicationArgs = app.ApplicationArguments;
        }

        protected virtual int Execute(string[] args)
        {
            return 0;
        }

        /// <summary>
        /// 设置显示版本的选项
        /// <para>
        /// 版本的值是程序集的版本号
        /// </para>
        /// </summary>
        /// <returns>命令选项</returns>
        protected CommandOption VersionOption()
        {
            return app.VersionOption("-v|--version", GetVersion);
        }

        /// <summary>
        /// 设置显示版本的选项
        /// </summary>
        /// <param name="version">版本号</param>
        /// <returns>命令选项</returns>
        protected CommandOption VersionOption(string version)
        {
            return app.VersionOption("-v|--version", version);
        }

        private static string GetVersion() => typeof(RootCommand).Assembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>()!.InformationalVersion;
        private static string Production => typeof(RootCommand).Assembly.GetCustomAttribute<AssemblyProductAttribute>()!.Product;
    }
}
