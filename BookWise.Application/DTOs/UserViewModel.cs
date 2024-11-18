using BookWise.Core.Entities;

namespace BookWise.Application.DTOs;

public record UserViewModel(string FullName, string Email, DateTime BirthDate)
{
    public static UserViewModel FromEntity(User entity)
        => new(entity.FullName, entity.Email, entity.BirthDate);
};