using TractorCompare.Models;

namespace TractorCompare
{
    public interface ITractorRepository
    {
        public IEnumerable<Tractors> GetAllTractors();

        public Tractors GetTractor(int id);
        public void UpdateTractor(Tractors tractor);



        public IEnumerable<Tractors> GetJD();


    }
}
