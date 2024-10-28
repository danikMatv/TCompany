//using AutoMapper;
//using DALEF.Conc;
//using DALEF.Mapping;
//using DTO.Entity;
//using System.Data;

//string connStr = "Data Source=HP_DANIK\\SQLEXPRESS01;Initial Catalog=TradingCompany;Integrated Security=True;Encrypt=False;";


//MapperConfiguration config = new MapperConfiguration(c => c.AddMaps(typeof(MovieProfile).Assembly));

//Console.ForegroundColor = ConsoleColor.Green;
//Console.WriteLine("═══════════════════════════════════════════");
//Console.WriteLine("         Welcome to Trading Company!       ");
//Console.WriteLine("═══════════════════════════════════════════");
//Console.ResetColor();

//char option = 's';

//while (option != 'q')
//{
//    Console.ForegroundColor = ConsoleColor.Yellow;
//    Console.WriteLine("Please select an option:");
//    Console.WriteLine("1. - Manager panel");
//    Console.WriteLine("2. - Loggin");
//    Console.WriteLine("Q. - Quit\n");
//    Console.ResetColor();

//    string selectedOption = Console.ReadLine() ?? "";

//    if (string.IsNullOrWhiteSpace(selectedOption) || selectedOption.Trim().Length > 1)
//    {
//        Console.ForegroundColor = ConsoleColor.Red;
//        Console.WriteLine("Incorrect option selected! Please try again.");
//        Console.ResetColor();
//        continue;
//    }

//    option = Convert.ToChar(selectedOption.Trim().ToLower());
//    switch (option)
//    {
//        case '1':
//            Console.ForegroundColor = ConsoleColor.Cyan;
//            Console.WriteLine("═══════════════════════════════════════════");
//            Console.WriteLine("               MANAGER PANEL               ");
//            Console.WriteLine("═══════════════════════════════════════════");
//            Console.ResetColor();
//            ManagerPannel();
//            break;
//        case '2':
//            Console.ForegroundColor = ConsoleColor.Cyan;
//            Console.WriteLine("═══════════════════════════════════════════");
//            Console.WriteLine("               LOGGIN PANEL                ");
//            Console.WriteLine("═══════════════════════════════════════════");
//            Console.ResetColor();
//            LogginPanel();
//            break;
//        case '3':
//            Console.ForegroundColor = ConsoleColor.Cyan;
//            Console.WriteLine("═══════════════════════════════════════════");
//            Console.WriteLine("              SHIPPING PANEL               ");
//            Console.WriteLine("═══════════════════════════════════════════");
//            Console.ResetColor();
//            ShippingPanel();
//            break;
//        case 'q':
//            Console.ForegroundColor = ConsoleColor.Yellow;
//            Console.WriteLine("Exiting the application... Goodbye!");
//            Console.ResetColor();
//            return;
//        default:
//            Console.ForegroundColor = ConsoleColor.Red;
//            Console.WriteLine("Incorrect option selected! Please try again.");
//            Console.ResetColor();
//            break;
//    }
//}

//void LogginPanel()
//{
//    Console.ForegroundColor = ConsoleColor.Yellow;
//    Console.WriteLine("Please enter your email:\n");
//    string name = Console.ReadLine() ?? "";
//    Console.WriteLine("Password:\n");
//    string password = Console.ReadLine() ?? "";
//    Console.ResetColor();

//    var managerssDal = new ManagersDalEf(connStr, config.CreateMapper());
//    var manager = managerssDal.login(name,password);
//    if (manager != null)
//    {
//        Console.ForegroundColor = ConsoleColor.Green;
//        Console.WriteLine("\nManager found!");
//        Console.WriteLine("═══════════════════════════════════════════");
//       Console.WriteLine($"|             WELCOME {manager.first_Name}              |");
//        Console.WriteLine("═══════════════════════════════════════════");
//        Console.ResetColor();
//        WorkPannel(manager.id);
//    }
//    else
//    {
//        Console.ForegroundColor = ConsoleColor.Red;
//        Console.WriteLine("\nManager not found.");
//        Console.ResetColor();
//    }
//}

//void WorkPannel(int managerId)
//{
//    char option = 's';

//    while (option != 'q')
//    {
//        Console.ForegroundColor = ConsoleColor.Green;
//        Console.WriteLine("═════════════════════════════════════════════════");
//        Console.WriteLine("                   WORK  PAGE                    ");
//        Console.WriteLine("═════════════════════════════════════════════════");
//        Console.ResetColor();
//        Console.WriteLine("Please select an option:");
//        Console.WriteLine("1. - Create new item");
//        Console.WriteLine("2. - Get all items");
//        Console.WriteLine("3. - Get item by ID");
//        Console.WriteLine("4. - Update item by ID");
//        Console.WriteLine("5. - Delete item by ID");
//        Console.WriteLine("6. - Create new shipping");
//        Console.WriteLine("7. - Get all shippings");
//        Console.WriteLine("8. - Update shipping by ID");
//        Console.WriteLine("9. - Delete shipping by ID");
//        Console.WriteLine("w. - Approve orders");
//        Console.WriteLine("Q. - Quit\n");

//        string selectedOption = Console.ReadLine() ?? "";

