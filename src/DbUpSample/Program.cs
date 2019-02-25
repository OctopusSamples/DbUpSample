using System;
using System.IO;
using System.Linq;
using System.Reflection;
using DbUp;
using DbUp.Engine;
using DbUp.Helpers;
using DbUp.Support;

namespace DbUpSample
{
    class Program
    {
        static void Main(string[] args)
        {
            var connectionString = args.FirstOrDefault(x => x.StartsWith("--ConnectionString", StringComparison.OrdinalIgnoreCase));

            connectionString = connectionString.Substring(connectionString.IndexOf("=") + 1).Replace(@"""", string.Empty);

            var upgradeEngineBuilder = DeployChanges.To
                .SqlDatabase(connectionString, null)
                .WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly(), x => x.StartsWith("DbUpSample.BeforeDeploymentScripts."), new SqlScriptOptions { ScriptType = ScriptType.RunAlways, RunGroupOrder = 0 })
                .WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly(), x => x.StartsWith("DbUpSample.DeploymentScripts"), new SqlScriptOptions { ScriptType = ScriptType.RunOnce, RunGroupOrder = 1 })
                .WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly(), x => x.StartsWith("DbUpSample.PostDeploymentScripts."), new SqlScriptOptions { ScriptType = ScriptType.RunAlways, RunGroupOrder = 2 })
                .WithTransactionPerScript()
                .LogToConsole();

            var upgrader = upgradeEngineBuilder.Build();

            Console.WriteLine("Is upgrade required: " + upgrader.IsUpgradeRequired());
            
            if (args.Any(a => a.StartsWith("--PreviewReportPath", StringComparison.InvariantCultureIgnoreCase)))
            {
                // Generate a preview file so Octopus Deploy can generate an artifact for approvals
                var report = args.FirstOrDefault(x => x.StartsWith("--PreviewReportPath", StringComparison.OrdinalIgnoreCase));
                report = report.Substring(report.IndexOf("=") + 1).Replace(@"""", string.Empty);

                var fullReportPath = Path.Combine(report, "UpgradeReport.html");

                Console.WriteLine($"Generating the report at {fullReportPath}");
                
                upgrader.GenerateUpgradeHtmlReport(fullReportPath);
            }
            else
            {
                var result = upgrader.PerformUpgrade();

                // Display the result
                if (result.Successful)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Success!");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(result.Error);
                    Console.WriteLine("Failed!");
                }
            }
        }
    }
}