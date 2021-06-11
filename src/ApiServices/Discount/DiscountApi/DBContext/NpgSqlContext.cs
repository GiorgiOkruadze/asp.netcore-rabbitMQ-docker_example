using Microsoft.Extensions.Configuration;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiscountApi.DBContext
{
    public interface INpgSqlContext
    {
        NpgsqlConnection GetConnection();
    }

    public class NpgSqlContext: INpgSqlContext
    {
        public readonly IConfiguration _configuration = default;

        public NpgSqlContext(IConfiguration configuration)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }


        public NpgsqlConnection GetConnection()
        {
            return new NpgsqlConnection(_configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
        }
    }
}
