using AutoMapper;
using ErniTechnicalExamMonteagudoJeffrey.Models;
using ErniTechnicalExamMonteagudoJeffrey.Requests;

namespace ErniTechnicalExamMonteagudoJeffrey.MappingConfigurations
{
    public class AccountProfile : Profile
    {


        public AccountProfile()
        {
            CreateMap<Account, CreateAccountRequest>();
            CreateMap<CreateAccountRequest, Account>();
        }
    }
}
