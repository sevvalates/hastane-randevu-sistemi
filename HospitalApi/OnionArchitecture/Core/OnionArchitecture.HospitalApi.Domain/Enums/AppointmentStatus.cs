﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchitecture.HospitalApi.Domain.Enums
{
    public enum AppointmentStatus
    {
        Pending,      // Beklemede
        Completed,    // Tamamlandı
        Canceled,     // İptal
        NoShow        // Gelmedi
    }
}

