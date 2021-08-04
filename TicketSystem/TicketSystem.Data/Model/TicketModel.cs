using System;
using System.Collections.Generic;
using System.Text;
using TicketSystem.Common.Enum;

namespace TicketSystem.Common.Model
{
    class TicketModel
    {
        public int TicketId { get; set; }

        public string Title { get; set; }

        public string Creator { get; set; }

        public string Assigned { get; set; }

        public SeverityEnum Severity { get; set; }

        public PriorityEnum Priority { get; set; }

        public TicketTypeEnum TicketType { get; set; }

        public TicketStatusEnum TicketStatus { get; set; }


    }
}
