using ReleaseRetention.Models;
using Environment = ReleaseRetention.Models.Environment;

namespace ReleaseRetention.Utils.Validation
{
    public class EnvironmentValidator
    {
        public static bool ValidateEnvironments(List<Environment> enviromentsToValidate)
        {
            if (enviromentsToValidate == null || enviromentsToValidate.Count == 0)
            {
                throw new Exception("Environments list cannot be null.");
            }

            foreach (var enviroment in enviromentsToValidate)
            {
                if (string.IsNullOrEmpty(enviroment.Id))
                {
                    throw new Exception("Environment ID cannot be null or empty.");
                }

                if (string.IsNullOrEmpty(enviroment.Name))
                {
                    throw new Exception("Environment Name cannot be null or empty.");
                }
            }

            return true;
        }
    }
}
