// See https://aka.ms/new-console-template for more information




using PapazKacti;
using System;

Oyuncu.GamerCrete(4); //Oyuncular oluşturluyor 

Kartlar.CardsDelivery(); //Kartlar oyunculara rastgele dağıtlıyor

int round=0;             //round sayacı

int[] kazananlar=new int[4];   //kazananların listesi index bazlı

int gamecount=0; //oyun sayacı

int raundsum = 0;  //toplam raund sayacı

float meangame = 0f;    //ortalama raund

float meankingchange = 0f;  //papazın el değiştirme değeri

int kingwinner =0;          // papaz ile başlayanın kazanma oranı

int secondplayer = 0;       //papaz ile başlamayanın kazanma oranı

while (gamecount<10000)
{    
    
        for (int i = 0; i < Oyuncu.Oyuncular.Count; i++)
        {
  
        
            if (Oyuncu.Oyuncular[i].Oyna())
            {
                Console.WriteLine($"{i}.nci oyuncu kazandı");
                kazananlar[i] = 1;
            
                if (kazananlar.Sum() == 3)
                {
                    if (kazananlar[3] == 1) kingwinner++;

                    if (kazananlar[2] == 1) secondplayer++;  //papaz ile başlamayanın kazanma oranı

                    gamecount++;
                    
                    
                    for(int j = 0; j < Oyuncu.Oyuncular.Count;j++)
                        {
                            kazananlar[j] = 0;

                        }
                    Console.WriteLine($"{gamecount}. oyun {round} rauntda tamamlandı");

                    raundsum = raundsum + round;        
                
                    Console.WriteLine($"Toplam raunt sayısı: {raundsum}");

                    meangame = (float)((float)raundsum / (float)gamecount);

                    meankingchange = ((float)Oyuncu.papazcounter / (float)raundsum);

                    Console.WriteLine($"Papaz ile başlayanın kazanma oranı: {(float)kingwinner/ (float)gamecount}"); 

                    Console.WriteLine($"Papaz ile başlamayanın kazanma oranı: {(float)secondplayer / (float)gamecount}");

                    Console.WriteLine($"Papazın el değiştirmesi: {Oyuncu.papazcounter}");                

                    Console.WriteLine($"Ort. papazın el değiştirmesi: {meankingchange:0.00##}");

                    Console.WriteLine($"Ort. raunt sayısı: {meangame:0.00##}");
                    
                    round = 0;

                    Kartlar.CardsDelivery();

                   
                    break;
                }

            }


        }
        
        round++;
        
        Console.WriteLine($"{round}. round oynandı");
            
}





