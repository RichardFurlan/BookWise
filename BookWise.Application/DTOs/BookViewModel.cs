using BookWise.Core.Entities;
using BookWise.Core.Enum;

namespace BookWise.Application.DTOs;

public record BookViewModel(
    int Id,
    string Title,
    string Isbn,
    DateTime PublicationDate,
    int Edition,
    int PublisherId,
    EnumLenguage Lenguage,
    int NumberOfPage,
    float? RatingAverage,
    int RatingQuantity,
    List<string> Ratings,
    List<LoanViewModel> RecentLoans
    )
{
    public static BookViewModel FromEntity(Book entity)
        => new(
            entity.Id,
            entity.Title,
            entity.Isbn,
            entity.PublicationDate,
            entity.Edition,
            entity.PublisherId,
            entity.Lenguage,
            entity.NumberOfPage,
            entity.RatingAverage,
            entity.RatingQuantity,
            entity.Ratings
                .OrderByDescending(r => r.CreatedAt)
                .Take(5)
                .Select(r => r.Content)
                .ToList(),
            entity.Loans
                .OrderByDescending(l => l.LoanDate)
                .Take(5)
                .Select(LoanViewModel.FromEntity)
                .ToList()
        );
}