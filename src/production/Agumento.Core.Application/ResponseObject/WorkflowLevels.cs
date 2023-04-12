
namespace Agumento.Core.Application.ResponseObject
{
    public class WorkflowLevels
    {
        public int Scheduled { get; set; }
        public int Completed { get; set; }
        //public int Hold { get; set; }
        public int Selected { get; set; }
        public int Rejected { get; set; }
    }
}
