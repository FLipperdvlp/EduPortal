namespace EduPortal.Entities.BaseEntities;

public class BaseEntityForPerson
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string? PhoneNumber { get; set; }
    //TODO public bool IsActive { get; set; } = true;   MAYBE
}