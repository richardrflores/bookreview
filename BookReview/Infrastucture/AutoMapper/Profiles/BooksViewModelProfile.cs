using System.Collections.Generic;
using AutoMapper;
using BookReview.Models;
using BookReview.ViewModels;

namespace BookReview.Infrastucture.AutoMapper.Profiles
{
    public class BooksViewModelProfile : Profile
    {
        protected override void Configure()
        {
            //Mapper.CreateMap<IEnumerable<Book>, IEnumerable<BookViewModel>>();
            Mapper.CreateMap<Book, BookViewModel>();
            Mapper.CreateMap<BookViewModel, Book>()
                .ForSourceMember(x => x.RatingAvg, o => o.Ignore());
        }
    }
}