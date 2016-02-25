﻿using System;
using System.Threading.Tasks;
using Exceptionless.Core.Pipeline;
using Exceptionless.Core.Extensions;

namespace Exceptionless.Core.Plugins.EventProcessor {
    [Priority(3)]
    public class ManualStackingPlugin : EventProcessorPluginBase {
        public override Task EventProcessingAsync(EventContext context) {
            var msi = context.Event.GetManualStackingInfo();
            if (msi?.SignatureData != null) {
                foreach (var kvp in msi.SignatureData)
                    context.StackSignatureData.AddItemIfNotEmpty(kvp.Key, kvp.Value);
            }

            return Task.CompletedTask;
        }
    }
}