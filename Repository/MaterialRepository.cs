using Edu_Hub_Project.Models;
using Edu_Hub_Project.Services;
using Edu_Hub_Project.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace Edu_Hub_Project.Repository
{
    public class MaterialRepository : IMaterialService
    {
        private readonly AppDbContext _context;

        public MaterialRepository(AppDbContext context)
        {
            _context = context;
        }

        public Material AddMaterial(Material newMaterial)
        {
            _context.Materials.Add(newMaterial);
            _context.SaveChanges();
            return newMaterial;

        }
        public List<Material> MyMaterial(int id)
        {
            return _context.Materials.Where(x => x.CourseId == id).ToList();
        }
        public List<Material> MyMaterialEducator(int id)
        {
            return _context.Materials.Where(x => x.CourseId == id).ToList();
        }

        public List<Material> GetMaterialByCourseId(int courseId)
        {
            return _context.Materials.Where(m => m.CourseId == courseId).ToList();
        }
          public Material GetMaterialByMaterialId(int id)
        {
            var data =_context.Materials.FirstOrDefault(m => m.MaterialId == id);
            return data;
        }

        public  Material UpdateMaterial(int id ,Material material)
        {
            var data = _context.Materials.FirstOrDefault(x => x.MaterialId == id);
            //_context.Materials.Update(data); // Mark the entity as modified
            data.Description = material.Description;
            data.Title = material.Title;
            data.URL = material.URL;
            data.ContentType = material.ContentType;
            _context.SaveChanges(); // Save changes to the database
            return material;
        }

    }

}