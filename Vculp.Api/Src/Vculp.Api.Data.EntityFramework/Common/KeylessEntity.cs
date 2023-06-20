namespace Vculp.Api.Data.EntityFramework.Common
{
    public abstract class KeylessEntity<T> where T : class
    {
        public bool IsDeleted { get; set; }
    }
}
