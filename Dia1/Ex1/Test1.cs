using NUnit.Framework;
using System;

namespace Ex1
{
	[TestFixture]
	public class Test1
	{
		[Test]
		public void TestPessoa()
		{
			Pessoa p = new Pessoa(); p.setNome("Jose");
			p.setAno(1998);

			Assertion.AssertEquals(p.getAno(),1998);
		}

		[Test]
		public void TestPessoaFisica()
		{
			PessoaFisica pf= new PessoaFisica("Soares");
			pf.setCPF("5718887500");
			pf.setNascimento(2000);
			pf.setRG("55666-10");

			Assert.AreEqual("Soares", pf.getNome()); 
			Assert.AreEqual(6, pf.getIdade());
			Assert.AreEqual(true, pf.EPessoaFisica());
		}

		[Test]
		public void TestPessoaJuridica()
		{
			PessoaJuridica pj = new PessoaJuridica("univale","555111/0001-10");
			Endereco end = new Endereco();
			end.setRua("XV Novembro");
			end.setBairro("Centro");
			end.setNumero(10);
			end.setAtivo(true);
			pj.setEndereco(end);

			Assert.AreEqual("555111/0001-10", pj.getCNPJ());
		}

		[Test]
		public void TestValidaPessoaFisica()
		{
			PessoaFisica pf= new PessoaFisica("Soares");
			pf.setCPF("5718887500");
			pf.setNascimento(2000);
			pf.setRG("55666-10");

			Assert.IsTrue(PessoaFisica.ValidaCPF(pf.getCPF())); 
		}

		[Test]
		public void TestValidaPessoaJuridica()
		{
			PessoaJuridica pj = new PessoaJuridica("univale","555111/0001-10");
			Endereco end = new Endereco();
			end.setRua("XV Novembro");
			end.setBairro("Centro");
			end.setNumero(10);
			end.setAtivo(true);
			pj.setEndereco(end);

			Assert.IsTrue(PessoaJuridica.ValidaCNPJ(pj.getCNPJ()));
		}

		[TestFixtureSetUp]
		public void Init()
		{
		}

		[TestFixtureTearDown]
		public void Dispose()
		{
		}
	} 
}

