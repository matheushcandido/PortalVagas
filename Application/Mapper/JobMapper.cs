using Application.DTOs;
using Core.Entities;
using Riok.Mapperly.Abstractions;

namespace Application.Mapper
{
    [Mapper]
    public partial class JobMapper
    {
        public partial Job ViewModelToDomain(JobDTO dto);
        public partial JobDTO DomainToViewModel(Job domain);
    }
}
