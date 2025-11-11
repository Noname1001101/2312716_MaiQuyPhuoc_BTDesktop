using System;
using System.Configuration;

namespace DataAccess
{
    public class Ultilities
    {
        private static string StrName = "RestaurantDB"; // trùng với tên trong App.config
        public static string ConnectionString = ConfigurationManager.ConnectionStrings[StrName].ConnectionString;

        public static string Food_GetAll = "Food_GetAll";
        public static string Food_InsertUpdateDelete = "Food_InsertUpdateDelete";
        public static string Category_GetAll = "Category_GetAll";
        public static string Category_InsertUpdateDelete = "Category_InsertUpdateDelete";
        public static string Bill_GetAll = "Bill_GetAll";
    }
}
