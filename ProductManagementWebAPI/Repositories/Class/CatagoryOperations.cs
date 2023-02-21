
using Microsoft.EntityFrameworkCore;
using ProductManagementWebAPI.Models;
using Repository.Repositories.Interfaces;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Threading.Tasks;
using ProductManagementWebAPI.DTO;

namespace ProductManagementWebAPI.Repositories.Class
{
    public class CatagoryOperations : ICatagoryOperation
    {
        readonly DataContext db;
        public CatagoryOperations(DataContext DB)
        {
            db = DB;
        }

       
        public async Task<bool> ActivateAsync(int id)
        {

            var parameter = new[]
            {
                new SqlParameter("@CatagoryId",id)
            };

            var data = await  db.Database.ExecuteSqlRawAsync("execute spActivator @CatagoryId",parameter);


            if (data > 0)
            {
                return true;
            }
            return false;
            
        }

        public async Task<bool> DeactivateAsync(int id )
        {
            var parameter = new[]
            {
                new SqlParameter("@CatagoryId",id)
            };

            var data = await db.Database.ExecuteSqlRawAsync("execute spDeactivate @CatagoryId", parameter);

            if(data > 0)
            { return true; }
            return false;

        }

        public async Task<bool> InsertProductInCatagoryAsync(int productId, int CatagoryId)
        {
            var parameter = new[]
           {
                new SqlParameter("@Productid",productId),
                new SqlParameter("@Catagoryid",CatagoryId)
            };

            var data = await db.Database.ExecuteSqlRawAsync("execute spAddProduct @ProductId = @Productid,@CatagoryId =@Catagoryid", parameter);

            if(data > 0)
            { return true; }
            return false;
        }

        public async Task<IEnumerable<ReportDto>> ReportAllAsync()
        {
            using (SqlConnection Con = new SqlConnection(db.cs))
            {

                SqlCommand command = new SqlCommand("sp_ReportAll", Con);
                command.CommandType = CommandType.StoredProcedure;
                await Con.OpenAsync();

                SqlDataReader sdr = await command.ExecuteReaderAsync();
                List<ReportDto> ReportList = new List<ReportDto>();
                while (await sdr.ReadAsync())
                {
                    ReportDto report = new ReportDto();

                    report.UserName = await sdr.GetFieldValueAsync<string>(0);
                    report.CatagoryName = await sdr.GetFieldValueAsync<string>(1);
                    report.ProductGenericName = await sdr.GetFieldValueAsync<string>(2);
                    report.ProductTitle = await sdr.GetFieldValueAsync<string>(3);
                    report.ProductPrice = await sdr.GetFieldValueAsync<int>(4);

                    ReportList.Add(report);
                }
                return ReportList;
            }
        }

        public async Task<IEnumerable<ReportDto>> ReportAsync(int id)
        {
            using (SqlConnection Con = new SqlConnection(db.cs))
            {

                SqlCommand command = new SqlCommand("spReport", Con);
                command.CommandType = CommandType.StoredProcedure;
                await Con.OpenAsync();
                command.Parameters.AddWithValue("@LoginId", id);

                SqlDataReader sdr = await command.ExecuteReaderAsync();
                List<ReportDto> ReportList = new List<ReportDto>();
                while (await sdr.ReadAsync())
                {
                    ReportDto report = new ReportDto();

                    report.UserName = await sdr.GetFieldValueAsync<string>(0);
                    report.CatagoryName = await sdr.GetFieldValueAsync<string>(1);
                    report.ProductGenericName = await sdr.GetFieldValueAsync<string>(2);
                    report.ProductTitle = await sdr.GetFieldValueAsync<string>(3);
                    report.ProductPrice = await sdr.GetFieldValueAsync<int>(4);

                    ReportList.Add(report);
                }
                return ReportList;
            }
        }

        


    }
}
