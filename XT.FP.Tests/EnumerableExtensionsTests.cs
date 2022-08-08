using XT.Core;

namespace XT.FP.Tests
{
    public class EnumerableExtensionsTests
    {
        [Fact]
        public void Returns_New_List_With_Null_Arg()
        {
            IEnumerable<string> nullEnumerable = null;
            var result = nullEnumerable.Map(s => s.ToUpper());
            Assert.NotNull(result);
            Assert.Empty(result);
        } 
        
        [Fact]
        public void Applies_Transform_On_Non_Empty_Arg()
        {
            var list = new List<string>() { "bob", "Bob", "BOB"};
            var result = list.Map(s => s.ToUpper());
            foreach (var value in result)
            {
                Assert.True(value.IsAllUpper());
            }
            
        }

      
    }
}