//        if (string.IsNullOrWhiteSpace(selectedOption) || selectedOption.Trim().Length > 1)
//        {
//            Console.ForegroundColor = ConsoleColor.Red;
//            Console.WriteLine("Incorrect option selected! Please try again.");
//            Console.ResetColor();
//            continue;
//        }

//        option = Convert.ToChar(selectedOption.Trim().ToLower());
//        switch (option)
//        {
//            case '1':
//                CreateNewGoods(managerId);
//                break;
//            case '2':
//                GetAllGoods();
//                break;
//            case '3':
//                GetGoodsByGoodsId();
//                break;
//            case '4':
//                UpdateGoodsByGoodsId(); 
//                break;
//            case '5':
//                DeleteGoodsByGoodsId();
//                break;
//            case '6':
//                CreateNewShipping();
//                break;
//            case '7':
//                GetAllShipping();
//                break;
//            case '8':
//                UpdateShippingByShippingId();
//                break;
//            case '9':
//                DeleteShippingByShippingId();
//                break;
//            case 'w':
//                ApproveOrders();
//                break;
//            case 'q':
//                Console.ForegroundColor = ConsoleColor.Yellow;
//                Console.WriteLine("Exiting from Panel...");
//                Console.ResetColor();
//                return;
//            default:
//                Console.ForegroundColor = ConsoleColor.Red;
//                Console.WriteLine("Incorrect option selected!");
//                Console.ResetColor();
//                break;
//        }

//    }
//}

//void ApproveOrders()
//{
//    Console.ForegroundColor = ConsoleColor.Cyan;
//    Console.WriteLine("═══════════════════════════════════════════");
//    Console.WriteLine("            MANAGE CLOSED SHIPPINGS        ");
//    Console.WriteLine("═══════════════════════════════════════════");
//    Console.ResetColor();

//    Console.WriteLine("Choose an option:");
//    Console.WriteLine("1 - View all approved shippings");
//    Console.WriteLine("2 - Approve a shipping by ID");
//    Console.Write("Your choice: ");

//    string choice = Console.ReadLine();

//    if (choice == "1")
//    {
//        GetAllApprovedShippings();
//    }
//    else if (choice == "2")
//    {
//        Console.Write("Please enter the shipping ID to approve: ");

//        if (int.TryParse(Console.ReadLine(), out int shippingId))
//        {
//            var shippingDal = new ShippingDalEf(connStr, config.CreateMapper());
//            var shipping = shippingDal.GetById(shippingId);

//            if (shipping != null)
//            {
//                Console.ForegroundColor = ConsoleColor.Green;
//                Console.WriteLine($"Approving shipping with ID: {shipping.id}, Status: {shipping.status}");
//                Console.ResetColor();

//                UpdateShippingStatusByShippingId(shippingId);

//                Console.ForegroundColor = ConsoleColor.Green;
//                Console.WriteLine("Shipping status updated successfully.");
//                Console.ResetColor();
//            }
//            else
//            {
//                Console.ForegroundColor = ConsoleColor.Red;
//                Console.WriteLine("Shipping not found.");
//                Console.ResetColor();
//            }
//        }
//        else
//        {
//            Console.ForegroundColor = ConsoleColor.Red;
//            Console.WriteLine("Invalid ID format.");
//            Console.ResetColor();
//        }
//    }
//    else
//    {
//        Console.ForegroundColor = ConsoleColor.Red;
//        Console.WriteLine("Invalid choice.");
//        Console.ResetColor();
//    }
//}

//void UpdateShippingStatusByShippingId(int shippingId)
//{
//    Console.ForegroundColor = ConsoleColor.Cyan;
//    Console.WriteLine("═══════════════════════════════════════════");
//    Console.WriteLine("                  UPDATING                 ");
//    Console.WriteLine("═══════════════════════════════════════════");
//    Console.ResetColor();
//    var shippingDal = new ShippingDalEf(connStr, config.CreateMapper());
//    var shipping = shippingDal.GetById(shippingId);
//    if (shipping != null)
//    {
//        shipping.status = "APPROVED";
//        shippingDal.Update(shippingId, shipping);

//        Console.ForegroundColor = ConsoleColor.Green;
//        Console.WriteLine("Shipping updated successfully.");
//        Console.ResetColor();
//    }
//    else
//    {
//        Console.ForegroundColor = ConsoleColor.Red;
//        Console.WriteLine("Shipping not found.");
//        Console.ResetColor();
//    }
//}
////Goods
//void GoodsPanel()
//{
//    //char option = ' ';
//    //while (option != 'q')
//    //{
//    //    Console.ForegroundColor = ConsoleColor.Green;
//    //    Console.WriteLine("═════════════════════════════════════════════════");
//    //    Console.WriteLine("                  GOODS PANEL                   ");
//    //    Console.WriteLine("═════════════════════════════════════════════════");
//    //    Console.ResetColor();
//    //    Console.WriteLine("Please select an option:");
//    //    Console.WriteLine("1. - Create new item");
//    //    Console.WriteLine("2. - Get all items");
//    //    Console.WriteLine("3. - Get item by ID");
//    //    Console.WriteLine("4. - Update item by ID");
//    //    Console.WriteLine("5. - Delete item by ID");
//    //    Console.WriteLine("Q. - Quit\n");

