using EmployeeApp.Models;
using EmployeeApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeApp.Controllers;

public class DepartmentController : Controller
{
    private readonly DepartmentService _service;
    public DepartmentController(DepartmentService service)
    {
        _service=service;
    }
    public async Task <IActionResult> Index()
    {
        var emps = await _service.GetAsync();
        return View(emps);
    }

    public async Task<IActionResult> Details(int empid)
    {
        var emps = await _service.GetAsync(empid);
        return View(emps);
    }
    
    public async Task<IActionResult> Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(Department department)
    {
        //if (department is null)
        //{
        //    //handel error 
        //}
        var emps = await _service.AddDepartmentAsync(department);
        return View(emps);
    }

    public async Task<IActionResult> Edit(int empid)
    {
        var emps = await _service.GetAsync(empid);
        return View(emps);
    }

    [HttpPut]
    public async Task<IActionResult> Edit(Department department)
    {
        var emps = await _service.EditDepartmentAsync(department);
        return View(emps);
    }
    [HttpDelete]
    public async Task<IActionResult> Delete(Department department)
    {
        var emps = await _service.Delete(department);
        return View(emps);
    }

}
