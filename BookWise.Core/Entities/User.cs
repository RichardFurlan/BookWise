using BookWise.Core.Enum;

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

        RentedBooks = [];
        ProfilePictureUrl = "";
        Ratings = [];
        Notifications = [];
    }

    public string FullName { get; private set; }
    public string Email { get; private set; }
    public string Password { get; private set; }
    public DateTime BirthDate { get; private set; }
    public bool Active { get; private set; }
    public EnumUserRole Role { get; private set; }
    public List<Book> RentedBooks { get; private set; }
    public string ProfilePictureUrl { get; private set; }
    public List<Rating> Ratings { get; private set; }
    public List<Notification> Notifications { get; private set; }


}