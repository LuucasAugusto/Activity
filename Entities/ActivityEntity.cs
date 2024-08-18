namespace ActivityStudents.Entities
{
    public class ActivityEntity
    {
        public int ActivityID { get; set; }
        public string ClassIdentify { get; set; }
        public string StudentNumber { get; set; }
        public string StudentName { get; set; }
        public string StudentEmail { get; set; }
        public string LinkActivity { get; set; }
        public DateTime? SubmitDate { get; set; }
        public DateTime RegisterDate { get; set; }
        public short Active { get; set; }
    }
}
