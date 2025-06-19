using Adventures.Web.Helpers;
using static Adventures.Web.Helpers.TravelHelper;

namespace Adventures.Tests
{
    [TestClass]
    public class TravelHelperTest
    {
        [TestMethod]
        public void gamedrive_Returnssafaritype()
        {
            // ARRANGE
            TravelHelper helper = new TravelHelper();
            TravelType type = new TravelType();

            // ACT
            var ans = TravelHelper.GetTravelType("We do a game drive every day");
            // ASSERT
            Assert.AreEqual(TravelHelper.TravelType.safari, ans);
        }

        [TestMethod]
        public void hiketrails_Returnswalking_vacation()
        {
            // ARRANGE
            TravelHelper helper = new TravelHelper();
            TravelType type = new TravelType();

            // ACT
            var ans = TravelHelper.GetTravelType("We hike all the trails in the area.");
            // ASSERT
            Assert.AreEqual(TravelHelper.TravelType.walking_vacation, ans);
        }

        [TestMethod]
        public void roadtriptoUSA_Returnsself_drive()
        {
            // ARRANGE
            TravelHelper helper = new TravelHelper();
            TravelType type = new TravelType();

            // ACT
            var ans = TravelHelper.GetTravelType("A fantastic road trip through the USA.");
            // ASSERT
            Assert.AreEqual(TravelHelper.TravelType.self_drive, ans);
        }

        [TestMethod]
        public void roadtriptoAfrica_Returnsexception()
        {
            // ARRANGE
            TravelHelper helper = new TravelHelper();
            TravelType type = new TravelType();


        }


    }
}