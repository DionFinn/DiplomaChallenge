using System;
using Classes; 
using Xunit;



namespace Testing
{
    public class test
    {
        [Theory]
        [InlineData(5,5)]
        [InlineData(1,5)]
        [InlineData(0,5)]
        [InlineData(5,0)]
        [InlineData(-5,5)]
        [InlineData(5,-5)]
        public void TestingForTotal(int qty, int cost)
        {
            var order = new Order().total(qty, cost);
            var result = qty * cost;

            Assert.Equal(order, result);
        }

        [Theory]
        [InlineData(5,5)]
        [InlineData(1,5)]
        [InlineData(0,5)]
        [InlineData(5,0)]
        [InlineData(-5,5)]
        [InlineData(5,-5)]
        public void TestingForGST(int qty, float cost)
        {
            var order = new Order().GST(qty, cost);
            var GSTresult = (qty * cost)/10;

            Assert.Equal(order,GSTresult);
        }
    }
}
