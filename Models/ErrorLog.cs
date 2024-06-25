namespace Capstone.Models
{
    public class ErrorLog
    {
        public int ErrorId { get; set; }
        public DateTime ErrorDate { get; set; }
        public string? ErrorMessage { get; set; }

        /* NO Argurments Constructor*/
        public ErrorLog()
        {

        }

        /* FULL Argurments Constructor */
        public ErrorLog(int errorId, DateTime errorDate, string errorMessage)
        {
            ErrorId = errorId;
            ErrorDate = errorDate;
            ErrorMessage =  errorMessage;
        }
    }
}
