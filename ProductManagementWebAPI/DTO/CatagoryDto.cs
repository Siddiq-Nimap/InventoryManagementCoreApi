﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagementWebAPI.DTO
{
    public class CatagoryDto
    {
        public int Id { get; set; }

        public string CatagoryName { get; set; }

        public bool IsActive { get; set; }
    }
}