//    //    string selectedOption = Console.ReadLine() ?? "";

//    //    if (string.IsNullOrWhiteSpace(selectedOption) || selectedOption.Trim().Length > 1)
//    //    {
//    //        Console.ForegroundColor = ConsoleColor.Red;
//    //        Console.WriteLine("Incorrect option selected! Please try again.");
//    //        Console.ResetColor();
//    //        continue;
//    //    }

//    //    option = Convert.ToChar(selectedOption.Trim().ToLower());
//    //    switch (option)
//    //    {
//    //        case '1':
//    //            //CreateNewGoods();
//    //            break;
//    //        case '2':
//    //            GetAllGoods();
//    //            break;
//    //        case '3':
//    //            GetGoodsByGoodsId();
//    //            break;
//    //        case '4':
//    //            UpdateGoodsByGoodsId();
//    //            break;
//    //        case '5':
//    //            DeleteGoodsByGoodsId();
//    //            break;
//    //        case 'q':
//    //            Console.ForegroundColor = ConsoleColor.Yellow;
//    //            Console.WriteLine("Exiting Goods Panel...");
//    //            Console.ResetColor();
//    //            return;
//    //        default:
//    //            Console.ForegroundColor = ConsoleColor.Red;
//    //            Console.WriteLine("Incorrect option selected!");
//    //            Console.ResetColor();
//    //            break;
//    //    }
//    //}
//}
//void DeleteGoodsByGoodsId()
//{
//    Console.ForegroundColor = ConsoleColor.Cyan;
//    Console.WriteLine("═══════════════════════════════════════════");
//    Console.WriteLine("           DELETING GOODS BY ID            ");
//    Console.WriteLine("═══════════════════════════════════════════");
//    Console.ResetColor();

//    Console.Write("Please enter the Goods ID to delete: ");
//    if (int.TryParse(Console.ReadLine(), out int goodsId))
//    {
//        var goodsDal = new GoodsDalEf(connStr, config.CreateMapper());
//        var deletedGoods = goodsDal.Delete(goodsId);

//        if (deletedGoods != null)
//        {
//            Console.ForegroundColor = ConsoleColor.Green;
//            Console.WriteLine($"Goods '{deletedGoods.name}' with ID {goodsId} was deleted successfully.");
//            Console.ResetColor();
//        }
//        else
//        {
//            Console.ForegroundColor = ConsoleColor.Red;
//            Console.WriteLine("Goods not found or deletion failed.");
//            Console.ResetColor();
//        }
//    }
//    else
//    {
//        Console.ForegroundColor = ConsoleColor.Red;
//        Console.WriteLine("Invalid ID format.");
//        Console.ResetColor();
//    }
//}
//void UpdateGoodsByGoodsId()
//{
//    Console.ForegroundColor = ConsoleColor.Cyan;
//    Console.WriteLine("═══════════════════════════════════════════");
//    Console.WriteLine("           UPDATING GOODS BY ID            ");
//    Console.WriteLine("═══════════════════════════════════════════");
//    Console.ResetColor();

//    Console.Write("Please enter the Goods ID to update: ");
//    if (int.TryParse(Console.ReadLine(), out int goodsId))
//    {
//        var goodsDal = new GoodsDalEf(connStr, config.CreateMapper());
//        var goods = goodsDal.GetById(goodsId);

//        if (goods != null)
//        {
//            Console.Write("Please enter new name (leave blank for no change): ");
//            string name = Console.ReadLine();

//            Console.Write("Please enter new price (leave blank for no change): ");
//            string priceInput = Console.ReadLine();
//            decimal? price = string.IsNullOrEmpty(priceInput) ? (decimal?)null : Convert.ToDecimal(priceInput);

//            Console.Write("Please enter new manager ID (leave blank for no change): ");
//            string managerIdInput = Console.ReadLine();
//            int? managerId = string.IsNullOrEmpty(managerIdInput) ? (int?)null : Convert.ToInt32(managerIdInput);

//            if (!string.IsNullOrEmpty(name)) goods.name = name;
//            if (price.HasValue) goods.price = (double)price.Value;
//            if (managerId.HasValue) goods.manager_id = managerId.Value;

//            goodsDal.Update(goodsId, goods);
//            Console.ForegroundColor = ConsoleColor.Green;
//            Console.WriteLine("Goods updated successfully.");
//            Console.ResetColor();
//        }
//        else
//        {
//            Console.ForegroundColor = ConsoleColor.Red;
//            Console.WriteLine("Goods not found.");
//            Console.ResetColor();
//        }
//    }
//    else
//    {
//        Console.ForegroundColor = ConsoleColor.Red;
//        Console.WriteLine("Invalid ID format.");
//        Console.ResetColor();
//    }
//}
//void GetGoodsByGoodsId()
//{
//    Console.ForegroundColor = ConsoleColor.Cyan;
//    Console.WriteLine("═══════════════════════════════════════════");
//    Console.WriteLine("             SEARCH GOODS BY ID            ");
//    Console.WriteLine("═══════════════════════════════════════════");
//    Console.ResetColor();

//    Console.Write("Please enter the Goods ID: ");
//    if (int.TryParse(Console.ReadLine(), out int goodsId))
//    {
//        var goodsDal = new GoodsDalEf(connStr, config.CreateMapper());
//        var goods = goodsDal.GetById(goodsId);

