using System;

namespace DYLHS5_HFT_2021221.Logic
{
    public class ProductOrCustomerNameMissingException : Exception
    {
        public ProductOrCustomerNameMissingException(string message) : base(message) { }

    }
}
