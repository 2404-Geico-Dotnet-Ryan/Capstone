namespace Capstone.Models
{
    public class Holiday
    {
        public int HolidayId { get; set; }
        public string? HolidayName { get; set; }
        public string? HolidayYear { get; set; }
        public string? HolidayDate { get; set; }

        /* NO Argurments Constructor*/
        public Holiday()
        {

        }

        /* FULL Argurments Constructor */
        public Holiday(int holidayId, string holidayName, string holidayYear, string holidayDate)
        {
            HolidayId = holidayId;
            HolidayName = holidayName;
            HolidayYear = holidayYear;
            HolidayDate = holidayDate;
        }
    }
}