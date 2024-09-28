using AutoMapper;
using DALEF.Conc;
using DALEF.Mapping;
using DTO.Entity;

string connStr = "Data Source=HP_DANIK\\SQLEXPRESS01;Initial Catalog=TradingCompany;Integrated Security=True;Encrypt=False;";


MapperConfiguration config = new MapperConfiguration(c => c.AddMaps(typeof(MovieProfile).Assembly));

Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine("═══════════════════════════════════════════");
Console.WriteLine("         Welcome to Trading Company!       ");
Console.WriteLine("═══════════════════════════════════════════");
Console.ResetColor();

char option = 's';

while (option != 'q')
{
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine("Please select an option:");
    Console.WriteLine("1. - Manager panel");
    Console.WriteLine("2. - Goods panel");
    Console.WriteLine("3. - Shipping panel");
    Console.WriteLine("Q. - Quit\n");
    Console.ResetColor();

    string selectedOption = Console.ReadLine() ?? "";

    if (string.IsNullOrWhiteSpace(selectedOption) || selectedOption.Trim().Length > 1)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Incorrect option selected! Please try again.");
        Console.ResetColor();
        continue;
    }

    option = Convert.ToChar(selectedOption.Trim().ToLower());
    switch (option)
    {
        case '1':
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("═══════════════════════════════════════════");
            Console.WriteLine("               MANAGER PANEL               ");
            Console.WriteLine("═══════════════════════════════════════════");
            Console.ResetColor();
            ManagerPannel();
            break;
        case '2':
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("═══════════════════════════════════════════");
            Console.WriteLine("               GOODS PANEL                 ");
            Console.WriteLine("═══════════════════════════════════════════");
            Console.ResetColor();
            GoodsPanel();
            break;
        case '3':
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("═══════════════════════════════════════════");
            Console.WriteLine("              SHIPPING PANEL               ");
            Console.WriteLine("═══════════════════════════════════════════");
            Console.ResetColor();
            ShippingPanel();
            break;
        case 'q':
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Exiting the application... Goodbye!");
            Console.ResetColor();
            return;
        default:
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Incorrect option selected! Please try again.");
            Console.ResetColor();
            break;
    }
}
//Goods
void GoodsPanel()
{
    char option = ' ';
    while (option != 'q')
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("═════════════════════════════════════════════════");
        Console.WriteLine("                  GOODS PANEL                   ");
        Console.WriteLine("═════════════════════════════════════════════════");
        Console.ResetColor();
        Console.WriteLine("Please select an option:");
        Console.WriteLine("1. - Create new item");
        Console.WriteLine("2. - Get all items");
        Console.WriteLine("3. - Get item by ID");
        Console.WriteLine("4. - Update item by ID");
        Console.WriteLine("5. - Delete item by ID");
        Console.WriteLine("Q. - Quit\n");

        string selectedOption = Console.ReadLine() ?? "";

        if (string.IsNullOrWhiteSpace(selectedOption) || selectedOption.Trim().Length > 1)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Incorrect option selected! Please try again.");
            Console.ResetColor();
            continue;
        }

        option = Convert.ToChar(selectedOption.Trim().ToLower());
        switch (option)
        {
            case '1':
                CreateNewGoods();
                break;
            case '2':
                GetAllGoods();
                break;
            case '3':
                GetGoodsByGoodsId();
                break;
            case '4':
                UpdateGoodsByGoodsId();
                break;
            case '5':
                DeleteGoodsByGoodsId();
                break;
            case 'q':
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Exiting Goods Panel...");
                Console.ResetColor();
                return;
            default:
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Incorrect option selected!");
                Console.ResetColor();
                break;
        }
    }
}
void DeleteGoodsByGoodsId()
{
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine("═══════════════════════════════════════════");
    Console.WriteLine("           DELETING GOODS BY ID            ");
    Console.WriteLine("═══════════════════════════════════════════");
    Console.ResetColor();

    Console.Write("Please enter the Goods ID to delete: ");
    if (int.TryParse(Console.ReadLine(), out int goodsId))
    {
        var goodsDal = new GoodsDalEf(connStr, config.CreateMapper());
        var deletedGoods = goodsDal.Delete(goodsId);

        if (deletedGoods != null)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Goods '{deletedGoods.name}' with ID {goodsId} was deleted successfully.");
            Console.ResetColor();
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Goods not found or deletion failed.");
            Console.ResetColor();
        }
    }
    else
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Invalid ID format.");
        Console.ResetColor();
    }
}
void UpdateGoodsByGoodsId()
{
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine("═══════════════════════════════════════════");
    Console.WriteLine("           UPDATING GOODS BY ID            ");
    Console.WriteLine("═══════════════════════════════════════════");
    Console.ResetColor();

    Console.Write("Please enter the Goods ID to update: ");
    if (int.TryParse(Console.ReadLine(), out int goodsId))
    {
        var goodsDal = new GoodsDalEf(connStr, config.CreateMapper());
        var goods = goodsDal.GetById(goodsId);

        if (goods != null)
        {
            Console.Write("Please enter new name (leave blank for no change): ");
            string name = Console.ReadLine();

            Console.Write("Please enter new price (leave blank for no change): ");
            string priceInput = Console.ReadLine();
            decimal? price = string.IsNullOrEmpty(priceInput) ? (decimal?)null : Convert.ToDecimal(priceInput);

            Console.Write("Please enter new manager ID (leave blank for no change): ");
            string managerIdInput = Console.ReadLine();
            int? managerId = string.IsNullOrEmpty(managerIdInput) ? (int?)null : Convert.ToInt32(managerIdInput);

            if (!string.IsNullOrEmpty(name)) goods.name = name;
            if (price.HasValue) goods.price = (double)price.Value;
            if (managerId.HasValue) goods.manager_id = managerId.Value;

            goodsDal.Update(goodsId, goods);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Goods updated successfully.");
            Console.ResetColor();
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Goods not found.");
            Console.ResetColor();
        }
    }
    else
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Invalid ID format.");
        Console.ResetColor();
    }
}
void GetGoodsByGoodsId()
{
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine("═══════════════════════════════════════════");
    Console.WriteLine("             SEARCH GOODS BY ID            ");
    Console.WriteLine("═══════════════════════════════════════════");
    Console.ResetColor();

    Console.Write("Please enter the Goods ID: ");
    if (int.TryParse(Console.ReadLine(), out int goodsId))
    {
        var goodsDal = new GoodsDalEf(connStr, config.CreateMapper());
        var goods = goodsDal.GetById(goodsId);

        if (goods != null)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"ID: {goods.id}\n" +
                $"Name: {goods.name}\n" +
                $"Price: {goods.price:C}\n" +
                $"Manager ID: {goods.manager_id}");
            Console.ResetColor();
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Goods not found.");
            Console.ResetColor();
        }
    }
    else
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Invalid ID format.");
        Console.ResetColor();
    }
}
void CreateNewGoods()
{
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine("═══════════════════════════════════════════");
    Console.WriteLine("             CREATING NEW GOODS            ");
    Console.WriteLine("═══════════════════════════════════════════");
    Console.ResetColor();

    Console.Write("Please enter Goods name: ");
    string name = Console.ReadLine();

    Console.Write("Please enter price: ");
    if (decimal.TryParse(Console.ReadLine(), out decimal price))
    {
        Console.Write("Please enter Manager ID: ");
        if (int.TryParse(Console.ReadLine(), out int managerId))
        {
            var goods = new Goods
            {
                name = name,
                price = (double)price,
                manager_id = managerId
            };

            var goodsDal = new GoodsDalEf(connStr, config.CreateMapper());
            Goods createdGoods = goodsDal.Create(goods);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"New Goods created successfully with ID: {createdGoods.id}");
            Console.ResetColor();
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Invalid Manager ID format.");
            Console.ResetColor();
        }
    }
    else
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Invalid price format.");
        Console.ResetColor();
    }
}
void GetAllGoods()
{
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine("═══════════════════════════════════════════");
    Console.WriteLine("                ALL GOODS                 ");
    Console.WriteLine("═══════════════════════════════════════════");
    Console.ResetColor();

    var goodsDal = new GoodsDalEf(connStr, config.CreateMapper());
    var goods = goodsDal.GetAll();

    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine($"{"ID",-5} {"Name",-20} {"Price",-10} {"Manager ID"}");
    Console.ResetColor();

    foreach (var item in goods)
    {
        if (item.id % 2 == 0)
            Console.ForegroundColor = ConsoleColor.Gray;
        else
            Console.ForegroundColor = ConsoleColor.White;

        Console.WriteLine($"{item.id,-5} {item.name,-20} {item.price,-10:C} {item.manager_id}");
        Console.ResetColor();
    }

    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine("═══════════════════════════════════════════");
    Console.ResetColor();
}
//Shipping
void ShippingPanel()
{
    char option = ' ';
    while (option != 'q')
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("═════════════════════════════════════════════════");
        Console.WriteLine("                SHIPPING PANEL                  ");
        Console.WriteLine("═════════════════════════════════════════════════");
        Console.ResetColor();
        Console.WriteLine("Please select an option:");
        Console.WriteLine("1. - Create new shipping");
        Console.WriteLine("2. - Get all shippings");
        Console.WriteLine("3. - Get shipping by ID");
        Console.WriteLine("4. - Update shipping by ID");
        Console.WriteLine("5. - Delete shipping by ID");
        Console.WriteLine("Q. - Quit\n");

        string selectedOption = Console.ReadLine() ?? "";

        if (string.IsNullOrWhiteSpace(selectedOption) || selectedOption.Trim().Length > 1)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Incorrect option selected! Please try again.");
            Console.ResetColor();
            continue;
        }

        option = Convert.ToChar(selectedOption.Trim().ToLower());
        switch (option)
        {
            case '1':
                CreateNewShipping();
                break;
            case '2':
                GetAllShipping();
                break;
            case '3':
                GetShippingByShippingId();
                break;
            case '4':
                UpdateShippingByShippingId();
                break;
            case '5':
                DeleteShippingByShippingId();
                break;
            case 'q':
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Exiting Shipping Panel...");
                Console.ResetColor();
                return;
            default:
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Incorrect option selected!");
                Console.ResetColor();
                break;
        }
    }
}

