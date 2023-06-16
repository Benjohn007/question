using FavListUserManagement.Domain.Entities;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FavListUserManagement.Application.IServices
{
    public interface IEmailServices
    {
        void SendEmail(Message mailMessage);
    }
}
