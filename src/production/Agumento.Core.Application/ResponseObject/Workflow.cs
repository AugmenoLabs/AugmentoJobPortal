
namespace Agumento.Core.Application.ResponseObject
{
    public class Workflow
    {
        public WorkflowLevels Screening { get; set; }
        public WorkflowLevels L1 { get; set; }
        public WorkflowLevels L2 { get; set; }
        public WorkflowLevels Managerial { get; set;}
        public WorkflowLevels HR { get; set; }
        public WorkflowLevels Hired { get; set;}

    }
}
