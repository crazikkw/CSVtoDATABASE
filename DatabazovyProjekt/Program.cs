namespace DatabazovyProjekt
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DatabaseManager dbManager = new DatabaseManager();

            // Vytvoření a vložení nového produktu
           /* var newProduct = new Product
            {
                Nazev = "Nový Produkt",
                Cena = 199.99f,
                Skladem = true,
                VyrobniDatum = DateTime.Now
            };
            dbManager.InsertProduct(newProduct);

            // Předpokládejme, že ID nově vytvořeného produktu je 1
            newProduct.ProductID = 1;
            newProduct.Cena = 299.99f; // Aktualizace ceny produktu
            dbManager.UpdateProduct(newProduct); // Aktualizace produktu v databázi

            
            // Mazání produktu
            // Předpokládejme, že chceš smazat produkt s ID 1
            dbManager.DeleteProduct(1);
            Console.WriteLine("Produkt byl smazán.");*/


            // Import produktů
            dbManager.ImportProductsFromCsv("produkty.csv");

            //Výpis produktů
            var products = dbManager.GetAllProducts();
            foreach (var product in products)
            {
                Console.WriteLine($" Název: {product.Nazev}, Cena: {product.Cena}, Skladem: {product.Skladem}, Výrobní datum: {product.VyrobniDatum.ToShortDateString()}");
            }

            // Import zákazníků
            dbManager.ImportCustomersFromCsv("zakaznici.csv");

            


        }
    }
    }
