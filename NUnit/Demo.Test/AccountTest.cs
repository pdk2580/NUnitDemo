using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Demo;

namespace Demo.Test
{
    [TestFixture]
    public class AccountTest
    {
        Account source;
        Account destination;

        [SetUp]
        public void Init()
        {
            source = new Account();
            source.Deposit(200m);

            destination = new Account();
            destination.Deposit(150m);
        }

        [Test]
        public void TransferFunds()
        {
            source.TransferFunds(destination, 100m);

            Assert.AreEqual(250m, destination.Balance);
            Assert.AreEqual(100m, source.Balance);
        }

        [Test]
        public void TransferWithInsufficientFunds()
        {
            source.TransferFunds(destination, 500m);
            //Assert.Throws<InsufficientFundsException>(()=> source.TransferFunds(destination, 300m));
        }

        //[Test]
        //[Ignore("Decide how to implement transaction management")]
        //public void TransferWithInsufficientFundsAtomicity()
        //{
        //    try
        //    {
        //        source.TransferFunds(destination, 300m);
        //    }
        //    catch (InsufficientFundsException expected)
        //    {
        //    }
            
        //    Assert.AreEqual(200m, source.Balance);
        //    Assert.AreEqual(150m, destination.Balance);
        //}
    }
}
