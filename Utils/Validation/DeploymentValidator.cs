using ReleaseRetention.Models;

namespace ReleaseRetention.Utils.Validation
{
    public class DeploymentValidator
    {
        public static bool ValidateDeployments(List<Deployment> deploymentsToValidate)
        {
            foreach (var deployment in deploymentsToValidate)
            {
                if (string.IsNullOrEmpty(deployment.Id))
                {
                    throw new Exception("Deployment ID cannot be null or empty.");
                }

                if (string.IsNullOrEmpty(deployment.ReleaseId))
                {
                    throw new Exception("Release ID cannot be null or empty.");
                }

                if (string.IsNullOrEmpty(deployment.EnvironmentId))
                {
                    throw new Exception("Environment ID cannot be null or empty.");
                }

                if (deployment.DeployedAt == default)
                {
                    throw new Exception("DeployedAt date cannot be default.");
                }
            }

            return true;
        }
    }
}