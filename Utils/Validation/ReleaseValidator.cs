using ReleaseRetention.Models;

namespace ReleaseRetention.Utils.Validation
{
    public class ReleaseValidator
    {
        public static bool ValidateReleases(List<Release> releasesToValidate)
        {
            foreach (var release in releasesToValidate)
            {
                if (string.IsNullOrEmpty(release.Id))
                {
                    throw new Exception("Release ID cannot be null or empty.");
                }

                if (string.IsNullOrEmpty(release.ProjectId))
                {
                    throw new Exception("Project ID cannot be null or empty.");
                }

                if (release.Created == default)
                {
                    throw new Exception("Created date cannot be default.");
                }
            }

            return true;
        }
    }
}
