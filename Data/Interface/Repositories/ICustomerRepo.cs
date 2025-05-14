using Inlämning1Tomaso.Data.Models;

namespace Inlämning1Tomaso.Data.Interface.Repositories
{
    public interface ICustomerRepo
    {
        void AddCustomer(Customer customer);

        void DeleteCustomer(int customerID);

        void UpdateCustomer(Customer customer);

        List <Customer> GetAllCustomer(int customerID);
    }
}
