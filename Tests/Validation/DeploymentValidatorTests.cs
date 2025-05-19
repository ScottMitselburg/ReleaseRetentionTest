using ReleaseRetention.Models;
using Xunit;
using FluentAssertions;

namespace ReleaseRetention.Utils.Validation.Tests
{
    public class DeploymentValidatorTest
    {
        private static Deployment GetValidDeployment()
        {
            return new Deployment
            {
                Id = "dep-1",
                ReleaseId = "rel-1",
                EnvironmentId = "env-1",
                DeployedAt = DateTime.UtcNow
            };
        }

        [Fact]
        public void ValidateDeployments_AllValid_ReturnsTrue()
        {
            var deployments = new List<Deployment>
            {
                GetValidDeployment(),
                GetValidDeployment()
            };

            DeploymentValidator.ValidateDeployments(deployments).Should().BeTrue();
        }

        [Fact]
        public void ValidateDeployments_NullOrEmptyDeploymentId_ThrowsException()
        {
            var deployments = new List<Deployment>
            {
                GetValidDeployment(),
                new Deployment
                {
                    Id = "",
                    ReleaseId = "rel-2",
                    EnvironmentId = "env-2",
                    DeployedAt = DateTime.UtcNow
                }
            };

            var act = () => DeploymentValidator.ValidateDeployments(deployments);
            act.Should().Throw<Exception>()
                .WithMessage("Deployment ID cannot be null or empty.");
        }

        [Fact]
        public void ValidateDeployments_NullOrEmptyReleaseId_ThrowsException()
        {
            var deployments = new List<Deployment>
            {
                GetValidDeployment(),
                new Deployment
                {
                    Id = "dep-2",
                    ReleaseId = null,
                    EnvironmentId = "env-2",
                    DeployedAt = DateTime.UtcNow
                }
            };

            var act = () => DeploymentValidator.ValidateDeployments(deployments);
            act.Should().Throw<Exception>()
                .WithMessage("Release ID cannot be null or empty.");
        }

        [Fact]
        public void ValidateDeployments_NullOrEmptyEnvironmentId_ThrowsException()
        {
            var deployments = new List<Deployment>
            {
                GetValidDeployment(),
                new Deployment
                {
                    Id = "dep-2",
                    ReleaseId = "rel-2",
                    EnvironmentId = "",
                    DeployedAt = DateTime.UtcNow
                }
            };

            var act = () => DeploymentValidator.ValidateDeployments(deployments);
            act.Should().Throw<Exception>()
                .WithMessage("Environment ID cannot be null or empty.");
        }

        [Fact]
        public void ValidateDeployments_DefaultDeployedAt_ThrowsException()
        {
            var deployments = new List<Deployment>
            {
                GetValidDeployment(),
                new Deployment
                {
                    Id = "dep-2",
                    ReleaseId = "rel-2",
                    EnvironmentId = "env-2",
                    DeployedAt = default
                }
            };

            var act = () => DeploymentValidator.ValidateDeployments(deployments);
            act.Should().Throw<Exception>()
                .WithMessage("DeployedAt date cannot be default.");
        }
    }
}