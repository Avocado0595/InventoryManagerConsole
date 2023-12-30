using Newtonsoft.Json;

namespace InventoryManagement
{
    public class DataService<TKey, TValue>
    {
        private readonly string sourcePath;
        public DataService(string sourcePath)
        {
            this.sourcePath = Path.Combine(Environment.CurrentDirectory, sourcePath);
        }
        public void Write(Dictionary<TKey, TValue> dataList)
        {
            string output;
            if (dataList != null)
            {
                output = JsonConvert.SerializeObject(dataList);
            }
            else
            {
                output = string.Empty;
            }
            StreamWriter sw = new StreamWriter(sourcePath);
            sw.Write(output);
            sw.Close();
        }
        public Dictionary<TKey, TValue>? Read()
        {
            StreamReader sr = new StreamReader(sourcePath);
            string data = sr.ReadToEnd();
            sr.Close();
            if (data.Trim() == string.Empty)
                return null;
            return JsonConvert.DeserializeObject<Dictionary<TKey, TValue>>(data);
        }
    }
}
