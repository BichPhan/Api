using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModel;
using System.Configuration;

namespace DataModel
{
    public class DataAccess
    {
        WebApiDbEntities db = new WebApiDbEntities();

        public List<Products> getProduct()
        {
            return db.Products.ToList();
        }

        public Tokens GenerateToken(int userId)
        {
            string token = Guid.NewGuid().ToString();
            DateTime issuedOn = DateTime.Now;
            DateTime expiredOn = DateTime.Now.AddSeconds(Convert.ToDouble("900"));
            var tokendomain = new Tokens
            {
                UserId = userId,
                AuthToken = token,
                IssuedOn = issuedOn,
                ExpiresOn = expiredOn
            };
            db.Tokens.Add(tokendomain);
            db.SaveChanges();
            return tokendomain;
        }
    }
}
