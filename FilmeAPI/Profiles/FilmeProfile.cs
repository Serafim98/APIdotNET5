using AutoMapper;
using FilmeAPI.Data.Dto;
using FilmeAPI.Models;

namespace FilmeAPI.Profiles
{
    public class FilmeProfile:Profile
    {
        public FilmeProfile()
        {
            CreateMap<createFilmeDto, Filme>();
            CreateMap<Filme, updateFilmeDto>();
            CreateMap<updateFilmeDto, Filme>();

        }
    }
}
