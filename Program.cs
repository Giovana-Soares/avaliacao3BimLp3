using Avaliacao3BimLp3.Database;
using Avaliacao3BimLp3.Models;
using Avaliacao3BimLp3.Repositories;
using Microsoft.Data.Sqlite;

var databaseConfig = new DatabaseConfig();
var DatabaseSetup= new DatabaseSetup(databaseConfig);

var productRepository = new ProductRepository(databaseConfig);

var modelName = args[0];
var modelAction = args[1];

if(modelName == "Product")
{
    if(modelAction == "List")
    {
        Console.WriteLine("Product List");
        foreach (var product in productRepository.GetAll())
        {
            Console.WriteLine("{0}, {1}, {2}, {3}", product.Id, product.Name, product.Price, product.Active);
        }
    }

    if(modelAction == "New")
    {
        int id = Convert.ToInt32(args[2]);
        string name = args[3];
        double price = Convert.ToDouble(args[4]);
        bool active = Convert.ToBoolean(args[5]);

       if (productRepository.existsById(id))
        {
            Console.WriteLine($"Produto com id {id} ja existe");
        }
        else
        {
            Console.WriteLine($"Produto {name} cadastrado com sucesso"); 
            var product = new Product(id, name, price, active);
            productRepository.Save(product);  
        }
    }

    if(modelAction == "Delete")
    {
       int id = Convert.ToInt32(args[2]);
       if (productRepository.existsById(id) == true)
       {
           productRepository.Delete(id);
       }
       else
       {
            Console.WriteLine($"Computer com id {id} não existe");
       }
    }

    if(modelAction == "Enable")
    {
        
        int id = Convert.ToInt32(args[2]);
        if (productRepository.existsById(id) == true)
        {
           productRepository.Enable(id);
        }
        else
        {
            Console.WriteLine($"Produto com id {id} não existe");
        }

    }

}
