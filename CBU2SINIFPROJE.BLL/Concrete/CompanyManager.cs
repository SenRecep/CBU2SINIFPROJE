
using CBU2SINIFPROJE.BLL.Interfaces;
using CBU2SINIFPROJE.DAL.Interfaces;
using CBU2SINIFPROJE.Entities.Concrete;

namespace CBU2SINIFPROJE.BLL.Concrete
{
    public class CompanyManager : ICompanyService
    {
        private readonly ICompanyDal companyDal;

        public CompanyManager(ICompanyDal companyDal)
        {
            this.companyDal = companyDal;
        }
        public void Delete(Company company)
        {
            companyDal.Delete(company);
        }
    }
}
