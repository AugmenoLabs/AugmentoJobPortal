
namespace Agumento.Core.Application.ResponseObject
{
    public class OpenPositionReport : OpenPosition
    {
        public int TotalApplied { get; set; }
        public int Screenings { get; set; }
        public int L1s { get; set; }
        public int L2s { get; set; }
        public int Managerials { get; set; }
        public int HR { get; set; }
        public int Offers { get; set; }
        public int Onboarded { get; set; }

    }
}