void CreateNewShipping()
{
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine("═══════════════════════════════════════════");
    Console.WriteLine("           CREATING NEW SHIPPING           ");
    Console.WriteLine("═══════════════════════════════════════════");
    Console.ResetColor();

    Console.Write("Please enter start address: ");
    string startAddress = Console.ReadLine();

    Console.Write("Please enter destination: ");
    string destination = Console.ReadLine();

    Console.Write("Please enter goods ID: ");
    if (!int.TryParse(Console.ReadLine(), out int goodsId))
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Invalid goods ID format.");
        Console.ResetColor();
        return;
    }

    var shipping = new Shipping
    {
        start_adress = startAddress,
        destination = destination,
        goods_id = goodsId
    };

    var shippingDal = new ShippingDalEf(connStr, config.CreateMapper());
    Shipping createdShipping = shippingDal.Create(shipping);

    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine($"Shipping created successfully: {createdShipping.id}.\t{createdShipping.start_adress}\t{createdShipping.destination}\t{createdShipping.goods_id}");
    Console.ResetColor();
}

void GetShippingByShippingId()
{
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine("═══════════════════════════════════════════");
    Console.WriteLine("           SEARCH SHIPPING BY ID           ");
    Console.WriteLine("═══════════════════════════════════════════");
    Console.ResetColor();

    Console.Write("Please enter the shipping ID: ");
    if (int.TryParse(Console.ReadLine(), out int shippingId))
    {
        var shippingDal = new ShippingDalEf(connStr, config.CreateMapper());
        var shipping = shippingDal.GetById(shippingId);

        if (shipping != null)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{shipping.id}.\t{shipping.start_adress}\t{shipping.destination}\t{shipping.goods_id}");
            Console.ResetColor();
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Shipping not found.");
            Console.ResetColor();
        }
    }
    else
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Invalid ID format.");
        Console.ResetColor();
    }
}

