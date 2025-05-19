using ReleaseRetention.Models;
using ReleaseRetention.Tests.TestModels;
using Environment = ReleaseRetention.Models.Environment;

namespace ReleaseRetention.Tests.TestData
{

    public static class ReleaseRetentionRulesTestData
    {
        public static class OneProject
        {
            public static ReleaseRetentionMockData OneEnviroment_OneRelease_OneDeployment()
            {
                return new ReleaseRetentionMockData
                {
                    Projects = new List<Project>
                {
                    new Project { Id = "P1", Name = "Project1" }
                },
                    Environments = new List<Environment>
                {
                    new Environment { Id = "E1", Name = "Env1" }
                },
                    Releases = new List<Release>
                {
                    new Release { Id = "R1", ProjectId = "P1", Version = "1.0", Created = DateTime.Parse("2000-01-01T08:00:00") }
                },
                    Deployments = new List<Deployment>
                {
                    new Deployment { Id = "D1", ReleaseId = "R1", EnvironmentId = "E1", DeployedAt = DateTime.Parse("2000-01-01T09:00:00") }
                }
                };
            }

            public static ReleaseRetentionMockData OneEnvironment_TwoReleases_TwoDeployments_To_Same_Enviroment()
            {
                return new ReleaseRetentionMockData
                {
                    Projects = new List<Project>
                {
                    new Project { Id = "P1", Name = "Project1" }
                },
                    Environments = new List<Environment>
                {
                    new Environment { Id = "E1", Name = "Env1" }
                },
                    Releases = new List<Release>
                {
                    new Release { Id = "R1", ProjectId = "P1", Version = "1.0", Created = DateTime.Parse("2000-01-01T08:00:00") },
                    new Release { Id = "R2", ProjectId = "P1", Version = "1.1", Created = DateTime.Parse("2000-01-01T09:00:00") }
                },
                    Deployments = new List<Deployment>
                {
                    new Deployment { Id = "D1", ReleaseId = "R2", EnvironmentId = "E1", DeployedAt = DateTime.Parse("2000-01-01T10:00:00") },
                    new Deployment { Id = "D2", ReleaseId = "R1", EnvironmentId = "E1", DeployedAt = DateTime.Parse("2000-01-01T11:00:00") },
                }

                };
            }

            public static ReleaseRetentionMockData OneEnvrioment_ThreeReleases_ThreeDeployments_To_Same_Environment()
            {
                return new ReleaseRetentionMockData
                {
                    Projects = new List<Project>
                {
                    new Project { Id = "P1", Name = "Project1" }
                },
                    Environments = new List<Environment>
                {
                    new Environment { Id = "E1", Name = "Env1" }
                },
                    Releases = new List<Release>
                {
                    new Release { Id = "R1", ProjectId = "P1", Version = "1.0", Created = DateTime.Parse("2000-01-01T08:00:00") },
                    new Release { Id = "R2", ProjectId = "P1", Version = "1.1", Created = DateTime.Parse("2000-01-01T09:00:00") },
                    new Release { Id = "R3", ProjectId = "P1", Version = "1.2", Created = DateTime.Parse("2000-01-01T10:00:00") }
                },
                    Deployments = new List<Deployment>
                {
                    new Deployment { Id = "D1", ReleaseId = "R2", EnvironmentId = "E1", DeployedAt = DateTime.Parse("2000-01-01T11:00:00") },
                    new Deployment { Id = "D2", ReleaseId = "R3", EnvironmentId = "E1", DeployedAt = DateTime.Parse("2000-01-01T12:00:00") },
                    new Deployment { Id = "D3", ReleaseId = "R1", EnvironmentId = "E1", DeployedAt = DateTime.Parse("2000-01-01T13:00:00") }
                }
                };
            }

