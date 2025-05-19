using System;
using System.Collections.Generic;
using ReleaseRetention.Models;
using ReleaseRetention.Utils.Validation;
using Xunit;
using FluentAssertions;

namespace ReleaseRetention.Utils.Validation.Tests
{
    public class ReleaseValidatorTests
    {
        private static Release GetValidRelease()
        {
            return new Release
            {
                Id = "rel-1",
                ProjectId = "proj-1",
                Version = "1.0.0",
                Created = DateTime.UtcNow
            };
        }

        [Fact]
        public void ValidateReleases_AllValid_ReturnsTrue()
        {
            var releases = new List<Release>
            {
                GetValidRelease(),
                new Release { Id = "rel-2", ProjectId = "proj-2", Version = "2.0.0", Created = DateTime.UtcNow }
            };

            ReleaseValidator.ValidateReleases(releases).Should().BeTrue();
        }

        [Fact]
        public void ValidateReleases_NullOrEmptyId_ThrowsException()
        {
            var releases = new List<Release>
            {
                GetValidRelease(),
                new Release { Id = "", ProjectId = "proj-2", Version = "2.0.0", Created = DateTime.UtcNow }
            };

            Action act = () => ReleaseValidator.ValidateReleases(releases);
            act.Should().Throw<Exception>()
                .WithMessage("Release ID cannot be null or empty.");
        }

        [Fact]
        public void ValidateReleases_NullOrEmptyProjectId_ThrowsException()
        {
            var releases = new List<Release>
            {
                GetValidRelease(),
                new Release { Id = "rel-2", ProjectId = "", Version = "2.0.0", Created = DateTime.UtcNow }
            };

            Action act = () => ReleaseValidator.ValidateReleases(releases);
            act.Should().Throw<Exception>()
                .WithMessage("Project ID cannot be null or empty.");
        }
    }
}