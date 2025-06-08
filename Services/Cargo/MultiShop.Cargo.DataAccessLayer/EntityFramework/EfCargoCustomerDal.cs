using MultiShop.Cargo.DataAccessLayer.Abstract;
using MultiShop.Cargo.DataAccessLayer.Concrete;
using MultiShop.Cargo.DataAccessLayer.Repositories;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.DataAccessLayer.EntityFramework
{
    public class EfCargoCustomerDal : GenericRepository<CargoCustomer>, ICargoCustomerDal
    {
        private readonly CargoContext _cargoContext;

        public EfCargoCustomerDal(CargoContext cargoContext) : base(cargoContext)
        {
            _cargoContext = cargoContext;
        }

        public CargoCustomer GetCargoCustumerById(string id)
        {
            var values = _cargoContext.CargoCustomers.Where(x => x.UserCustomerID == id).FirstOrDefault();

            return values;
        }
    }
}
