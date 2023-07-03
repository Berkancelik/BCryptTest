using System;
using BCrypt.Net;

namespace BCryptConsole
{
    class Program
    {
        static string bcryptHash = ""; // bcryptHash değişkenini geniş bir kapsama alanına taşıdık

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("1. Şifre Belirle");
                Console.WriteLine("2. Giriş Yap");
                Console.WriteLine("3. Çıkış");
                Console.Write("Seçiminizi yapın: ");
                string secim = Console.ReadLine();

                if (secim == "1")
                {
                    Console.WriteLine("Parola belirleyin:");
                    string girilenParola = Console.ReadLine();

                    // Parolayı bcrypt ile şifrele
                    bcryptHash = BCrypt.Net.BCrypt.HashPassword(girilenParola);
                    Console.WriteLine("Parola başarıyla şifrelendi. Şifrelenmiş yazı: " + bcryptHash);
                }
                else if (secim == "2")
                {
                    if (string.IsNullOrEmpty(bcryptHash))
                    {
                        Console.WriteLine("Önce bir şifre belirlemelisiniz.");
                        continue;
                    }

                    Console.WriteLine("Giriş yapmak için parolayı girin:");
                    string girisParolasi = Console.ReadLine();

                    // Şifrelenmiş giriş parolasını kaydettiğimiz bcrypt hash değeriyle karşılaştır
                    if (BCrypt.Net.BCrypt.Verify(girisParolasi, bcryptHash))
                    {
                        Console.WriteLine("Giriş başarılı. Hoş geldiniz!");
                    }
                    else
                    {
                        Console.WriteLine("Hatalı parola. Giriş başarısız.");
                    }
                }
                else if (secim == "3")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Geçersiz seçim. Lütfen tekrar deneyin.");
                }
            }
        }
    }
}
