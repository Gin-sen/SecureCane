using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Net.WebSockets;

namespace SC.SocketServer.Api.Controllers
{
  [ApiController]
  [Route("")]
  public class WebSocketController : ControllerBase
  {
    private readonly ILogger<WebSocketController> _logger;

    public WebSocketController(ILogger<WebSocketController> logger)
    {
      _logger = logger;
    }

    [HttpGet("/ws")]
    public async Task Get()
    {
      if (HttpContext.WebSockets.IsWebSocketRequest)
      {
        // Socket accepté
        using var webSocket = await HttpContext.WebSockets.AcceptWebSocketAsync();

        // Fais des choses avant le traitement du socket
        await Task.Delay(1000);
        
        // Boucle de Réception-Emission a travers le socket
        await HandleWebsocketAsync(webSocket);
      }
      else
      {
        HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
      }
    }

    /// <summary>
    /// Main WebSocket loop 
    /// </summary>
    /// <param name="webSocket"></param>
    /// <returns></returns>
    private static async Task HandleWebsocketAsync(WebSocket webSocket)
    {
      // Connexion établie, await la réception d'un payload avant de lancer la boucle d'écoute
      int messagesReceivedCount = 0;
      int messagesSendCount = 0;
      var buffer = new byte[1024 * 4];
      var receiveResult = await webSocket.ReceiveAsync(
          new ArraySegment<byte>(buffer), CancellationToken.None);
      messagesReceivedCount++;


      Console.WriteLine();
      Console.WriteLine($"buffer : {System.Text.Encoding.Default.GetString(buffer)}");
      Console.WriteLine($"receiveResult count : {receiveResult.Count}");
      Console.WriteLine($"messagesReceivedCount : {messagesReceivedCount}");
      Console.WriteLine($"messagesSendCount : {messagesSendCount}");
      Console.WriteLine();

      // 1.    Process la première interaction
      await Task.Delay(1000);

      // Boucle Envois-Réception
      while (!receiveResult.CloseStatus.HasValue)
      {
        // 1-n. await l'envois du resultat de la n-ième interaction 
        await webSocket.SendAsync(
            new ArraySegment<byte>(buffer, 0, receiveResult.Count),
            receiveResult.MessageType,
            receiveResult.EndOfMessage,
            CancellationToken.None);
        messagesSendCount++;

        Console.WriteLine();
        Console.WriteLine($"buffer : {System.Text.Encoding.Default.GetString(buffer)}");
        Console.WriteLine($"receiveResult count : {receiveResult.Count}");
        Console.WriteLine($"messagesReceivedCount : {messagesReceivedCount}");
        Console.WriteLine($"messagesSendCount : {messagesSendCount}");
        Console.WriteLine();

        // 2-n. await la réception de nouvelles données dans le socket
        receiveResult = await webSocket.ReceiveAsync(
            new ArraySegment<byte>(buffer), CancellationToken.None);
        messagesReceivedCount++;

        Console.WriteLine();
        Console.WriteLine($"buffer : {System.Text.Encoding.Default.GetString(buffer)}");
        Console.WriteLine($"receiveResult count : {receiveResult.Count}");
        Console.WriteLine($"messagesReceivedCount : {messagesReceivedCount}");
        Console.WriteLine($"messagesSendCount : {messagesSendCount}");
        Console.WriteLine();

        // 2-n. Process la deuxième interaction
        await Task.Delay(1000);

      }

      await webSocket.CloseAsync(
          receiveResult.CloseStatus.Value,
          receiveResult.CloseStatusDescription,
          CancellationToken.None);
    }
  }
}