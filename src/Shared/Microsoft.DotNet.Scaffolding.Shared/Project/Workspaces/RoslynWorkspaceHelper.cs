// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.DotNet.Scaffolding.Shared.ProjectModel;

namespace Microsoft.DotNet.Scaffolding.Shared.Project.Workspaces
{
    public static class RoslynWorkspaceHelper
    {
        internal static IEnumerable<ProjectReferenceInformation> GetProjectReferenceInformation(IEnumerable<string> projectReferenceStrings)
        {
            List<ProjectReferenceInformation> projectReferenceInformation = new List<ProjectReferenceInformation>();
            if (projectReferenceStrings != null && projectReferenceStrings.Any())
            {
                foreach (string projectReferenceString in projectReferenceStrings)
                    try
                    {
                        var currentProject = new Build.Evaluation.Project(Path.GetFullPath(projectReferenceString));
                        if (currentProject != null)
                        {
                            projectReferenceInformation.Add(GetProjectInformation(currentProject));
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new InvalidOperationException($"Could not load information for project {projectReferenceString}", ex);
                    }
            }
            return projectReferenceInformation;
        }

        internal static ProjectReferenceInformation GetProjectInformation(Build.Evaluation.Project project)
        {
            var compileItems = project.GetItems("Compile").Select(i => i.EvaluatedInclude);
            var fullPath = project.FullPath;
            var name = project.GetProperty("ProjectName")
                ?.EvaluatedValue
                ?? Path.GetFileNameWithoutExtension(fullPath);

            var assemblyPath = project.GetProperty("TargetPath")
                ?.EvaluatedValue;

            var assemblyName = string.IsNullOrEmpty(assemblyPath)
                ? name
                : Path.GetFileNameWithoutExtension(assemblyPath);

            return new ProjectReferenceInformation()
            {
                ProjectName = name,
                AssemblyName = assemblyName,
                CompilationItems = compileItems.ToList(),
                FullPath = fullPath
            };
        }
    }
}