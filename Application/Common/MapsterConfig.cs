using Application.Models.Jibit;
using Domain.Entites;
using Mapster;

namespace Application.Common
{
    public class MapsterConfig
    {
        public static void Mapper()
        {
            TypeAdapterConfig<TransferDetail, JibitTransferModel>
             .NewConfig()
             .Map(dest => dest.DestinationFirstName, src => src.FirstName)
             .Map(dest => dest.DestinationLastName, src => src.LastName)
             .Map(dest => dest.Destination, src => src.Iban)
             .Map(dest => dest.TransferId, src => src.ReferenceId);
        }
    }
}
