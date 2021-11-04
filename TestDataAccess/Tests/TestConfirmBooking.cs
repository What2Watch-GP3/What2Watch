using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Model;
using NUnit.Framework;
using DataAccess.BookingDataAccess;

namespace TestDataAccess.Tests
{
    class TestConfirmBooking
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void ConfirmBooking()
        {
            decimal totalPrice = 11.99M;
            var dateString = "5/1/2021 8:30:52 AM";
            DateTime date = DateTime.Parse(dateString, System.Globalization.CultureInfo.InvariantCulture);
            Booking booking1 = new Booking(totalPrice, date);
            BookingDataAccess.CreateAsync(booking1);

            // Act
            //account.Debit(debitAmount);


            // Assert
            Assert.AreEqual(expected, actual, 0.001, "Account not debited correctly");
            Assert.Pass();
        }
    }
}
