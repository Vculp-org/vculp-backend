using System;

namespace Vculp.Api.Common.Common
{
    public class OperationResult<T> : OperationResult, IOperationResult<T>
    {
        public OperationResult()
            : base()
        {
        }

        public T Result { get; private set; }

        public void SetResult(T result)
        {
            if (result == null)
            {
                throw new ArgumentNullException(nameof(result));
            }

            Result = result;
        }
    }
}
