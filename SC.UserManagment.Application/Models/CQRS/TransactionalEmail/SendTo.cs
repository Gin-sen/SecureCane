namespace SC.UserManagment.Application.Models.CQRS.TransactionalEmail
{
  /// <summary>
  /// Objet de Destinataire à qui envoyer le mail
  /// </summary>
  public class SendTo
  {
    /// <summary>
    /// 
    /// </summary>
    public string Email { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public string Name { get; set; }
  }
}