using AutoMapper;
using BookReview.Infrastucture.AutoMapper.Profiles;

namespace BookReview.Infrastucture.AutoMapper
{
    public class AutoMapperConfiguration
    {
         public static void Configure()
         {
             Mapper.AddProfile(new BooksViewModelProfile());
         }
    }
}