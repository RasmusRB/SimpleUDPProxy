using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ModelLib.Model;

namespace SensorREST.Managers
{
    public class SensorManager
    {
        private static readonly List<SensorData> _datas = new List<SensorData>();
        private static int Count = 0;

        public SensorManager()
        {

        }

        public IEnumerable<SensorData> Get()
        {
            return _datas;
        }

        public SensorData GetId(int id)
        {
            return _datas.Find(d => d.Id == id);
        }

        public void Post(SensorData value)
        {
            int nextId = (_datas.Count != 0) ? _datas.Max(d => d.Id) + 1 : 1;
            value.Id = nextId;
            _datas.Add(value);
        }
    }
}
