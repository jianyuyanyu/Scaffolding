// Copyright (c) Microsoft Corporation. All rights reserved.
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.DotNet.Tools.Scaffold.Flow;
using Spectre.Console.Cli;
using Spectre.Console.Flow;

namespace Microsoft.UpgradeAssistant.Cli.Commands;

public abstract class BaseCommand<TSettings> : AsyncCommand<TSettings>
    where TSettings : CommandSettings
{
    protected BaseCommand(IFlowProvider flowProvider)
    {
        FlowProvider = flowProvider;
    }

    protected IFlowProvider FlowProvider { get; }

    protected async ValueTask<int> RunFlowAsync(IEnumerable<IFlowStep> flowSteps, TSettings settings, bool nonInteractive = false, bool showSelectedOptions = true)
    {
        var properties = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase)
        {};

        IFlow? flow = null;
        Exception? exception = null;

        try
        {
            flow = FlowProvider.GetFlow(flowSteps, properties, nonInteractive, showSelectedOptions);

            return await flow.RunAsync(CancellationToken.None);
        }
        catch (Exception) {}

        return exception is not null
            ? throw exception
            : int.MinValue;
    }
}