//        if (goods != null)
//        {
//            Console.ForegroundColor = ConsoleColor.Green;
//            Console.WriteLine($"ID: {goods.id}\n" +
//                $"Name: {goods.name}\n" +
//                $"Price: {goods.price:C}\n" +
//                $"Manager ID: {goods.manager_id}");
//            Console.ResetColor();
//        }
//        else
//        {
//            Console.ForegroundColor = ConsoleColor.Red;
//            Console.WriteLine("Goods not found.");
//            Console.ResetColor();
//        }
//    }
//    else
//    {
//        Console.ForegroundColor = ConsoleColor.Red;
//        Console.WriteLine("Invalid ID format.");
//        Console.ResetColor();
//    }
//}
//void CreateNewGoods(int managerId)
//{
//    Console.ForegroundColor = ConsoleColor.Cyan;
//    Console.WriteLine("═══════════════════════════════════════════");
//    Console.WriteLine("             CREATING NEW GOODS            ");
//    Console.WriteLine("═══════════════════════════════════════════");
//    Console.ResetColor();

//    Console.Write("Please enter Goods name: ");
//    string name = Console.ReadLine();

//    Console.Write("Please enter price: ");
//    if (decimal.TryParse(Console.ReadLine(), out decimal price))
//    {
//        var goods = new Goods
//        {
//            name = name,
//            price = (double)price,
//            manager_id = managerId
//        };

//        var goodsDal = new GoodsDalEf(connStr, config.CreateMapper());
//        Goods createdGoods = goodsDal.Create(goods);

//        Console.ForegroundColor = ConsoleColor.Green;
//        Console.WriteLine($"New Goods created successfully with ID: {createdGoods.id}");
//        Console.ResetColor();
//    }
//    else
//    {
//        Console.ForegroundColor = ConsoleColor.Red;
//        Console.WriteLine("Invalid price format.");
//        Console.ResetColor();
//    }
//}
//void GetAllGoods()
//{
//    Console.ForegroundColor = ConsoleColor.Cyan;
//    Console.WriteLine("═══════════════════════════════════════════");
//    Console.WriteLine("                ALL GOODS                 ");
//    Console.WriteLine("═══════════════════════════════════════════");
//    Console.ResetColor();

//    var goodsDal = new GoodsDalEf(connStr, config.CreateMapper());
//    var goods = goodsDal.GetAll();

//    Console.ForegroundColor = ConsoleColor.Yellow;
//    Console.WriteLine($"{"ID",-5} {"Name",-20} {"Price",-10} {"Manager ID"}");
//    Console.ResetColor();

//    foreach (var item in goods)
//    {
//        if (item.id % 2 == 0)
//            Console.ForegroundColor = ConsoleColor.Gray;
//        else
//            Console.ForegroundColor = ConsoleColor.White;

//        Console.WriteLine($"{item.id,-5} {item.name,-20} {item.price,-10:C} {item.manager_id}");
//        Console.ResetColor();
//    }

//    Console.ForegroundColor = ConsoleColor.Cyan;
//    Console.WriteLine("═══════════════════════════════════════════");
//    Console.ResetColor();
//}
////Shipping
//void ShippingPanel()
//{
//    char option = ' ';
//    while (option != 'q')
//    {
//        Console.ForegroundColor = ConsoleColor.Green;
//        Console.WriteLine("═════════════════════════════════════════════════");
//        Console.WriteLine("                SHIPPING PANEL                  ");
//        Console.WriteLine("═════════════════════════════════════════════════");
//        Console.ResetColor();
//        Console.WriteLine("Please select an option:");
//        Console.WriteLine("1. - Create new shipping");
//        Console.WriteLine("2. - Get all shippings");
//        Console.WriteLine("3. - Get shipping by ID");
//        Console.WriteLine("4. - Update shipping by ID");
//        Console.WriteLine("5. - Delete shipping by ID");
//        Console.WriteLine("Q. - Quit\n");

//        string selectedOption = Console.ReadLine() ?? "";

//        if (string.IsNullOrWhiteSpace(selectedOption) || selectedOption.Trim().Length > 1)
//        {
//            Console.ForegroundColor = ConsoleColor.Red;
//            Console.WriteLine("Incorrect option selected! Please try again.");
//            Console.ResetColor();
//            continue;
//        }

//        option = Convert.ToChar(selectedOption.Trim().ToLower());
//        switch (option)
//        {
//            case '1':
//                CreateNewShipping();
//                break;
//            case '2':
//                GetAllShipping();
//                break;
//            case '3':
//                GetShippingByShippingId();
//                break;
//            case '4':
//                UpdateShippingByShippingId();
//                break;
//            case '5':
//                DeleteShippingByShippingId();
//                break;
//            case 'q':
//                Console.ForegroundColor = ConsoleColor.Yellow;
//                Console.WriteLine("Exiting Shipping Panel...");
//                Console.ResetColor();
//                return;
//            default:
//                Console.ForegroundColor = ConsoleColor.Red;
//                Console.WriteLine("Incorrect option selected!");
//                Console.ResetColor();
//                break;
//        }
//    }
//}

