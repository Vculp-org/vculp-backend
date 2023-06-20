using System.Collections.Generic;

namespace Vculp.Api.Common.Common.Dtos
{
    public class LinkedCollectionResourceWrapperDto<T> : LinkedResourceDto
        where T : LinkedResourceDto
    {
        public LinkedCollectionResourceWrapperDto(IEnumerable<T> value)
        {
            Value = value;
        }

        public IEnumerable<T> Value { get; set; }
    }
}
