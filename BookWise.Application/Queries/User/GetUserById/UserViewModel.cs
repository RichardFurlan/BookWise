namespace BookWise.Application.Queries.User.GetUserById;

public record UserViewModel(string FullName, string Email, DateTime BirthDate)
{
    public static UserViewModel FromEntity(Core.Entities.User entity)
        => new(entity.FullName, entity.Email, entity.BirthDate);
};