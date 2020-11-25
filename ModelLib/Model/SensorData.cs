using System;
using System.Collections.Generic;
using System.Text;

namespace ModelLib.Model
{
    public class SensorData
    {
        private int _id;
        private string _sensorName;
        private int _temperature;
        private int _co2;

        public SensorData()
        {
        }

        public SensorData(int id, string sensorName, int temperature, int co2)
        {
            _id = id;
            _sensorName = sensorName;
            _temperature = temperature;
            _co2 = co2;
        }

        public int Id
        {
            get => _id;
            set => _id = value;
        }

        public string SensorName
        {
            get => _sensorName;
            set => _sensorName = value;
        }

        public int Temperature
        {
            get => _temperature;
            set => _temperature = value;
        }

        public int Co2
        {
            get => _co2;
            set => _co2 = value;
        }

        public override string ToString()
        {
            return $"{nameof(Id)}: {Id}, {nameof(SensorName)}: {SensorName}, {nameof(Temperature)}: {Temperature}, {nameof(Co2)}: {Co2}";
        }
    }
}
