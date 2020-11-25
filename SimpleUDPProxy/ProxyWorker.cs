using System;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using ModelLib.Model;
using Newtonsoft.Json;

namespace SimpleUDPProxy
{
    class ProxyWorker
    {

        private const string URI = "http://rb-sensordata-rest.azurewebsites.net/api/sensor";

        private readonly UdpClient client = new UdpClient(10100); // modtager pakker på port 10100
        private byte[] buffer;

        public ProxyWorker()
        {

        }

        public async void Start()
        {
            while (true)
            {
                SensorData obj = ReadUDPPacket();
                SendToRest(obj);
            }
        }

        public SensorData ReadUDPPacket()
        {
            // udp read
            IPEndPoint remotEndPoint = new IPEndPoint(IPAddress.Any, 0);
            buffer = client.Receive(ref remotEndPoint);

            string jsonstr = Encoding.UTF8.GetString(buffer);
            // Console.WriteLine("Modtaget : " + jsonstr);

            return JsonConvert.DeserializeObject<SensorData>(jsonstr);
        }

        public async void SendToRest(SensorData obj)
        {
            using (HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json");

                HttpResponseMessage resp = await client.PostAsync(URI, content);

                if (resp.IsSuccessStatusCode)
                {
                    return;
                }
                throw new ArgumentException("Post failed");
            }
        }
    }
}