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
            return _conn.QuerySingle<Tractors>("Select * From Tractors Where tractorID = @id", new { id = id });
        }

        public IEnumerable<Tractors> GetJD()
        {
            return _conn.Query<Tractors>("Select * From Tractors Where Brand = 'John Deere';") ;
        }
    }
}
