using Churchmanagement.Models;

namespace Churchmanagement.Services
{
    public interface IChurchService
    {
        List<LocalChurch> GetLocalChurchesInParish(int parishID);

        List<LocalChurch> GetLocalChurchesInDiocese(int dioceseID);
        List<Parish> GetParishesInDiocese(int dioceseID);

        List<Diocese> GetAllDiocese();

        List<Parish> GetAllParish();

        LocalChurch GetLocalChurchDetails(int localChurchID);
    }
}
