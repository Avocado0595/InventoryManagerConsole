using Newtonsoft.Json;

namespace InventoryManagement.Staff
{
    public class StaffModel
    {
        private readonly string sourcePath;
        public StaffModel(string sourcePath)
        {
            this.sourcePath = Path.Combine(Environment.CurrentDirectory, sourcePath);
        }
        public void Write(Dictionary<string, Staff> staffList)
        {
            string output;
            if (staffList != null)
            {
                output = JsonConvert.SerializeObject(staffList);
            }
            else
            {
                output = string.Empty;
            }
            StreamWriter sw = new StreamWriter(sourcePath);
            sw.Write(output);
            sw.Close();
        }
        public Dictionary<string, Staff>? Read()
        {
            StreamReader sr = new StreamReader(sourcePath);
            string data = sr.ReadToEnd();
            sr.Close();
            if (data.Trim() == string.Empty)
                return null;
            return JsonConvert.DeserializeObject<Dictionary<string, Staff>>(data);
        }
    }
}
