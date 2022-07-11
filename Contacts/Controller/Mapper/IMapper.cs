using Contacts.DTO;
using Contacts.Model;
using Contacts.Service.util;

namespace Contacts.Controller.Mapper
{
    public interface IMapper
    {
        public TOut Map<TIn, TOut>(TIn valueToConvert);
    }
}
