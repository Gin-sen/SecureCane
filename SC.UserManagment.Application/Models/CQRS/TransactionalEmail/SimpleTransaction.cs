using System;
using System.Collections.Generic;
using System.Text;

namespace SC.UserManagment.Application.Models.CQRS.TransactionalEmail
{
  /// <summary>
  /// Email simple (sans template)
  /// </summary>
  public class SimpleTransaction
  {
    /// <summary>
    /// 
    /// </summary>
    public Sender Sender { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public List<SendTo> To { get; set; }

    /// <summary>
    /// Object du mail
    /// </summary>
    public string Subject { get; set; }

    /// <summary>
    /// Contenu du mail
    /// </summary>
    public string HtmlContent { get; set; }
  }
}
