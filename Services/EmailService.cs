using MailKit.Net.Smtp;
using MimeKit;
using Capstone.Models;
using Capstone.DTOs;

namespace Capstone.Services;

    // To get e-mail services running in your project you need to run the following terminal command
    // dotnet add package MailKit --version 4.6.0
class EmailService
{
    // This method sets up to send out an e-mail using the Geico Network
    public static void SendEmail(string sendFromName, string sendFromEmail, string sendToName, string sendToEmail, string emailSubject, string emailBody)
    {
        var message = new MimeMessage();
        message.From.Add(new MailboxAddress(sendFromName, sendFromEmail));
        message.To.Add(new MailboxAddress(sendToName, sendToEmail));
        message.Subject = emailSubject;
        message.Body = new TextPart("plain")
        {
            Text = emailBody
        };

        using (var client = new SmtpClient())
        {
            client.Connect("mailrelay.geico.net", 25, false);
            client.Send(message);
            client.Disconnect(true);
        }
    }

    /******************************************/
    /* Create e-mail to send to Employee once */  
    /* Manager completes the approval process */
    /******************************************/
    public static void ToEmployeeLeaveReviewEmailDTO(LeaveEmailDTO leaveEmailDTO)
    {
        string subject = $"Your recently submitted leave request has been {leaveEmailDTO.Status}";

        string body = $"Hello {leaveEmailDTO.EmployeeFirstName+" "+leaveEmailDTO.EmployeeLastName}"
            + Environment.NewLine + Environment.NewLine +
            $"Your recent {leaveEmailDTO.LeaveType} leave request {(leaveEmailDTO.LeaveEndDate == leaveEmailDTO.LeaveStartDate ? $"on {leaveEmailDTO.LeaveStartDate}" : $"from {leaveEmailDTO.LeaveStartDate} to {leaveEmailDTO.LeaveEndDate}")} has been {leaveEmailDTO.Status} by {leaveEmailDTO.ManagerFirstName}."
            + Environment.NewLine + Environment.NewLine +
            "This is an automated email. Please do not respond.";

        SendEmail(".Net WorkForce", "test@geico.com", leaveEmailDTO.EmployeeFirstName+" "+leaveEmailDTO.EmployeeLastName, leaveEmailDTO.EmployeeEmail, subject, body);
    }

    /************************************************/
    /* Create e-mail to send to Manager once        */  
    /* Employee completes the leave request process */
    /************************************************/
    public static void ToManagerLeaveRequestEmailDTO(LeaveEmailDTO leaveEmailDTO)
    {
        string subject = "You have a new employee leave request to review";
        string body =  $"Hello {leaveEmailDTO.ManagerFirstName+" "+leaveEmailDTO.ManagerLastName},"
            + Environment.NewLine + Environment.NewLine +
            $"{leaveEmailDTO.EmployeeFirstName} {leaveEmailDTO.EmployeeLastName} has requested {leaveEmailDTO.LeaveType} leave {(leaveEmailDTO.LeaveEndDate == leaveEmailDTO.LeaveStartDate ? $"on {leaveEmailDTO.LeaveStartDate}" : $"from {leaveEmailDTO.LeaveStartDate} to {leaveEmailDTO.LeaveEndDate}")}. Please review this request in .Net WorkForce."
            + Environment.NewLine + Environment.NewLine +
            "This is an automated email. Please do not respond.";
        
        SendEmail(".Net WorkForce", "test@geico.com", leaveEmailDTO.ManagerFirstName+" "+leaveEmailDTO.ManagerLastName, leaveEmailDTO.ManagerEmail, subject, body);
    }
}