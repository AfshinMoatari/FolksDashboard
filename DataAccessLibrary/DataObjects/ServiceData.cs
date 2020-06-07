using DataAccessLibrary.Interfaces;
using DataAccessLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.DataObjects
{
    public class ServiceData : IServiceData
    {
        private readonly ISqlDataAccess _db;

        public ServiceData(ISqlDataAccess db)
        {
            _db = db;
        }
        public Task<List<ServiceModel>> GetService()
        {
            string sql = "SELECT * FROM [dbo].[Service]";
            return _db.LoadData<ServiceModel, dynamic>(sql, new { });
        }
        public Task<bool> InsertService(ServiceModel service)
        {
            string sql = @"INSERT INTO [dbo].[Service] (Name, Description, Fee)
                            VALUES (@Name, @Description, @Fee);";
            return _db.SaveData(sql, service);
        }
        public Task<List<ExpenseModel>> GetExpense(string SelectedService)
        {
            DateTime now = DateTime.Now;
            var SelectedYear = now.Year;
            string sql = @"SELECT 
                        SUM(CASE datepart(month,OrderDate) WHEN 1 THEN Price ELSE 0 END) AS 'January',
                        SUM(CASE datepart(month,OrderDate) WHEN 2 THEN Price ELSE 0 END) AS 'February',
                        SUM(CASE datepart(month,OrderDate) WHEN 3 THEN Price ELSE 0 END) AS 'March',
                        SUM(CASE datepart(month,OrderDate) WHEN 4 THEN Price ELSE 0 END) AS 'April',
                        SUM(CASE datepart(month,OrderDate) WHEN 5 THEN Price ELSE 0 END) AS 'May',
                        SUM(CASE datepart(month,OrderDate) WHEN 6 THEN Price ELSE 0 END) AS 'June',
                        SUM(CASE datepart(month,OrderDate) WHEN 7 THEN Price ELSE 0 END) AS 'July',
                        SUM(CASE datepart(month,OrderDate) WHEN 8 THEN Price ELSE 0 END) AS 'August',
                        SUM(CASE datepart(month,OrderDate) WHEN 9 THEN Price ELSE 0 END) AS 'September',
                        SUM(CASE datepart(month,OrderDate) WHEN 10 THEN Price ELSE 0 END) AS 'October',
                        SUM(CASE datepart(month,OrderDate) WHEN 11 THEN Price ELSE 0 END) AS 'November',
                        SUM(CASE datepart(month,OrderDate) WHEN 12 THEN Price ELSE 0 END) AS 'December'
                        FROM
                        [dbo].[Service] AS s
                        INNER JOIN [dbo].[Order_Service] AS os 
                        ON os.[ServiceId] = s.[ServiceId]
                        INNER JOIN [dbo].[Order] AS o 
                        ON o.[OrderID] = os.[OrderId]
                        WHERE s.[Name] = @selectedService
                        AND year([OrderDate]) = @selectedYear;";
            return _db.LoadData<ExpenseModel, dynamic>(sql, new { selectedService = SelectedService, selectedYear = SelectedYear });
        }
    }
}
