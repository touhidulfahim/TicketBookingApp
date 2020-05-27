using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketBooking.Common.Converter
{
    public static class ObjectConverter<TSource, TDestination>
    {
        public static TDestination Convert(TSource source)
        {
            return AutoMapper.Mapper.Map<TSource, TDestination>(source);
        }

        public static IList<TDestination> ConvertList(IEnumerable<TSource> source)
        {
            return AutoMapper.Mapper.Map<IEnumerable<TSource>, IList<TDestination>>(source);
        }
    }
}
