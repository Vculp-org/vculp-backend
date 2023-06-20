using System.Collections.Generic;

namespace Vculp.Api.Common.Common.Dtos
{
    public abstract class LinkedResourceDto
    {
        public List<LinkDto> Links { get; set; } = new List<LinkDto>();
    }
}
