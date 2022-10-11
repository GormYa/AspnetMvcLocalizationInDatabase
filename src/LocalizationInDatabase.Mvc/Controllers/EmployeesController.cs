using AutoMapper;
using LocalizationInDatabase.Mvc.Models.Entities;
using LocalizationInDatabase.Mvc.Services.EntityServices;
using LocalizationInDatabase.Mvc.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace LocalizationInDatabase.Mvc.Controllers;

public class EmployeesController : Controller
{
    private readonly IMapper _mapper;
    private readonly IEmployeeService _employeeService;

    public EmployeesController(IMapper mapper, IEmployeeService employeeService)
    {
        _mapper = mapper;
        _employeeService = employeeService;
    }

    #region Create
    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> CreateAsync(EmployeeViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        var entity = _mapper.Map<Employee>(model);
        await _employeeService.AddAsync(entity);

        if (model.SubmitButton == "redirect")
        {
            return RedirectToAction("List");
        }
        else
        {
            return RedirectToAction("Create");
        }
    }
    #endregion

    #region Read
    [HttpGet]
    public async Task<IActionResult> ListAsync()
    {
        var entities = await _employeeService.ListAsync();
        var model = _mapper.Map<List<EmployeeViewModel>>(entities);

        return View(model);
    }

    [HttpGet]
    public async Task<IActionResult> DetailsAsync(Guid id)
    {
        // Don't exhaust the database if guid has an empty value
        if (id == Guid.Empty)
        {
            return NotFound();
        }

        var entity = await _employeeService.GetAsync(e => e.Id.Equals(id));
        if (entity == null)
        {
            return NotFound();
        }

        var model = _mapper.Map<EmployeeViewModel>(entity);

        return View(model);
    }
    #endregion

    #region Update
    [HttpGet]
    public async Task<IActionResult> EditAsync(Guid id, string? returnUrl)
    {
        // Don't exhaust the database if guid has an empty value
        if (id == Guid.Empty)
        {
            return NotFound();
        }

        var entity = await _employeeService.GetAsync(e => e.Id.Equals(id));
        if (entity == null)
        {
            return NotFound();
        }

        var model = _mapper.Map<EmployeeEditModel>(entity);

        return View(model);
    }

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> EditAsync(Guid id, EmployeeEditModel model, string? returnUrl)
    {
        // Don't exhaust the database if guid has an empty value
        if (id == Guid.Empty)
        {
            return NotFound();
        }

        if (!ModelState.IsValid)
        {
            return View(model);
        }

        var entity = await _employeeService.GetAsync(e => e.Id.Equals(id));
        if (entity == null)
        {
            return NotFound();
        }

        entity = _mapper.Map(model, entity);
        await _employeeService.UpdateAsync(entity);

        if (model.SubmitButton == "redirect")
        {
            if (string.IsNullOrEmpty(returnUrl))
            {
                return RedirectToAction("List");
            }
            else
            {
                return Redirect(returnUrl);
            }
        }
        else
        {
            return RedirectToAction("Edit", new { Id = id, returnUrl });
        }
    }
    #endregion

    #region Delete
    [HttpGet]
    public async Task<IActionResult> DeleteAsync(Guid id, string? returnUrl)
    {
        // Don't exhaust the database if guid has an empty value
        if (id == Guid.Empty)
        {
            return NotFound();
        }

        var entity = await _employeeService.GetAsync(e => e.Id.Equals(id));
        if (entity == null)
        {
            return NotFound();
        }

        await _employeeService.DeleteAsync(entity);

        return string.IsNullOrEmpty(returnUrl) ? RedirectToAction("List") : Redirect(returnUrl);
    }
    #endregion
}