            public static ReleaseRetentionMockData TwoEnvironments_TwoReleases_TwoDeployments_To_Different_Environments()
            {
                return new ReleaseRetentionMockData
                {
                    Projects = new List<Project>
                {
                    new Project { Id = "P1", Name = "Project1" }
                },
                    Environments = new List<Environment>
                {
                    new Environment { Id = "E1", Name = "Env1" },
                    new Environment { Id = "E2", Name = "Env2" }
                },
                    Releases = new List<Release>
                {
                    new Release { Id = "R1", ProjectId = "P1", Version = "1.0", Created = DateTime.Parse("2000-01-01T08:00:00") },
                    new Release { Id = "R2", ProjectId = "P1", Version = "1.1", Created = DateTime.Parse("2000-01-01T09:00:00") }
                },
                    Deployments = new List<Deployment>
                {
                    new Deployment { Id = "D1", ReleaseId = "R2", EnvironmentId = "E1", DeployedAt = DateTime.Parse("2000-01-01T10:00:00") },
                    new Deployment { Id = "D2", ReleaseId = "R1", EnvironmentId = "E2", DeployedAt = DateTime.Parse("2000-01-01T11:00:00") },
                }
                };
            }

            public static ReleaseRetentionMockData TwoEnvironments_SixReleases_SixDeployments_To_Different_Environments()
            {
                return new ReleaseRetentionMockData
                {
                    Projects = new List<Project>
                {
                    new Project { Id = "P1", Name = "Project1" }
                },
                    Environments = new List<Environment>
                {
                    new Environment { Id = "E1", Name = "Env1" },
                    new Environment { Id = "E2", Name = "Env2" }
                },
                    Releases = new List<Release>
                {
                    new Release { Id = "R1", ProjectId = "P1", Version = "1.0", Created = DateTime.Parse("2000-01-01T08:00:00") },
                    new Release { Id = "R2", ProjectId = "P1", Version = "1.1", Created = DateTime.Parse("2000-01-01T09:00:00") },
                    new Release { Id = "R3", ProjectId = "P1", Version = "1.2", Created = DateTime.Parse("2000-01-01T10:00:00") },
                    new Release { Id = "R4", ProjectId = "P1", Version = "1.3", Created = DateTime.Parse("2000-01-01T11:00:00") },
                    new Release { Id = "R5", ProjectId = "P1", Version = "1.4", Created = DateTime.Parse("2000-01-01T12:00:00") },
                    new Release { Id = "R6", ProjectId = "P1", Version = "1.5", Created = DateTime.Parse("2000-01-01T13:00:00") }
                },
                    Deployments = new List<Deployment>
                {
                    new Deployment { Id = "D1", ReleaseId = "R2", EnvironmentId = "E1", DeployedAt = DateTime.Parse("2000-01-01T10:00:00") },
                    new Deployment { Id = "D2", ReleaseId = "R1", EnvironmentId = "E2", DeployedAt = DateTime.Parse("2000-01-01T11:00:00") },
                    new Deployment { Id = "D3", ReleaseId = "R3", EnvironmentId = "E1", DeployedAt = DateTime.Parse("2000-01-01T12:00:00") },
                    new Deployment { Id = "D4", ReleaseId = "R4", EnvironmentId = "E2", DeployedAt = DateTime.Parse("2000-01-01T13:00:00") },
                    new Deployment { Id = "D5", ReleaseId = "R5", EnvironmentId = "E1", DeployedAt = DateTime.Parse("2000-01-01T14:00:00") },
                    new Deployment { Id = "D6", ReleaseId = "R6", EnvironmentId = "E2", DeployedAt = DateTime.Parse("2000-01-01T15:00:00") }
                }
                };
            }
        }

        public static class TwoProjects
        {
            public static ReleaseRetentionMockData TwoEnvironments_TwoReleases_TwoDeployments_To_Different_Environments()
            {
                return new ReleaseRetentionMockData
                {
                    Projects = new List<Project>
                {
                    new Project { Id = "P1", Name = "Project1" },
                    new Project { Id = "P2", Name = "Project2" }
                },
                    Environments = new List<Environment>
                {
                    new Environment { Id = "E1", Name = "Env1" },
                    new Environment { Id = "E2", Name = "Env2" }
                },
                    Releases = new List<Release>
                {
                    new Release { Id = "R1", ProjectId = "P1", Version = "1.0", Created = DateTime.Parse("2000-01-01T08:00:00") },
                    new Release { Id = "R2", ProjectId = "P2", Version = "1.1", Created = DateTime.Parse("2000-01-01T09:00:00") }
                },
                    Deployments = new List<Deployment>
                {
                    new Deployment { Id = "D1", ReleaseId = "R1", EnvironmentId = "E1", DeployedAt = DateTime.Parse("2000-01-01T10:00:00") },
                    new Deployment { Id = "D2", ReleaseId = "R2", EnvironmentId = "E2", DeployedAt = DateTime.Parse("2000-01-01T11:00:00") },
                }
                };
            }

