﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ProductManagementWebAPI.DTO
{
   
    public class ReportDto
    {
        public string UserName { get; set; }
        public string CatagoryName { get; set; }
        public string ProductGenericName { get; set; }
        public string ProductTitle { get; set; }
        public int ProductPrice { get; set; }
    }
}
