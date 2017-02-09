﻿using System;

namespace Nancy.Raygun.AspNetCore.Messages
{
    public class RaygunMessage
    {
        public RaygunMessage()
        {
            OccurredOn = DateTime.UtcNow;
            Details = new RaygunMessageDetails();
        }

        public DateTime OccurredOn { get; set; }
        public RaygunMessageDetails Details { get; set; }
    }
}
