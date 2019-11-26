using System;
using System.Collections.Generic;
using WorkingWithVisualStudio.Models;
using Xunit;

namespace WorkingWithVisualStudio.Tests
{ 
    public class CouponServiceTests
    {
        public static IEnumerable<object[]> ValidateTestCases
        {
            get
            {
                yield return new object[] { new CouponValidateTestCase { Id = Guid.NewGuid(), IsValid = true } };
                yield return new object[] { new CouponValidateTestCase { Id = Guid.NewGuid(), IsValid = true } };
                yield return new object[] { new CouponValidateTestCase { Id = Guid.NewGuid(), IsValid = true } };
                yield return new object[] { new CouponValidateTestCase { Id = Guid.NewGuid(), IsValid = true } };
            }
        }


        /// <summary>
        /// CouponValidateTestCase implements IXunitSerializable: all test cases are enumerated individually.
        /// </summary>
        [Theory(DisplayName = "CouponService should validate coupons.")]
        [MemberData(nameof(ValidateTestCases))]
        public void Validate(CouponValidateTestCase testCase)
        {
            CouponService couponService = new CouponService();

            var actual = couponService.Validate(testCase.Id);

            Assert.Equal(testCase.IsValid, actual);
        }
    }
}