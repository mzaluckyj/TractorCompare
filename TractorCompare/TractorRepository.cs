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
            _conn.Execute("Update Tractors SET Brand = @brand, Model = @Model, Class = @Class, HP = @HP Where tractorID = @id;",
                new {Brand = tractor.brand, Model = tractor.Model, Class = tractor.Class, HP = tractor.HP, id = tractor.tractorID});
        }
        public IEnumerable<Tractors> GetJD()
        {
            return _conn.Query<Tractors>("Select * From Tractors Where brandID = '1';") ;
        }

        public IEnumerable<Tractors> GetKubota()
        {
            return _conn.Query<Tractors>("Select * From Tractors Where brandID = '2';");
        }

        public IEnumerable<Tractors> CompareNow() 
        {
            return _conn.Query<Tractors>("Select * From Tractors;");
        }

        public void InsertTractor(Tractors newtractor)
        {
            _conn.Execute("INSERT INTO Tractors (Model, HP, brandID) VALUES (@model, @hp, @brandID);",
                new { Model = newtractor.Model, HP = newtractor.HP, brandID = newtractor.brandID });
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
