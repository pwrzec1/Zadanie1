using System;

/// <summary>
/// Przykładowe rozwiązanie zadania pierwszego z laboratorium nr 4.
/// (c) Waldemar Karwowski, Piotr Wrzeciono, 2013
/// </summary>
namespace Laboratorium4Zadanie1
{
	public struct MarkaPojazdu
	{
		private String NazwaProducentaPojazdu;
		private String NazwaPojazdu;
		private String NumerSeryjnyPojazdu;

		/// <summary>
		/// Initializes a new instance of the <see cref="Laboratorium4Zadanie1.MarkaPojazdu"/> struct.
		/// </summary>
		/// <param name="Producent">Nazwa producenta pojazdu</param>
		/// <param name="Nazwa">Nazwa pojazdu</param>
		/// <param name="Numer">Numer seryjny pojazdu</param>
		public MarkaPojazdu(String Producent, String Nazwa, String Numer)
		{
			NazwaProducentaPojazdu = Producent;
			NazwaPojazdu = Nazwa;
			NumerSeryjnyPojazdu = Numer;
		}//Koniec konstruktora

		private void PoprawnaMarkaPojazdu()
		{
			if(NazwaProducentaPojazdu.CompareTo("") == 0 || NazwaPojazdu.CompareTo("") == 0 || NumerSeryjnyPojazdu.CompareTo("") == 0)
			{
				NazwaProducentaPojazdu = "BRAK_NAZWY_PRODUCENTA";
				NazwaPojazdu = "BRAK_NAZWY_POJAZDU";
				NumerSeryjnyPojazdu = "BRAK_NUMERU_SERYJNEGO_POJAZDU";
			}//end if

		}//Koniec konstruktora domyślnego

		public String getNazwęProducentaPojazdu()
		{
			PoprawnaMarkaPojazdu();
			return NazwaProducentaPojazdu;
		}//Koniec metody zwracającej nazwę producenta pojazdu

		public String getNazwęPojazdu()
		{
			PoprawnaMarkaPojazdu();
			return NazwaPojazdu;
		}//Koniec metody zwracającej nazwę pojazdu

		public String getNumerSeryjnyPojazdu()
		{
			PoprawnaMarkaPojazdu();
			return NumerSeryjnyPojazdu;
		}//Koniec metody pobierającej numer seryjny pojazdu

	}//Koniec struktury
}

