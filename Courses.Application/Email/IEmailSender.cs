using Courses.Application.DataTransfer;
using System;
using System.Collections.Generic;
using System.Text;

namespace Courses.Application.Email
{
    public interface IEmailSender
    {
        void Send(SendEmailDto dto);
    }
}
