using FluentAssertions;
using Newtonsoft.Json;
using ReleaseRetention.Models;
using ReleaseRetention.Tests.TestData;
using Xunit;

namespace ReleaseRetentionTest
{
    public class ReleaseRetentionRuleTest
    {
        public class OneProjectTests
        {
            [Fact]
            public void OneRelease_DeployedTo_Environment_KeepOne()
            {
                var releasesToKeep = 1;

                var (projects, environments, releases, deployments) = ReleaseRetentionRulesTestData.OneProject.OneEnviroment_OneRelease_OneDeployment();

                var actualResult = ReleaseRetention.ReleaseRetentionRule.ReleasesToKeep(releasesToKeep, projects, environments, releases, deployments);

                var expectedresult = new List<Release>
            {
                new Release { Id = "R1", ProjectId = "P1", Version = "1.0", Created = DateTime.Parse("2000-01-01T08:00:00") }
            };

                actualResult.Should().BeEquivalentTo(expectedresult);
            }

            [Fact]
            public void TwoReleases_DeployedTo_Same_Environment_KeepOne()
            {
                var releasesToKeep = 1;

                var (projects, environments, releases, deployments) = ReleaseRetentionRulesTestData.OneProject.OneEnvironment_TwoReleases_TwoDeployments_To_Same_Enviroment();

                var actualResult = ReleaseRetention.ReleaseRetentionRule.ReleasesToKeep(releasesToKeep, projects, environments, releases, deployments);

                var expectedresult = new List<Release>
            {
                new Release { Id = "R1", ProjectId = "P1", Version = "1.0", Created = DateTime.Parse("2000-01-01T08:00:00") }
            };

                actualResult.Should().BeEquivalentTo(expectedresult);
            }

            [Fact]
            public void TwoReleases_DeployedTo_Same_Environment_KeepTwo()
            {
                var releasesToKeep = 2;

                var (projects, environments, releases, deployments) = ReleaseRetentionRulesTestData.OneProject.OneEnvironment_TwoReleases_TwoDeployments_To_Same_Enviroment();

                var actualResult = ReleaseRetention.ReleaseRetentionRule.ReleasesToKeep(releasesToKeep, projects, environments, releases, deployments);

                var expectedresult = new List<Release>
            {
                new Release { Id = "R1", ProjectId = "P1", Version = "1.0", Created = DateTime.Parse("2000-01-01T08:00:00") },
                new Release { Id = "R2", ProjectId = "P1", Version = "1.1", Created = DateTime.Parse("2000-01-01T09:00:00") }
            };

                actualResult.Should().BeEquivalentTo(expectedresult);
            }

            [Fact]
            public void ThreeReleases_DeployedTo_Same_Environment_KeepTwo()
            {
                var releasesToKeep = 2;

                var (projects, environments, releases, deployments) = ReleaseRetentionRulesTestData.OneProject.OneEnvrioment_ThreeReleases_ThreeDeployments_To_Same_Environment();

                var actualResult = ReleaseRetention.ReleaseRetentionRule.ReleasesToKeep(releasesToKeep, projects, environments, releases, deployments);

                var expectedresult = new List<Release>
            {
                new Release { Id = "R1", ProjectId = "P1", Version = "1.0", Created = DateTime.Parse("2000-01-01T08:00:00") },
                new Release { Id = "R3", ProjectId = "P1", Version = "1.2", Created = DateTime.Parse("2000-01-01T10:00:00") }
            };

                actualResult.Should().BeEquivalentTo(expectedresult);
            }

            [Fact]
            public void TwoReleases_DeployedTo_Different_Environments_KeepOne()
            {
                var releasesToKeep = 1;

                var (projects, environments, releases, deployments) = ReleaseRetentionRulesTestData.OneProject.TwoEnvironments_TwoReleases_TwoDeployments_To_Different_Environments();

                var actualResult = ReleaseRetention.ReleaseRetentionRule.ReleasesToKeep(releasesToKeep, projects, environments, releases, deployments);

                var expectedresult = new List<Release>
            {
                new Release { Id = "R2", ProjectId = "P1", Version = "1.1", Created = DateTime.Parse("2000-01-01T09:00:00") },
                new Release { Id = "R1", ProjectId = "P1", Version = "1.0", Created = DateTime.Parse("2000-01-01T08:00:00") }
            };

                actualResult.Should().BeEquivalentTo(expectedresult);

            }

            [Fact]
            public void SixReleases_DeployedTo_Different_Environments_KeepTwo()
            {
                var releasesToKeep = 2;

                var (projects, environments, releases, deployments) = ReleaseRetentionRulesTestData.OneProject.TwoEnvironments_SixReleases_SixDeployments_To_Different_Environments();

                var actualResult = ReleaseRetention.ReleaseRetentionRule.ReleasesToKeep(releasesToKeep, projects, environments, releases, deployments);

                var expectedresult = new List<Release>
            {
                new Release { Id = "R6", ProjectId = "P1", Version = "1.5", Created = DateTime.Parse("2000-01-01T13:00:00") },
                new Release { Id = "R5", ProjectId = "P1", Version = "1.4", Created = DateTime.Parse("2000-01-01T12:00:00") },
                new Release { Id = "R4", ProjectId = "P1", Version = "1.3", Created = DateTime.Parse("2000-01-01T11:00:00") },
                new Release { Id = "R3", ProjectId = "P1", Version = "1.2", Created = DateTime.Parse("2000-01-01T10:00:00") },
            };

                actualResult.Should().BeEquivalentTo(expectedresult);

            }
        }

