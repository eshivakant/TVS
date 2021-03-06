﻿using System.Threading.Tasks;

namespace TVS.WebApp.Services
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}
