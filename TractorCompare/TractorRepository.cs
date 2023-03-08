using Dapper;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
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
            _conn.Execute("Update Tractors SET Brand = @Brand, Model = @Model, Class = @Class, HP = @HP Where tractorID = @id;",
                new {Brand = tractor.Brand, Model = tractor.Model, Class = tractor.Class, HP = tractor.HP, id = tractor.tractorID});
        }
        public IEnumerable<Tractors> GetJD()
        {
            return _conn.Query<Tractors>("Select * From Tractors Where Brand = 'John Deere';") ;
        }

        public IEnumerable<Tractors> GetKubota()
        {
            return _conn.Query<Tractors>("Select * From Tractors Where Brand = 'Kubota';");
        }
    }
}
