using System;
using RestaurantApp.Views;

static class Program
{
    static void Main()
    {
        UsersView appStart = new UsersView();
        appStart.StartApp();
        //const string connectionString =
        //    "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=aspnet-NetFlixApplication-f48077b8-8a4d-4abe-a72f-6c2cc190875e;Integrated Security=True;";

        //const string queryString = "SELECT * FROM Person";

        //using SqlConnection connection = new(connectionString);
        //SqlCommand command = new(queryString, connection);

        //try
        //{
        //    connection.Open();
        //    SqlDataReader reader = command.ExecuteReader();

        //    while (reader.Read())
        //    {
        //        for (int i = 0; i < reader.FieldCount; i++)
        //        {
        //            Console.Write($"{reader.GetName(i)}: {reader[i]}  ");
        //        }

        //        Console.WriteLine();
        //    }

        //    reader.Close();
        //}
        //catch (Exception ex)
        //{
        //    Console.WriteLine(ex.Message);
        //}

        //Console.ReadLine();
    }
}