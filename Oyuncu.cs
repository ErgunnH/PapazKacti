using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PapazKacti
{
    internal class Oyuncu
    {
        public List<int> kartlar=new List<int>();                      //oyuncunun kart listesi

        static public List<Oyuncu> Oyuncular=new List<Oyuncu>();       //oyuncu listesi

        public readonly int id;                                        //oyuncu id'si         

        public static int papazcounter;                                //papaz el değiştirme sayacı

        public Oyuncu()
        {

            Oyuncu.Oyuncular.Add(this);                                //oyuncu nesnelerini otamatik listeye atıyor
            id = Oyuncu.Oyuncular.Count-1;                             //id ataması
            
        }
        

        static public void GamerCrete(int number)                       //parametre sayısına göre oyuncu nesnesi oluşturuyor
        {   
            for(int i = 0; i < number; i++)
            {
                Oyuncu oyuncu = new Oyuncu();

            }
      
        }

        public void CardReduction()                                           //eş kartları listesinden siliyor
        {
            for (int i = 0; i < this.kartlar.Count; i++)              
            {
                for (int j = i + 1; j < this.kartlar.Count; j++)
                {
                    if ((this.kartlar[i] - this.kartlar[j]) % 12 == 0)
                    {

                        this.kartlar.RemoveAt(i);
                        this.kartlar.RemoveAt(j - 1);

                    }
                }

            }

        }

        public bool Oyna()                                            //oyun oynanıyor  
        {

            if (this.kartlar.Count == 0)                              //kartı kalmayan oyuncu oyun oynayamaz

                return true;

            this.CardReduction();
            

            int beforegamerid=this.id-1;                             //bir önceki oyuncudan kart seçme işlemi
           

            if (beforegamerid < 0) beforegamerid = Oyuncu.Oyuncular.Count - 1;
               
            while(Oyuncu.Oyuncular[beforegamerid].kartlar.Count == 0)
            { 
                beforegamerid = beforegamerid - 1;

                if (beforegamerid < 0)
                    {
                        beforegamerid = Oyuncu.Oyuncular.Count - 1;
                            
                    }
            }
            
            Random rand = new Random();
           
            int takecard=rand.Next(0, Oyuncu.Oyuncular[beforegamerid].kartlar.Count);

            this.kartlar.Add(Oyuncu.Oyuncular[beforegamerid].kartlar[takecard]);

            if (Oyuncu.Oyuncular[beforegamerid].kartlar[takecard] == 49)          //papaz el değiştirme sayacını arttırıyor     
            {
                papazcounter++;
            }

            Console.WriteLine($"{beforegamerid} oyuncusundan {Oyuncu.Oyuncular[beforegamerid].kartlar[takecard]} numaralı kartı alındı");

            Console.WriteLine($"{beforegamerid} oyuncusundan {Oyuncu.Oyuncular[beforegamerid].kartlar[takecard]} numaralı kart silindi");

            Oyuncu.Oyuncular[beforegamerid].kartlar.RemoveAt(takecard);


            this.CardReduction();

            Console.WriteLine($"{this.id}. oyuncusunun {Oyuncu.Oyuncular[this.id].kartlar.Count} adet kartı kaldı");

            if (this.kartlar.Count == 0)

                return true;

            else 

                return false;

        }

      

        




    }
}
