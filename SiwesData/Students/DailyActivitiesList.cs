using System;
using System.Collections.Generic;
using System.Text;

namespace SiwesData.Students
{
    public class DailyActivitiesList
    {
        public int Id { get; set; }
        public int DailyActivitiesId { get; set; }
        public DateTime DayDate { get; set; }
        public string DayDescription { get; set; }
        public string  WeekDayName { get; set; }
        //public string Day2Description { get; set; }
        //public DateTime Day3 { get; set; }
        //public string Day3Description { get; set; }
        //public DateTime Day4 { get; set; }
        //public string Day4Description { get; set; }
        //public DateTime Day5 { get; set; }
        //public string Day5Description { get; set; }

        public DailyActivities DailyActivities { get; set; }
    }
}
