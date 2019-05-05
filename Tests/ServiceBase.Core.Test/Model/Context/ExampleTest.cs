using CleanDdd.Common.Model.Identity;
using ServiceBase.Core.Model.Context;
using Xunit;

namespace ServiceBase.Core.Test.Model.Context
{
    public class ExampleTest
    {
        public const string Property1 = "One";
        public const string Property2 = "Two";
        
        [Fact]
        public void CreateTest()
        {
            var obj = new ExampleModel(new LongIdentity(1),Property1,Property2 );
            
            Assert.Equal(Property1,obj.Property1);
            Assert.Equal(Property2,obj.Property2);
            Assert.True(obj.IsValid());
        }
    }
}