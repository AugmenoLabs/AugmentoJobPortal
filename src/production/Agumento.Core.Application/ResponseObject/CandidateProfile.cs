﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agumento.Core.Application.ResponseObject
{
    public class CandidateProfile
    {
        public Guid Id { get; set; }
        public string CandidateName { get; set; }
        public string Email { get; set; }
        public Guid OpenPositionId { get; set; }
        public byte[] Resume { get; set; }
        public string FileExt { get; set; }
    }
}
