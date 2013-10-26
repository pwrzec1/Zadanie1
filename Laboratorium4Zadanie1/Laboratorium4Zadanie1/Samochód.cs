using System;

/// <summary>
/// Przykładowe rozwiązanie zadania pierwszego z laboratorium nr 4.
/// (c) Waldemar Karwowski, Piotr Wrzeciono, 2013
/// </summary>
namespace Laboratorium4Zadanie1
{
	/// <summary>
	/// Klasa Samochód (patrz treść zadania)
	/// </summary>
	public class Samochód
	{
		public const uint RUCH_DO_PRZODU = 0;
		public const uint RUCH_DO_TYŁU = 1;
		public const uint BEZRUCH = 2;

		protected DateTime rokProdukcji;
		protected MarkaPojazdu MarkaSamochodu;
		protected uint PrędkośćMaksymalna;

		protected uint PrędkośćBieżącaSamochodu;
		protected uint KierunekRuchuSamochodu;

		/// <summary>
		/// Konstruktor pierwszy<see cref="Laboratorium4Zadanie1.Samochód"/> class.
		/// </summary>
		/// <param name="Marka">Marka pojazdu <see cref="Laboratorium4Zadanie1.MarkaPojazdu"/></param>
		/// <param name="RokProdukcjiSamochodu">Rok produkcji samochodu (struktura DateTime)</param>
		/// <param name="Vmax">Prędkość maksymalna pojazdu</param>
		public Samochód (MarkaPojazdu Marka, DateTime RokProdukcjiSamochodu, uint Vmax)
		{

			MarkaSamochodu = new MarkaPojazdu(Marka.getNazwęProducentaPojazdu(), Marka.getNazwęPojazdu(), Marka.getNumerSeryjnyPojazdu());
			Inicjalizacja(RokProdukcjiSamochodu,Vmax);

		}//Koniec konstruktora pierwszego

		/// <summary>
		/// Konstruktor drugi<see cref="Laboratorium4Zadanie1.Samochód"/> class.
		/// </summary>
		/// <param name="NazwaProducenta">Nazwa producenta samochodu</param>
		/// <param name="NazwPojazdu">Nazw samochodu</param>
		/// <param name="NumerSeryjny">Numer seryjny samochodu</param>
		/// <param name="RokProdukcjiSamochodu">Rok produkcji samochodu</param>
		/// <param name="Vmax">Prędkość maksymalna samochodu</param>
		public Samochód(String NazwaProducenta, String NazwPojazdu, String NumerSeryjny, DateTime RokProdukcjiSamochodu, uint Vmax)
		{

			MarkaSamochodu = new MarkaPojazdu(NazwaProducenta, NazwPojazdu, NumerSeryjny);
			Inicjalizacja(RokProdukcjiSamochodu,Vmax);

		}//Koniec drugiego konstruktora

		/// <summary>
		/// Inicjalizacja Data produkcji samochodu oraz prędkości maksymalnej.
		/// </summary>
		/// <param name="DataProdukcji">Data produkcji samochodu</param>
		/// <param name="Vmax">Prędkość maksymalna</param>
		private void Inicjalizacja(DateTime DataProdukcji, uint Vmax)
		{
			int Rok;
			int Miesiąc;
			int Dzień;

			Rok = DataProdukcji.Date.Year;
			Miesiąc = DataProdukcji.Date.Month;
			Dzień = DataProdukcji.Date.Day;

			rokProdukcji = new DateTime(Rok,Miesiąc,Dzień);

			PrędkośćMaksymalna = Vmax;

			PrędkośćBieżącaSamochodu = 0;

			KierunekRuchuSamochodu = BEZRUCH;


		}//Koniec metody inicjalizującej to samo w każdym z konstruktorów

		/// <summary>
		/// Zwraca prędkość bieżącą samochodu
		/// </summary>
		/// <value>Prędkość bieżąca pojazdu</value>
		public uint PrędkośćBieżąca
		{
			get
			{
				uint Prędkość;

				Prędkość = 0;

				if(KierunekBieżący != BEZRUCH) Prędkość = PrędkośćBieżącaSamochodu;

				return Prędkość;
			}//end get

		}//Koniec pobierania prędkości bieżącej samochodu

		/// <summary>
		/// Ustawia lub pobiera kierunek bieżący samochodu.
		/// Uwaga!! Kierunek bieżący musi być podany według stałych:
		/// RUCH_DO_PRZODU, RUCH_DO_TYŁU, BEZRUCH. Wpisanie innych wartości spowoduje
		/// automatyczne przypisanie wartości stałej BEZRUCH do kierunku poruszania się
		/// samochodu
		/// </summary>
		/// <value>Kierunek bieżący pojazdu</value>
		public uint KierunekBieżący
		{
			get
			{
				uint Kierunek;

				Kierunek = BEZRUCH;

				if(PrędkośćBieżąca > 0)
				{
					Kierunek = KierunekBieżący;
				}//end if

				return Kierunek;

			}//end get

			set
			{
				//Zabezpieczenie przed nieprawidłowymi danymi!
				if(KierunekBieżący != RUCH_DO_PRZODU && KierunekBieżący != RUCH_DO_TYŁU)
				{
					KierunekRuchuSamochodu = BEZRUCH;
				}else
				{
					KierunekRuchuSamochodu = KierunekBieżący;
				}//end if
			}//end set
		}//Koniec pobierania i ustawiania kierunku bieżącego samochodu

		/// <summary>
		/// Pokauje kierunek jazdy samochodu w konsoli.
		/// </summary>
		public void PokażKierunekSamochodu()
		{
			String RodzajKierunku;

			RodzajKierunku = "samochód stoi";

			if(KierunekRuchuSamochodu == RUCH_DO_PRZODU) RodzajKierunku = "samochód jedzie do przodu";
			if(KierunekRuchuSamochodu == RUCH_DO_TYŁU) RodzajKierunku = "samochód się cofa";

			Console.WriteLine(RodzajKierunku);
		}//Koniec metody pokazującej kierunek samochodu

		/// <summary>
		/// Pokazuje prędkość samochodu w konsoli.
		/// </summary>
		public void PokażPrędkośćSamochodu()
		{
			Console.WriteLine("Prędkość samochodu wynosi: " + PrędkośćBieżącaSamochodu + " km/h");
		}//Koniec metody pokazującej prędkość samochodu

	}//Koniec klasy
}

