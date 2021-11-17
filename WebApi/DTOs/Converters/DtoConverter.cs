using AutoMapper;
using System.Linq;
using System.Collections.Generic;

namespace WebApi.DTOs.Converters
{
    public static class DtoConverter<T, U>
    {
        private static MapperConfiguration config = new(cfg => cfg.CreateMap<T, U>());
        private static Mapper mapper = new(config);

        //      OUTPUT                     <FROM>      <TO>               <SOURCE>
        //var bookingList = DtoConverter<BookingDto, Booking>.FromList(bookingDtoList);
        //var bookingDto = DtoConverter<Booking, BookingDto>.From(booking);
        //var booking = DtoConverter<BookingDto, Booking>.From(bookingDto);
        public static U From(T sourceObject) => mapper.Map<T, U>(sourceObject);
        public static IEnumerable<U> FromList(IEnumerable<T> sourceList) => sourceList.ToList().Select(obj => From(obj));
    }
} 