using TractorCompare.Models;

namespace TractorCompare
{
    public interface ITractorRepository
    {
        public IEnumerable<Tractors> GetAllTractors();

    }
}
