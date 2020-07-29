using AutoMapper;
using BudgetMonitor.Business;
using BudgetMonitor.DAL;
using BudgetMonitor.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Npgsql;
using System;
using System.Collections.Generic;

namespace BudgetMonitor.Test
{
    [TestClass]
    public class TestDAL
    {
        BudgetMonitorContext dbContext = new BudgetMonitorContext();
        static MapperConfiguration mapperConfig = new MapperConfiguration(cnfg => cnfg.AddProfile<BudgetMappings>());
        IMapper Mapper = mapperConfig.CreateMapper();
        public TestDAL()
        {
        }
        [TestMethod]
        public void TestInsertUser()
        {
            //IUser user = new User(Mapper);
            //UserDTO userEntity = new UserDTO
            //{
            //    Name = "Mathi",
            //    Secret = "mathi",
            //    CreatedBy = 1,
            //    CreatedDate = DateTime.Now
            //};
            //user.Add(userEntity);
            //var newUser = user.Get(1);

            //Assert.IsNotNull(newUser, "User Not Added.");
        }

        [TestMethod]
        public void TestInsertAdodotNet_User()
        {
            //UserEntity user = new UserEntity
            //{
            //    Name = "Mathi",
            //    Secret = "mathi",
            //    CreatedBy = 1,
            //    CreatedDate = DateTime.Now
            //};

            //NpgsqlParameter npgsqlParameterName = new NpgsqlParameter("Name", NpgsqlTypes.NpgsqlDbType.Text);
            //npgsqlParameterName.Value = user.Name;
            //NpgsqlParameter npgsqlParameterSecret = new NpgsqlParameter("Secret", NpgsqlTypes.NpgsqlDbType.Text);
            //npgsqlParameterSecret.Value = user.Secret;
            //NpgsqlParameter npgsqlParameterCreatedBy = new NpgsqlParameter("CreatedBy", NpgsqlTypes.NpgsqlDbType.Integer);
            //npgsqlParameterCreatedBy.Value = user.CreatedBy;
            //NpgsqlParameter npgsqlParameterCreatedDate = new NpgsqlParameter("CreatedDate", NpgsqlTypes.NpgsqlDbType.Date);
            //npgsqlParameterCreatedDate.Value = user.CreatedDate;

            //List<NpgsqlParameter> npgsqlParameters = new List<NpgsqlParameter> { npgsqlParameterName , npgsqlParameterSecret , npgsqlParameterCreatedBy , npgsqlParameterCreatedDate };

            //DBHelper.Insert("INSERT INTO public.\"Users\" (\"Name\",\"Secret\",\"CreatedBy\",\"CreatedDate\") Values (@Name,@Secret,@CreatedBy,@CreatedDate)", npgsqlParameters);
        }
    }
}
