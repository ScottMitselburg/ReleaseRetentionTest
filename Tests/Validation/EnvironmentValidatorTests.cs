using Xunit;
using FluentAssertions;
using Environment = ReleaseRetention.Models.Environment;

namespace ReleaseRetention.Utils.Validation.Tests
{
    public class EnvironmentValidatorTests
    {
        private static Environment GetValidEnvironment()
        {
            return new Environment
            {
                Id = "env-1",
                Name = "Production"
            };
        }

        [Fact]
        public void ValidateEnvironments_AllValid_ReturnsTrue()
        {
            var environments = new List<Environment>
            {
                GetValidEnvironment(),
                new Environment { Id = "env-2", Name = "Staging" }
            };

            EnvironmentValidator.ValidateEnvironments(environments).Should().BeTrue();
        }

        [Fact]
        public void ValidateEnvironments_NullOrEmptyId_ThrowsException()
        {
            var environments = new List<Environment>
            {
                GetValidEnvironment(),
                new Environment { Id = "", Name = "Staging" }
            };

            Action act = () => EnvironmentValidator.ValidateEnvironments(environments);
            act.Should().Throw<Exception>()
                .WithMessage("Environment ID cannot be null or empty.");
        }

        [Fact]
        public void ValidateEnvironments_NullOrEmptyName_ThrowsException()
        {
            var environments = new List<Environment>
            {
                GetValidEnvironment(),
                new Environment { Id = "env-2", Name = "" }
            };

            Action act = () => EnvironmentValidator.ValidateEnvironments(environments);
            act.Should().Throw<Exception>()
                .WithMessage("Environment Name cannot be null or empty.");
        }

        [Fact]
        public void ValidateEnvironments_NullList_ThrowsException()
        {
            List<Environment> environments = null;

            Action act = () => EnvironmentValidator.ValidateEnvironments(environments);
            act.Should().Throw<Exception>()
                .WithMessage("Environments list cannot be null.");
        }

        [Fact]
        public void ValidateEnvironments_EmptyList_ThrowsException()
        {
            var environments = new List<Environment>();

            Action act = () => EnvironmentValidator.ValidateEnvironments(environments);
            act.Should().Throw<Exception>()
                .WithMessage("Environments list cannot be null.");
        }
    }
}