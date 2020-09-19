using Microsoft.VisualStudio.TestTools.UnitTesting;
using ngApplication.Controllers;

namespace UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestPost()
        {
            //Arrange
            string jsonMenuTest = @"{
                'menu':{
                'header':'menu',
                'items': [
                    {
                       'id':27
                    },
                    {
                       'id':0,
                       'label':'Label 0'
                    },
                    null,
                    {
                       'id':93
                    },
                    {
                       'id':85
                    },
                    {
                       'id':54
                    },
                    null,
                    {
                       'id':46,
                       'label':'Label 46'
                    }
                ]
                }
            }";

            var controller = new UploadController();
            
            //Act
            var result = controller.GetFileStub(jsonMenuTest);

            //Assert
            Assert.AreEqual(46, result);

        }
    }
}
