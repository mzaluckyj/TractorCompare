using Microsoft.AspNetCore.Mvc;
using TractorCompare.Models;

namespace TractorCompare
{
    public interface ITractorRepository
    {
        public IEnumerable<Tractors> GetAllTractors();

        public Tractors GetTractor(int id);
        public void UpdateTractor(Tractors tractor);

        public IEnumerable<Tractors> CompareNow();

        public IEnumerable<Tractors> GetJD();
        public IEnumerable<Tractors> GetKubota();


        public void InsertTractor(Tractors newtractor);

        public IEnumerable<Brand> GetBrands();

        public Tractors AssignBrand();

        public void DeleteTractor(Tractors tractor);



    }
}
