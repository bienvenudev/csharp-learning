using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TrainingSystem.Models;
using System.IO;
using System.Threading.Tasks;
using System.Linq;
namespace TrainingSystem.Pages;

public class Enrollment : PageModel
{
    public string ConfirmationMessage { get; set; }
    public string ErrorMessage { get; set; }
    public string EnrollmentStatus { get; set; }
    public TrainingCourse Course { get; set; }

    // Form Properties
    [BindProperty]
    public int CourseId { get; set; }
    [BindProperty]
    public string EmployeeName { get; set; }
    [BindProperty]
    public string EmployeeEmail { get; set; }
    [BindProperty]
    public string Department { get; set; }
    [BindProperty]
    public string SpecialRequests { get; set; }

    public void OnGet(int courseId)
    {
        CourseId = courseId;
        Course = CourseRepository.GetAllCourses().FirstOrDefault(c => c.Id == courseId);
    }
        
    public async Task OnPostAsync()
    {
        Course = CourseRepository.GetAllCourses().FirstOrDefault(c => c.Id == CourseId);
        if (string.IsNullOrWhiteSpace(EmployeeName) && string.IsNullOrWhiteSpace(EmployeeEmail))
        {
            ErrorMessage = "Can't find employee name or email!";
            return;
        }
        await Task.Delay(2000);
        ConfirmationMessage = "Sucess Message";
        EnrollmentStatus = "Completed";
    }
}