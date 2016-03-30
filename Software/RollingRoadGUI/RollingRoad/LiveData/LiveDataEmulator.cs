﻿using System;
using System.Collections.Generic;
using System.Linq;
using RollingRoad.Data;

namespace RollingRoad
{
    public class LiveDataEmulator : ILiveDataSource
    {
        private readonly IDataset _source;
        private readonly DataList _xAxis;
        private int _index;
        private double _lastMs;

        /// <summary>
        /// Event when at new value is sent
        /// </summary>
        public event ReadOnlyDataEntryList OnNextReadValue;
        /// <summary>
        /// Logger used for debug messages
        /// </summary>
        public ILogger Logger { get; set; }

        private ITimer _timer;

        /// <summary>
        /// Timer used for timing when to send new values
        /// </summary>
        public ITimer Timer
        {
            private get { return _timer; }
            set
            {
                //If a timer is allready connected, disconnect the event
                if (_timer != null)
                    _timer.Elapsed -= SendNextValue;

                _timer = value;

                //If the new timer is not not, connect the event
                if (_timer != null)
                    _timer.Elapsed += SendNextValue;
            }
        }

        /// <summary>
        /// Ctor, before the timer starts sending values, start must be called
        /// </summary>
        /// <param name="source">Source to emulate</param>
        public LiveDataEmulator(IDataset source)
        {
            _source = source;
            
            _xAxis = source.GetDataList("Time");

            Timer = new SystemTimer();
            
            Reset();
        }

        //Stop the transmission of values
        public void Stop()
        {
            Timer.Stop();
        }

        /// <summary>
        /// Start the timer
        /// </summary>
        public void Start()
        {
            Logger?.WriteLine("Emulator: starting");
            SendNextValue();
        }

        /// <summary>
        /// Resets the timer, making it possible to re-transmit all values
        /// </summary>
        private void Reset()
        {
            _index = 0;

            if(_xAxis != null && _xAxis.Data.Count > 0)
                _lastMs = GetMs(_xAxis.Data.First(), _xAxis.Type.Unit);

            Timer.Stop();
        }

        private double GetMs(double value, string unit)
        {
            switch (unit)
            {
                case "Seconds":
                    return value*1000;
                case "ms":
                    return value;
                default:
                    Logger?.WriteLine("Unknown time unit: " + unit);
                    return 0;
            }
        }
        
        /// <summary>
        /// Transmits next value and restarts the timer if more data i available
        /// </summary>
        private void SendNextValue()
        {
            if(_xAxis == null)
                return;

            //If there's not more available data, stop. 
            if (_index >= _xAxis.Data.Count)
            {
                Logger?.WriteLine("Emulator: stopping");
                Timer.Stop();
                return;
            }

            //Setup data to transmit
            List<Datapoint> entry = new List<Datapoint>();
            for (int i = 0; i < _source.Collection.Count; i++)
            {
                DataList data = _source.Collection[i];
                entry.Add(new Datapoint(data.Type, data.Data.ElementAt(_index)));
            }
            
            OnNextReadValue?.Invoke(entry); //Send value

            //Calculate time to wait
            double time = GetMs(_xAxis.Data.ElementAt(_index), _xAxis.Type.Unit);
            double delta = time - _lastMs;
            _lastMs = time;

            //Move data index
            _index++;

            if (delta == 0)
                delta = 1;

            Timer.Start((int) delta);
        }

        public override string ToString()
        {
            return "Live data emulator (" + _source + ")";
        }
    }
}