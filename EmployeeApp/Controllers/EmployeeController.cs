using EmployeeApp.Models;
using EmployeeApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeApp.Controllers;

public class EmployeeController : Controller
{
    private readonly EmployeeService _service;
    private readonly DepartmentService _departmentService;
    public EmployeeController(EmployeeService service,
        DepartmentService departmentService)
    {
        _service = service;
        _departmentService = departmentService;
    }
    public async Task<IActionResult> Index()
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
    public async Task<IActionResult> Create(Employee employee)
    {
        //if (employee is null)
        //{
        //    //handel error 
        //}
        var emps = await _service.AddEmployeeAsync(employee);
        return View(emps);
    }

    public async Task<IActionResult> Edit(int empid)
    {
        var emps = await _service.GetAsync(empid);
        return View(emps);
    }

    [HttpPut]
    public async Task<IActionResult> Edit(Employee employee)
    {
        var emps = await _service.EditEmployeeAsync(employee);
        ViewBag.ManagerId = await _service.GetAsync();
        ViewBag.DepartmentId = await _departmentService.GetAsync();

        return View(emps);
    }
    public async Task<IActionResult> Delete(int empid)
    {
        var emps = await _service.GetAsync(empid);
        return View(emps);
    }
    [HttpDelete]
    public async Task<IActionResult> Delete(Employee employee)
    {
        var emps = await _service.Delete(employee);
        return View(emps);
    }

}
