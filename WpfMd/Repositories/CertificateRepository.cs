using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace WpfMd.Repositories
{
    public class CertificateRepository : ICertificateRepository
    {
        public IEnumerable<string> GetCertNames()
        {
            List<string> result = new List<string>();
            X509Store store = new X509Store(StoreLocation.CurrentUser);

            try
            {
                store.Open(OpenFlags.ReadOnly);

                // Place all certificates in an X509Certificate2Collection object.
                X509Certificate2Collection certCollection = store.Certificates;
                foreach (X509Certificate2 x509 in certCollection)
                {
                    //Console.WriteLine(x509.IssuerName.Name);
                    result.Add(x509.IssuerName.Name);
                }
            }
            finally
            {
                store.Close();
            }


            return result;
        }
    }
}
