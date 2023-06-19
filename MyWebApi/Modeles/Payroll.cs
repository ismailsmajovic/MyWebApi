using System.Collections.Generic;

namespace MyWebApi.Models
{
    public class Payroll
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public decimal Salary { get; set; }
        public decimal Tax { get; set; }
        public decimal Contributions { get; set; }
        public decimal Bonus { get; set; }
    }
     
    public static class PayrollData
    {
        private static List<Payroll> payrollList;

        static PayrollData()
        {
            payrollList = new List<Payroll>();
        }

        public static void AddPayroll(Payroll payroll)
        {
            payrollList.Add(payroll);
        }

        public static List<Payroll> GetAllPayrolls()
        {
            return payrollList;
        }

        public static Payroll GetPayrollById(int id)
        {
            return payrollList.Find(p => p.Id == id);
        }

        public static void UpdatePayroll(Payroll updatedPayroll)
        {
            int index = payrollList.FindIndex(p => p.Id == updatedPayroll.Id);
            if (index != -1)
            {
                payrollList[index] = updatedPayroll;
            }
        }

        public static void DeletePayroll(int id)
        {
            payrollList.RemoveAll(p => p.Id == id);
        }
    }
}
