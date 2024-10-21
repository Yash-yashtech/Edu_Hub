
using Edu_Hub_Project.Models;
using Edu_Hub_Project.Repository;

namespace Edu_Hub_Project.Services;

public interface IMaterialService
{
   public Material AddMaterial(Material newMaterial);
   public  List<Material> MyMaterial(int id);
   public List<Material> MyMaterialEducator(int id);
    public List<Material> GetMaterialByCourseId(int id);
    public Material GetMaterialByMaterialId(int id);
    

    Material UpdateMaterial(int id ,Material data);
}