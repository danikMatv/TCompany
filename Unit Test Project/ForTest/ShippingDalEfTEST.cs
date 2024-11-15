//using AutoMapper;
//using DAL.Repository;
//using DALEF.Ct;
//using DALEF.Models;
//using DTO.Entity;

//namespace Unit_Test_Project.ForTest
//{
//    public class ShippingDalEfTEST : IShipping
//    {
//        private readonly ImdbContext _context;
//        private readonly IMapper _mapper;
//        private readonly string _connectionString;

//        public ShippingDalEfTEST(ImdbContext context, IMapper mapper)
//        {
//            _context = context;
//            _mapper = mapper;
//        }

//        public Shipping Create(Shipping shipping)
//        {
//            using (var context = new ImdbContext(_connectionString))
//            {
//                var tblShipping = _mapper.Map<TblShipping>(shipping);
//                context.Shippings.Add(tblShipping);
//                context.SaveChanges();

//                shipping.id = tblShipping.id;
//                return shipping;
//            }
//        }

//        public Shipping Delete(int id)
//        {
//            using (var context = new ImdbContext(_connectionString))
//            {
//                var tblShipping = context.Shippings.FirstOrDefault(e => e.id == id);
//                if (tblShipping != null)
//                {
//                    context.Shippings.Remove(tblShipping);
//                    context.SaveChanges();
//                }
//                return _mapper.Map<Shipping>(tblShipping);
//            }
//        }

//        public List<Shipping> GetAll()
//        {
//            using (var context = new ImdbContext(_connectionString))
//            {
//                var tblShippings = context.Shippings.ToList();
//                return _mapper.Map<List<Shipping>>(tblShippings);
//            }
//        }

//        public List<Shipping> GetAllByStatus(string status)
//        {
//            using (var context = new ImdbContext(_connectionString))
//            {
//                var tblShippings = context.Shippings
//                    .Where(e => e.status == status)
//                    .ToList();
//                return _mapper.Map<List<Shipping>>(tblShippings);
//            }
//        }


//        public Shipping GetById(int id)
//        {
//            using (var context = new ImdbContext(_connectionString))
//            {
//                var tblShipping = context.Shippings.FirstOrDefault(e => e.id == id);
//                return _mapper.Map<Shipping>(tblShipping);
//            }
//        }

//        public Shipping Update(int id, Shipping shipping)
//        {
//            using (var context = new ImdbContext(_connectionString))
//            {
//                var tblStipping = context.Shippings.FirstOrDefault(e => e.id == id);
//                if (tblStipping != null)
//                {
//                    _mapper.Map(shipping, tblStipping);
//                    context.SaveChanges();
//                }
//                return shipping;
//            }
//        }
//    }
//}
