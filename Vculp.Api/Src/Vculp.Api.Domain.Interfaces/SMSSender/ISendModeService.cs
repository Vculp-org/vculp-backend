using System.Threading.Tasks;
using Vculp.Api.Common.Common.Models.Sms;

namespace Vculp.Api.Domain.Interfaces.SMSSender
{
    public interface ISendModeService
    {
        Task SendSms(SmsPayload smsPayload);
    }
}