            public static ReleaseRetentionMockData ThreeEnvrionments_FourReleases_FourDeployments_To_Two_Different_Environments()
            {
                return new ReleaseRetentionMockData
                {
                    Projects = new List<Project>
                    {
                        new Project { Id = "P1", Name = "Project1" },
                        new Project { Id = "P2", Name = "Project2" }
                    },
                    Environments = new List<Environment>
                    {
                        new Environment { Id = "E1", Name = "Env1" },
                        new Environment { Id = "E2", Name = "Env2" },
                        new Environment { Id = "E3", Name = "Env3" }
                    },
                    Releases = new List<Release>
                    {
                        new Release { Id = "R1", ProjectId = "P1", Version = "1.0", Created = DateTime.Parse("2000-01-01T08:00:00") },
                        new Release { Id = "R2", ProjectId = "P2", Version = "1.1", Created = DateTime.Parse("2000-01-01T09:00:00") },
                        new Release { Id = "R3", ProjectId = "P1", Version = "1.2", Created = DateTime.Parse("2000-01-01T10:00:00") },
                        new Release { Id = "R4", ProjectId = "P2", Version = "1.3", Created = DateTime.Parse("2000-01-01T11:00:00") }
                    },
                    Deployments = new List<Deployment>
                    {
                        new Deployment { Id = "D1", ReleaseId = "R1", EnvironmentId = "E1", DeployedAt = DateTime.Parse("2000-01-01T12:00:00") },
                        new Deployment { Id = "D2", ReleaseId = "R2", EnvironmentId = "E2", DeployedAt = DateTime.Parse("2000-01-01T13:00:00") },
                        new Deployment { Id = "D3", ReleaseId = "R3", EnvironmentId = "E1", DeployedAt = DateTime.Parse("2000-01-01T14:00:00") },
                        new Deployment { Id = "D4", ReleaseId = "R4", EnvironmentId = "E2", DeployedAt = DateTime.Parse("2000-01-01T15:00:00") },
                    }
                };
            }
        }

        public static class ThreeProjects
        {
            public static ReleaseRetentionMockData OneEnvrionment_FourReleases_ThreeDeployments_To_Same_Environment()
            {
                return new ReleaseRetentionMockData
                {
                    Projects = new List<Project>
                    {
                        new Project { Id = "P1", Name = "Project1" },
                        new Project { Id = "P2", Name = "Project2" },
                        new Project { Id = "P3", Name = "Project3" }
                    },
                    Environments = new List<Environment>
                    {
                        new Environment { Id = "E1", Name = "Env1" }
                    },
                    Releases = new List<Release>
                    {
                        new Release { Id = "R1", ProjectId = "P1", Version = "1.0", Created = DateTime.Parse("2000-01-01T08:00:00") },
                        new Release { Id = "R2", ProjectId = "P2", Version = "1.0", Created = DateTime.Parse("2000-01-01T09:00:00") },
                        new Release { Id = "R3", ProjectId = "P3", Version = null, Created = DateTime.Parse("2000-01-01T10:00:00") },
                        new Release { Id = "R4", ProjectId = "P1", Version = "1.0", Created = DateTime.Parse("2000-01-01T11:00:00") }
                    },
                    Deployments = new List<Deployment>
                    {
                        new Deployment { Id = "D1", ReleaseId = "R1", EnvironmentId = "E1", DeployedAt = DateTime.Parse("2000-01-01T12:00:00") },
                        new Deployment { Id = "D2", ReleaseId = "R2", EnvironmentId = "E1", DeployedAt = DateTime.Parse("2000-01-01T13:00:00") },
                        new Deployment { Id = "D3", ReleaseId = "R4", EnvironmentId = "E1", DeployedAt = DateTime.Parse("2000-01-01T14:00:00") }
                    }
                };
            }
        }