void UpdateShippingByShippingId()
{
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine("═══════════════════════════════════════════");
    Console.WriteLine("           UPDATING SHIPPING BY ID         ");
    Console.WriteLine("═══════════════════════════════════════════");
    Console.ResetColor();

    Console.Write("Please enter the shipping ID to update: ");
    if (int.TryParse(Console.ReadLine(), out int shippingId))
    {
        var shippingDal = new ShippingDalEf(connStr, config.CreateMapper());
        var shipping = shippingDal.GetById(shippingId);

        if (shipping != null)
        {
            Console.Write("Please enter new start address (leave blank for no change): ");
            string newStartAddress = Console.ReadLine();
            if (!string.IsNullOrEmpty(newStartAddress)) shipping.start_adress = newStartAddress;

            Console.Write("Please enter new destination (leave blank for no change): ");
            string newDestination = Console.ReadLine();
            if (!string.IsNullOrEmpty(newDestination)) shipping.destination = newDestination;

            Console.Write("Please enter new goods ID (leave blank for no change): ");
            string newGoodsIdInput = Console.ReadLine();
            if (int.TryParse(newGoodsIdInput, out int newGoodsId)) shipping.goods_id = newGoodsId;

            shippingDal.Update(shippingId, shipping);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Shipping updated successfully.");
            Console.ResetColor();
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Shipping not found.");
            Console.ResetColor();
        }
    }
    else
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Invalid ID format.");
        Console.ResetColor();
    }
}

