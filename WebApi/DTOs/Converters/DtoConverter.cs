using AutoMapper;
using System.Linq;
using System.Collections.Generic;

namespace WebApi.DTOs.Converters
{
    public static class DtoConverter<T, U>
    {
        static MapperConfiguration config = new MapperConfiguration(cfg => cfg.CreateMap<U, T>());
        static Mapper mapper = new Mapper(config);

        //var bookingList = DtoConverter<Booking, BookingDto>.FromList(bookingDtoList);
        //var bookingDto = DtoConverter<Booking, BookingDto>.From(booking);
        //var booking = DtoConverter<BookingDto, Booking>.From(bookingDto);
        public static T From(U to) => mapper.Map<U, T>(to);
        public static IEnumerable<T> FromList(IEnumerable<U> to) => to.ToList().Select(obj => From(obj));
    }
} 