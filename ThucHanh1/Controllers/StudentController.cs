using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Cryptography.X509Certificates;
using ThucHanh1.Models;
using IHostingEnvironment =  Microsoft.AspNetCore.Hosting.IHostingEnvironment;
namespace ThucHanh1.Controllers
{
	[Route("Admin/Student")]
	public class StudentController : Controller
	{
		private List<Student> lstStudents = new List<Student>();
		private readonly IHostingEnvironment env;
		public StudentController(IHostingEnvironment _env)
		{
			env = _env;
			List<Student> students = new List<Student>()
			{

				new Student() { Id = 101, Name = "Hải Nam", Branch = Branch.IT,
					Gender = Gender.Male, IsRegular = true,
					Address = "A1-2018", Email = "nam@g.com" },
				new Student() { Id = 102, Name = "Minh Tú", Branch = Branch.BE,
					Gender = Gender.Female, IsRegular = true,
					Address = "A1-2019", Email = "tu@g.com" },
				new Student() { Id = 103, Name = "Hoàng Phong", Branch = Branch.CE,
					Gender = Gender.Male, IsRegular = false,
					Address = "A1-2020", Email = "phong@g.com" },
				new Student() { Id = 104, Name = "Xuân Mai", Branch = Branch.EE,
					Gender = Gender.Female, IsRegular = false,
					Address = "A1-2021", Email = "mai@g.com" }
			};
			lstStudents = students;
		}
		[HttpGet("List")]
		public IActionResult Index()
		{
			return View(lstStudents);
		}
		[HttpGet("Add")]
		public IActionResult Create()
		{

			//lấy danh sách các giá trị Gender để hiển thị radio button trên form
			ViewBag.AllGenders = Enum.GetValues(typeof(Gender)).Cast<Gender>().ToList();
			//lấy danh sách các giá trị Branch để hiển thị select-option trên form
			//Để hiển thị select-option trên View cần dùng List<SelectListItem>
			ViewBag.AllBranches = new List<SelectListItem>()
				 {
				 new SelectListItem { Text = "IT", Value = "1" },
				 new SelectListItem { Text = "BE", Value = "2" },
				 new SelectListItem { Text = "CE", Value = "3" },
				 new SelectListItem { Text = "EE", Value = "4" }
				 };
			return View();
		}
		[HttpPost("Add")]
		public async Task<ActionResult> Create(Student s)
		{
			if (s.Img != null)
			{
				var file = Path.Combine(env.ContentRootPath, "wwwroot\\FileImg", s.Img.FileName);
				using (FileStream fileStream = new FileStream(file, FileMode.Create))
				{
					await s.Img.CopyToAsync(fileStream);
				}
			}
			s.Id = lstStudents.Last<Student>().Id + 1;
			lstStudents.Add(s);
			return View("Index", lstStudents);
		}
	}
}
