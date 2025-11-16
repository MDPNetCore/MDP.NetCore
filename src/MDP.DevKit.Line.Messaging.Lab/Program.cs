using MDP.DevKit.Line.Messaging;
using System;
using System.IO;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using System.Threading.Tasks;

namespace MDP.DevKit.Line.Messaging.Lab
{
    public class Program
    {
        // Methods
        public static void Run(MessageContext messageContext)
        {
            #region Contracts

            ArgumentNullException.ThrowIfNull(messageContext);

            #endregion


            // Variables
            var userId = "Ub9d250d0199ddb3741579b8a5ef035bc";
            var senderName = "Clark";
            var imageUrl = @"https://sprofile.line-scdn.net/0hwTIGPma7KHtkPj653TZWBBRuKxFHT3FpQQpgSQQ-fh9fCD0sSlg1HwNrdEpRWz0rTwtgG1ZpdBhoLV8demjUT2MOdkxdCWguS1xjnQ";
            var videoUrl = @"https://file-examples.com/storage/fefb234bc0648a3e7a1a47d/2017/04/file_example_MP4_480_1_5MG.mp4";
            var audioUrl = @"https://file-examples.com/storage/fefb234bc0648a3e7a1a47d/2017/04/file_example_MP4_480_1_5MG.mp4";

            // Sender
            var sender = new Sender();
            sender.Name = senderName;
            sender.IconUrl = imageUrl;

            // PushMessageAsync
            //var result = messageContext.MessageService.PushMessageAsync(new TextMessage() { Text = "Hello World", Sender = sender }, userId).GetAwaiter().GetResult();
            //var result = messageContext.MessageService.PushMessageAsync(new StickerMessage() { PackageId = 1, StickerId = 109, Sender = sender }, userId).GetAwaiter().GetResult();
            //var result = messageContext.MessageService.PushMessageAsync(new ImageMessage() { OriginalContentUrl = imageUrl, PreviewImageUrl = imageUrl, Sender = sender }, userId).GetAwaiter().GetResult();
            //var result = messageContext.MessageService.PushMessageAsync(new VideoMessage() { OriginalContentUrl = videoUrl, PreviewImageUrl = imageUrl, Sender = sender }, userId).GetAwaiter().GetResult();
            //var result = messageContext.MessageService.PushMessageAsync(new AudioMessage() { OriginalContentUrl = audioUrl, Duration = 27000, Sender = sender }, userId).GetAwaiter().GetResult();
            //var result = messageContext.MessageService.PushMessageAsync(new LocationMessage() { Title = "my location", Address = "1-6-1 Yotsuya, Shinjuku-ku, Tokyo, 160-0004, Japan", Latitude = 35.687574, Longitude = 139.72922, Sender = sender }, userId).GetAwaiter().GetResult();
            var result = messageContext.MessageService.PushMessageAsync(new FlexMessage() { AlternativeText = "Hello World", Contents= @"{""type"":""bubble"",""body"":{""type"":""box"",""layout"":""vertical"",""contents"":[{""type"":""text"",""text"":""Hello World"",""color"":""#0000FF"",""align"":""center""}]}}", Sender = sender }, userId).GetAwaiter().GetResult();

            // Display
            Console.WriteLine(System.Text.Json.JsonSerializer.Serialize(result, new JsonSerializerOptions
            {
                WriteIndented = true,
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.All)
            }));
        }

        public static void Main(string[] args)
        {
            // Host
            MDP.NetCore.Host.Run<Program>(args);
        }
    }
}
