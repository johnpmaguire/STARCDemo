namespace STARCDemo.Models;

public record SessionLeader(
    Guid     LeaderId,
    string   LeaderName,
    string   SessionDay,
    DateOnly WeekStart,
    RunGroup Group
);
