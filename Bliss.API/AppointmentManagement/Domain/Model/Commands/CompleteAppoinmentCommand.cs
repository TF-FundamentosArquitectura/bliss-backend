using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bliss.API.AppointmentManagement.Domain.Model.Commands
{
    public record CompleteAppoinmentCommand(int AppointmentId)
    {

    }
}