using Dominio.Patterns.Domain;

namespace Dominio.Entitys.Custon.LogsDatabase
{
    public static class LogsDatabaseBusinessRules
    {
        public static void Prepare(ILogsDatabaseEntity logsDatabase, DomainOperationContext context)
        {
            if (!string.IsNullOrWhiteSpace(logsDatabase.LOGS_KEY1)
                || string.IsNullOrWhiteSpace(logsDatabase.LOGS_KEY))
            {
                return;
            }

            var keyIndex = 0;
            var segmentStart = 0;
            for (var index = 0; index <= logsDatabase.LOGS_KEY.Length && keyIndex < 4; index++)
            {
                if (index != logsDatabase.LOGS_KEY.Length && logsDatabase.LOGS_KEY[index] != ',')
                {
                    continue;
                }

                SetKeyValue(logsDatabase, keyIndex, ExtractValue(logsDatabase.LOGS_KEY, segmentStart, index));
                keyIndex++;
                segmentStart = index + 1;
            }
        }

        private static string ExtractValue(string source, int start, int end)
        {
            for (var index = start; index < end; index++)
            {
                if (source[index] == ':')
                {
                    return source.Substring(index + 1, end - index - 1).Trim();
                }
            }

            return string.Empty;
        }

        private static void SetKeyValue(ILogsDatabaseEntity logsDatabase, int keyIndex, string value)
        {
            switch (keyIndex)
            {
                case 0:
                    logsDatabase.LOGS_KEY1 = value;
                    break;
                case 1:
                    logsDatabase.LOGS_KEY2 = value;
                    break;
                case 2:
                    logsDatabase.LOGS_KEY3 = value;
                    break;
                case 3:
                    logsDatabase.LOGS_KEY4 = value;
                    break;
            }
        }
    }
}
