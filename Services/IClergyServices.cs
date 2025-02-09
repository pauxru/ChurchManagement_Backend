using Churchmanagement.Models;

namespace Churchmanagement.Services
{
    public interface IClergyServices
    {

        public Clergy getClergyByID(int clergyID);
        public List<Clergy> getLocalChurchClergy(int localChurchID);
        public List<Clergy> getParishClergy(int parishID);
        public List<Clergy> getDioceseClergy(int dioceseID);


    }
}
