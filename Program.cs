using System.Collections;
using System.ComponentModel.Design;

using System; 



namespace Manav
{
    internal class Program
    {
       
        static void Main(string[] args)
        {
            ArrayList HalMeyve = new ArrayList() { "elma", "armut", "kayısı", "karpuz", "kavun", "çilek", "kiraz", "mango", "kivi", "muz" };
            ArrayList HalSebze = new ArrayList() { "biber", "patlıcan", "domates", "salatalık", "ıspanak", "sogan", "patates", "kabak", "enginar", "kıvırcık" };

            
            Console.WriteLine("*****MANAV HAL'DEN ALIŞVERİŞ YAPIYOR ******");
            ArrayList manavinMeyveleri = HalMeyveBölümü(HalMeyve);
            ArrayList manavinSebzeleri = HalSebzeBölümü(HalSebze);

            Console.WriteLine("\nHal'den alışveriş tamamlandı. Devam etmek için bir tuşa basın...");
            Console.ReadKey();
            Console.Clear(); 

            // 2. Müşterinin listelerini al ve SAKLA
            Console.WriteLine("--- MÜŞTERİ MANAVDAN ALIŞVERİŞ YAPIYOR ---");
            ArrayList musterininMeyveleri = ManavMeyveBölümü(manavinMeyveleri);
            ArrayList musterininSebzeleri = ManavSebzeBölümü(manavinSebzeleri);

            Console.WriteLine("\nManavdan alışveriş tamamlandı. Devam etmek için bir tuşa basın...");
            Console.ReadKey();
            Console.Clear(); 

         
            Müşteri(musterininMeyveleri, musterininSebzeleri);
        }

        public static ArrayList HalMeyveBölümü(ArrayList HalMeyve)
        {
            ArrayList ManavMeyveListesi = new ArrayList();
            Console.WriteLine("***** HALİN MEYVE BÖLÜMÜNE HOŞ GELDİNİZ *****");
            while (true)
            {
                for (int i = 0; i < HalMeyve.Count; i++)
                {
                    Console.WriteLine(i + " - " + HalMeyve[i]);
                }
                Console.WriteLine("Alınacak meyvenin kodunu giriniz ");
                int HalMeyveKod = Convert.ToInt32((Console.ReadLine()));

                if (HalMeyveKod >= 0 && HalMeyveKod < HalMeyve.Count)
                {
                    Console.WriteLine("Alınacak meyvenin miktarını giriniz");
                    int HalMeyveMiktar = Convert.ToInt32((Console.ReadLine()));

                    Console.WriteLine("İşlem başarılı.");
                    ManavMeyveListesi.Add(HalMeyve[HalMeyveKod]);
                    ManavMeyveListesi.Add(HalMeyveMiktar);
                    Console.WriteLine("Alıcagınız başka meyve var mı ? EVET(E) \n HAYIR(H)");
                    String cevap = Console.ReadLine().ToUpper();
                    if (cevap == "E")
                    {
                        Console.WriteLine("AlIŞ-VERİŞ DEVAM EDİYOR");
                    }
                    else if (cevap == "H")
                    {
                        Console.WriteLine("SEBZE BÖLÜMÜNE GEÇİLİYOR");
                        return ManavMeyveListesi;
                    }
                }
                else
                {
                    Console.WriteLine("Hatalı kod girdiniz.");
                }
            }
        }

        public static ArrayList HalSebzeBölümü(ArrayList HalSebze)
        {
            ArrayList ManavSebzeListesi = new ArrayList();
            Console.WriteLine("***** HALİN SEBZE BÖLÜMÜNE HOŞ GELDİNİZ *****");
            while (true)
            {
                for (int i = 0; i < HalSebze.Count; i++)
                {
                    Console.WriteLine(i + " - " + HalSebze[i]);
                }
                Console.WriteLine("Alınacak sebzenin kodunu giriniz ");
                int HalSebzeKod = Convert.ToInt32((Console.ReadLine()));
                Console.WriteLine("Alınacak sebzenin miktarını giriniz");
                int HalSebzeMiktar = Convert.ToInt32((Console.ReadLine()));

                if (HalSebzeKod >= 0 && HalSebzeKod < HalSebze.Count)
                {
                    Console.WriteLine("İşlem başarılı.");
                    ManavSebzeListesi.Add(HalSebze[HalSebzeKod]);
                    ManavSebzeListesi.Add(HalSebzeMiktar);
                    Console.WriteLine("Alıcagınız başka sebze var mı ? EVET(E) \n HAYIR(H)");
                    String cevap = Console.ReadLine().ToUpper();
                    if (cevap == "E")
                    {
                        Console.WriteLine("AlIŞ-VERİŞ DEVAM EDİYOR");
                    }
                    else if (cevap == "H")
                    {
                        Console.WriteLine("HALDEN ÇIKIŞ YAPIYORSUNUZ");
                        return ManavSebzeListesi;
                    }
                }
                else
                {
                    Console.WriteLine("Hatalı kod girdiniz.");
                }
            }
        }

