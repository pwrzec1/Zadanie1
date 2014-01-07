using System;

/// <summary>
/// Przykładowe rozwiązanie zadania pierwszego z laboratorium nr 4.
/// (c) Waldemar Karwowski, Piotr Wrzeciono, 2013
/// </summary>
namespace Laboratorium4Zadanie1
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			MarkaPojazdu MarkaSamochodu;
			String NazwaProducenta;
			String NazwaSamochodu;
			String NumerSeryjny;
			uint PrędkośćMaksymalna;
			int RokProdukcjiPojazdu;
			SamochódKierowany MójPojazd;
			DateTime DataProdukcji;

			char ZnakZKlawiatury;

			Console.WriteLine ("Jedźmy samochodem!\n");
			Console.WriteLine ("A teraz nowa aktualizacja!");
			Console.WriteLine ("Kolejny przykład aktualizacji!");

			Console.Write("Nazwa producenta samochodu ... ? ");
			NazwaProducenta = Console.ReadLine();

			Console.Write("Nazwa samochodu .............. ? ");
			NazwaSamochodu = Console.ReadLine();

			Console.Write("Numer seryjny samochodu ...... ? ");
			NumerSeryjny = Console.ReadLine();

			Console.Write("Prędkość maksymalna [km/h] ... ? ");
			PrędkośćMaksymalna = UInt32.Parse(Console.ReadLine());

			Console.Write("Rok produkcji samochodu ...... ? ");
			RokProdukcjiPojazdu = Int32.Parse(Console.ReadLine());

			MarkaSamochodu = new MarkaPojazdu(NazwaProducenta, NazwaSamochodu, NumerSeryjny);
			DataProdukcji = new DateTime(RokProdukcjiPojazdu,1,1);
			MójPojazd = new SamochódKierowany(MarkaSamochodu, DataProdukcji, PrędkośćMaksymalna);

			Console.WriteLine("\nDziękujemy za podanie danych samochodu. Można już ruszyć.");
			Console.WriteLine("Możliwości są następujące:");
			Console.WriteLine("P - przyspiesz, Z - zwolnij, E - do przodu, S - w lewo, F - w prawo,");
			Console.WriteLine("X - do tyłu, D - jedź prosto, C - zatrzymaj, N - zakończ,");
			Console.WriteLine("I - informacja o samochodzie, K - informacja o jeździe\n");

			do{ //Początek pętli programu
				ZnakZKlawiatury = (char)Console.ReadKey(true).KeyChar;

				if(ZnakZKlawiatury > 'a') ZnakZKlawiatury = (char)(ZnakZKlawiatury - 'a' + 'A');

				if(ZnakZKlawiatury == 'P') MójPojazd.Przyspiesz();
				if(ZnakZKlawiatury == 'Z') MójPojazd.Zwolnij();
				if(ZnakZKlawiatury == 'E') MójPojazd.JedźDoPrzodu();
				if(ZnakZKlawiatury == 'S') MójPojazd.Skręć(SamochódKierowany.SKRĘT_W_LEWO);
				if(ZnakZKlawiatury == 'F') MójPojazd.Skręć(SamochódKierowany.SKRĘT_W_PRAWO);
				if(ZnakZKlawiatury == 'X') MójPojazd.JedźDoTyłu();
				if(ZnakZKlawiatury == 'D') MójPojazd.Skręć(SamochódKierowany.JEDŹ_PROSTO);
				if(ZnakZKlawiatury == 'C') MójPojazd.Zatrzymaj();
				if(ZnakZKlawiatury == 'I') MójPojazd.WyświetlInformacjęOSamochodzie();
				if(ZnakZKlawiatury == 'K') MójPojazd.WyświetlInfromacjęORuchuSamochodu();
									
			}while(ZnakZKlawiatury != 'N'); //Koniec pętli programu

			Console.ReadKey(true);

		}//Koniec metody main
	}
}
