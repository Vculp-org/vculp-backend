using System.Threading.Tasks;
using Vculp.Api.Common.Common.Models.Email;

namespace Vculp.Api.Domain.Interfaces.EmailSender
{
    public interface IEmailSender
    {
       Task SendMail(MailRequest mailRequest);
    }
}