        public static ArrayList ManavMeyveBölümü(ArrayList ManavMeyveListesi)
        {
            ArrayList MüsteriMeyveListesi = new ArrayList();
            Console.WriteLine("MANAVIN MEYVE BÖLÜMÜNE HOŞ GELDİNİZ");

            while (true)
            {
               
                int kodcount = 1;
                Console.WriteLine("--- Manavdaki Meyveler ---");
                for (int i = 0; i < ManavMeyveListesi.Count; i += 2)
                {
                    Console.WriteLine("KOD : " + kodcount + " - " + ManavMeyveListesi[i] + " / STOK : " + ManavMeyveListesi[i + 1] + " kg");
                    kodcount++;
                }
                Console.WriteLine("--------------------------");

                Console.WriteLine("Alınacak meyvenin kodunu giriniz ");
                int ManavMeyveKod = Convert.ToInt32((Console.ReadLine()));
                Console.WriteLine("Alınacak meyvenin miktarını giriniz");
                int MüsteriMeyveMiktar = Convert.ToInt32((Console.ReadLine()));

                
                int miktarIndex = ManavMeyveKod * 2 - 1;

               
                if (ManavMeyveKod > 0 && ManavMeyveKod < kodcount && (int)ManavMeyveListesi[miktarIndex] >= MüsteriMeyveMiktar)
                {
                    Console.WriteLine("İşlem başarılı.");
                   
                    MüsteriMeyveListesi.Add(ManavMeyveListesi[ManavMeyveKod * 2 - 2]);
                    MüsteriMeyveListesi.Add(MüsteriMeyveMiktar);

                   
                    ManavMeyveListesi[miktarIndex] = (int)ManavMeyveListesi[miktarIndex] - MüsteriMeyveMiktar;

                    Console.WriteLine("Alıcagınız başka meyve var mı ? EVET(E) \n HAYIR(H)");
                    String cevap = Console.ReadLine().ToUpper();
                    if (cevap == "E")
                    {
                        Console.WriteLine("AlIŞ-VERİŞ DEVAM EDİYOR");
                    }
                    else if (cevap == "H")
                    {
                        Console.WriteLine("SEBZE BÖLÜMÜNE GEÇİLİYOR");
                        return MüsteriMeyveListesi;
                    }
                }
                else
                {
                    Console.WriteLine("Hatalı kod girdiniz VEYA bu üründe yeterli stok bulunmuyor.");
                }
            }
        }

        public static ArrayList ManavSebzeBölümü(ArrayList ManavSebzeListesi)
        {
            ArrayList MüsteriSebzeListesi = new ArrayList();
            Console.WriteLine("MANAVIN SEBZE BÖLÜMÜNE HOŞ GELDİNİZ");

            while (true)
            {
        
                int kodcount = 1;
                Console.WriteLine("--- Manavdaki Sebzeler ---");
                for (int i = 0; i < ManavSebzeListesi.Count; i += 2)
                {
                    Console.WriteLine("KOD : " + kodcount + " - " + ManavSebzeListesi[i] + " / STOK : " + ManavSebzeListesi[i + 1] + " kg");
                    kodcount++;
                }
                Console.WriteLine("--------------------------");

                Console.WriteLine("Alınacak sebzenin kodunu giriniz (1, 2, 3...)");
                int ManavSebzeKod = Convert.ToInt32((Console.ReadLine()));
                Console.WriteLine("Alınacak sebzenin miktarını giriniz");
                int MüsteriSebzeMiktar = Convert.ToInt32((Console.ReadLine()));

                int miktarIndex = ManavSebzeKod * 2 - 1;

                if (ManavSebzeKod > 0 && ManavSebzeKod < kodcount && (int)ManavSebzeListesi[miktarIndex] >= MüsteriSebzeMiktar)
                {
                    Console.WriteLine("İşlem başarılı.");
                    MüsteriSebzeListesi.Add(ManavSebzeListesi[ManavSebzeKod * 2 - 2]);
                    MüsteriSebzeListesi.Add(MüsteriSebzeMiktar);

                    // Manavın stoğunu güncelle
                    ManavSebzeListesi[miktarIndex] = (int)ManavSebzeListesi[miktarIndex] - MüsteriSebzeMiktar;

                    Console.WriteLine("Alıcagınız başka sebze var mı ? EVET(E) \n HAYIR(H)");
                    String cevap = Console.ReadLine().ToUpper();
                    if (cevap == "E")
                    {
                        Console.WriteLine("AlIŞ-VERİŞ DEVAM EDİYOR");
                    }
                    else if (cevap == "H")
                    {
                        Console.WriteLine("MANAVDAN ÇIKIŞ YAPILIYOR");
                        return MüsteriSebzeListesi;
                    }
                }
                else
                {
                    Console.WriteLine("Hatalı kod girdiniz VEYA bu üründe yeterli stok bulunmuyor.");
                }
            }
        }

        public static void Müşteri(ArrayList MüsteriMeyve, ArrayList MüsteriSebze)
        {
            ArrayList alınanlar = new ArrayList();
            Console.WriteLine("***** ALINANLAR (MÜŞTERİ SEPETİ) ********");
            alınanlar.AddRange(MüsteriMeyve);
            alınanlar.AddRange(MüsteriSebze);

            if (alınanlar.Count == 0)
            {
                Console.WriteLine("Sepetiniz boş.");
                return;
            }

           
            for (int i = 0; i < alınanlar.Count; i += 2)
            {
                Console.WriteLine("Ürün: " + alınanlar[i] + "\t Miktar: " + alınanlar[i + 1] + " kg");
            }
        }
    }
}
