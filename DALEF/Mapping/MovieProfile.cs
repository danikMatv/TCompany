using AutoMapper;
using DALEF.Models;
using DTO.Entity;

namespace DALEF.Mapping
{
    public class MovieProfile : Profile
    {
        public MovieProfile()
        {
            CreateMap<TblGoods, Goods>();
            CreateMap<Goods, TblGoods>();

            CreateMap<TblEmployees, Employees>();
            CreateMap<Employees, TblEmployees>();

            CreateMap<TblShipping, Shipping>();
            CreateMap<Shipping, TblShipping>();
        }
    }
}
