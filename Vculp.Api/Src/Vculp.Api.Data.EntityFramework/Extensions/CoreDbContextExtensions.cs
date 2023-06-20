using Microsoft.EntityFrameworkCore;

namespace Vculp.Api.Data.EntityFramework.Extensions
{
    public static class CoreDbContextExtensions
    {
        public static string DefaultDateTimeUtcExpression(this CoreContext context)
        {
            if (context.Database.IsSqlServer())
            {
                return "GETUTCDATE()";
            }
            else
            {
                return "platform-not-supported";
            }
        }
    }
}
