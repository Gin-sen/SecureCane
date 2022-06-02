using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SC.Common.AzureTables
{
  public class AzureTableException : Exception
  {
    public AzureTableException(string? message) : base(message)
    {
    }

    public AzureTableException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
  }
}
