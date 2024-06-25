namespace Capstone.Models
{
    public class LeaveType
    {
        public int LeaveTypeId { get; set; }
        public string? LeaveTypeName { get; set; }
        public bool IsPaid { get; set; }

        /* NO Argurments Constructor*/
        public LeaveType()
        {

        }

        /* FULL Argurments Constructor */
        public LeaveType(int leaveTypeId, string leaveTypeName, bool isPaid)
        {
            LeaveTypeId = leaveTypeId;
            LeaveTypeName = leaveTypeName;
            IsPaid = isPaid;
        }
    }
}