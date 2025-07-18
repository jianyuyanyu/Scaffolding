// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.DotNet.Tools.Scaffold.AspNet.Common
{
    internal class ProjectReferenceParser
    {
        public static List<string> ParseProjectReferences(string referencesOutput)
        {
            var references = new List<string>();
            bool inProjectReferencesSection = false;

            using var sr = new StringReader(referencesOutput);
            string? line;
            while ((line = sr.ReadLine()) is not null)
            {
                line = line.Trim();

                // Detect the reference banner
                if (line.StartsWith("Project reference", StringComparison.OrdinalIgnoreCase))
                {
                    inProjectReferencesSection = true;
                    continue;
                }

                // If we are in the references section, skip the dashed line
                if (inProjectReferencesSection && line.StartsWith("-"))
                {
                    continue;
                }

                // Collect reference lines
                if (inProjectReferencesSection && !string.IsNullOrEmpty(line))
                {
                    references.Add(line);
                }
            }

            return references;
        }

    }
}
