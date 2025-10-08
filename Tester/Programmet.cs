using System.Diagnostics;

namespace Tester
{
    [TestClass]
    public sealed class Programmet
    {
        static string[] errors = [];

        [ClassInitialize]
        public static void Init(TestContext testContext)
        {
            var projectPath = @"..\..\..\..\Uppgift\Uppgift.csproj";

            var processStartInfo = new ProcessStartInfo
            {
                FileName = "dotnet",
                Arguments = $"build \"{projectPath}\" --no-incremental -warnaserror",
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            using var process = new Process { StartInfo = processStartInfo };
            process.Start();

            var output = process.StandardOutput.ReadToEnd();
            process.WaitForExit();

            errors = output
                .Split('\n')
                .Where(x => x.Contains(": warning CS") || x.Contains(": error CS"))
                .Select(x =>
                {
                    var safe = x.Replace('\\', '/');
                    var start = safe.IndexOf("/Uppgift/");
                    if (start < 0) return x;

                    var trimmed = x.Substring(start + 1);

                    var pathEnds = trimmed.IndexOf(':');
                    var path = trimmed.Substring(0, pathEnds);
                    path = path.Replace('(', ':').Replace(',', ':').TrimEnd(')');

                    trimmed = trimmed.Substring(pathEnds + 1);
                    trimmed = trimmed.Substring(trimmed.IndexOf("CS"));

                    var warningEnds = trimmed.IndexOf(':');
                    var code = trimmed.Substring(0, warningEnds);
                    trimmed = trimmed.Substring(warningEnds + 1).TrimStart();

                    return $" • {path} (felkod {code}): {trimmed}";
                })
                .Distinct()
                .ToArray();
        }

        [TestMethod("Har inga oanvända värden")]
        public void NoUnused()
        {
            CompileWithWarnings("Programmet har följande oanvända värden:", "CS0168", "CS0219");
        }

        [TestMethod("Har inga null-varningar")]
        public void NoNullWarnings()
        {
            CompileWithWarnings("Programmet får följande null-varningar:", "CS8600", "CS8602", "CS8603", "CS8618", "CS8625");
        }





        static void CompileWithWarnings(string errorDescription, params string[] warnings)
        {
            var errorRows = errors.Where(row => warnings.Any(code => row.Contains($"(felkod {code}):"))).ToArray();

            if (errorRows.Length > 0)
            {
                Assert.Fail($"{errorDescription}\n{string.Join("\n", errorRows)}");
            }
        }
    }
}
