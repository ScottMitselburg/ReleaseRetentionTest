using ReleaseRetention.Models;
using Xunit;
using FluentAssertions;

namespace ReleaseRetention.Utils.Validation.Tests
{
    public class ProjectValidatorTests
    {
        private static Project GetValidProject()
        {
            return new Project
            {
                Id = "proj-1",
                Name = "My Project"
            };
        }

        [Fact]
        public void ValidateProjects_AllValid_ReturnsTrue()
        {
            var projects = new List<Project>
            {
                GetValidProject(),
                new Project { Id = "proj-2", Name = "Another Project" }
            };

            ProjectValidator.ValidateProjects(projects).Should().BeTrue();
        }

        [Fact]
        public void ValidateProjects_NullOrEmptyId_ThrowsException()
        {
            var projects = new List<Project>
            {
                GetValidProject(),
                new Project { Id = "", Name = "Another Project" }
            };

            Action act = () => ProjectValidator.ValidateProjects(projects);
            act.Should().Throw<Exception>()
                .WithMessage("Project ID cannot be null or empty.");
        }

        [Fact]
        public void ValidateProjects_NullOrEmptyName_ThrowsException()
        {
            var projects = new List<Project>
            {
                GetValidProject(),
                new Project { Id = "proj-2", Name = "" }
            };

            Action act = () => ProjectValidator.ValidateProjects(projects);
            act.Should().Throw<Exception>()
                .WithMessage("Project Name cannot be null or empty.");
        }

        [Fact]
        public void ValidateProjects_NullList_ThrowsException()
        {
            List<Project> projects = null;

            Action act = () => ProjectValidator.ValidateProjects(projects);
            act.Should().Throw<Exception>()
                .WithMessage("Projects list cannot be null or empty.");
        }

        [Fact]
        public void ValidateProjects_EmptyList_ThrowsException()
        {
            var projects = new List<Project>();

            Action act = () => ProjectValidator.ValidateProjects(projects);
            act.Should().Throw<Exception>()
                .WithMessage("Projects list cannot be null or empty.");
        }
    }
}