//void CreateNewShipping()
//{
//    Console.ForegroundColor = ConsoleColor.Cyan;
//    Console.WriteLine("═══════════════════════════════════════════");
//    Console.WriteLine("           CREATING NEW SHIPPING           ");
//    Console.WriteLine("═══════════════════════════════════════════");
//    Console.ResetColor();

//    Console.Write("Please enter start address: ");
//    string startAddress = Console.ReadLine();

//    Console.Write("Please enter destination: ");
//    string destination = Console.ReadLine();

//    Console.Write("Please enter goods ID: ");
//    if (!int.TryParse(Console.ReadLine(), out int goodsId))
//    {
//        Console.ForegroundColor = ConsoleColor.Red;
//        Console.WriteLine("Invalid goods ID format.");
//        Console.ResetColor();
//        return;
//    }
//    DateTime end_date = GetDateFromUser("Enter the destination date (format: yyyy-MM-dd): ");


//    var shipping = new Shipping
//    {
//        start_adress = startAddress,
//        destination = destination,
//        goods_id = goodsId,
//        status = "Waiting for approve",
//        start_date = DateTimeOffset.Now,
//        destination_date = end_date
//    };

//    var shippingDal = new ShippingDalEf(connStr, config.CreateMapper());
//    Shipping createdShipping = shippingDal.Create(shipping);

//    Console.ForegroundColor = ConsoleColor.Green;
//    Console.WriteLine($"Shipping created successfully: {createdShipping.id}.\t{createdShipping.start_adress}\t{createdShipping.destination}\t{createdShipping.goods_id}");
//    Console.ResetColor();
//}

//void GetShippingByShippingId()
//{
//    Console.ForegroundColor = ConsoleColor.Cyan;
//    Console.WriteLine("═══════════════════════════════════════════");
//    Console.WriteLine("           SEARCH SHIPPING BY ID           ");
//    Console.WriteLine("═══════════════════════════════════════════");
//    Console.ResetColor();

//    Console.Write("Please enter the shipping ID: ");
//    if (int.TryParse(Console.ReadLine(), out int shippingId))
//    {
//        var shippingDal = new ShippingDalEf(connStr, config.CreateMapper());
//        var shipping = shippingDal.GetById(shippingId);

//        if (shipping != null)
//        {
//            Console.ForegroundColor = ConsoleColor.Yellow;
//            Console.WriteLine($"{"ID",-5} {"Start Address",-20} {"Destination",-20} {"Goods ID",-10} {"Status",-10} {"Start Date",-20} {"Destination Date",-20}");
//            Console.ResetColor();

//            Console.ForegroundColor = ConsoleColor.Green;
//            Console.WriteLine($"{shipping.id,-5} {shipping.start_adress,-20} {shipping.destination,-20} {shipping.goods_id,-10} " +
//                              $"{shipping.status,-10} {shipping.start_date,-20} {shipping.destination_date,-20}");
//            Console.ResetColor();
//        }
//        else
//        {
//            Console.ForegroundColor = ConsoleColor.Red;
//            Console.WriteLine("Shipping not found.");
//            Console.ResetColor();
//        }
//    }
//    else
//    {
//        Console.ForegroundColor = ConsoleColor.Red;
//        Console.WriteLine("Invalid ID format.");
//        Console.ResetColor();
//    }
//}
//void UpdateShippingByShippingId()
//{
//    Console.ForegroundColor = ConsoleColor.Cyan;
//    Console.WriteLine("═══════════════════════════════════════════");
//    Console.WriteLine("           UPDATING SHIPPING BY ID         ");
//    Console.WriteLine("═══════════════════════════════════════════");
//    Console.ResetColor();

//    Console.Write("Please enter the shipping ID to update: ");
//    if (int.TryParse(Console.ReadLine(), out int shippingId))
//    {
//        var shippingDal = new ShippingDalEf(connStr, config.CreateMapper());
//        var shipping = shippingDal.GetById(shippingId);

//        if (shipping != null)
//        {
//            Console.Write("Please enter new start address (leave blank for no change): ");
//            string newStartAddress = Console.ReadLine();
//            if (!string.IsNullOrEmpty(newStartAddress)) shipping.start_adress = newStartAddress;

//            Console.Write("Please enter new destination (leave blank for no change): ");
//            string newDestination = Console.ReadLine();
//            if (!string.IsNullOrEmpty(newDestination)) shipping.destination = newDestination;

//            Console.Write("Please enter new goods ID (leave blank for no change): ");
//            string newGoodsIdInput = Console.ReadLine();
//            if (int.TryParse(newGoodsIdInput, out int newGoodsId)) shipping.goods_id = newGoodsId;

//            Console.Write("Please enter new status (leave blank for no change): ");
//            string newStatus = Console.ReadLine();
//            if (!string.IsNullOrEmpty(newStatus)) shipping.status = newStatus;

//            shippingDal.Update(shippingId, shipping);

