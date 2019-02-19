using System;
using System.Linq;
using System.Reflection;

namespace DbUpSample
{
    class Program
    {
        static void Main(string[] args)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var scripts = assembly.GetManifestResourceNames().Where(script => script.StartsWith("SampleApplication.PostDeployment.")).ToList();

            foreach (var script in scripts)
            {
                Console.WriteLine(script);
            }
        }
    }
}