using ReleaseRetention.Models;
using Xunit;
using FluentAssertions;
using Environment = ReleaseRetention.Models.Environment;

namespace ReleaseRetention.Utils.Validation.Tests
{
    public class ReleaseRetentionValidationTests
    {
        private static Project GetValidProject() => new Project { Id = "proj-1", Name = "Project 1" };
        private static Release GetValidRelease() => new Release { Id = "rel-1", ProjectId = "proj-1", Version = "1.0.0", Created = DateTime.UtcNow };
        private static Environment GetValidEnvironment() => new Environment { Id = "env-1", Name = "Production" };
        private static Deployment GetValidDeployment() => new Deployment
        {
            Id = "dep-1",
            ReleaseId = "rel-1",
            EnvironmentId = "env-1",
            DeployedAt = DateTime.UtcNow
        };

        [Fact]
        public void ValidateReleaseRetentionData_AllValid_ReturnsTrue()
        {
            var projects = new List<Project> { GetValidProject() };
            var environments = new List<Environment> { GetValidEnvironment() };
            var releases = new List<Release> { GetValidRelease() };
            var deployments = new List<Deployment> { GetValidDeployment() };

            var result = ReleaseRetentionValidation.ValidateReleaseRetentionData(projects, environments, releases, deployments);

            result.Should().BeTrue();
        }

        [Fact]
        public void ValidateReleaseRetentionData_InvalidProjects_ReturnsFalse()
        {
            var projects = new List<Project> { new Project { Id = "", Name = "Project 1" } };
            var environments = new List<Environment> { GetValidEnvironment() };
            var releases = new List<Release> { GetValidRelease() };
            var deployments = new List<Deployment> { GetValidDeployment() };

            var result = ReleaseRetentionValidation.ValidateReleaseRetentionData(projects, environments, releases, deployments);

            result.Should().BeFalse();
        }

        [Fact]
        public void ValidateReleaseRetentionData_InvalidEnvironments_ReturnsFalse()
        {
            var projects = new List<Project> { GetValidProject() };
            var environments = new List<Environment> { new Environment { Id = "", Name = "Production" } };
            var releases = new List<Release> { GetValidRelease() };
            var deployments = new List<Deployment> { GetValidDeployment() };

            var result = ReleaseRetentionValidation.ValidateReleaseRetentionData(projects, environments, releases, deployments);

            result.Should().BeFalse();
        }

        [Fact]
        public void ValidateReleaseRetentionData_InvalidReleases_ReturnsFalse()
        {
            var projects = new List<Project> { GetValidProject() };
            var environments = new List<Environment> { GetValidEnvironment() };
            var releases = new List<Release> { new Release { Id = "", ProjectId = "proj-1", Version = "1.0.0" } };
            var deployments = new List<Deployment> { GetValidDeployment() };

            var result = ReleaseRetentionValidation.ValidateReleaseRetentionData(projects, environments, releases, deployments);

            result.Should().BeFalse();
        }

        [Fact]
        public void ValidateReleaseRetentionData_InvalidDeployments_ReturnsFalse()
        {
            var projects = new List<Project> { GetValidProject() };
            var environments = new List<Environment> { GetValidEnvironment() };
            var releases = new List<Release> { GetValidRelease() };
            var deployments = new List<Deployment> { new Deployment { Id = "", ReleaseId = "rel-1", EnvironmentId = "env-1", DeployedAt = DateTime.UtcNow } };

            var result = ReleaseRetentionValidation.ValidateReleaseRetentionData(projects, environments, releases, deployments);

            result.Should().BeFalse();
        }
    }
}