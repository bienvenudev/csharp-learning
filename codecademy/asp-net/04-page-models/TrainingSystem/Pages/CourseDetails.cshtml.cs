using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TrainingSystem.Models;
using System.Linq;
namespace TrainingSystem.Pages;

public class CourseDetails : PageModel
{
    public TrainingCourse CurrentCourse { get; set; }
        
    public void OnGet(int id)
    {
        CurrentCourse = CourseRepository.GetAllCourses().FirstOrDefault(x => x.Id == id);
    }
}