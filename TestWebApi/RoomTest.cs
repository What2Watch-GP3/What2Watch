using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using WebApi.Controllers;

namespace TestWebApi
{
    public class RoomTest
    {
        RoomsController _roomController;
        ObjectResult _objectResult;

        [SetUp]
        public void SetUp()
        {
            _objectResult = null;
        }

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _roomController = new RoomsController(new RoomStub(),new SeatStub(), new ShowStub());
        }
    }
}
