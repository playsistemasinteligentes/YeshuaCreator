using OpenTelemetry;
using System.Diagnostics;

namespace Shared.Operational;

public sealed class OperationalActivitySanitizingProcessor : BaseProcessor<Activity>
{
    public override void OnEnd(Activity activity)
    {
        List<string>? forbiddenTags = null;
        foreach (var tag in activity.TagObjects)
        {
            if (!OperationalEvidenceProtection.IsForbiddenName(tag.Key))
                continue;

            forbiddenTags ??= [];
            forbiddenTags.Add(tag.Key);
        }

        if (forbiddenTags is null)
            return;

        foreach (var tag in forbiddenTags)
            activity.SetTag(tag, null);
    }
}
