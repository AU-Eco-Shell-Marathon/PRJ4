﻿using System;
using System.Diagnostics.CodeAnalysis;
using System.IO.Ports;

namespace RollingRoad
{
    [ExcludeFromCodeCoverage]
    public class SerialConnection : ProtocolInterpreter, IDisposable
    {
        public SerialPort Port { get; }

        public SerialConnection(SerialPort port) : base(port.BaseStream)
        {
            Port = port;
        }

        public void Dispose()
        {
            if (Port == null)
                return;

            if (!Port.IsOpen)
                return;

            Port.Dispose();
        }

        public override string ToString()
        {
            return Port.PortName;
        }
    }
}
