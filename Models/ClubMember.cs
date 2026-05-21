namespace STARCDemo.Models;

public record ClubMember(
    Guid             Id,
    string           FirstName,
    string           LastName,
    string           PreferredName,
    string           ProfilePicUrl,
    string           Bio,
    bool             IsProfilePublic,
    string           Email,
    string?          PhoneNumber,
    DateOnly         MemberSince,
    bool             IsActive,
    List<ClubRole>   Roles,
    bool             EnglandAthleticsAffiliated,
    string?          EnglandAthleticsNumber,
    DateOnly?        DateOfBirth,
    string?          Gender,
    string?          PreferredPace,
    string?          EmergencyContactName,
    string?          EmergencyContactPhone,
    List<RaceResult> RaceResults
)
{
    public string DisplayName =>
        string.IsNullOrWhiteSpace(PreferredName) ? FirstName : PreferredName;

    public string FullName => $"{FirstName} {LastName}";

    public RaceResult? PB(RaceDistance distance) =>
        RaceResults
            .Where(r => r.Distance == distance && r.IsPB)
            .MinBy(r => r.FinishTime);

    public ClubRole PrimaryRole =>
        Roles.Contains(ClubRole.Admin)     ? ClubRole.Admin :
        Roles.Contains(ClubRole.Committee) ? ClubRole.Committee :
        Roles.Contains(ClubRole.Leader)    ? ClubRole.Leader :
                                             ClubRole.Member;
}
