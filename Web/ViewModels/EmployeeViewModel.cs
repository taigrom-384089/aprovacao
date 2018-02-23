using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web.Models;

namespace Web.ViewModels
{
    public class EmployeeViewModel
    {
        public EmpDetailsModel empDetailModel { get; set; }
        public EmpAddressModel empAddressModel { get; set; }
    }
}