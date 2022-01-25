using AutoMapper;
using DatabaseApproach.Models.Request;
using DatabaseApproach.Models.Response;
using DBApproach.Domain.Repository.Models;

namespace DatabaseApproach.Extensions.Profiles
{
    public class MapperProfile : Profile
    {       
        public MapperProfile()
        {            
            CreateMap<AccountRequest, Account>();
            CreateMap<Account, AccountResponse>();

            CreateMap<AttendanceRequest, Attendance>();
            CreateMap<Attendance, AttendanceResponse>();

            CreateMap<AttendanceDetailRequest, AttendanceDetail>();
            CreateMap<AttendanceDetail, AttendanceDetailResponse>();

            CreateMap<MaterialRequest, Material>();
            CreateMap<Material, MaterialResponse>();

            CreateMap<ComponentRequest, Component>();
            CreateMap<Component, ComponentResponse>();

            CreateMap<ImportExportRequest, ImportExport>();
            CreateMap<ImportExport, ImportExportResponse>();

            CreateMap<ImportExportDetailRequest, ImportExportDetail>();
            CreateMap<ImportExportDetail, ImportExportDetailResponse>();

            CreateMap<OrderRequest, Order>();
            CreateMap<Order, OrderResponse>();

            CreateMap<OrderDetailRequest, OrderDetail>();
            CreateMap<OrderDetail, OrderDetailResponse>();

            CreateMap<ProductRequest, Product>();
            CreateMap<Product, ProductResponse>();

            CreateMap<ProcessRequest, Process>();
            CreateMap<Process, ProcessResponse>();

            CreateMap<SectionRequest, Section>();
            CreateMap<Section, SectionResponse>();
        }
    }
}
