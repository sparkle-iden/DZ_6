using System;
using System.IO;
using System.Text;

namespace Dz_5
{
    static internal class BattleLogger
    {
        private static TextWriter _originalOut;
        private static StreamWriter _fileWriter;
        private static StringBuilder _memoryLog;
        private static TeeTextWriter _teeWriter;

        public static void Start(string filePath)
        {
            if (_originalOut != null) return; 

            _originalOut = Console.Out;
            _fileWriter = new StreamWriter(filePath, false, Encoding.UTF8) { AutoFlush = true };
            _memoryLog = new StringBuilder();
            _teeWriter = new TeeTextWriter(_originalOut, _fileWriter, _memoryLog);
            Console.SetOut(_teeWriter);
        }

        public static string GetMemoryLog()
        {
            return _memoryLog?.ToString() ?? string.Empty;
        }

        public static void Stop()
        {
            if (_originalOut == null) return;

            Console.Out.Flush();
            Console.SetOut(_originalOut);
            _fileWriter?.Dispose();
            _fileWriter = null;
            _teeWriter = null;
            _originalOut = null;
        }

        private class TeeTextWriter : TextWriter
        {
            private readonly TextWriter _console;
            private readonly TextWriter _file;
            private readonly StringBuilder _mem;
            private readonly object _lock = new object();

            public TeeTextWriter(TextWriter console, TextWriter file, StringBuilder mem)
            {
                _console = console;
                _file = file;
                _mem = mem;
            }

            public override Encoding Encoding => Encoding.UTF8;

            public override void Write(char value)
            {
                lock (_lock)
                {
                    _console.Write(value);
                    _file.Write(value);
                    _mem.Append(value);
                }
            }

            public override void Write(string value)
            {
                if (value == null) return;
                lock (_lock)
                {
                    _console.Write(value);
                    _file.Write(value);
                    _mem.Append(value);
                }
            }

            public override void Write(char[] buffer, int index, int count)
            {
                lock (_lock)
                {
                    _console.Write(buffer, index, count);
                    _file.Write(buffer, index, count);
                    _mem.Append(buffer, index, count);
                }
            }

            public override void WriteLine(string value)
            {
                lock (_lock)
                {
                    _console.WriteLine(value);
                    _file.WriteLine(value);
                    _mem.AppendLine(value);
                }
            }

            public override void Flush()
            {
                lock (_lock)
                {
                    _console.Flush();
                    _file.Flush();
                }
            }
        }
    }
}
