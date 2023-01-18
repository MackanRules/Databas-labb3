using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace Labb3
{
    internal class InventoryController
    {
        IProductDAO productDAO;
        IStringIO io;

        public InventoryController(IStringIO io, IProductDAO productDAO)
        {
            this.io = io;
            this.productDAO = productDAO;
        }

        void CreateProduct()
        {
            bool correctInput = false;
            string productDescription = "";
            string productName = "";
            int productStock = 0;

            while (!correctInput){

                io.PrintString("Enter name of product: ");
                productName = io.GetString();

                try
                {
                    io.PrintString("Enter number in stock: ");
                    productStock = int.Parse(io.GetString());
                }
                catch (Exception ex) {
                    io.PrintString("Error, only integers allowed for number in stock");
                }

                io.PrintString("Enter description of product: ");
                productDescription = io.GetString();

            
                io.PrintString("Are the following selections correct? \n" +
                    "Product name: " + productName +
                    "\nNumber in stock: " + productStock +
                    "\nProduct description: " + productDescription +
                    "\nIf not you will need to reenter the information." +
                    "\ny/n");
                if (io.GetString().Equals("y")){
                    correctInput = true;
                }
            }

            productDAO.CreateProduct(new ProductODM { Name = productName, Amount = productStock, Description = productDescription });
        }

        void UpdateProduct()
        {
            bool correctInput = false;
            string productName = "";
            int productStock = 0;

            while (!correctInput){

                io.PrintString("Enter name of the product you want to update the stock for: ");
                productName = io.GetString();

                productStock = 0;
                try
                {
                    io.PrintString("Enter new number in stock: ");
                    productStock = int.Parse(io.GetString());
                }
                catch (Exception ex)
                {
                    io.PrintString("Error, only integers allowed for number in stock");
                }

            
                io.PrintString("Are the following selections correct? \n" +
                    "Product name: " + productName +
                    "\nNumber in stock: " + productStock +
                    "\nIf not you will need to reenter the information." +
                    "\ny/n");
                if (io.GetString().Equals("y"))
                {
                    correctInput = true;
                }
            }

            productDAO.UpdateProduct(productName, productStock);

        }

        void DeleteProduct()
        {
            bool correctInput = false;
            string productName = "";

            while (!correctInput)
            {
                io.PrintString("Enter the name of the product you want to delete: ");
                productName = io.GetString();

                io.PrintString("Is the following name correct? \n" + 
                    "Name: " + productName +
                    "\nIf not you will need to reenter the information." +
                    "\ny/n");

                if (io.GetString().Equals("y"))
                {
                    correctInput = true;
                }
            }

            productDAO.DeleteProduct(productName);
            
        }
        
        public void Start()
        {
            while (true)
            {
                io.PrintString("\n----------- Product database interface ----------- \n");
                io.PrintString("Options: \n" +
                    "1. List all products \n" +
                    "2. Create product \n" +
                    "3. Update product \n" +
                    "4. Delete product \n" +
                    "5. Exit \n");
                io.PrintString("Enter your choice 1-5: ");

                int menuChoice = 0;
                Int32.TryParse(io.GetString(), out menuChoice);
                io.PrintString("\n");


                switch (menuChoice)
                {
                    case 1:
                        List<ProductODM> productList = productDAO.GetAllProducts();
                        foreach (var document in productList)
                        {
                            io.PrintString("Product name: " + document.Name +
                                "\nNumber in stock: " + document.Amount +
                                "\nProduct description: " + document.Description + "\n");
                        }
                        break;
                    case 2:
                        CreateProduct();
                        io.PrintString("New product added!");
                        break;
                    case 3:
                        UpdateProduct();
                        io.PrintString("Product updated!");
                        break;
                    case 4:
                        DeleteProduct();
                        io.PrintString("Product deleted!");
                        break;
                    case 5:
                        io.Exit();
                        break;
                    default:
                        Console.WriteLine("Giltiga val är 1-5");
                        break;
                }
            }
            
        
        }

    }
}
