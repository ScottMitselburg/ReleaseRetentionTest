using ReleaseRetention.Models;
using Environment = ReleaseRetention.Models.Environment;

namespace ReleaseRetention.Utils.Validation
{
    public class ReleaseRetentionValidation
    {
        public static bool ValidateReleaseRetentionData(List<Project> projects, List<Environment> enviroments, List<Release> releases, List<Deployment> deployments)
        {
            bool isValid;
            try
            {
                isValid = ProjectValidator.ValidateProjects(projects);
                isValid = EnvironmentValidator.ValidateEnvironments(enviroments);
                isValid = ReleaseValidator.ValidateReleases(releases);
                isValid = DeploymentValidator.ValidateDeployments(deployments);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Validation error: {ex.Message}");
                isValid = false;
            }
// 
            return isValid;
        }
    }
}