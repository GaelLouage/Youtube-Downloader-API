using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructuur.Extensions
{
    public static class ObjectToByte
    {
        public static byte[] ConvertToByteArray<T>(this T model) => 
            Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(model));
        public static object ByteArrayToObjectAsync(this byte[] byteArray)
        {
            using(var memoryStream = new MemoryStream(byteArray))
            {
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                //set mem stream to starting point
                memoryStream.Position = 0;
                return binaryFormatter.Deserialize(memoryStream);
            }
        }
    }
}
