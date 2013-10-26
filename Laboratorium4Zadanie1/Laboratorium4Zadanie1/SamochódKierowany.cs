using System;

/// <summary>
/// Przykładowe rozwiązanie zadania pierwszego z laboratorium nr 4.
/// (c) Waldemar Karwowski, Piotr Wrzeciono, 2013
/// </summary>
namespace Laboratorium4Zadanie1
{
	public class SamochódKierowany : Samochód
	{
		public const uint SKRĘT_W_LEWO = 1;
		public const uint SKRĘT_W_PRAWO = 2;
		public const uint JEDŹ_PROSTO = 3;

		protected uint RodzajSkrętu;

		public SamochódKierowany(MarkaPojazdu Marka, DateTime RokProdukcjiSamochodu, uint Vmax):base(Marka,RokProdukcjiSamochodu,Vmax)
		{
			RodzajSkrętu = JEDŹ_PROSTO;
		}//Koniec konstruktora pierwszego

		public SamochódKierowany(String NazwaProducenta, String NazwPojazdu, String NumerSeryjny, DateTime RokProdukcjiSamochodu, uint Vmax):base(NazwaProducenta,NazwPojazdu,NumerSeryjny,RokProdukcjiSamochodu,Vmax)
		{
			RodzajSkrętu = JEDŹ_PROSTO;
		}//Koniec drugiego konstruktora


		public void Przyspiesz()
		{
			PrędkośćBieżącaSamochodu++;
			if(PrędkośćBieżącaSamochodu > PrędkośćMaksymalna) PrędkośćBieżącaSamochodu = PrędkośćMaksymalna;
			if(KierunekRuchuSamochodu == BEZRUCH) KierunekRuchuSamochodu = RUCH_DO_PRZODU;
		}//Koniec metody przyspieszającej

		public void Zwolnij()
		{
			if(PrędkośćBieżącaSamochodu > 0)
			{
				PrędkośćBieżącaSamochodu--;
			}else
			{
				KierunekRuchuSamochodu = BEZRUCH;
			}//end if
		}//Koniec metody zwalniającej

		public void Zatrzymaj()
		{
			PrędkośćBieżącaSamochodu = 0;
			KierunekRuchuSamochodu = BEZRUCH;
		}//Koniec metody zatrzymującej

		public void JedźDoPrzodu()
		{
			KierunekRuchuSamochodu = RUCH_DO_PRZODU;
		}//Koniec zmiany kierunku jazdy na ruch do przodu

		public void JedźDoTyłu()
		{
			KierunekRuchuSamochodu = RUCH_DO_TYŁU;
		}//Koniec zmiant kierunku jazdy na ruch do tyłu

		public void Skręć(uint KierunekSkrętu)
		{
			if(KierunekSkrętu != SKRĘT_W_LEWO && KierunekSkrętu != SKRĘT_W_PRAWO)
			{
				RodzajSkrętu = JEDŹ_PROSTO;
			}else
			{
				RodzajSkrętu = KierunekSkrętu;
			}//end if
		}//Koniec metody skręcającej

		public uint PodajRodzajSkrętu()
		{
			return RodzajSkrętu;
		}//Koniec zwracania rodzaju skrętu

		public void WyświetlInformacjęOSamochodzie()
		{
			Console.WriteLine();
			Console.WriteLine("Producent samochodu ........ " + MarkaSamochodu.getNazwęProducentaPojazdu());
			Console.WriteLine("Nazwa samochodu ............ " + MarkaSamochodu.getNazwęPojazdu());
			Console.WriteLine("Numer seryjny samochodu .... " + MarkaSamochodu.getNumerSeryjnyPojazdu());
			Console.WriteLine("Rok produkcji samochodu: ... " + rokProdukcji.Year);
			Console.WriteLine("Prędkość maksymalna: ....... " + PrędkośćMaksymalna);
		}//Koniec metody wyświetlającej na konsoli informację o samochodzie

		public void WyświetlInfromacjęORuchuSamochodu()
		{
			String Skręt;

			Skręt = "Samochód jedzie prosto";
			if(RodzajSkrętu == SKRĘT_W_LEWO && KierunekRuchuSamochodu != BEZRUCH && PrędkośćBieżącaSamochodu > 0) Skręt = "Samochód skręca w lewo";
			if(RodzajSkrętu == SKRĘT_W_PRAWO && KierunekRuchuSamochodu != BEZRUCH && PrędkośćBieżącaSamochodu > 0) Skręt = "Samochód skręca w prawo";

			Console.WriteLine();

			PokażKierunekSamochodu();
			PokażPrędkośćSamochodu();
			if(KierunekRuchuSamochodu != BEZRUCH && PrędkośćBieżącaSamochodu != 0)  Console.WriteLine(Skręt);

		}//Koniec metody wyświetlającej informację o ruchu samochodu

	}//Koniec klasy
}

