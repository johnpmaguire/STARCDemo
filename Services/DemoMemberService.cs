using STARCDemo.Models;

namespace STARCDemo.Services;

public class DemoMemberService
{
    private static readonly Dictionary<string, ClubMember> _members = new()
    {
        ["member"] = new ClubMember(
            Id:                         Guid.Parse("aaaaaaaa-0000-0000-0000-000000000001"),
            FirstName:                  "Alex",
            LastName:                   "Member",
            PreferredName:              "Alex",
            ProfilePicUrl: "images/team/james.png",
            Bio:                        "Completed the 0-5K programme last year and have not stopped running since.",
            IsProfilePublic:            false,
            Email:                      "alex.member@example.com",
            PhoneNumber:                null,
            MemberSince:                new DateOnly(2023, 9, 1),
            IsActive:                   true,
            Roles:                      [ClubRole.Member],
            EnglandAthleticsAffiliated: true,
            EnglandAthleticsNumber:     "EA-100001",
            DateOfBirth:                new DateOnly(1990, 6, 15),
            Gender:                     "M",
            PreferredPace:              "8:30 /km",
            EmergencyContactName:       "Jo Member",
            EmergencyContactPhone:      "07700 900001",
            RaceResults:
            [
                new(Guid.NewGuid(), "Kernow 5K",      new DateOnly(2024, 3, 10),
                    RaceDistance.FiveK, TimeSpan.FromMinutes(31.5), "31:30", "SM35", 142, 28, true),
                new(Guid.NewGuid(), "St Austell 10K", new DateOnly(2024, 6,  2),
                    RaceDistance.TenK,  TimeSpan.FromMinutes(67),   "1:07:00", "SM35", 310, 55, true),
            ]
        ),
        ["leader"] = new ClubMember(
            Id:                         Guid.Parse("aaaaaaaa-0000-0000-0000-000000000002"),
            FirstName:                  "Sarah",
            LastName:                   "Connor",
            PreferredName:              "Sarah",
            ProfilePicUrl: "images/team/james.png",
            Bio:                        "10 years coaching, marathon finisher, loves a muddy trail.",
            IsProfilePublic:            true,
            Email:                      "sarah.connor@example.com",
            PhoneNumber:                "07700 900002",
            MemberSince:                new DateOnly(2014, 1, 15),
            IsActive:                   true,
            Roles:                      [ClubRole.Member, ClubRole.Leader],
            EnglandAthleticsAffiliated: true,
            EnglandAthleticsNumber:     "EA-100002",
            DateOfBirth:                new DateOnly(1982, 3, 22),
            Gender:                     "F",
            PreferredPace:              "6:00 /km",
            EmergencyContactName:       "Mike Connor",
            EmergencyContactPhone:      "07700 900003",
            RaceResults:
            [
                new(Guid.NewGuid(), "Cornwall Marathon", new DateOnly(2023, 10, 15),
                    RaceDistance.Marathon,     new TimeSpan(3, 42,  0), "3:42:00", "SF40", 88, 12, true),
                new(Guid.NewGuid(), "Truro Half",        new DateOnly(2024,  4,  7),
                    RaceDistance.HalfMarathon, new TimeSpan(1, 45, 30), "1:45:30", "SF40", 44,  8, true),
            ]
        ),
        ["committee"] = new ClubMember(
            Id:                         Guid.Parse("aaaaaaaa-0000-0000-0000-000000000003"),
            FirstName:                  "Priya",
            LastName:                   "Nair",
            PreferredName:              "Priya",
            ProfilePicUrl: "images/team/james.png",
            Bio:                        "Organises all club events and races. Spreadsheet wizard.",
            IsProfilePublic:            true,
            Email:                      "priya.nair@example.com",
            PhoneNumber:                "07700 900004",
            MemberSince:                new DateOnly(2018, 4, 3),
            IsActive:                   true,
            Roles:                      [ClubRole.Member, ClubRole.Committee],
            EnglandAthleticsAffiliated: true,
            EnglandAthleticsNumber:     "EA-100003",
            DateOfBirth:                new DateOnly(1985, 11, 8),
            Gender:                     "F",
            PreferredPace:              "7:00 /km",
            EmergencyContactName:       "Raj Nair",
            EmergencyContactPhone:      "07700 900005",
            RaceResults:
            [
                new(Guid.NewGuid(), "Falmouth 10K", new DateOnly(2024, 5, 19),
                    RaceDistance.TenK, new TimeSpan(0, 58, 45), "58:45", "SF35", 201, 38, true),
            ]
        ),
        ["admin"] = new ClubMember(
            Id:                         Guid.Parse("aaaaaaaa-0000-0000-0000-000000000004"),
            FirstName:                  "James",
            LastName:                   "Murphy",
            PreferredName:              "James",
            ProfilePicUrl: "images/team/james.png",
            Bio:                        "Couch to 5K graduate turned coach. Your biggest cheerleader.",
            IsProfilePublic:            true,
            Email:                      "james.murphy@example.com",
            PhoneNumber:                "07700 900006",
            MemberSince:                new DateOnly(2019, 9, 10),
            IsActive:                   true,
            Roles:                      [ClubRole.Member, ClubRole.Leader, ClubRole.Committee, ClubRole.Admin],
            EnglandAthleticsAffiliated: true,
            EnglandAthleticsNumber:     "EA-100004",
            DateOfBirth:                new DateOnly(1978, 7, 30),
            Gender:                     "M",
            PreferredPace:              "6:30 /km",
            EmergencyContactName:       "Claire Murphy",
            EmergencyContactPhone:      "07700 900007",
            RaceResults:
            [
                new(Guid.NewGuid(), "St Austell 10K",  new DateOnly(2024,  6,  2),
                    RaceDistance.TenK,     new TimeSpan(0, 49, 12), "49:12",   "SM45",    55,    9, true),
                new(Guid.NewGuid(), "Kernow 5K",       new DateOnly(2024,  3, 10),
                    RaceDistance.FiveK,    new TimeSpan(0, 23, 40), "23:40",   "SM45",    28,    5, true),
                new(Guid.NewGuid(), "London Marathon", new DateOnly(2023,  4, 23),
                    RaceDistance.Marathon, new TimeSpan(3, 58,  0), "3:58:00", "SM45", 12804, 1820, false),
            ]
        ),
    };

    public ClubMember? GetByUsername(string username) =>
        _members.TryGetValue(username.ToLowerInvariant(), out var m) ? m : null;

    public IReadOnlyList<ClubMember> GetAll() => _members.Values.ToList();

    public IReadOnlyList<ClubMember> GetActive() =>
        _members.Values.Where(m => m.IsActive).ToList();

    public IReadOnlyList<ClubMember> GetInactive() =>
        _members.Values.Where(m => !m.IsActive).ToList();

    public IReadOnlyList<ClubMember> GetByRole(ClubRole role) =>
        _members.Values.Where(m => m.Roles.Contains(role)).ToList();

    public IReadOnlyList<ClubMember> GetEAAffiliated() =>
        _members.Values.Where(m => m.EnglandAthleticsAffiliated).ToList();

    public static string BuildMailtoLink(IEnumerable<ClubMember> members, string subject = "")
    {
        var bcc = string.Join(",", members.Select(m => m.Email));
        var sub = Uri.EscapeDataString(subject);
        return $"mailto:?bcc={bcc}&subject={sub}";
    }

    public string ActiveMembersMailto(string subject = "") =>
        BuildMailtoLink(GetActive(), subject);

    public string RoleMailto(ClubRole role, string subject = "") =>
        BuildMailtoLink(GetByRole(role), subject);
}



