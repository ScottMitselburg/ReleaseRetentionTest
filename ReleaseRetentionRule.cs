using ReleaseRetention.Models;
using ReleaseRetention.Utils.Loggers;
using ReleaseRetention.Utils.Validation;
using Environment = ReleaseRetention.Models.Environment;

namespace ReleaseRetention
{
    public class ReleaseRetentionRule
    {
        public static IList<Release> ReleasesToKeep(int numberOfReleasesToKeep, List<Project> projects, List<Environment> environments, List<Release> releases, List<Deployment> deployments)
        {
            if (!ReleaseRetentionValidation.ValidateReleaseRetentionData(projects, environments, releases, deployments))
                return new List<Release>();

            if (!releases.Any()) return HandleNoReleasesFound(projects, environments);

            var releaseMap = releases.ToDictionary(r => r.Id, r => r);
            var releaseIdsToKeep = new HashSet<string>();

            var groupedDeployments = GroupDeploymentsByProjectIdAndEnvironmentId(deployments, releaseMap);

            foreach (var group in groupedDeployments)
            {
                var (projectId, environmentId) = group.Key;

                var groupedReleases = GroupReleasesByIdAndGetRecentDeploy(group);

                var releasesToKeep = ReturnMostRecentReleasesToKeep(groupedReleases, numberOfReleasesToKeep);

                foreach (var releaseInfo in releasesToKeep)
                {
                    if (releaseIdsToKeep.Add(releaseInfo.ReleaseId)) LogReleaseToKeep(releaseInfo.ReleaseId, environmentId, projectId);
                }
            }

            return [.. releases.Where(r => releaseIdsToKeep.Contains(r.Id))];
        }

        private static IEnumerable<IGrouping<(string, string), Deployment>> GroupDeploymentsByProjectIdAndEnvironmentId(List<Deployment> deployments, Dictionary<string, Release> releaseMap)
        {
            return deployments
                .Where(d => releaseMap.ContainsKey(d.ReleaseId))
                .GroupBy(d =>
                {
                    var release = releaseMap[d.ReleaseId];
                    return (release.ProjectId, d.EnvironmentId);
                });
        }

        private static IEnumerable<ReleaseDeployInfo> GroupReleasesByIdAndGetRecentDeploy(IGrouping<(string, string), Deployment> group)
        {
            return group
                .GroupBy(g => g.ReleaseId)
                .Select(g => new ReleaseDeployInfo
                {
                    ReleaseId = g.Key,
                    DeployedAt = g.Max(d => d.DeployedAt)
                });
        }

        private static IEnumerable<ReleaseDeployInfo> ReturnMostRecentReleasesToKeep(IEnumerable<ReleaseDeployInfo> releaseGroups, int releasesToKeep)
        {
            return releaseGroups
                .OrderByDescending(r => r.DeployedAt)
                .Take(releasesToKeep);
        }

        private static void LogReleaseToKeep(string releaseId, string environmentId, string projectId)
        {
            var logInformation = $"{releaseId} kept because it was the most recently deployed to {environmentId} in project {projectId}";
            ReleaseLogger.WriteLogsToJsonFile(logInformation).GetAwaiter().GetResult();
        }

        private static List<Release> HandleNoReleasesFound(List<Project> projects, List<Environment> environments)
        {
            string projectIds = string.Join(", ", projects.Select(p => p.Id));
            string environmentIds = string.Join(", ", environments.Select(e => e.Id));
            var message = $"No releases found on the projects: {projectIds} and environments: {environmentIds}";

            ReleaseLogger.WriteLogsToJsonFile(message).GetAwaiter().GetResult();
            return new List<Release>();
        }
    }
}
