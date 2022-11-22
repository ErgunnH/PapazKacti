using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PapazKacti
{
    internal class Kartlar
    {   
      

        static public void CardsDelivery()
        {
            List<int> kartlar = new List<int>();  //deste listesi
        

            for (int f = 0; f < 49; f++)     //deste numaralardan oluşturuldu 1-12 kupa 13-24 karo 25-36 maça 36-48 sinek  49 sinek papaz
            {
                kartlar.Add(f + 1);

            }
        
            Random random = new Random();     //kartlar rastgele dağıtlıyor oyunculara

            int gamercount = Oyuncu.Oyuncular.Count;

            for (int c = 0; c < gamercount; c++)
            {
               
                if (gamercount - 1 == c)
                {
                    Oyuncu.Oyuncular[c].kartlar.AddRange(kartlar);

                    break;
                }

                var keyList = kartlar.OrderBy(item => random.Next()).Take(49 / Oyuncu.Oyuncular.Count).ToList();

                Oyuncu.Oyuncular[c].kartlar.AddRange(keyList);

                foreach (int key in keyList)
                {
                    kartlar.Remove(key);
                }
               

            }


        }

    }
}
