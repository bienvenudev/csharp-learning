namespace TrainingSystem.Models
{
    public class TrainingCourse
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Duration { get; set; }
        public string Instructor { get; set; }
        public int MaxCapacity { get; set; }
        public string Prerequisites { get; set; }
    }
}