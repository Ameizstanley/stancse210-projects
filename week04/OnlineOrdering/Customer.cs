using System;

public class Customer
{
    private string _name;
    private string _email;
    private string _phoneNumber;
    private Address _address;

    public Customer(string name, string email, string phoneNumber, Address address)
    {
        _name = name;
        _email = email;
        _phoneNumber = phoneNumber;
        _address = address;
    }

    public string GetName()
    {
        return _name;
    }

    public void SetName(string name)
    {
        _name = name;
    }

    public string GetEmail()
    {
        return _email;
    }

    public void SetEmail(string email)
    {
        _email = email;
    }

    public string GetPhoneNumber()
    {
        return _phoneNumber;
    }

    public void SetPhoneNumber(string phoneNumber)
    {
        _phoneNumber = phoneNumber;
    }

    public Address GetAddress()
    {
        return _address;
    }

    public void SetAddress(Address address)
    {
        _address = address;
    }

    public bool IsInUSA()
    {
        return _address.IsInUSA();
    }

}