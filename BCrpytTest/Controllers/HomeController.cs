 using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace BCryptNetTest.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Encrypt(string text)
        {
            // Şifreleme işlemi
            string encryptedText = BCrypt.Net.BCrypt.HashPassword(text);

            // Şifrelenmiş metni view'e iletmek için ViewBag kullanabilirsiniz
            ViewBag.EncryptedText = encryptedText;

            return View("Index");
        }

        [HttpPost]
        public ActionResult Decrypt(string encryptedText)
        {
            // Şifrelenmiş metni doğrulama işlemi
            bool isMatch = BCrypt.Net.BCrypt.Verify(encryptedText, encryptedText);

            string decryptedText;
            if (isMatch)
            {
                decryptedText = "Şifre doğrulandı.";
            }
            else
            {
                decryptedText = "Şifre doğrulanmadı.";
            }

            // Çözülen metni view'e iletmek için ViewBag kullanabilirsiniz
            ViewBag.DecryptedText = decryptedText;

            return View("Index");
        }
    }
}
