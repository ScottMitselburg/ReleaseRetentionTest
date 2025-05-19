using ReleaseRetention.Models;

namespace ReleaseRetention.Utils.Validation
{
    public class ProjectValidator
    {
        public static bool ValidateProjects(List<Project> projectsToValidate)
        {
            if (projectsToValidate == null || projectsToValidate.Count == 0)
            {
                throw new Exception("Projects list cannot be null or empty.");
            }
            ;

            foreach (var project in projectsToValidate)
            {
                if (string.IsNullOrEmpty(project.Id))
                {
                    throw new Exception("Project ID cannot be null or empty.");
                }

                if (string.IsNullOrEmpty(project.Name))
                {
                    throw new Exception("Project Name cannot be null or empty.");
                }
            }

            return true;
        }
    }
}