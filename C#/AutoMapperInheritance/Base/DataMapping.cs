using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base
{
    public static class DataMapping
    {
        static DataMapping()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Source, DestinationBase>()
                    .ForMember(dest => dest.VALUE, opt => opt.MapFrom(src => src.CVALUE));


                // Another mapping ..
            });
        }

        public static DestinationBase Map(Source s)
        {
            return Mapper.Map<DestinationBase>(s);
        }

        public static T Map<T>(Source s) where T : DestinationBase
        {
            // I want this (!!!!)
            //return Mapper.Map<T>(s);

            // I have this (double mapping with temporary mapper)
            IMapper mapper = new MapperConfiguration(cfg => cfg.CreateMap(typeof(DestinationBase), typeof(T))).CreateMapper();
            return mapper.Map<T>(Mapper.Map<DestinationBase>(s));
        }
    }
}