void DeleteShippingByShippingId()
{
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine("═══════════════════════════════════════════");
    Console.WriteLine("           DELETING SHIPPING BY ID         ");
    Console.WriteLine("═══════════════════════════════════════════");
    Console.ResetColor();

    Console.Write("Please enter the shipping ID to delete: ");
    if (int.TryParse(Console.ReadLine(), out int shippingId))
    {
        var shippingDal = new ShippingDalEf(connStr, config.CreateMapper());
        var deletedShipping = shippingDal.Delete(shippingId);

        if (deletedShipping != null)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Shipping deleted successfully.");
            Console.ResetColor();
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Shipping not found or deletion failed.");
            Console.ResetColor();
        }
    }
    else
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Invalid ID format.");
        Console.ResetColor();
    }
}

void GetAllShipping()
{
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine("═══════════════════════════════════════════");
    Console.WriteLine("                ALL SHIPPING               ");
    Console.WriteLine("═══════════════════════════════════════════");
    Console.ResetColor();

    var shippingDal = new ShippingDalEf(connStr, config.CreateMapper());
    var shippings = shippingDal.GetAll();

    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine($"{"ID",-5} {"Start Address",-20} {"Destination",-20} {"Goods ID"}");
    Console.ResetColor();

    foreach (var shipping in shippings)
    {
        if (shipping.id % 2 == 0)
            Console.ForegroundColor = ConsoleColor.Gray;
        else
            Console.ForegroundColor = ConsoleColor.White;

        Console.WriteLine($"{shipping.id,-5} {shipping.start_adress,-20} {shipping.destination,-20} {shipping.goods_id}");
        Console.ResetColor();
    }
}


