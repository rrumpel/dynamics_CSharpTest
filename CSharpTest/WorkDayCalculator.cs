using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTest
{
    public class WorkDayCalculator : IWorkDayCalculator
    {
        public DateTime Calculate(DateTime startDate, int dayCount, WeekEnd[] weekEnds)
        {
            DateTime res = startDate.AddDays(dayCount - 1);//"-1" to count the first day as an account
            TimeSpan days;
            if (weekEnds == null) return res;

            foreach (var period in weekEnds)
            {
                if (period.StartDate >= startDate && period.StartDate <= res)
                {
                    days = period.EndDate.Subtract(period.StartDate);
                    res = res.Add(days);
                    res = res.AddDays(1);//same reason, but DateTime are more convenient in "day+=1" then TimeSpan
                }
                else if (period.EndDate >= startDate && period.EndDate <= res)
                {
                    days = period.EndDate.Subtract(startDate);
                    res = res.Add(days);
                    res = res.AddDays(1);//same reason
                }
            }
            return res;
        }
    }
}