        public class TwoProjectsTests
        {
            [Fact]
            public void TwoReleases_DeployedTo_Different_Envrioments_In_Different_Projects_KeepOne()
            {
                var releasesToKeep = 1;

                var (projects, environments, releases, deployments) = ReleaseRetentionRulesTestData.TwoProjects.TwoEnvironments_TwoReleases_TwoDeployments_To_Different_Environments();

                var actualResult = ReleaseRetention.ReleaseRetentionRule.ReleasesToKeep(releasesToKeep, projects, environments, releases, deployments);

                var expectedresult = new List<Release>
                {

                    new Release { Id = "R2", ProjectId = "P2", Version = "1.1", Created = DateTime.Parse("2000-01-01T09:00:00") },
                    new Release { Id = "R1", ProjectId = "P1", Version = "1.0", Created = DateTime.Parse("2000-01-01T08:00:00") }
                };

                actualResult.Should().BeEquivalentTo(expectedresult);
            }

            [Fact]
            public void FoursReleases_DeployedTo_Two_Different_Envrioments_In_Different_Projects_With_A_Enviroment_Not_Deployed_To_KeepOne()
            {
                var releasesToKeep = 1;

                var (projects, environments, releases, deployments) = ReleaseRetentionRulesTestData.TwoProjects.ThreeEnvrionments_FourReleases_FourDeployments_To_Two_Different_Environments();

                var actualResult = ReleaseRetention.ReleaseRetentionRule.ReleasesToKeep(releasesToKeep, projects, environments, releases, deployments);

                var expectedresult = new List<Release>
                {
                    new Release { Id = "R4", ProjectId = "P2", Version = "1.3", Created = DateTime.Parse("2000-01-01T11:00:00") },
                    new Release { Id = "R3", ProjectId = "P1", Version = "1.2", Created = DateTime.Parse("2000-01-01T10:00:00") }
                };

                actualResult.Should().BeEquivalentTo(expectedresult);
            }
        }

        public class ThreeProjectTests
        {
            [Fact]
            public void ThreeReleases_DeployedTo_The_Same_Environment_In_Different_Projects_With_One_Release_Not_Deployed_KeepOne()
            {
                var releasesToKeep = 1;

                var (projects, environments, releases, deployments) = ReleaseRetentionRulesTestData.ThreeProjects.OneEnvrionment_FourReleases_ThreeDeployments_To_Same_Environment();

                var actualResult = ReleaseRetention.ReleaseRetentionRule.ReleasesToKeep(releasesToKeep, projects, environments, releases, deployments);

                var expectedresult = new List<Release>
                {
                    new Release { Id = "R4", ProjectId = "P1", Version = "1.0", Created = DateTime.Parse("2000-01-01T11:00:00") },
                    new Release { Id = "R2", ProjectId = "P2", Version = "1.0", Created = DateTime.Parse("2000-01-01T09:00:00") }
                };

                actualResult.Should().BeEquivalentTo(expectedresult);
            }
        }

        public class ExceptionTests
        {
            [Fact]
            public void Invalid_Projects_Returns_Empty_List()
            {
                var (projects, environments, releases, deployments) = ReleaseRetentionRulesTestData.ExpectionData.InvalidProject();

                var actualResult = ReleaseRetention.ReleaseRetentionRule.ReleasesToKeep(1, projects, environments, releases, deployments);
                var expectedresult = new List<Release>();
                actualResult.Should().BeEquivalentTo(expectedresult);
            }

            [Fact]
            public void Invalid_Environments_Returns_Empty_List()
            {
                var (projects, environments, releases, deployments) = ReleaseRetentionRulesTestData.ExpectionData.InvalidEnvironment();

                var actualResult = ReleaseRetention.ReleaseRetentionRule.ReleasesToKeep(1, projects, environments, releases, deployments);
                var expectedresult = new List<Release>();
                actualResult.Should().BeEquivalentTo(expectedresult);
            }

            [Fact]
            public void Invalid_Releases_Returns_Empty_List()
            {
                var (projects, environments, releases, deployments) = ReleaseRetentionRulesTestData.ExpectionData.InvalidRelease();

                var actualResult = ReleaseRetention.ReleaseRetentionRule.ReleasesToKeep(1, projects, environments, releases, deployments);
                var expectedresult = new List<Release>();
                actualResult.Should().BeEquivalentTo(expectedresult);
            }

            [Fact]
            public void Invalid_Deployments_Returns_Empty_List()
            {
                var (projects, environments, releases, deployments) = ReleaseRetentionRulesTestData.ExpectionData.InvalidDeployment();

                var actualResult = ReleaseRetention.ReleaseRetentionRule.ReleasesToKeep(1, projects, environments, releases, deployments);
                var expectedresult = new List<Release>();
                actualResult.Should().BeEquivalentTo(expectedresult);
            }

            [Fact]
            public void Empty_Releases_Returns_Empty_List()
            {
                var (projects, environments, releases, deployments) = ReleaseRetentionRulesTestData.ExpectionData.EmptyReleases();

                var actualResult = ReleaseRetention.ReleaseRetentionRule.ReleasesToKeep(1, projects, environments, releases, deployments);
                var expectedresult = new List<Release>();
                actualResult.Should().BeEquivalentTo(expectedresult);
            }

            [Fact]
            public void Empty_Deployments_Returns_Empty_List()
            {
                var (projects, environments, releases, deployments) = ReleaseRetentionRulesTestData.ExpectionData.EmptyDeployments();

                var actualResult = ReleaseRetention.ReleaseRetentionRule.ReleasesToKeep(1, projects, environments, releases, deployments);
                var expectedresult = new List<Release>();
                actualResult.Should().BeEquivalentTo(expectedresult);
            }
        }

    }
}