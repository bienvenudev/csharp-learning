using System.Collections.Generic;

namespace TrainingSystem.Models
{
    public static class CourseRepository
    {
        public static List<TrainingCourse> GetAllCourses()
        {
            return new List<TrainingCourse>
            {
                new TrainingCourse
                {
                    Id = 1,
                    Title = "Leadership Training",
                    Description = "Develop essential leadership skills for managing teams and driving organizational success.",
                    Duration = 16,
                    Instructor = "Sarah Johnson",
                    MaxCapacity = 20,
                    Prerequisites = "2+ years management experience"
                },
                new TrainingCourse
                {
                    Id = 2,
                    Title = "Data Security Fundamentals",
                    Description = "Learn best practices for protecting sensitive company data and preventing cyber threats.",
                    Duration = 8,
                    Instructor = "Michael Chen",
                    MaxCapacity = 25,
                    Prerequisites = "Basic computer skills"
                },
                new TrainingCourse
                {
                    Id = 3,
                    Title = "Project Management Essentials",
                    Description = "Master project planning, execution, and delivery using industry-standard methodologies.",
                    Duration = 24,
                    Instructor = "Emily Rodriguez",
                    MaxCapacity = 15,
                    Prerequisites = "None"
                },
                new TrainingCourse
                {
                    Id = 4,
                    Title = "Effective Communication",
                    Description = "Enhance your verbal and written communication skills for professional success.",
                    Duration = 12,
                    Instructor = "David Thompson",
                    MaxCapacity = 30,
                    Prerequisites = "None"
                },
                new TrainingCourse
                {
                    Id = 5,
                    Title = "Financial Planning for Managers",
                    Description = "Learn budgeting, forecasting, and financial analysis techniques for department management.",
                    Duration = 20,
                    Instructor = "Lisa Wang",
                    MaxCapacity = 18,
                    Prerequisites = "Management role required"
                }
            };
        }
    }
}