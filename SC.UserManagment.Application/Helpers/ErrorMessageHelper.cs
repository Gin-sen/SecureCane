using System;
using System.Collections.Generic;
using System.Text;

namespace SC.UserManagment.Application.Helpers
{
  /// <summary>
  /// 
  /// </summary>
  public static class ErrorMessageHelper
  {
    /// <summary>
    /// 
    /// </summary>
    /// <param name="errorMessage"></param>
    /// <returns></returns>
    public static string Title(string errorMessage)
    {
      return errorMessage + "_TITLE";
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="errorMessage"></param>
    /// <returns></returns>
    public static string Message(string errorMessage)
    {
      return errorMessage + "_MESSAGE";
    }
  }
}
