namespace STARCDemo.Models;

public record RaceResult(
    Guid         Id,
    string       RaceName,
    DateOnly     Date,
    RaceDistance Distance,
    TimeSpan     FinishTime,
    string       OfficialFinishTime,
    string       Category,
    int?         PositionOverall,
    int?         PositionInCategory,
    bool         IsPB
);
