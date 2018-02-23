using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls.WebParts;
using Web.ViewModels;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        //public ActionResult Home()
        //{
        //    return PartialView();
        //}



        public ActionResult AddEmployee(EmployeeViewModel EmployeeViewModelClient)
        {
            return PartialView();
        }

        public ActionResult ShowEmpList()
        {
            List<EmployeeViewModel> empViewModelList = GetEmpDetails();
            return Json(empViewModelList, JsonRequestBehavior.AllowGet);
        }

        
        public ActionResult AddEmpDetails(EmployeeViewModel EmployeeViewModelClient)
        {
            InsertEmpAddress(EmployeeViewModelClient);
            List<EmployeeViewModel> list = new List<EmployeeViewModel>();
            list.Add(EmployeeViewModelClient);
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        public ActionResult AddressEmployee()
        {
            return PartialView();
        }

        public void InsertEmpAddress(EmployeeViewModel employeeViewModel)
        {
            try
            {

                string ConnString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                using (SqlConnection sqlcon = new SqlConnection(ConnString))
                {
                    if (sqlcon.State == System.Data.ConnectionState.Closed)
                    {
                        sqlcon.Open();
                    }

                    SqlCommand cmd = new SqlCommand("spEmpAddress_ins", sqlcon);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add("@EmpName", SqlDbType.VarChar).Value = employeeViewModel.empDetailModel.EmpName;
                    cmd.Parameters.Add("@EmpPhone", SqlDbType.VarChar).Value = employeeViewModel.empDetailModel.EmpPhone;
                    cmd.Parameters.Add("@EmpAddress1", SqlDbType.VarChar).Value = employeeViewModel.empAddressModel.Address1;
                    cmd.Parameters.Add("@EmpAddress2", SqlDbType.VarChar).Value = employeeViewModel.empAddressModel.Address2;
                    cmd.Parameters.Add("@EmpAddress3", SqlDbType.VarChar).Value = employeeViewModel.empAddressModel.Address3;

                    int Result = cmd.ExecuteNonQuery();
                }
            }
            catch
            {

            }
        }

        public List<EmployeeViewModel> GetEmpDetails()
        {
            List<EmployeeViewModel> empViewModelList = new List<EmployeeViewModel>();
            try
            {
                string ConnString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                using (SqlConnection sqlcon = new SqlConnection(ConnString))
                {
                    if (sqlcon.State == System.Data.ConnectionState.Closed)
                    {
                        sqlcon.Open();
                    }

                    SqlCommand cmd = new SqlCommand("select * from EmpDetails ED INNER JOIN EmpAddress EA on EA.EmpID = ED.EmpID", sqlcon);
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        EmployeeViewModel empViewModel = new EmployeeViewModel();
                        empViewModel.empAddressModel = new Models.EmpAddressModel();
                        empViewModel.empDetailModel = new Models.EmpDetailsModel();

                        empViewModel.empDetailModel.EmpName = Convert.ToString(dr["EmpName"]);
                        empViewModel.empDetailModel.EmpPhone = Convert.ToString(dr["EmpPhone"]);
                        empViewModel.empAddressModel.Address1 = Convert.ToString(dr["Address1"]);
                        empViewModel.empAddressModel.Address2 = Convert.ToString(dr["Address2"]);
                        empViewModel.empAddressModel.Address3 = Convert.ToString(dr["Address3"]);

                        empViewModelList.Add(empViewModel);
                    }

                }
            }
            catch
            {

            }
            return empViewModelList;

        }

        public ActionResult DeleteEmployee()
        {
            return PartialView();
        }

        public ActionResult EditEmployee()
        {
            return PartialView();
        }

    }
}
