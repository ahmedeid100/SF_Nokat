using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Nokat.UI.Controllers;
using System.Web.Mvc;

namespace Nokat.Tests
{
    [TestFixture]
    public class JokeControllerTests
    {
        [Test]
        public void GetInterestList()
        {
            var controller = new JokeController();
            var result = controller.indexPartial(null);
            Assert.IsNotEmpty((List<object>)(((ViewResult)result).Model));
        }

        [Test]
        public void GetFirstPageInterestList()
        {
            var controller = new JokeController();
            var result = controller.indexPartial(1);
            Assert.IsNotEmpty((List<object>)(((ViewResult)result).Model));
        }
    }
}
