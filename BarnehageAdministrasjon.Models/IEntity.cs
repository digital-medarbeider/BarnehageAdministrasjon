using System;
using System.Collections.Generic;
using System.Text;

namespace BarnehageAdministrasjon.Models
{
    public interface IEntity
    {
        Guid Id { get; set; }
    }
}
