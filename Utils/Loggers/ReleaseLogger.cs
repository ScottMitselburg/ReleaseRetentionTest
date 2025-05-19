using System.Reflection;
using System.Text;
using Newtonsoft.Json;

namespace ReleaseRetention.Utils.Loggers
{
    public class ReleaseLogger
    {
        public class LogEntry
        {
            public required string Timestamp { get; set; }
            public required string Info { get; set; }
        }

        private static readonly SemaphoreSlim _semaphore = new SemaphoreSlim(1, 1);

        public static async Task WriteLogsToJsonFile(string data)
        {
            string exePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string projectRoot = Directory.GetParent(exePath).Parent.Parent.FullName;
            string folderPath = Path.Combine(projectRoot, "Logs", "ReleasesToKeepLogs");
            string fileName = "releasesToKeep.json";
            string path = Path.Combine(folderPath, fileName);

            Directory.CreateDirectory(folderPath);

            await _semaphore.WaitAsync();
            try
            {
                List<LogEntry> items;

                if (File.Exists(path))
                {
                    var existingJson = await File.ReadAllTextAsync(path);
                    try
                    {
                        items = JsonConvert.DeserializeObject<List<LogEntry>>(existingJson) ?? new List<LogEntry>();
                    }
                    catch
                    {
                        items = new List<LogEntry>();
                    }
                }
                else
                {
                    items = new List<LogEntry>();
                }

                var logEntry = new LogEntry
                {
                    Timestamp = DateTime.UtcNow.ToString("s"),
                    Info = data
                };

                items.Add(logEntry);

                var jsonString = JsonConvert.SerializeObject(items, Formatting.Indented);
                await File.WriteAllTextAsync(path, jsonString, Encoding.UTF8);
            }
            finally
            {
                _semaphore.Release();
            }
        }
    }
}