//            Console.ForegroundColor = ConsoleColor.Green;
//            Console.WriteLine("Shipping updated successfully.");
//            Console.ResetColor();
//        }
//        else
//        {
//            Console.ForegroundColor = ConsoleColor.Red;
//            Console.WriteLine("Shipping not found.");
//            Console.ResetColor();
//        }
//    }
//    else
//    {
//        Console.ForegroundColor = ConsoleColor.Red;
//        Console.WriteLine("Invalid ID format.");
//        Console.ResetColor();
//    }
//}
//void DeleteShippingByShippingId()
//{
//    Console.ForegroundColor = ConsoleColor.Cyan;
//    Console.WriteLine("═══════════════════════════════════════════");
//    Console.WriteLine("           DELETING SHIPPING BY ID         ");
//    Console.WriteLine("═══════════════════════════════════════════");
//    Console.ResetColor();

//    Console.Write("Please enter the shipping ID to delete: ");
//    if (int.TryParse(Console.ReadLine(), out int shippingId))
//    {
//        var shippingDal = new ShippingDalEf(connStr, config.CreateMapper());
//        var deletedShipping = shippingDal.Delete(shippingId);

//        if (deletedShipping != null)
//        {
//            Console.ForegroundColor = ConsoleColor.Green;
//            Console.WriteLine("Shipping deleted successfully.");
//            Console.ResetColor();
//        }
//        else
//        {
//            Console.ForegroundColor = ConsoleColor.Red;
//            Console.WriteLine("Shipping not found or deletion failed.");
//            Console.ResetColor();
//        }
//    }
//    else
//    {
//        Console.ForegroundColor = ConsoleColor.Red;
//        Console.WriteLine("Invalid ID format.");
//        Console.ResetColor();
//    }
//}
//void GetAllShipping()
//{
//    Console.ForegroundColor = ConsoleColor.Cyan;
//    Console.WriteLine("═══════════════════════════════════════════");
//    Console.WriteLine("                ALL SHIPPING               ");
//    Console.WriteLine("═══════════════════════════════════════════");
//    Console.ResetColor();

//    var shippingDal = new ShippingDalEf(connStr, config.CreateMapper());
//    var shippings = shippingDal.GetAll();

//    Console.WriteLine("Choose sorting option:");
//    Console.WriteLine("1 - No sorting");
//    Console.WriteLine("2 - Sort by delivery date");
//    Console.WriteLine("3 - Sort by status");
//    Console.Write("Your choice: ");

//    string choice = Console.ReadLine();

//    switch (choice)
//    {
//        case "2":
//            shippings = shippings.OrderBy(s => s.destination_date).ToList();
//            break;
//        case "3":
//            shippings = shippings.OrderBy(s => s.status).ToList();
//            break;
//        default:
//            break;
//    }

//    Console.ForegroundColor = ConsoleColor.Yellow;
//    Console.WriteLine("══════════════════════════════════════════════════════════════════════════════");
//    Console.WriteLine($"{"ID",-5} {"Start Address",-20} {"Destination",-20} {"Goods ID",-10} {"Status",-20} {"Start Date",-15} {"Destination Date",-15}");
//    Console.WriteLine("══════════════════════════════════════════════════════════════════════════════");
//    Console.ResetColor();

//    foreach (var shipping in shippings)
//    {
//        string startDate = shipping.start_date.ToString("dd.MM.yyyy");
//        string destinationDate = shipping.destination_date.ToString("dd.MM.yyyy");

//        Console.ForegroundColor = shipping.id % 2 == 0 ? ConsoleColor.Gray : ConsoleColor.White;

//        Console.WriteLine($"{shipping.id,-5} {shipping.start_adress,-20} {shipping.destination,-20} {shipping.goods_id,-10} " +
//                          $"{shipping.status,-20} {startDate,-15} {destinationDate,-15}");
//    }

//    Console.ResetColor();
//    Console.WriteLine("═══════════════════════════════════════════");
//}

//void GetAllApprovedShippings()
//{
//    Console.ForegroundColor = ConsoleColor.Cyan;
//    Console.WriteLine("═══════════════════════════════════════════");
//    Console.WriteLine("            ALL APPROVED SHIPPING          ");
//    Console.WriteLine("═══════════════════════════════════════════");
//    Console.ResetColor();

//    var shippingDal = new ShippingDalEf(connStr, config.CreateMapper());
//    var closedShippings = shippingDal.GetAllByStatus("APPROVED");

//    if (closedShippings.Count > 0)
//    {
//        Console.ForegroundColor = ConsoleColor.Yellow;
//        Console.WriteLine($"{"ID",-5} {"Start Address",-20} {"Destination",-20} {"Goods ID",-10} {"Status",-10} {"Start Date",-20} {"Destination Date",-20}");
//        Console.ResetColor();

//        foreach (var shipping in closedShippings)
//        {
//            if (shipping.id % 2 == 0)
//                Console.ForegroundColor = ConsoleColor.Gray;
//            else
//                Console.ForegroundColor = ConsoleColor.White;

//            Console.WriteLine($"{shipping.id,-5} {shipping.start_adress,-20} {shipping.destination,-20} {shipping.goods_id,-10} " +
//                              $"{shipping.status,-10} {shipping.start_date,-20} {shipping.destination_date,-20}");
//            Console.ResetColor();
//        }
//    }
//    else
//    {
//        Console.ForegroundColor = ConsoleColor.Red;
//        Console.WriteLine("No approved shipping records found.");
//        Console.ResetColor();
//    }
//}

//DateTime GetDateFromUser(string prompt)
//{
//    DateTime date;
//    Console.Write(prompt);

