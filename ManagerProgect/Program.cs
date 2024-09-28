//using AutoMapper;
//using DAL.Repository;
//using DALEF.Conc;
//using DALEF.Mapping;
//using DTO;




//string connStr = "Data Source=HP_DANIK\\SQLEXPRESS01;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False";

//MapperConfiguration config = new MapperConfiguration(c => c.AddMaps(typeof(MovieProfile).Assembly));

//Console.WriteLine("Welcome to IMDB!\n");
//char option = 's';

//while (option != 'q')
//{
//    Console.WriteLine("Please select option:\n1. - List all Genres\n2. - Get genre by Id\n3. - Get all movies\n4. - Add movie\n5. - List movies with EF\n6. - Add movie with EF\nQ. - Quit\n");

//    string selectedOption = Console.ReadLine() ?? "";

//    if (string.IsNullOrWhiteSpace(selectedOption) || selectedOption.Trim().Length > 1)
//    {
//        Console.WriteLine("Incorrect option selected!");
//        continue;
//    }

//    option = Convert.ToChar(selectedOption.Trim().ToLower());
//    switch (option)
//    {
//        default: break;
//    }
//}
