using TractorCompare.Models;

namespace TractorCompare
{
    public interface ITractorRepository
    {
        public IEnumerable<Tractors> GetAllTractors();

        public Tractors GetTractor(int id);

        public IEnumerable<Tractors> GetJD();


    }
}