//Manager
void ManagerPannel()
{
    char option = ' ';
    while (option != 'q')
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("═══════════════════════════════════════════");
        Console.WriteLine("          MANAGER CONTROL PANEL           ");
        Console.WriteLine("═══════════════════════════════════════════");
        Console.ResetColor();

        Console.WriteLine("Please select an option:");
        Console.WriteLine(" 1. - Create new manager");
        Console.WriteLine(" 2. - Get all managers");
        Console.WriteLine(" 3. - Get manager by ID");
        Console.WriteLine(" 4. - Update manager by ID");
        Console.WriteLine(" 5. - Delete manager by ID");
        Console.WriteLine(" Q. - Quit");

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write("\nYour choice: ");
        Console.ResetColor();

        string selectedOption = Console.ReadLine() ?? "";

        if (string.IsNullOrWhiteSpace(selectedOption) || selectedOption.Trim().Length > 1)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nIncorrect option selected! Please try again.");
            Console.ResetColor();
            Thread.Sleep(1500);
            continue;
        }

        option = Convert.ToChar(selectedOption.Trim().ToLower());

        switch (option)
        {
            case '1':
                CreateNewManager();
                break;
            case '2':
                GetAllManagers();
                break;
            case '3':
                GetManagerByManagerId();
                break;
            case '4':
                UpdateManagerByManagerId();
                break;
            case '5':
                DeleteManagerByManagerId();
                break;
            case 'q':
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nThank you for using the Manager Control Panel!");
                Console.ResetColor();
                return;
            default:
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nIncorrect option selected! Please try again.");
                Console.ResetColor();
                Thread.Sleep(1500);
                break;
        }
    }
}
void GetAllManagers()
{
    var employeesDal = new EmployeesDalEf(connStr, config.CreateMapper());
    var managers = employeesDal.GetAll();

    if (managers.Any())
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("\n═══════════════════════════════════════════");
        Console.WriteLine("               MANAGER LIST               ");
        Console.WriteLine("═══════════════════════════════════════════");
        Console.ResetColor();

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"{"ID",-5} {"First Name",-15} {"Last Name",-15} {"Position",-15} {"Email",-25} {"Phone Number",-15}");
        Console.ResetColor();

        foreach (var manager in managers)
        {
            if (manager.id % 2 == 0)
                Console.ForegroundColor = ConsoleColor.Gray;
            else
                Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine($"{manager.id,-5} {manager.first_Name,-15} {manager.last_Name,-15} {manager.position,-15} {manager.email,-25} {manager.phone_Number,-15}");
            Console.ResetColor();
        }
    }
    else
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("\nNo managers found.");
        Console.ResetColor();
    }
    Console.WriteLine("\nPress any key to return to the Manager Panel...");
    Console.ReadKey();
}
void GetManagerByManagerId()
{
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine("\nPlease enter the manager ID:");
    Console.ResetColor();

    if (int.TryParse(Console.ReadLine(), out int managerId))
    {
        var employeesDal = new EmployeesDalEf(connStr, config.CreateMapper());
        var manager = employeesDal.GetById(managerId);

        if (manager != null)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nManager found:");
            Console.WriteLine("═══════════════════════════════════════════");
            Console.ResetColor();

            Console.WriteLine($"ID: {manager.id}");
            Console.WriteLine($"First Name: {manager.first_Name}");
            Console.WriteLine($"Last Name: {manager.last_Name}");
            Console.WriteLine($"Position: {manager.position}");
            Console.WriteLine($"Email: {manager.email}");
            Console.WriteLine($"Phone Number: {manager.phone_Number}");
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nManager not found.");
            Console.ResetColor();
        }
    }
    else
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("\nInvalid ID format.");
        Console.ResetColor();
    }

    Console.WriteLine("\nPress any key to return to the Manager Panel...");
    Console.ReadKey();
}
void UpdateManagerByManagerId()
{
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine("\nPlease enter the manager ID to update:");
    Console.ResetColor();

    if (int.TryParse(Console.ReadLine(), out int managerId))
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("\nPlease enter new information (leave blank for no change):");
        Console.ResetColor();

        Console.Write("First Name: ");
        string firstName = Console.ReadLine();

        Console.Write("Last Name: ");
        string lastName = Console.ReadLine();

        Console.Write("Phone Number: ");
        string pNumber = Console.ReadLine();

        Console.Write("Position: ");
        string position = Console.ReadLine();

        Console.Write("Email: ");
        string email = Console.ReadLine();

        var employeesDal = new EmployeesDalEf(connStr, config.CreateMapper());
        var manager = employeesDal.GetById(managerId);

        if (manager != null)
        {
            if (!string.IsNullOrEmpty(firstName)) manager.first_Name = firstName;
            if (!string.IsNullOrEmpty(lastName)) manager.last_Name = lastName;
            if (!string.IsNullOrEmpty(pNumber)) manager.phone_Number = pNumber;
            if (!string.IsNullOrEmpty(position)) manager.position = position;
            if (!string.IsNullOrEmpty(email)) manager.email = email;

            employeesDal.Update(managerId, manager);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nManager updated successfully!");
            Console.ResetColor();
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nManager not found.");
            Console.ResetColor();
        }
    }
    else
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("\nInvalid ID format.");
        Console.ResetColor();
    }

    Console.WriteLine("\nPress any key to return to the Manager Panel...");
    Console.ReadKey();
}
void DeleteManagerByManagerId()
{
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine("\nPlease enter the manager ID to delete:");
    Console.ResetColor();

    if (int.TryParse(Console.ReadLine(), out int managerId))
    {
        var employeesDal = new EmployeesDalEf(connStr, config.CreateMapper());
        var deletedManager = employeesDal.Delete(managerId);

        if (deletedManager != null)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nManager deleted successfully!");
            Console.ResetColor();
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nManager not found or deletion failed.");
            Console.ResetColor();
        }
    }
    else
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("\nInvalid ID format.");
        Console.ResetColor();
    }

    Console.WriteLine("\nPress any key to return to the Manager Panel...");
    Console.ReadKey();
}
void CreateNewManager()
{
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine("\nPlease enter the following details for the new manager:");
    Console.ResetColor();

    Console.Write("First Name: ");
    string firstName = Console.ReadLine();

    Console.Write("Last Name: ");
    string lastName = Console.ReadLine();

    Console.Write("Phone Number: ");
    string pNumber = Console.ReadLine();

    Console.Write("Position: ");
    string position = Console.ReadLine();

    Console.Write("Email: ");
    string email = Console.ReadLine();

    var manager = new Employees
    {
        first_Name = firstName,
        last_Name = lastName,
        phone_Number = pNumber,
        position = position,
        email = email
    };

    var employeesDal = new EmployeesDalEf(connStr, config.CreateMapper());
    Employees employees = employeesDal.Create(manager);

    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("\nNew manager created successfully!");
    Console.WriteLine($"ID: {employees.id}");
    Console.WriteLine($"First Name: {employees.first_Name}");
    Console.WriteLine($"Last Name: {employees.last_Name}");
    Console.WriteLine($"Position: {employees.position}");
    Console.WriteLine($"Email: {employees.email}");
    Console.WriteLine($"Phone Number: {employees.phone_Number}");
    Console.ResetColor();

    Console.WriteLine("\nPress any key to return to the Manager Panel...");
    Console.ReadKey();
}
