using STARCDemo.Models;

namespace STARCDemo.Services;

public class AttendanceService
{
    private readonly List<SessionAttendance> _records = [];
    private readonly List<SessionLeader>     _leaders = [];

    public static DateOnly CurrentWeekStart()
    {
        var today = DateOnly.FromDateTime(DateTime.Today);
        int diff = ((int)today.DayOfWeek - (int)DayOfWeek.Monday + 7) % 7;
        return today.AddDays(-diff);
    }

    // ── Member attendance ─────────────────────────────────────────────

    public bool IsAttending(Guid memberId, string sessionDay, DateOnly weekStart) =>
        _records.Any(r => r.MemberId == memberId && r.SessionDay == sessionDay && r.WeekStart == weekStart);

    public SessionAttendance? GetAttendance(Guid memberId, string sessionDay, DateOnly weekStart) =>
        _records.FirstOrDefault(r => r.MemberId == memberId && r.SessionDay == sessionDay && r.WeekStart == weekStart);

    public void MarkAttending(Guid memberId, string memberName, string sessionDay, DateOnly weekStart, RunGroup group)
    {
        _records.RemoveAll(r => r.MemberId == memberId && r.SessionDay == sessionDay && r.WeekStart == weekStart);
        _records.Add(new SessionAttendance(memberId, memberName, sessionDay, weekStart, group));
    }

    public void Withdraw(Guid memberId, string sessionDay, DateOnly weekStart) =>
        _records.RemoveAll(r => r.MemberId == memberId && r.SessionDay == sessionDay && r.WeekStart == weekStart);

    public IReadOnlyList<SessionAttendance> GetAttendees(string sessionDay, DateOnly weekStart) =>
        _records.Where(r => r.SessionDay == sessionDay && r.WeekStart == weekStart).ToList();

    public int GetAttendeeCount(string sessionDay, DateOnly weekStart) =>
        _records.Count(r => r.SessionDay == sessionDay && r.WeekStart == weekStart);

    // ── Leader volunteering ───────────────────────────────────────────

    public bool IsLeading(Guid leaderId, string sessionDay, DateOnly weekStart, RunGroup group) =>
        _leaders.Any(l => l.LeaderId == leaderId && l.SessionDay == sessionDay && l.WeekStart == weekStart && l.Group == group);

    public bool IsLeadingAnyGroup(Guid leaderId, string sessionDay, DateOnly weekStart) =>
        _leaders.Any(l => l.LeaderId == leaderId && l.SessionDay == sessionDay && l.WeekStart == weekStart);

    public void VolunteerAsLeader(Guid leaderId, string leaderName, string sessionDay, DateOnly weekStart, RunGroup group)
    {
        // One leader per group per session — replace any existing entry for this leader+session+group
        _leaders.RemoveAll(l => l.LeaderId == leaderId && l.SessionDay == sessionDay && l.WeekStart == weekStart && l.Group == group);
        _leaders.Add(new SessionLeader(leaderId, leaderName, sessionDay, weekStart, group));
    }

    public void WithdrawLeader(Guid leaderId, string sessionDay, DateOnly weekStart, RunGroup group) =>
        _leaders.RemoveAll(l => l.LeaderId == leaderId && l.SessionDay == sessionDay && l.WeekStart == weekStart && l.Group == group);

    public IReadOnlyList<SessionLeader> GetLeaders(string sessionDay, DateOnly weekStart) =>
        _leaders.Where(l => l.SessionDay == sessionDay && l.WeekStart == weekStart).ToList();

    public SessionLeader? GetGroupLeader(string sessionDay, DateOnly weekStart, RunGroup group) =>
        _leaders.FirstOrDefault(l => l.SessionDay == sessionDay && l.WeekStart == weekStart && l.Group == group);
}
