using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Edu_Hub_Project.Models;
using Edu_Hub_Project.Services;
using Edu_Hub_Project.Repository;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using System.Data;



namespace Edu_Hub_Project.Controllers;

public class MaterialController : Controller
{
    // Private field to hold an instance of IMaterialService
    private readonly IMaterialService _materialService;
    // Constructor to initialize the MaterialController with an instance of IMaterialService
    public MaterialController(IMaterialService materialService)
    {
        _materialService = materialService;

    }

    // HTTP GET action to add a new material
    [HttpGet]
    public IActionResult AddMaterial(int id)
    {
        // Create a new Material object with the provided course ID
        Material material = new Material()
        {
            CourseId = id,
        };
        return View(material);
    }

    // HTTP POST action to add a new material
    [HttpPost]
    public IActionResult AddMaterial(Material material, int id)
    {
        _materialService.AddMaterial(material); // Call service to add material
        return RedirectToAction("MyCourse", "Course"); // Redirect after successful add
    }

    // HTTP GET action to view materials for a specific course
    [HttpGet]
    public IActionResult MyMaterial(int id)
    {
        // var id = Convert.ToInt32(HttpContext.Session.GetString("CourseId"));
        var data = _materialService.GetMaterialByCourseId(id);       // Get the materials for the specified course ID
        return View(data);
    }

    // HTTP GET action to view materials for a specific course (educator view)
    public IActionResult MyMaterialEducator(int id)
    {
        // var id = Convert.ToInt32(HttpContext.Session.GetString("CourseId"));
        var data = _materialService.GetMaterialByCourseId(id);         // Get the materials for the specified course ID
        return View(data);
    }
    
    // HTTP GET action to edit a material
    [HttpGet]
    public IActionResult EditMaterial(int id)
    {
        if (id == null)      // Check if the material ID is null
            return View();
        else
        {
            var data = _materialService.GetMaterialByMaterialId(id);      // Get the material by the specified material ID
            // Check if the material is null
            if (data == null)
                return NotFound();    // Return a 404 Not Found response
            return View(data);
        }
    }
    
    // HTTP POST action to edit a material
    [HttpPost]
    public IActionResult EditMaterial(int id, Material modified)
    {
        if (ModelState.IsValid) // Validate model state
        {
            
            _materialService.UpdateMaterial(id, modified); // Call service to update material

            return RedirectToAction(nameof(MyMaterialEducator)); // Redirect after successful edit
        }

        return View(modified); // If model state is invalid, return the same view with errors
    }
}