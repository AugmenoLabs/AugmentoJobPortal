using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agumento.Core.Domain
{
    public class ProfileStatus : BaseEntity
    {
        [Display(Name = "CandidateProfile")]
        public virtual string? CandidateId { get; set; }

        [ForeignKey("CandidateId")]
        public virtual CandidateProfile CandidateProfile { get; set; }

        [Display(Name = "OpenPosition")]
        public virtual Guid Id { get; set; }

        [ForeignKey("Id")]
        public virtual OpenPosition OpenPosition { get; set; }

        public string? InterviewStatus { get; set; } //Pending, Assigned, Done

        public string? InterviewRound { get; set; } //1st Techincal, 2nd Technical or HR 

        public string? Interviewer { get; set; } //Name of the person going to take interview

        public string? CandidateContactNumber { get; set; }
    }
}
