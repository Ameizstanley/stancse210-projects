using System;
using System.Collections.Generic;
using System.Text;

public class Order
{
    private List<Product> _products;
    private Customer _customer;
    private const double _shippingCost = 5.99;
    private const double INTERNATIONAL_SHIPPING_COST = 15.99;


    public Order(Customer customer)
    {
        _customer = customer;
        _products = new List<Product>();
    }

    public Customer GetCustomer()
    {
        return _customer;
    }

    public void SetCustomer(Customer customer)
    {
        _customer = customer;
    }

    public List<Product> GetProducts()
    {
        return _products;
    }

    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    public double CalculateTotalPrice()
    {
        double productTotal = 0;
        foreach (Product product in _products)
        {
            productTotal += product.CalculateTotalCost();
        }
        double shippingCost = _customer.IsInUSA() ? _shippingCost : INTERNATIONAL_SHIPPING_COST;

        return productTotal + shippingCost;

    }

    public string GetPackLabel()
    {
        StringBuilder packingLabel = new StringBuilder();

        foreach (Product product in _products)
        {
            packingLabel.AppendLine($"{product.GetName()} - {product.GetProductId()} - {product.GetQuantity()}");
        }

        return packingLabel.ToString().TrimEnd();
    }

    public string GetShippingLabel()
    {
        return $"{_customer.GetName()} - {_customer.GetAddress()}";
    }
}
        