//    while (!DateTime.TryParse(Console.ReadLine(), out date))
//    {
//        Console.ForegroundColor = ConsoleColor.Red;
//        Console.WriteLine("Invalid date format. Please enter the date in the format: yyyy-MM-dd.");
//        Console.ResetColor();
//        Console.Write(prompt); // Re-prompt the user
//    }

//    return date;
//}

////Manager
//void ManagerPannel()
//{
//    char option = ' ';
//    while (option != 'q')
//    {
//        Console.Clear();
//        Console.ForegroundColor = ConsoleColor.Cyan;
//        Console.WriteLine("═══════════════════════════════════════════");
//        Console.WriteLine("          MANAGER CONTROL PANEL           ");
//        Console.WriteLine("═══════════════════════════════════════════");
//        Console.ResetColor();

//        Console.WriteLine("Please select an option:");
//        Console.WriteLine(" 1. - Create new manager");
//        Console.WriteLine(" 2. - Get all managers");
//        Console.WriteLine(" 3. - Get manager by ID");
//        Console.WriteLine(" 4. - Update manager by ID");
//        Console.WriteLine(" 5. - Delete manager by ID");
//        Console.WriteLine(" Q. - Quit");

//        Console.ForegroundColor = ConsoleColor.Yellow;
//        Console.Write("\nYour choice: ");
//        Console.ResetColor();

//        string selectedOption = Console.ReadLine() ?? "";

//        if (string.IsNullOrWhiteSpace(selectedOption) || selectedOption.Trim().Length > 1)
//        {
//            Console.ForegroundColor = ConsoleColor.Red;
//            Console.WriteLine("\nIncorrect option selected! Please try again.");
//            Console.ResetColor();
//            Thread.Sleep(1500);
//            continue;
//        }

//        option = Convert.ToChar(selectedOption.Trim().ToLower());

//        switch (option)
//        {
//            case '1':
//                CreateNewManager();
//                break;
//            case '2':
//                GetAllManagers();
//                break;
//            case '3':
//                GetManagerByManagerId();
//                break;
//            case '4':
//                UpdateManagerByManagerId();
//                break;
//            case '5':
//                DeleteManagerByManagerId();
//                break;
//            case 'q':
//                Console.ForegroundColor = ConsoleColor.Green;
//                Console.WriteLine("\nThank you for using the Manager Control Panel!");
//                Console.ResetColor();
//                return;
//            default:
//                Console.ForegroundColor = ConsoleColor.Red;
//                Console.WriteLine("\nIncorrect option selected! Please try again.");
//                Console.ResetColor();
//                Thread.Sleep(1500);
//                break;
//        }
//    }
//}
//void GetAllManagers()
//{
//    var managerssDal = new ManagersDalEf(connStr, config.CreateMapper());
//    var managers = managerssDal.GetAll();

//    if (managers.Any())
//    {
//        Console.ForegroundColor = ConsoleColor.Cyan;
//        Console.WriteLine("\n═══════════════════════════════════════════");
//        Console.WriteLine("               MANAGER LIST               ");
//        Console.WriteLine("═══════════════════════════════════════════");
//        Console.ResetColor();

//        Console.ForegroundColor = ConsoleColor.Yellow;
//        Console.WriteLine($"{"ID",-5} {"First Name",-15} {"Last Name",-15} {"Email",-25} {"Phone Number",-15}");
//        Console.ResetColor();

//        foreach (var manager in managers)
//        {
//            if (manager.id % 2 == 0)
//                Console.ForegroundColor = ConsoleColor.Gray;
//            else
//                Console.ForegroundColor = ConsoleColor.White;

//            Console.WriteLine($"{manager.id,-5} {manager.first_Name,-15} {manager.last_Name,-15} {manager.email,-25} {manager.phone_Number,-15}");
//            Console.ResetColor();
//        }
//    }
//    else
//    {
//        Console.ForegroundColor = ConsoleColor.Red;
//        Console.WriteLine("\nNo managers found.");
//        Console.ResetColor();
//    }
//    Console.WriteLine("\nPress any key to return to the Manager Panel...");
//    Console.ReadKey();
//}
//void GetManagerByManagerId()
//{
//    Console.ForegroundColor = ConsoleColor.Yellow;
//    Console.WriteLine("\nPlease enter the manager ID:");
//    Console.ResetColor();

//    if (int.TryParse(Console.ReadLine(), out int managerId))
//    {
//        var managerssDal = new ManagersDalEf(connStr, config.CreateMapper());
//        var manager = managerssDal.GetById(managerId);

//        if (manager != null)
//        {
//            Console.ForegroundColor = ConsoleColor.Green;
//            Console.WriteLine("\nManager found:");
//            Console.WriteLine("═══════════════════════════════════════════");
//            Console.ResetColor();

//            Console.WriteLine($"ID: {manager.id}");
//            Console.WriteLine($"First Name: {manager.first_Name}");
//            Console.WriteLine($"Last Name: {manager.last_Name}");
//            Console.WriteLine($"Email: {manager.email}");
//            Console.WriteLine($"Phone Number: {manager.phone_Number}");
//        }
//        else
//        {
//            Console.ForegroundColor = ConsoleColor.Red;
//            Console.WriteLine("\nManager not found.");
//            Console.ResetColor();
//        }
//    }
//    else
//    {
//        Console.ForegroundColor = ConsoleColor.Red;
//        Console.WriteLine("\nInvalid ID format.");
//        Console.ResetColor();
//    }

