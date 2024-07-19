// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
namespace Microsoft.DotNet.Tools.Scaffold.AspNet.Commands.Settings;

internal class EfWithModelCommandSettings : BaseCommandSettings
{
    public string? DatabaseProvider { get; set; }
    public string? DataContext { get; set; }
    public required string Model { get; set; }
}
