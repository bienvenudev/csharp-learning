using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using TrainingSystem.Models;

namespace TrainingSystem.Pages;

public class IndexModel : PageModel
{
    public List<TrainingCourse> Courses { get; set; }

    public void OnGet()
    {
        Courses = CourseRepository.GetAllCourses();
    }
}