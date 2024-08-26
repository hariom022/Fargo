using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CITDomain.Model
{
    public class OrderModel
    {
        public string OrderNumber { get; set; }
        public int OrderId { get; set; }
        public int OrderTypeId { get; set; }
        public int CustomerId { get; set; }
        public int RouteID { get; set; }
        public int PickUpLocation { get; set; }
        public string IsVault { get; set; }
        public string IsVaultFinal { get; set; }
        public bool FullDayOccupancy { get; set; }
        public int Repeats { get; set; }
        public int PriorityId { get; set; }
        public int CreatedBy { get; set; }
        public DateTime StartDate { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public DateTime EndTask { get; set; }
        public string RepeatIn { get; set; }
        public List<TaskModel> TaskModellist { get; set; }

    }
    public class TaskModel
    {
        public int TaskID { get; set; }
        public int OrderID { get; set; }
        public string TaskType { get; set; }
        public int PickType { get; set; }
        public string PickUpLocation { get; set; }
        public string DeliveryLocation { get; set; }
        public int TaskSequence { get; set; }
        public bool IsRecurring { get; set; }
        public string DataSource { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public bool IsDeleted { get; set; }
        public string PickupType { get; set; }
    }
    public class RouteMaster
    {

        public int RouteID { get; set; }
        public string PickUpLocation { get; set; }
        public string DeliveryLocation { get; set; }
    }
}
