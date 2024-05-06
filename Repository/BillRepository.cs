using BERecruitmentss.Common.BillDTO;
using BERecruitmentss.Data;
using BERecruitmentss.Models;

namespace BERecruitmentss.Repository
{
    public interface IBillRepository : IBaseRepository<Bill>
    {
        Task<Bill> InsertFullDetailAsync(RequestBillFullDetail request);
        Task<Bill> Test();
        Task<Bill> Test(int id);
    }
    public class BillRepository : BaseRepository<Bill>, IBillRepository
    {
        public BillRepository(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor) : base(context, httpContextAccessor)
        {
        }

        public async Task<Bill> InsertFullDetailAsync(RequestBillFullDetail request)
        {
            if (request != null)
            {
                if (request.Id == 0)
                {
                    var bill = new Bill()
                    {
                        Code = request.Code,
                        Date = request.Date,
                        PhoneNumber = request.PhoneNumber
                    };

                    _context.Bills.Add(bill);
                    await _context.SaveChangesAsync();

                    var billDetails = new List<BillDetail>();

                    if (bill.Id > 0)
                    {
                        foreach (var item in request.BillDetails)
                        {
                            item.Id = 0;
                            item.BillId = bill.Id;
                            var detailItem = new BillDetail()
                            {
                                BillId = item.BillId,
                                ProductId = item.ProductId,
                                Quantity = item.Quantity,
                                Price = item.Price
                            };
                            billDetails.Add(detailItem);
                        }
                        _context.BillDetails.AddRange(billDetails);
                        await _context.SaveChangesAsync();

                        return bill;
                    }
                }
            }
            return null;
        }

        public async Task<Bill> Test()
        {
            return null;
        }

        public async Task<Bill> Test(int id)
        {
            return null;
        }

    }
}

