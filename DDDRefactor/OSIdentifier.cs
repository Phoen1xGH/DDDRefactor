using CSharpFunctionalExtensions;
using System.Runtime.InteropServices;

namespace DDDRefactor
{
    internal class OSIdentifier
    {
        /// <summary>
        /// Паттерн путей в ОС Windows
        /// </summary>
        /* Пояснение:
                   ^[a-zA-Z]: — начало пути с указанием диска (например, C:).
                   \ — обратный слэш как разделитель директорий.
                   (?:[^\/:*?"<>|\r\n]+\) — одна или несколько директорий.
                   [^\/:?"<>|\r\n]$ — имя файла (может быть пустым, если путь заканчивается на слэш).
        */
        private const string _windowsPattern = @"^[a-zA-Z]:\\(?:[^\\/:*?""<>|\r\n]+\\)*[^\\/:*?""<>|\r\n]*$";

        /// <summary>
        /// Паттерн путей в Unix-системах
        /// </summary>
        /* Пояснение:
            ^/ — путь начинается с корневой директории /.
            (?:[^/\0]+/) — одна или несколько директорий.
            [^/\0]*$ — имя файла (может быть пустым, если путь заканчивается на /).
        */
        private const string _unixPattern = @"^\/(?:[^\/\0]+\/)*[^\/\0]*$";

        public Result<string> GetRegexPatternByCurrentOS()
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                return _windowsPattern;
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux) ||
                RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                return _unixPattern;

            return Result.Failure<string>("Тип ОС не поддерживается!");
        }
    }
}
