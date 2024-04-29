using System;
using System.Collections.Generic;

namespace PenjualanBuku
{
    class Program
    {
        static void Main(string[] args)
        {
            // Data awal buku
            List<Buku> daftarBuku = new List<Buku>()
            {
                new Buku("123456", "Harry Potter", "J.K. Rowling", 100000, 10),
                new Buku("789012", "Lord of the Rings", "J.R.R. Tolkien", 150000, 5),
                new Buku("345678", "The Great Gatsby", "F. Scott Fitzgerald", 80000, 8),
                new Buku("269182", "The Hobbit", "J.R.R Tolkien", 50000, 6),
                new Buku("104732", "Percy Jackson", "Rick Riordan", 90000, 12),
                new Buku("392712", "Life of Pi", "Yann Martel", 120000, 21)
            };

            // Login
            Console.WriteLine("Selamat datang!");
            Console.Write("Username: ");
            string username = Console.ReadLine();
            Console.Write("Password: ");
            string password = Console.ReadLine();

            if (username == "admin" && password == "1234")
            {
                Console.WriteLine("Login berhasil!\n");

                bool runApp = true;
                while (runApp)
                {
                    // Menu
                    Console.WriteLine("Menu:");
                    Console.WriteLine("1. Cari Produk");
                    Console.WriteLine("2. Sortir Produk berdasarkan jumlah stok");
                    Console.WriteLine("3. Tambah Produk Baru");
                    Console.WriteLine("4. Hapus Produk");
                    Console.WriteLine("5. Keluar");
                    Console.Write("Pilihan Anda: ");
                    string pilihan = Console.ReadLine();

                    switch (pilihan)
                    {
                        case "1":
                            Console.Write("Masukkan kata kunci pencarian: ");
                            string kataKunci = Console.ReadLine();
                            Console.Write("Masukkan harga minimum: ");
                            double hargaMin = double.Parse(Console.ReadLine());
                            Console.Write("Masukkan harga maksimum: ");
                            double hargaMax = double.Parse(Console.ReadLine());
                            CariProduk(daftarBuku, kataKunci, hargaMin, hargaMax);
                            break;
                        case "2":
                            SortirBerdasarkanStok(daftarBuku);
                            break;
                        case "3":
                            TambahProduk(daftarBuku);
                            break;
                        case "4":
                            HapusProduk(daftarBuku);
                            break;
                        case "5":
                            runApp = false;
                            Console.WriteLine("Terima kasih telah menggunakan aplikasi!");
                            break;
                        default:
                            Console.WriteLine("Pilihan tidak valid. Silakan coba lagi.");
                            break;
                    }
                }
            }
            else
            {
                Console.WriteLine("Login gagal. Username atau password salah.");
            }
        }

        static void CariProduk(List<Buku> daftarBuku, string kataKunci, double hargaMin, double hargaMax)
        {
            Console.WriteLine("Hasil Pencarian:");
            foreach (var buku in daftarBuku)
            {
                if (buku.Nama.ToLower().Contains(kataKunci.ToLower()) && buku.Harga >= hargaMin && buku.Harga <= hargaMax)
                {
                    Console.WriteLine(buku);
                }
            }
            Console.WriteLine();
        }

        static void SortirBerdasarkanStok(List<Buku> daftarBuku)
        {
            daftarBuku.Sort((x, y) => y.Stok.CompareTo(x.Stok));
            Console.WriteLine("Produk tersortir berdasarkan jumlah stok:");
            foreach (var buku in daftarBuku)
            {
                Console.WriteLine(buku);
            }
            Console.WriteLine();
        }

        static void TambahProduk(List<Buku> daftarBuku)
        {
            Console.Write("Masukkan ISBN: ");
            string isbn = Console.ReadLine();
            Console.Write("Masukkan Nama Buku: ");
            string nama = Console.ReadLine();
            Console.Write("Masukkan Penulis: ");
            string penulis = Console.ReadLine();
            Console.Write("Masukkan Harga: ");
            double harga = double.Parse(Console.ReadLine());
            Console.Write("Masukkan Stok: ");
            int stok = int.Parse(Console.ReadLine());

            Buku bukuBaru = new Buku(isbn, nama, penulis, harga, stok);
            daftarBuku.Add(bukuBaru);

            Console.WriteLine("Produk berhasil ditambahkan!\n");
        }

        static void HapusProduk(List<Buku> daftarBuku)
        {
            Console.Write("Masukkan ISBN produk yang ingin dihapus: ");
            string isbn = Console.ReadLine();

            Buku buku = daftarBuku.Find(x => x.ISBN == isbn);
            if (buku != null)
            {
                daftarBuku.Remove(buku);
                Console.WriteLine("Produk berhasil dihapus!\n");
            }
            else
            {
                Console.WriteLine("Produk tidak ditemukan.\n");
            }
        }
    }
    class Buku
    {
        public string ISBN { get; }
        public string Nama { get; }
        public string Penulis { get; }
        public double Harga { get; }
        public int Stok { get; }

        public Buku(string isbn, string nama, string penulis, double harga, int stok)
        {
            ISBN = isbn;
            Nama = nama;
            Penulis = penulis;
            Harga = harga;
            Stok = stok;
        }

        public override string ToString()
        {
            return $"{ISBN,-10} {Nama,-20} {Penulis,-20} {Harga,-10:C} {Stok,-5}";
        }
    }
}
