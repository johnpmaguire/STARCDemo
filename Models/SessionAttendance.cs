namespace STARCDemo.Models;

public record SessionAttendance(
    Guid     MemberId,
    string   MemberName,
    string   SessionDay,
    DateOnly WeekStart,
    RunGroup Group
);