//    Console.WriteLine("\nPress any key to return to the Manager Panel...");
//    Console.ReadKey();
//}
//void UpdateManagerByManagerId()
//{
//    Console.ForegroundColor = ConsoleColor.Yellow;
//    Console.WriteLine("\nPlease enter the manager ID to update:");
//    Console.ResetColor();

//    if (int.TryParse(Console.ReadLine(), out int managerId))
//    {
//        Console.ForegroundColor = ConsoleColor.Cyan;
//        Console.WriteLine("\nPlease enter new information (leave blank for no change):");
//        Console.ResetColor();

//        Console.Write("First Name: ");
//        string firstName = Console.ReadLine();

//        Console.Write("Last Name: ");
//        string lastName = Console.ReadLine();

//        Console.Write("Phone Number: ");
//        string pNumber = Console.ReadLine();


//        Console.Write("Email: ");
//        string email = Console.ReadLine();

//        var managerssDal = new ManagersDalEf(connStr, config.CreateMapper());
//        var manager = managerssDal.GetById(managerId);

//        if (manager != null)
//        {
//            if (!string.IsNullOrEmpty(firstName)) manager.first_Name = firstName;
//            if (!string.IsNullOrEmpty(lastName)) manager.last_Name = lastName;
//            if (!string.IsNullOrEmpty(pNumber)) manager.phone_Number = pNumber;
//            if (!string.IsNullOrEmpty(email)) manager.email = email;

//            managerssDal.Update(managerId, manager);

//            Console.ForegroundColor = ConsoleColor.Green;
//            Console.WriteLine("\nManager updated successfully!");
//            Console.ResetColor();
//        }
//        else
//        {
//            Console.ForegroundColor = ConsoleColor.Red;
//            Console.WriteLine("\nManager not found.");
//            Console.ResetColor();
//        }
//    }
//    else
//    {
//        Console.ForegroundColor = ConsoleColor.Red;
//        Console.WriteLine("\nInvalid ID format.");
//        Console.ResetColor();
//    }

//    Console.WriteLine("\nPress any key to return to the Manager Panel...");
//    Console.ReadKey();
//}
//void DeleteManagerByManagerId()
//{
//    Console.ForegroundColor = ConsoleColor.Yellow;
//    Console.WriteLine("\nPlease enter the manager ID to delete:");
//    Console.ResetColor();

//    if (int.TryParse(Console.ReadLine(), out int managerId))
//    {
//        var managerssDal = new ManagersDalEf(connStr, config.CreateMapper());
//        var deletedManager = managerssDal.Delete(managerId);

//        if (deletedManager != null)
//        {
//            Console.ForegroundColor = ConsoleColor.Green;
//            Console.WriteLine("\nManager deleted successfully!");
//            Console.ResetColor();
//        }
//        else
//        {
//            Console.ForegroundColor = ConsoleColor.Red;
//            Console.WriteLine("\nManager not found or deletion failed.");
//            Console.ResetColor();
//        }
//    }
//    else
//    {
//        Console.ForegroundColor = ConsoleColor.Red;
//        Console.WriteLine("\nInvalid ID format.");
//        Console.ResetColor();
//    }

//    Console.WriteLine("\nPress any key to return to the Manager Panel...");
//    Console.ReadKey();
//}
//void CreateNewManager()
//{
//    Console.ForegroundColor = ConsoleColor.Cyan;
//    Console.WriteLine("\nPlease enter the following details for the new manager:");
//    Console.ResetColor();

//    Console.Write("First Name: ");
//    string firstName = Console.ReadLine();

//    Console.Write("Last Name: ");
//    string lastName = Console.ReadLine();

//    Console.Write("Password : ");
//    string pass = Console.ReadLine();

//    string hashedPassword = BCrypt.Net.BCrypt.HashPassword(pass);

//    Console.Write("Phone Number: ");
//    string pNumber = Console.ReadLine();

//    Console.Write("Email: ");
//    string email = Console.ReadLine();

//    var manager = new Managers
//    {
//        first_Name = firstName,
//        last_Name = lastName,
//        password = hashedPassword,
//        phone_Number = pNumber,
//        email = email
//    };

//    var managerssDal = new ManagersDalEf(connStr, config.CreateMapper());
//    Managers managerss = managerssDal.Create(manager);

//    Console.ForegroundColor = ConsoleColor.Green;
//    Console.WriteLine("\nNew manager created successfully!");
//    //Console.WriteLine($"ID: {managerss.id}");
//    //Console.WriteLine($"First Name: {managerss.first_Name}");
//    //Console.WriteLine($"Last Name: {managerss.last_Name}");
//    //Console.WriteLine($"Email: {managerss.email}");
//    //Console.WriteLine($"Phone Number: {managerss.phone_Number}");
//    //Console.WriteLine($"Password: {managerss.password}");
//    Console.ResetColor();

//    Console.WriteLine("\nPress any key to return to the Manager Panel...");
//    Console.ReadKey();
//}
