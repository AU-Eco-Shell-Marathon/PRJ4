﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RollingRoad.Loggers
{
    public class FileLogger : Logger
    {
        public string FilePath { get; }
        private readonly StreamWriter _writer;

        public FileLogger(string path)
        {
            FilePath = path;
            _writer = new StreamWriter(File.Open(FilePath, FileMode.Create));
        }

        public override void WriteLine(string line)
        {
            _writer.WriteLine(DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss.fff", CultureInfo.InvariantCulture) + ": " + line);
            _writer.Flush();
            base.WriteLine(line);
        }
    }
}