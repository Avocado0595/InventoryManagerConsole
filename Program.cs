using InventoryManagement.Staff;
using Newtonsoft.Json;
using System.Buffers;
using System.ComponentModel;
using System.Text;
using System.Text.Json;
using static System.Net.Mime.MediaTypeNames;
namespace InventoryManagement
{
    class Program
    {
       
        public static void Main(string[] args)
        {
            
            StaffModel staffModel = new StaffModel("staff.json");
            StaffController staffController = new StaffController(staffModel);
            StaffView staffView = new StaffView(staffController);
            
        }
    }
}
