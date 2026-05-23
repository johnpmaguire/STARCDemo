using STARCDemo.Models;

namespace STARCDemo.Services;

public class DemoMemberService
{
    private static readonly Dictionary<string, ClubMember> _members = new()
    {
        ["member1"] = new ClubMember(
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
        ["leader1"] = new ClubMember(
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
        ["committee1"] = new ClubMember(
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

        // ── Extra members ─────────────────────────────────────────────
        ["member2"] = new ClubMember(
            Id:                         Guid.Parse("aaaaaaaa-0000-0000-0000-000000000005"),
            FirstName:                  "Tom",
            LastName:                   "Briggs",
            PreferredName:              "Tom",
            ProfilePicUrl:              "images/team/james.png",
            Bio:                        "Park run regular. Chasing a sub-25 5K.",
            IsProfilePublic:            false,
            Email:                      "tom.briggs@example.com",
            PhoneNumber:                null,
            MemberSince:                new DateOnly(2022, 3, 1),
            IsActive:                   true,
            Roles:                      [ClubRole.Member],
            EnglandAthleticsAffiliated: true,
            EnglandAthleticsNumber:     "EA-100005",
            DateOfBirth:                new DateOnly(1995, 2, 14),
            Gender:                     "M",
            PreferredPace:              "5:30 /km",
            EmergencyContactName:       "Sue Briggs",
            EmergencyContactPhone:      "07700 900010",
            RaceResults:
            [
                new(Guid.NewGuid(), "Kernow 5K", new DateOnly(2024, 3, 10),
                    RaceDistance.FiveK, new TimeSpan(0, 25, 48), "25:48", "SM25", 38, 8, true),
            ]
        ),
        ["member3"] = new ClubMember(
            Id:                         Guid.Parse("aaaaaaaa-0000-0000-0000-000000000006"),
            FirstName:                  "Chloe",
            LastName:                   "Walsh",
            PreferredName:              "Chloe",
            ProfilePicUrl:              "images/team/james.png",
            Bio:                        "Joined after completing Couch to 5K. Loving every step.",
            IsProfilePublic:            false,
            Email:                      "chloe.walsh@example.com",
            PhoneNumber:                null,
            MemberSince:                new DateOnly(2024, 1, 10),
            IsActive:                   true,
            Roles:                      [ClubRole.Member],
            EnglandAthleticsAffiliated: false,
            EnglandAthleticsNumber:     null,
            DateOfBirth:                new DateOnly(2000, 8, 23),
            Gender:                     "F",
            PreferredPace:              "9:00 /km",
            EmergencyContactName:       "Mark Walsh",
            EmergencyContactPhone:      "07700 900011",
            RaceResults:                []
        ),
        ["member4"] = new ClubMember(
            Id:                         Guid.Parse("aaaaaaaa-0000-0000-0000-000000000007"),
            FirstName:                  "Ravi",
            LastName:                   "Patel",
            PreferredName:              "Ravi",
            ProfilePicUrl:              "images/team/james.png",
            Bio:                        "Marathon training is my therapy.",
            IsProfilePublic:            true,
            Email:                      "ravi.patel@example.com",
            PhoneNumber:                "07700 900012",
            MemberSince:                new DateOnly(2020, 6, 15),
            IsActive:                   true,
            Roles:                      [ClubRole.Member],
            EnglandAthleticsAffiliated: true,
            EnglandAthleticsNumber:     "EA-100007",
            DateOfBirth:                new DateOnly(1988, 4, 5),
            Gender:                     "M",
            PreferredPace:              "5:45 /km",
            EmergencyContactName:       "Meena Patel",
            EmergencyContactPhone:      "07700 900013",
            RaceResults:
            [
                new(Guid.NewGuid(), "Truro Half",     new DateOnly(2024, 4,  7),
                    RaceDistance.HalfMarathon, new TimeSpan(1, 52, 10), "1:52:10", "SM35", 112, 22, true),
                new(Guid.NewGuid(), "St Austell 10K", new DateOnly(2024, 6,  2),
                    RaceDistance.TenK,         new TimeSpan(0, 55, 30), "55:30",   "SM35", 189, 40, true),
            ]
        ),
        ["member5"] = new ClubMember(
            Id:                         Guid.Parse("aaaaaaaa-0000-0000-0000-000000000008"),
            FirstName:                  "Niamh",
            LastName:                   "Kelly",
            PreferredName:              "Niamh",
            ProfilePicUrl:              "images/team/james.png",
            Bio:                        "Trail runner at heart. Mud is just nature's grip.",
            IsProfilePublic:            true,
            Email:                      "niamh.kelly@example.com",
            PhoneNumber:                "07700 900014",
            MemberSince:                new DateOnly(2021, 11, 20),
            IsActive:                   true,
            Roles:                      [ClubRole.Member],
            EnglandAthleticsAffiliated: true,
            EnglandAthleticsNumber:     "EA-100008",
            DateOfBirth:                new DateOnly(1993, 12, 1),
            Gender:                     "F",
            PreferredPace:              "6:15 /km",
            EmergencyContactName:       "Conor Kelly",
            EmergencyContactPhone:      "07700 900015",
            RaceResults:
            [
                new(Guid.NewGuid(), "Kernow 5K",    new DateOnly(2024, 3, 10),
                    RaceDistance.FiveK, new TimeSpan(0, 28, 55), "28:55",   "SF30",  95, 14, true),
                new(Guid.NewGuid(), "Falmouth 10K", new DateOnly(2024, 5, 19),
                    RaceDistance.TenK,  new TimeSpan(1,  2, 10), "1:02:10", "SF30", 244, 35, true),
            ]
        ),
        ["member6"] = new ClubMember(
            Id:                         Guid.Parse("aaaaaaaa-0000-0000-0000-000000000009"),
            FirstName:                  "Dan",
            LastName:                   "Foster",
            PreferredName:              "Dan",
            ProfilePicUrl:              "images/team/james.png",
            Bio:                        "Interval sessions are my favourite. Speed work never stops.",
            IsProfilePublic:            false,
            Email:                      "dan.foster@example.com",
            PhoneNumber:                null,
            MemberSince:                new DateOnly(2023, 2, 8),
            IsActive:                   true,
            Roles:                      [ClubRole.Member],
            EnglandAthleticsAffiliated: true,
            EnglandAthleticsNumber:     "EA-100009",
            DateOfBirth:                new DateOnly(1997, 7, 19),
            Gender:                     "M",
            PreferredPace:              "4:50 /km",
            EmergencyContactName:       "Helen Foster",
            EmergencyContactPhone:      "07700 900016",
            RaceResults:
            [
                new(Guid.NewGuid(), "St Austell 10K", new DateOnly(2024, 6,  2),
                    RaceDistance.TenK,  new TimeSpan(0, 44, 22), "44:22", "SM25", 30, 5, true),
                new(Guid.NewGuid(), "Kernow 5K",      new DateOnly(2024, 3, 10),
                    RaceDistance.FiveK, new TimeSpan(0, 21, 10), "21:10", "SM25", 12, 2, true),
            ]
        ),
        ["member7"] = new ClubMember(
            Id:                         Guid.Parse("aaaaaaaa-0000-0000-0000-000000000010"),
            FirstName:                  "Lucia",
            LastName:                   "Ferreira",
            PreferredName:              "Lucia",
            ProfilePicUrl:              "images/team/james.png",
            Bio:                        "Running my first marathon this autumn. Very nervous!",
            IsProfilePublic:            false,
            Email:                      "lucia.ferreira@example.com",
            PhoneNumber:                null,
            MemberSince:                new DateOnly(2023, 5, 14),
            IsActive:                   true,
            Roles:                      [ClubRole.Member],
            EnglandAthleticsAffiliated: false,
            EnglandAthleticsNumber:     null,
            DateOfBirth:                new DateOnly(1991, 3, 28),
            Gender:                     "F",
            PreferredPace:              "7:30 /km",
            EmergencyContactName:       "Paulo Ferreira",
            EmergencyContactPhone:      "07700 900017",
            RaceResults:
            [
                new(Guid.NewGuid(), "Truro Half", new DateOnly(2024, 4, 7),
                    RaceDistance.HalfMarathon, new TimeSpan(2, 10, 45), "2:10:45", "SF30", 198, 42, true),
            ]
        ),
        ["member8"] = new ClubMember(
            Id:                         Guid.Parse("aaaaaaaa-0000-0000-0000-000000000011"),
            FirstName:                  "Owen",
            LastName:                   "Hughes",
            PreferredName:              "Owen",
            ProfilePicUrl:              "images/team/james.png",
            Bio:                        "Retired teacher, started running at 60. Best decision ever.",
            IsProfilePublic:            true,
            Email:                      "owen.hughes@example.com",
            PhoneNumber:                "07700 900018",
            MemberSince:                new DateOnly(2019, 4, 2),
            IsActive:                   true,
            Roles:                      [ClubRole.Member],
            EnglandAthleticsAffiliated: true,
            EnglandAthleticsNumber:     "EA-100011",
            DateOfBirth:                new DateOnly(1961, 9, 10),
            Gender:                     "M",
            PreferredPace:              "8:00 /km",
            EmergencyContactName:       "Gwen Hughes",
            EmergencyContactPhone:      "07700 900019",
            RaceResults:
            [
                new(Guid.NewGuid(), "Falmouth 10K", new DateOnly(2024, 5, 19),
                    RaceDistance.TenK,  new TimeSpan(1,  8, 30), "1:08:30", "SM60", 295, 4, true),
                new(Guid.NewGuid(), "Kernow 5K",    new DateOnly(2024, 3, 10),
                    RaceDistance.FiveK, new TimeSpan(0, 33, 15), "33:15",   "SM60", 138, 2, true),
            ]
        ),
        ["member9"] = new ClubMember(
            Id:                         Guid.Parse("aaaaaaaa-0000-0000-0000-000000000012"),
            FirstName:                  "Amara",
            LastName:                   "Osei",
            PreferredName:              "Amara",
            ProfilePicUrl:              "images/team/james.png",
            Bio:                        "Speedster on the track, social runner on Mondays.",
            IsProfilePublic:            true,
            Email:                      "amara.osei@example.com",
            PhoneNumber:                "07700 900020",
            MemberSince:                new DateOnly(2022, 9, 5),
            IsActive:                   true,
            Roles:                      [ClubRole.Member],
            EnglandAthleticsAffiliated: true,
            EnglandAthleticsNumber:     "EA-100012",
            DateOfBirth:                new DateOnly(1999, 6, 3),
            Gender:                     "F",
            PreferredPace:              "4:30 /km",
            EmergencyContactName:       "Kwame Osei",
            EmergencyContactPhone:      "07700 900021",
            RaceResults:
            [
                new(Guid.NewGuid(), "St Austell 10K", new DateOnly(2024, 6,  2),
                    RaceDistance.TenK,  new TimeSpan(0, 41, 55), "41:55", "SF25", 18, 3, true),
                new(Guid.NewGuid(), "Kernow 5K",      new DateOnly(2024, 3, 10),
                    RaceDistance.FiveK, new TimeSpan(0, 19, 48), "19:48", "SF25",  6, 1, true),
            ]
        ),
        ["member10"] = new ClubMember(
            Id:                         Guid.Parse("aaaaaaaa-0000-0000-0000-000000000013"),
            FirstName:                  "Jack",
            LastName:                   "Tanner",
            PreferredName:              "Jack",
            ProfilePicUrl:              "images/team/james.png",
            Bio:                        "Just here for the post-run biscuits, if I'm honest.",
            IsProfilePublic:            false,
            Email:                      "jack.tanner@example.com",
            PhoneNumber:                null,
            MemberSince:                new DateOnly(2024, 9, 1),
            IsActive:                   true,
            Roles:                      [ClubRole.Member],
            EnglandAthleticsAffiliated: false,
            EnglandAthleticsNumber:     null,
            DateOfBirth:                new DateOnly(2003, 1, 17),
            Gender:                     "M",
            PreferredPace:              "10:00 /km",
            EmergencyContactName:       "Fiona Tanner",
            EmergencyContactPhone:      "07700 900022",
            RaceResults:                []
        ),

        // ── Extra leaders ─────────────────────────────────────────────
        ["leader2"] = new ClubMember(
            Id:                         Guid.Parse("aaaaaaaa-0000-0000-0000-000000000014"),
            FirstName:                  "Beth",
            LastName:                   "Cartwright",
            PreferredName:              "Beth",
            ProfilePicUrl:              "images/team/james.png",
            Bio:                        "Qualified run leader and half marathon addict.",
            IsProfilePublic:            true,
            Email:                      "beth.cartwright@example.com",
            PhoneNumber:                "07700 900023",
            MemberSince:                new DateOnly(2016, 3, 12),
            IsActive:                   true,
            Roles:                      [ClubRole.Member, ClubRole.Leader],
            EnglandAthleticsAffiliated: true,
            EnglandAthleticsNumber:     "EA-100014",
            DateOfBirth:                new DateOnly(1984, 10, 6),
            Gender:                     "F",
            PreferredPace:              "5:50 /km",
            EmergencyContactName:       "Neil Cartwright",
            EmergencyContactPhone:      "07700 900024",
            RaceResults:
            [
                new(Guid.NewGuid(), "Truro Half",        new DateOnly(2024, 4,  7),
                    RaceDistance.HalfMarathon, new TimeSpan(1, 40, 22), "1:40:22", "SF40", 31,  5, true),
                new(Guid.NewGuid(), "Cornwall Marathon", new DateOnly(2023, 10, 15),
                    RaceDistance.Marathon,     new TimeSpan(3, 35,  0), "3:35:00", "SF40", 62,  9, true),
            ]
        ),
        ["leader3"] = new ClubMember(
            Id:                         Guid.Parse("aaaaaaaa-0000-0000-0000-000000000015"),
            FirstName:                  "Marcus",
            LastName:                   "Webb",
            PreferredName:              "Marcus",
            ProfilePicUrl:              "images/team/james.png",
            Bio:                        "Sub-3 marathoner and enthusiastic Wednesday night session lead.",
            IsProfilePublic:            true,
            Email:                      "marcus.webb@example.com",
            PhoneNumber:                "07700 900025",
            MemberSince:                new DateOnly(2015, 7, 20),
            IsActive:                   true,
            Roles:                      [ClubRole.Member, ClubRole.Leader],
            EnglandAthleticsAffiliated: true,
            EnglandAthleticsNumber:     "EA-100015",
            DateOfBirth:                new DateOnly(1980, 5, 14),
            Gender:                     "M",
            PreferredPace:              "4:15 /km",
            EmergencyContactName:       "Lisa Webb",
            EmergencyContactPhone:      "07700 900026",
            RaceResults:
            [
                new(Guid.NewGuid(), "London Marathon", new DateOnly(2024, 4, 21),
                    RaceDistance.Marathon, new TimeSpan(2, 58, 44), "2:58:44", "SM45",  890, 120, true),
                new(Guid.NewGuid(), "St Austell 10K",  new DateOnly(2024, 6,  2),
                    RaceDistance.TenK,     new TimeSpan(0, 40, 12), "40:12",   "SM45",   14,   2, true),
            ]
        ),

        // ── Extra committee ───────────────────────────────────────────
        ["committee2"] = new ClubMember(
            Id:                         Guid.Parse("aaaaaaaa-0000-0000-0000-000000000016"),
            FirstName:                  "Diane",
            LastName:                   "Hollis",
            PreferredName:              "Diane",
            ProfilePicUrl:              "images/team/james.png",
            Bio:                        "Club treasurer and enthusiastic Sunday long runner.",
            IsProfilePublic:            true,
            Email:                      "diane.hollis@example.com",
            PhoneNumber:                "07700 900027",
            MemberSince:                new DateOnly(2017, 2, 28),
            IsActive:                   true,
            Roles:                      [ClubRole.Member, ClubRole.Committee],
            EnglandAthleticsAffiliated: true,
            EnglandAthleticsNumber:     "EA-100016",
            DateOfBirth:                new DateOnly(1972, 8, 11),
            Gender:                     "F",
            PreferredPace:              "7:15 /km",
            EmergencyContactName:       "Pete Hollis",
            EmergencyContactPhone:      "07700 900028",
            RaceResults:
            [
                new(Guid.NewGuid(), "Falmouth 10K", new DateOnly(2024, 5, 19),
                    RaceDistance.TenK,         new TimeSpan(1,  4, 50), "1:04:50", "SF50", 228, 12, true),
                new(Guid.NewGuid(), "Truro Half",   new DateOnly(2024, 4,  7),
                    RaceDistance.HalfMarathon, new TimeSpan(2, 18,  0), "2:18:00", "SF50", 210, 18, true),
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



