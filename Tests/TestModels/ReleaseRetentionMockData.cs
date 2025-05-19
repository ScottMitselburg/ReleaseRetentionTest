using ReleaseRetention.Models;
using Environment = ReleaseRetention.Models.Environment;

namespace ReleaseRetention.Tests.TestModels
{
    public class ReleaseRetentionMockData
    {
        public List<Project> Projects { get; set; }
        public List<Environment> Environments { get; set; }
        public List<Release> Releases { get; set; }
        public List<Deployment> Deployments { get; set; }

        public void Deconstruct(out List<Project> projects, out List<Environment> environments, out List<Release> releases, out List<Deployment> deployments)
        {
            projects = Projects;
            environments = Environments;
            releases = Releases;
            deployments = Deployments;
        }
    }

}