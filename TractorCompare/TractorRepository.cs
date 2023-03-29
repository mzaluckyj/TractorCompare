using Dapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Runtime.CompilerServices;
using TractorCompare.Models;

namespace TractorCompare
{
    public class TractorRepository : ITractorRepository
    {
        private readonly IDbConnection _conn;
        public TractorRepository(IDbConnection conn) 
        {
            _conn= conn;
        }

        public IEnumerable<Tractors> GetAllTractors() 
        {
            return _conn.Query<Tractors>("Select * From Tractors;");
        }

        public Tractors GetTractor(int id)
        {
            return _conn.QuerySingle<Tractors>("Select * From Tractors Where tractorID = @id",
                new { id = id });
        }

        public void UpdateTractor(Tractors tractor) 
        {
            _conn.Execute("Update Tractors SET Class = @Class, PTO =@PTO, fuel = @fuel, hydroSteer = @hydroSteer, hydroImp = @hydroImp, threePT = @threePT, HP = @HP Where tractorID = @id;",
                new {Class = tractor.Class, PTO = tractor.PTO, fuel = tractor.fuel, hydroSteer = tractor.hydroSteer, hydroImp = tractor.hydroImp, threePT = tractor.threePT, HP = tractor.HP, id = tractor.tractorID});
        }

        public IEnumerable<Tractors> CompareNow() 
        {
            return _conn.Query<Tractors>("Select * From Tractors;");
        }

        public void InsertTractor(Tractors newtractor)
        {
            _conn.Execute("INSERT INTO Tractors (Model, HP, brandID, CLass, PTO, fuel, hydroSteer, hydroImp, threePT) VALUES (@model, @hp, @brandID, @Class, @PTO, @fuel, @hydroSteer, @hydroImp, @threePT);",
                new { Model = newtractor.Model, HP = newtractor.HP, brandID = newtractor.brandID, Class = newtractor.Class, PTO = newtractor.PTO, fuel = newtractor.fuel, hydroSteer = newtractor.hydroSteer, hydroImp = newtractor.hydroImp, threePT = newtractor.threePT, });
        }

        public IEnumerable<Brand> GetBrands()
        {
            return _conn.Query<Brand>("SELECT * FROM brand;");
        }

        public Tractors AssignBrand()
        {
            var brandList = GetBrands();
            var tractor = new Tractors();
            tractor.name = brandList;
            return tractor;
        }

        public void DeleteTractor(Tractors tractor)
        {
            _conn.Execute("DELETE FROM tractors WHERE tractorID = @id;", new { id = tractor.tractorID });
        }

    }
}
