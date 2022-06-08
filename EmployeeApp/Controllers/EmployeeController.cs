using EmployeeApp.Models;
using EmployeeApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeApp.Controllers;

public class EmployeeController : Controller
{
    private readonly EmployeeService _service;
    public EmployeeController(EmployeeService service)
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
        return View(emps);
    }
    [HttpDelete]
    public async Task<IActionResult> Delete(Employee employee)
    {
        var emps = await _service.Delete(employee);
        return View(emps);
    }

}