        public static class ExpectionData
        {
            public static ReleaseRetentionMockData InvalidProject()
            {
                return new ReleaseRetentionMockData
                {
                    Projects = new List<Project>
                {
                    new Project { Id = "P1", Name = "" }
                },
                    Environments = new List<Environment>
                {
                    new Environment { Id = "E1", Name = "Env1" }
                },
                    Releases = new List<Release>
                {
                    new Release { Id = "R1", ProjectId = "P1", Version = "1.0", Created = DateTime.Parse("2000-01-01T08:00:00") }
                },
                    Deployments = new List<Deployment>
                {
                    new Deployment { Id = "D1", ReleaseId = "R1", EnvironmentId = "E1", DeployedAt = DateTime.Parse("2000-01-01T09:00:00") }
                }
                };
            }

            public static ReleaseRetentionMockData InvalidEnvironment()
            {
                return new ReleaseRetentionMockData
                {
                    Projects = new List<Project>
                {
                    new Project { Id = "P1", Name = "Project1" }
                },
                    Environments = new List<Environment>
                {
                    new Environment { Id = "E1", Name = "" }
                },
                    Releases = new List<Release>
                {
                    new Release { Id = "R1", ProjectId = "P1", Version = "1.0", Created = DateTime.Parse("2000-01-01T08:00:00") }
                },
                    Deployments = new List<Deployment>
                {
                    new Deployment { Id = "D1", ReleaseId = "R1", EnvironmentId = "E1", DeployedAt = DateTime.Parse("2000-01-01T09:00:00") }
                }
                };
            }

            public static ReleaseRetentionMockData InvalidRelease()
            {
                return new ReleaseRetentionMockData
                {
                    Projects = new List<Project>
                {
                    new Project { Id = "P1", Name = "Project1" }
                },
                    Environments = new List<Environment>
                {
                    new Environment { Id = "E1", Name = "Env1" }
                },
                    Releases = new List<Release>
                {
                    new Release { Id = "", ProjectId = "P1", Version = "1.1", Created = DateTime.Parse("2000-01-01T08:00:00") }
                },
                    Deployments = new List<Deployment>
                {
                    new Deployment { Id = "D1", ReleaseId = "R1", EnvironmentId = "E1", DeployedAt = DateTime.Parse("2000-01-01T09:00:00") }
                }
                };
            }

            public static ReleaseRetentionMockData InvalidDeployment()
            {
                return new ReleaseRetentionMockData
                {
                    Projects = new List<Project>
                {
                    new Project { Id = "P1", Name = "Project1" }
                },
                    Environments = new List<Environment>
                {
                    new Environment { Id = "E1", Name = "Env1" }
                },
                    Releases = new List<Release>
                {
                    new Release { Id = "R1", ProjectId = "P1", Version = "1.0", Created = DateTime.Parse("2000-01-01T08:00:00") }
                },
                    Deployments = new List<Deployment>
                {
                    new Deployment { Id = "", ReleaseId = "R1", EnvironmentId = "E1", DeployedAt = DateTime.Parse("2000-01-01T09:00:00") }
                }
                };
            }

            public static ReleaseRetentionMockData EmptyReleases()
            {
                return new ReleaseRetentionMockData
                {
                    Projects = new List<Project>
                {
                    new Project { Id = "P1", Name = "Project1" }
                },
                    Environments = new List<Environment>
                {
                    new Environment { Id = "E1", Name = "Env1" }
                },
                    Releases = new List<Release>(),
                    Deployments = new List<Deployment>
                {
                    new Deployment { Id = "D1", ReleaseId = "R1", EnvironmentId = "E1", DeployedAt = DateTime.Parse("2000-01-01T09:00:00") }
                }
                };
            }

            public static ReleaseRetentionMockData EmptyDeployments()
            {
                return new ReleaseRetentionMockData
                {
                    Projects = new List<Project>
                {
                    new Project { Id = "P1", Name = "Project1" }
                },
                    Environments = new List<Environment>
                {
                    new Environment { Id = "E1", Name = "Env1" }
                },
                    Releases = new List<Release>
                {
                    new Release { Id = "R1", ProjectId = "P1", Version = "1.0", Created = DateTime.Parse("2000-01-01T08:00:00") }
                },
                    Deployments = new List<Deployment>()
                };
            }


        }
    }
}