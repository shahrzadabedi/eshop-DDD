using System;
using System.Linq;
using Nuke.Common;
using Nuke.Common.Execution;
using Nuke.Common.ProjectModel;
using Nuke.Common.Tooling;
using Nuke.Common.Tools.DotNet;
using Nuke.Common.Utilities.Collections;
using static Nuke.Common.EnvironmentInfo;
using static Nuke.Common.IO.FileSystemTasks;
using static Nuke.Common.IO.PathConstruction;
using static Nuke.Common.Tools.DotNet.DotNetTasks;

[CheckBuildProjectConfigurations]
[UnsetVisualStudioEnvironmentVariables]
class Build : NukeBuild
{
    public static int Main() => Execute<Build>(x => x.PushPackages);

    [Parameter("Configuration to build - Default is 'Debug' (local) or 'Release' (server)")]
    readonly string Configuration = IsLocalBuild ? "Debug" : "Release";

    [Solution] readonly Solution Solution;
    [Parameter] string ArtifactPath = "./artifacts/";

    Target Clean => _ => _
        .Before(Restore)
        .Executes(() =>
        {
            GlobDirectories(Solution.Directory, "src/**/bin", "src/**/obj").ForEach(DeleteDirectory);
            GlobDirectories(Solution.Directory, "test/**/bin", "test/**/obj").ForEach(DeleteDirectory);
            EnsureCleanDirectory(ArtifactPath);
        });

    Target Restore => _ => _
        .Executes(() =>
        {
            DotNetRestore(a => a.SetProjectFile(Solution));
        });

    Target Compile => _ => _
        .DependsOn(Restore)
        .Executes(() =>
        {
            DotNetBuild(a =>
                a.SetProjectFile(Solution)
                    .SetConfiguration(Configuration)
                    .SetNoRestore(true));
        });

    Target RunUnitTests => _ => _
        .DependsOn(Compile)
        .Executes(() =>
        {
            //var testProjects = Solution.AllProjects.Where(s => s.Name.Contains("Tests.Unit"));
            //foreach (var project in testProjects)
            //{
            //    DotNetTest(a => a
            //        .SetProjectFile(project)
            //        .SetConfiguration(Configuration)
            //        .SetNoBuild(true)
            //        .SetNoRestore(true));
            //}
        });

    Target Pack => _ => _
        .DependsOn(RunUnitTests)
        .Executes(() =>
        {
            var projects = Solution.AllProjects.Where(s => !s.Name.Contains("Tests.Unit"));
            foreach (var project in projects)
            {
                DotNetPack(a =>
                        a.SetProject(project)
                            .SetNoRestore(true)
                            .SetNoBuild(true)
                            .SetOutputDirectory(ArtifactPath)
                            .SetVersion("2.0.4")        //TODO: replace this with git version
                                                        //.SetVersion(GitVersion.NuGetVersionV2)
                                                        //.SetAssemblyVersion(GitVersion.AssemblySemVer)
                );
            }
        });

    Target PushPackages => _ => _
        .DependsOn(Pack)
        .Executes(() =>
        {
            //TODO: push packages in nuget package manager
        });
}
