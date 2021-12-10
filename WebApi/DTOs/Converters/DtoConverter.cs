using AutoMapper;
using System.Linq;
using System.Collections.Generic;
using Tools.Enums;

namespace WebApi.DTOs.Converters
{
    public static class DtoConverter<T, U>
    {
        private static MapperConfiguration config = new(cfg =>
        {
            cfg.CreateMap<T, U>();
            cfg.CreateMap<Language, string>().ConvertUsing(src => src.ToString());
            cfg.CreateMap<GraphicType, string>().ConvertUsing(src => src.ToString());
            cfg.CreateMap<SoundType, string>().ConvertUsing(src => src.ToString());
        });
        private static Mapper mapper = new(config);

        //      OUTPUT                     <FROM>      <TO>               <SOURCE>
        //var bookingList = DtoConverter<BookingDto, Booking>.FromList(bookingDtoList);
        //var bookingDto = DtoConverter<Booking, BookingDto>.From(booking);
        //var booking = DtoConverter<BookingDto, Booking>.From(bookingDto);
        public static U From(T sourceObject) => mapper.Map<T, U>(sourceObject);
        public static IEnumerable<U> FromList(IEnumerable<T> sourceList) => sourceList.ToList().Select(obj => From(obj));
        //public static IEnumerable<U> FromList(IEnumerable<T> sourceList)
        //{
        //    List<U> returnList = new List<U>();
        //    foreach (T sourceObject in sourceList)
        //    {
        //        returnList.Add(From(sourceObject));
        //    }
        //    return returnList;
        //}
    }
}