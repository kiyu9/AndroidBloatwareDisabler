using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndroidBloatwareDisabler
{
    public class DeviceInformation
    {
        public string ID { get; }
        public string Name { get; }
        public string Model { get; }
        public string Device { get; }
        public DeviceInformation(string id, string name, string model, string device)
        {
            ID = id;
            Name = name;
            Model = model;
            Device = device;
        }
    }
}
