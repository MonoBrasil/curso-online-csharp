using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Runtime.Serialization.Json;

namespace Exemplos
{

	public class Pessoa
	{
		public int ID { get; set; }
		public string Nome { get; set; }
		public int Idade { get; set; }
		public bool Valido { get; set; }
		public string Pais { get; set; }
	}

	public class Pais
	{
		public string Nome { get; set; }
		public long Populacao { get; set; }
		public string Continente { get; set; }
	}

	public static class Helper 
	{
		public static string Dump(this object @this) {
			if (@this == null)
				return "NULL";

			var serializer = new DataContractJsonSerializer(@this.GetType());
			MemoryStream ms = new MemoryStream();
			serializer.WriteObject(ms, @this);
			string json = Encoding.Default.GetString(ms.ToArray());
			return json;
		}
	}

	public class MainClass
	{
		public static void Main (string[] args)
		{		
			Pessoa[] pessoas = new Pessoa[] {
				new Pessoa { ID = 1, Nome = "Marcio", Idade = 33, Valido = true, Pais = "Brazil"},
				new Pessoa { ID = 2, Nome = "Alexandre", Idade = 37, Valido = false, Pais = "China"},
				new Pessoa { ID = 3, Nome = "Alessandro", Idade = 35, Valido = true, Pais = "Brazil"},
				new Pessoa { ID = 4, Nome = "Vanessa", Idade = 35, Valido = true, Pais = "United States"},
				new Pessoa { ID = 5, Nome = "Carla", Idade = 29, Valido = false, Pais = "India"},
				new Pessoa { ID = 6, Nome = "Maria", Idade = 43, Valido = true, Pais = "Brazil"},
				new Pessoa { ID = 7, Nome = "Marcio", Idade = 43, Valido = true, Pais = "United States"},
			};

			Pais[] paises = new Pais[10];
			
			for (int indice = 0; indice < paises.Length; indice++)
			{
				paises[indice] = new Pais();
			}
			
			paises[0].Nome = "Bangladesh";
			paises[0].Populacao = 156594962;
			paises[0].Continente = "Asia";
			paises[1].Nome = "Brazil";
			paises[1].Populacao = 200361925;
			paises[1].Continente = "America";
			paises[2].Nome = "China";
			paises[2].Populacao = 1357380000;
			paises[2].Continente = "Asia";
			paises[3].Nome = "India";
			paises[3].Populacao = 1252139596;
			paises[3].Continente = "Asia";
			paises[4].Nome = "Indonesia";
			paises[4].Populacao = 249865631;
			paises[4].Continente = "Asia";
			paises[5].Nome = "Japan";
			paises[5].Populacao = 127338621;
			paises[5].Continente = "Asia";
			paises[6].Nome = "Nigeria";
			paises[6].Populacao = 173615345;
			paises[6].Continente = "Africa";
			paises[7].Nome = "Pakistan";
			paises[7].Populacao = 182142594;
			paises[7].Continente = "Asia";
			paises[8].Nome = "Russian Federation";
			paises[8].Populacao = 143499861;
			paises[8].Continente = "Europe";
			paises[9].Nome = "United States";
			paises[9].Populacao = 316128839;
			paises[9].Continente = "America";

			var marcio = pessoas.First(obj => obj.Nome == "Marcio");
			Console.WriteLine ("Macio: {0}", marcio.Dump());
			Console.WriteLine("Média de idade: {0}", pessoas.Average(obj => obj.Idade));

			int[] array = { 1, 3, 5, 7 };
			Console.WriteLine(array.Average());

			Console.WriteLine ("Média de população: {0}", paises.Average (obj => obj.Populacao));

			var america = paises.Where (pais => pais.Continente == "America");
			Console.WriteLine ("-----");
			Console.WriteLine ("Países: {0}", string.Join(", ", america.Select (obj => obj.Nome)));
			Console.WriteLine ("Média de população: {0}", america.Average( p => p.Populacao));
			Console.WriteLine ("Soma de população: {0}", america.Sum( p => p.Populacao));
			Console.WriteLine ("Menor população: {0}", america.Min( p => p.Populacao));


			var paisesSelecionados = from pais in paises where pais.Continente == "America" select pais;
			Console.WriteLine ("-----");
			Console.WriteLine ("Países: {0}", string.Join(", ", paisesSelecionados.Select (obj => obj.Nome)));
			Console.WriteLine ("Média de população: {0}", paisesSelecionados.Average( p => p.Populacao));
			Console.WriteLine ("Soma de população: {0}", paisesSelecionados.Sum( p => p.Populacao));
			Console.WriteLine ("Menor população: {0}", paisesSelecionados.Min( p => p.Populacao));

			var america2 = pessoas.Join (paises.Where (pais => pais.Continente == "America"), pessoa => pessoa.Pais, pais => pais.Nome, (p1, p2) => p1);
			Console.WriteLine ("-----");
			Console.WriteLine ("Pessoas: {0}", string.Join(", ", america2.Select (obj => obj.Nome).OrderBy( n => n)));


			var pessoasDePaises = from pessoa in pessoas
				join pais in paises on pessoa.Pais equals pais.Nome
					where pais.Continente == "Asia"
				select pessoa;

			Console.WriteLine ("-----");
			Console.WriteLine ("Pessoas: {0}", string.Join(", ", pessoasDePaises.Select (obj => obj.Nome)));
		}
	}
}
