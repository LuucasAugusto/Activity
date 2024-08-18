using ActivityStudents.Entities;

namespace ActivityStudents.Models
{
    public class Student
    {
        public Student(ActivityEntity entity)
        {
            StudentNumber = entity.StudentNumber;
            StudentName = entity.StudentName;
            SubmitDate = entity.SubmitDate.Value;
            IsSubmited = entity.SubmitDate.HasValue;
            IsOverdue = false;
            DaysOverdue = (int)(!entity.SubmitDate.HasValue ? 0 : Math.Abs(entity.RegisterDate.Subtract(entity.SubmitDate.Value).TotalDays));
        }

        public string StudentNumber { get; set; }
        public string StudentName { get; set; }
        public DateTime SubmitDate { get; set; }
        public bool IsSubmited { get; set; }
        public bool IsOverdue { get; set; }
        public int DaysOverdue { get; set; }
    }
}
