using System.Collections.Generic;
using AutoMapper;
using CleanConnect.Common.Model.Settings;
using CleanDdd.Common.Model.Identity;
using Dapper;
using Microsoft.Extensions.Options;
using Npgsql;
using ServiceBase.Core.Interfaces;
using ServiceBase.Core.Model.Context;
using ServiceBase.Infrastructure.Records;

namespace ServiceBase.Infrastructure.Repository
{
    public class ExampleRepository: IExampleRepository
    {
        private readonly IMapper _mapper;
        private readonly DbSettings _dbSettings;

        public ExampleRepository(IMapper mapper, IOptions<DbSettings> options)
        {
            _mapper = mapper;
            _dbSettings = options.Value;
        }
        
        public ExampleModel Get(long id)
        {
            var sql = "select * from examples where id = @id";

            using (var conn = new NpgsqlConnection(_dbSettings.GetConnectionString()))
            {
                var result = conn.Query<ExampleRecord>(sql,new { id=id});
                return _mapper.Map<ExampleModel>(result);
            }
        }

        public IList<ExampleModel> Get(int index, int size)
        {
            var sql = "select * from example limit @size offset @index";

            using (var conn = new NpgsqlConnection(_dbSettings.GetConnectionString()))
            {
                var result = conn.Query<ExampleRecord>(sql,new { index = index, size = size});
                return _mapper.Map<IList<ExampleModel>>(result);
            }
        }

        public ExampleModel Save(ExampleModel exampleModel)
        {
            var sql = "insert into example (property1, property2) values(@p1,@p2) returning id";

            using (var conn = new NpgsqlConnection(_dbSettings.GetConnectionString()))
            {
                var result = conn.ExecuteScalar(sql,new {p1 = exampleModel.Property1,p2 = exampleModel.Property2});
                exampleModel.Id.SetIdentity((long)result);
            }

            return exampleModel;
        }
    }
}