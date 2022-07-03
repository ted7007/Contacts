using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Contacts.Controller.util;
using Contacts.DTO;
using Contacts.Model;
using Contacts.Service.util;

namespace Contacts.Controller.Mapper
{
    public class PersonMapper : IMapper
    { 

        public TOut Map<TIn, TOut>(TIn valueToConvert)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<TIn, TOut>());
            var mapper = new AutoMapper.Mapper(config);

            var result = mapper.Map<TOut>(valueToConvert);
            return result;

        }

    }
}
