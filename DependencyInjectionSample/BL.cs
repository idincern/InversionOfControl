using System.Collections.Generic;

public class BL
{
    private readonly IDAL _dataAccess;

    public BL(IDAL dataAccess)
    {
        _dataAccess = dataAccess;
    }

    public List<Product> GetProducts()
    {
        // Delegate the call to the DAL implementation
        return _dataAccess.GetProducts();
    }
}
