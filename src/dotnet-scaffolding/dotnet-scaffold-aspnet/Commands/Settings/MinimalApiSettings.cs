// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
namespace Microsoft.DotNet.Tools.Scaffold.AspNet.Commands.Settings;

internal class MinimalApiSettings : EfWithModelCommandSettings
{
    public string? Endpoints { get; set; }
    public bool OpenApi { get; set; } = true;
}
