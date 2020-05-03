using Microsoft.Extensions.Configuration;
using Dapper;
using PRACTICE.MODEL;
using PRACTICE.REPOSITORY.Contracts;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace PRACTICE.REPOSITORY
{
    public class MemberRepository : IMemberRepository

    {
        private readonly IConfiguration _config;

        public MemberRepository(IConfiguration config)
        {
            _config = config;
        }

        public async Task<ReturnObject> AddMember(Member member)
        {
            try
            {
                using (IDbConnection cn = new DapperConfig(_config).ProjectDbConnection)
                {
                    string storedProcName = "spAddMember";
                    DynamicParameters parameter = new DynamicParameters();
                    parameter.Add("@Id", member.Id);
                    parameter.Add("@Name", member.Name);
                    parameter.Add("@Comment", member.Comment);
                    parameter.Add("@Phone", member.Phone);
                    parameter.Add("@City", member.City);

                    var ret = await cn.QueryFirstOrDefaultAsync<ReturnObject>(storedProcName, parameter, commandType: CommandType.StoredProcedure);
                    if (ret.Status)
                    {
                        var objString = Newtonsoft.Json.JsonConvert.SerializeObject(member);
                    }
                    return ret;
                }
            }
            catch (Exception ex)
            {
                return new ReturnObject { Id = 0, Status = false, StatusMessage = $"{ex.Message}" };
            }
            //using (var sqlConnection = new SqlConnection(connectionString))
            //{
            //    await sqlConnection.OpenAsync();
            //    var dynamicParameters = new DynamicParameters();
            //    dynamicParameters.Add("@Id", member.Id);
            //    dynamicParameters.Add("@Name", member.Name);
            //    dynamicParameters.Add("@Comment", member.Comment);
            //    dynamicParameters.Add("@Phone", member.Phone);
            //    dynamicParameters.Add("@City", member.City);

            //    await sqlConnection.ExecuteAsync(
            //        "spAddMember",
            //        dynamicParameters,
            //        commandType: CommandType.StoredProcedure);
            //}


        }

        public async Task<ReturnObject> DeleteMember(int Id)
        {
            try
            {
                using (IDbConnection cn = new DapperConfig(_config).ProjectDbConnection)
                {
                    string storedProcName = "spDeleteById";
                    DynamicParameters parameter = new DynamicParameters();
                    parameter.Add("@Id", Id);
                    var ret = await cn.QueryFirstOrDefaultAsync<ReturnObject>(storedProcName, parameter, commandType: CommandType.StoredProcedure);
                    return ret;
                }
            }
            catch (Exception ex)
            {
                //learn to log something on the console
                return new ReturnObject { Id = 0, Status = false, StatusMessage = $"{ex.Message}" };
            }


            //using (var sqlConnection = new SqlConnection(connectionString))
            //{
            //    await sqlConnection.OpenAsync();
            //    var dynamicParameters = new DynamicParameters();
            //    dynamicParameters.Add("@Id", Id);
            //    await sqlConnection.ExecuteAsync(
            //        "spDeleteById",
            //        dynamicParameters,
            //        commandType: CommandType.StoredProcedure);
            //}
        }

        public async Task<List<Member>> GetAllMember()
        {
            try
            {
                using (IDbConnection cn = new DapperConfig(_config).ProjectDbConnection)
                {
                    string storedProcName = "spGetAllMembers";

                    var retAsync = await cn.QueryAsync<Member>(storedProcName, commandType: CommandType.StoredProcedure);

                    return retAsync.ToList();
                }
            }
            catch (Exception ex)
            {
                //return new ReturnObject { Id = 0, Status = false, StatusMessage = $"{ex.Message}" };
                //return new List<Member>();
                return null;
            }
            //using (var sqlConnection = new SqlConnection(connectionString))
            //{


            //    await sqlConnection.OpenAsync();
            //    return await sqlConnection.QueryAsync<Members>(
            //        "spGetAllMembers",
            //        null,
            //        commandType: CommandType.StoredProcedure);


            //}
        }

        public async Task<Member> GetMemberById(int Id)
        {
            try
            {
                using (IDbConnection cn = new DapperConfig(_config).ProjectDbConnection)
                {
                    string storedProcName = "spGetMemberById";
                    DynamicParameters parameter = new DynamicParameters();
                    parameter.Add("@Id", Id);
                    var retAsync = await cn.QueryFirstOrDefaultAsync<Member>(storedProcName, parameter, commandType: CommandType.StoredProcedure);

                    return retAsync;
                }
            }
            catch (Exception ex)
            {
                //learn to log something on the console
                return null;
            }

            //using (var sqlConnection = new SqlConnection(connectionString))
            //{
            //    await sqlConnection.OpenAsync();
            //    var dynamicParameters = new DynamicParameters();
            //    dynamicParameters.Add("@Id", Id);
            //    return await sqlConnection.QuerySingleOrDefaultAsync<Members>(
            //        "spGetMemberById",
            //        dynamicParameters,
            //        commandType: CommandType.StoredProcedure);
            //}
        }

        public async Task<ReturnObject> UpdateMember(Member member)
        {
            try
            {
                using (IDbConnection cn = new DapperConfig(_config).ProjectDbConnection)
                {
                    string storedProcName = "spUpdateMemberById";
                    DynamicParameters parameter = new DynamicParameters();
                    parameter.Add("@Id", member.Id);
                    parameter.Add("@Name", member.Name);
                    parameter.Add("@Comment", member.Comment);
                    parameter.Add("@Phone", member.Phone);
                    parameter.Add("@City", member.City);

                    var ret = await cn.QueryFirstOrDefaultAsync<ReturnObject>(storedProcName, parameter, commandType: CommandType.StoredProcedure);
                    if (ret.Status)
                    {
                        var objString = Newtonsoft.Json.JsonConvert.SerializeObject(member);

                    }
                    return ret;

                }

            }
            catch (Exception ex)
            {
                return new ReturnObject { Id = 0, Status = false, StatusMessage = $"{ex.Message}" };
            }

            //using (var sqlConnection = new SqlConnection(connectionString))
            //    {
            //        await sqlConnection.OpenAsync();
            //        var dynamicParameters = new DynamicParameters();
            //        dynamicParameters.Add("@Id", member.Id);
            //        dynamicParameters.Add("@Name", member.Name);
            //        dynamicParameters.Add("@Comment", member.Comment);
            //        dynamicParameters.Add("@Phone", member.Phone);
            //        dynamicParameters.Add("@City", member.City);
            //        await sqlConnection.ExecuteAsync(
            //            "spUpdateMemberById",
            //            dynamicParameters,
            //            commandType: CommandType.StoredProcedure);
            //    }
        }
    }
}
