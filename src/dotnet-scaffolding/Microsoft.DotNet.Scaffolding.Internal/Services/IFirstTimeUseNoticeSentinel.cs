// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace Microsoft.DotNet.Scaffolding.Internal.Services;

internal interface IFirstTimeUseNoticeSentinel
{
    string Title { get; }
    string DisclosureText { get; }
    bool SkipFirstTimeExperience { get; }
    string ProductFullVersion { get; }
    bool Exists();
    void CreateIfNotExists();
}
