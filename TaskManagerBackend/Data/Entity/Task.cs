namespace TaskManagerBackend.Data.Entity
{
    public class Task
    {
        public int TaskId { get; set; }
        public string TaskName { get; set; }
        public string TaskDescription { get; set; }
        public DateTime CreatedDate { get; set; }
        public string TaskAdmin { get; set; }
        
    }
}
