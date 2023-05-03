using System.Collections.Generic;

namespace WpfMd.Repositories
{
    public interface ICertificateRepository
    {
        IEnumerable<string> GetCertNames();
    }
}