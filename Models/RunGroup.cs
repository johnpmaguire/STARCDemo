namespace STARCDemo.Models;

public enum RunGroup
{
    Progression,
    Sub11,
    Sub10,
    Sub9,
    Sub8
}

public static class RunGroupExtensions
{
    public static string DisplayName(this RunGroup group) => group switch
    {
        RunGroup.Progression => "Progression",
        RunGroup.Sub11       => "Sub 11",
        RunGroup.Sub10       => "Sub 10",
        RunGroup.Sub9        => "Sub 9",
        RunGroup.Sub8        => "Sub 8",
        _                    => group.ToString()
    };
}
