using NUnit.Framework;
using System;

namespace Ex1
{
	[TestFixture ()]
	public class Test2
	{
		[Test ()]
		public void TestIRPF1 ()
		{
			PessoaFisica pf = CriaPessoaFisica ();

			Imposto irpf = new Irpf (pf);
			Assert.AreEqual (0.27, irpf.Aliquota);
			Assert.AreEqual (270, irpf.Calcula (1000));
		}

		[Test(), ExpectedException(typeof(ArgumentException))]
		public void TestIRPF2 ()
		{
			PessoaJuridica pj = CriaPessoaJuridica ();

			Imposto irpf = new Irpf (pj);
		}

		[Test ()]
		public void TestIRPFJ1()
		{
			PessoaJuridica pj = CriaPessoaJuridica ();

			Imposto irpf = new Irpf (pj);
			Assert.AreEqual (0.12, irpf.Aliquota);
			Assert.AreEqual (120, irpf.Calcula (1000));
		}

		[Test(), ExpectedException(typeof(ArgumentException))]
		public void TestIRPJ2 ()
		{
			PessoaFisica pf = CriaPessoaFisica ();

			Imposto irpj = new Irpj (pf);
		}

		private PessoaFisica CriaPessoaFisica ()
		{
			PessoaFisica pf = new PessoaFisica ("Soares");
			pf.setCPF ("5718887500");
			pf.setNascimento (2000);
			pf.setRG ("55666-10");

			return pf;
		}

		private PessoaJuridica CriaPessoaJuridica()
		{
			PessoaJuridica pj = new PessoaJuridica("univale","555111/0001-10");
			Endereco end = new Endereco();
			end.setRua("XV Novembro");
			end.setBairro("Centro");
			end.setNumero(10);
			end.setAtivo(true);
			pj.setEndereco(end);

			return pj;
		}
	}
}

