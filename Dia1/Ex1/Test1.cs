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

			Assert.AreEqual(p.getAno(),1998);
		}

		[Test]
		public void TestPessoaFisica()
		{
			PessoaFisica pf= new PessoaFisica("Soares");
            pf.setCPF("45647782507");
			pf.setNascimento(2000);
			pf.setRG("55666-10");

			Assert.AreEqual("Soares", pf.getNome()); 
			Assert.AreNotEqual(6, pf.getIdade());
            Assert.AreEqual(14, pf.getIdade());
            Assert.AreEqual(2000, pf.getAno());
			Assert.AreEqual(true, pf.EhPessoaFisica()); //Testa se é uma pessoa física
		}

		[Test]
		public void TestPessoaJuridica()
		{
            PessoaJuridica pj = new PessoaJuridica("univale", "20374307000160");
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
            pf.setCPF("14279871817");
			pf.setNascimento(2000);
			pf.setRG("55666-10");

			Assert.IsTrue(PessoaFisica.ValidaCPF(pf.getCPF())); 
		}

		[Test]
		public void TestValidaPessoaJuridica()
		{
            PessoaJuridica pj = new PessoaJuridica("univale", "538037540001461");
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

