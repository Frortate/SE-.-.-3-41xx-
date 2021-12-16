using DAL.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface
{
    public interface IReportRepository
    {
        Report ReportUser(int userId, int month);
    }
}
