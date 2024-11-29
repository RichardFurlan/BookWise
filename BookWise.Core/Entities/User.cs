using BookWise.Core.Enum;
using BookWise.Core.ValueObjects;

namespace BookWise.Core.Entities;

public class User : BaseEntity
{
    public User(string fullName, string email, string password, DateTime birthDate) : base()
    {
        FullName = fullName;
        Email = email;
        Password = password;
        BirthDate = birthDate;
        Active = true;

        Role = EnumUserRole.Unknow;
        ProfilePictureUrl = "";
        Ratings = [];
        Notifications = [];
        Loans = [];
        Address = null;
    }

    public string FullName { get; private set; }
    public string Email { get; private set; }
    public string Password { get; private set; }
    public DateTime BirthDate { get; private set; }
    public bool Active { get; private set; }
    public EnumUserRole Role { get; private set; }
    public string ProfilePictureUrl { get; private set; }
    public List<Rating> Ratings { get; private set; }
    public List<Notification> Notifications { get; private set; }
    public List<Loan> Loans { get; private set; }
    public Address? Address { get; private set; }

    #region Updates
    public void UpdateProfilePicture(string profilePictureUrl)
        => ProfilePictureUrl = profilePictureUrl;

    public void UpdateFullName(string newFullName)
        => FullName = newFullName;
    
    public void UpdateAddress(Address address)
        => Address = address;

    public void UpdateBirthDate(DateTime birthDate)
        => BirthDate = birthDate;

    #endregion
}