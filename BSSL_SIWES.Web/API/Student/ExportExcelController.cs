using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using ExcelDataReader;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SiwesData;
using SiwesData.Students;

namespace BSSL_SIWES.Web.API.Student
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExportExcelController : ControllerBase
    {
        //private readonly ApplicationDbContext _context;

        //public ExportExcelController(ApplicationDbContext context)
        //{
        //    _context = context;
        //}
        //private List<StudentSetUp> GetDataFromCSVFile(Stream stream)
        //{
        //    var empList = new List<StudentSetUp>();
        //    try
        //    {
        //        using (var reader = ExcelReaderFactory.CreateCsvReader(stream))
        //        {
        //            var dataSet = reader.AsDataSet(new ExcelDataSetConfiguration
        //            {
        //                ConfigureDataTable = _ => new ExcelDataTableConfiguration
        //                {
        //                    UseHeaderRow = true // To set First Row As Column Names  
        //                }
        //            });

        //            if (dataSet.Tables.Count > 0)
        //            {
        //                var dataTable = dataSet.Tables[0];
        //                foreach (DataRow objDataRow in dataTable.Rows)
        //                {
        //                    if (objDataRow.ItemArray.All(x => string.IsNullOrEmpty(x?.ToString()))) continue;
        //                    empList.Add(new StudentSetUp()
        //                    {
        //                        Id = Convert.ToInt32(objDataRow["ID"].ToString()),
        //                        MatricNumber = objDataRow["MatricNumber"].ToString(),
        //                        MatricYear = objDataRow["MatricYear"].ToString(),
        //                        Surname = objDataRow["Surname"].ToString(),
        //                        OtherNames = objDataRow["OtherName"].ToString(),
        //                        YearOfStudy = objDataRow["YearOfStudy"].ToString(),
        //                        PhoneNo = objDataRow["PhoneNo"].ToString(),
        //                        Email = objDataRow["Email"].ToString(),
        //                        BatchNo = objDataRow["BatchNo"].ToString(),
        //                        SiwesYear = objDataRow["SiwesYear"].ToString(),
        //                    });
        //                }
        //            }

        //        }
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }

        //    return empList;
        //}

        //public static class Extensions
        //{
        //    public static DataTable ToDataTable<T>(this List<T> items)
        //    {
        //        DataTable dataTable = new DataTable(typeof(T).Name);

        //        //Get all the properties  
        //        PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
        //        foreach (PropertyInfo prop in Props)
        //        {
        //            //Defining type of data column gives proper data table   
        //            var type = (prop.PropertyType.IsGenericType && prop.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>) ? Nullable.GetUnderlyingType(prop.PropertyType) : prop.PropertyType);
        //            //Setting column names as Property names  
        //            dataTable.Columns.Add(prop.Name, type);
        //        }
        //        foreach (T item in items)
        //        {
        //            var values = new object[Props.Length];
        //            for (int i = 0; i < Props.Length; i++)
        //            {
        //                //inserting property values to datatable rows  
        //                values[i] = Props[i].GetValue(item, null);
        //            }
        //            dataTable.Rows.Add(values);
        //        }
        //        return dataTable;
        //    }
        //}

        //// GET: api/ExportExcel
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET: api/ExportExcel/5
        //[HttpGet("{id}", Name = "Get")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST: api/ExportExcel
        //[HttpPost]
        //public async Task<ActionResult> ImportFile(HttpPostedFileBase importFile)
        //{
        //    if (importFile == null) return Json(new { Status = 0, Message = "No File Selected" });

        //    try
        //    {
        //        var fileData = GetDataFromCSVFile(importFile.InputStream);

        //        var dtEmployee = fileData.ToDataTable();
        //        var tblEmployeeParameter = new SqlParameter("tblEmployeeTableType", SqlDbType.Structured)
        //        {
        //            TypeName = "dbo.tblTypeEmployee",
        //            Value = dtEmployee
        //        };
        //        await _context.Database.ExecuteSqlCommandAsync("EXEC spBulkImportEmployee @tblEmployeeTableType", tblEmployeeParameter);
        //        return Json(new { Status = 1, Message = "File Imported Successfully " });
        //    }
        //    catch (Exception ex)
        //    {
        //        return Json(new { Status = 0, Message = ex.Message });
        //    }
        //}

        //// PUT: api/ExportExcel/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE: api/ApiWithActions/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
