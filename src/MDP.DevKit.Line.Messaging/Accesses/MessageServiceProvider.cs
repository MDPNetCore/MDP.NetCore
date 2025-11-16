using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MDP.DevKit.Line.Messaging
{
    public class MessageServiceProvider : MessageService
    {
        // Fields
        private readonly IHttpClientFactory _httpClientFactory;


        // Constructors
        public MessageServiceProvider(IHttpClientFactory httpClientFactory)
        {
            #region Contracts

            ArgumentNullException.ThrowIfNull(httpClientFactory);

            #endregion

            // Default
            _httpClientFactory = httpClientFactory;
        }


        // Methods
        public Task<string> ReplyMessageAsync(Message message, string replyToken)
        {
            #region Contracts

            if (message == null) throw new ArgumentException($"{nameof(message)}=null");
            if (string.IsNullOrEmpty(replyToken) == true) throw new ArgumentException($"{nameof(replyToken)}=null");

            #endregion

            // ReplyMessageAsync
            return this.ReplyMessageAsync(new List<Message>() { message }, replyToken);
        }

        public Task<string> PushMessageAsync(Message message, string userId)
        {
            #region Contracts

            if (message == null) throw new ArgumentException($"{nameof(message)}=null");
            if (string.IsNullOrEmpty(userId) == true) throw new ArgumentException($"{nameof(userId)}=null");

            #endregion

            // PushMessageAsync
            return this.PushMessageAsync(new List<Message>() { message }, userId);
        }

        public Task<string> MulticastMessageAsync(Message message, List<string> userIdList)
        {
            #region Contracts

            if (message == null) throw new ArgumentException($"{nameof(message)}=null");
            if (userIdList == null) throw new ArgumentException($"{nameof(userIdList)}=null");

            #endregion

            // MulticastMessageAsync
            return this.MulticastMessageAsync(new List<Message>() { message }, userIdList);
        }

        public Task<string> BroadcastMessageAsync(Message message)
        {
            #region Contracts

            if (message == null) throw new ArgumentException($"{nameof(message)}=null");

            #endregion

            // BroadcastMessageAsync
            return this.BroadcastMessageAsync(new List<Message>() { message });
        }


        public async Task<string> ReplyMessageAsync(List<Message> messageList, string replyToken)
        {
            #region Contracts

            if (messageList == null) throw new ArgumentException($"{nameof(messageList)}=null");
            if (string.IsNullOrEmpty(replyToken) == true) throw new ArgumentException($"{nameof(replyToken)}=null");

            #endregion

            // RequestUrl
            var requestUri = @"/message/reply";

            // RequestContent
            var requestContent = new
            {
                // ReplyToken 
                replyToken = replyToken,

                // Messages
                messages = messageList.Select(message => this.SerializeMessages(message)).ToList()
            };

            // Execute
            {
                // PostAsync
                var resultModel = await _httpClientFactory.CreateMessageClient().PostAsync<string, ErrorModel>(requestUri, content: requestContent);
                if (resultModel == null) throw new InvalidOperationException($"{nameof(resultModel)}=null");

                // Return
                return resultModel;
            }
        }

        public async Task<string> PushMessageAsync(List<Message> messageList, string userId)
        {
            #region Contracts

            if (messageList == null) throw new ArgumentException($"{nameof(messageList)}=null");
            if (string.IsNullOrEmpty(userId) == true) throw new ArgumentException($"{nameof(userId)}=null");

            #endregion

            // RequestUrl
            var requestUri = @"/message/push";

            // RequestContent
            var requestContent = new
            {
                // To 
                to = userId,

                // Messages
                messages = messageList.Select(message => this.SerializeMessages(message)).ToList()
            };

            // Execute
            {
                // PostAsync
                var resultModel = await _httpClientFactory.CreateMessageClient().PostAsync<string, ErrorModel>(requestUri, content: requestContent);
                if (resultModel == null) throw new InvalidOperationException($"{nameof(resultModel)}=null");

                // Return
                return resultModel;
            }
        }

        public async Task<string> MulticastMessageAsync(List<Message> messageList, List<string> userIdList)
        {
            #region Contracts

            if (messageList == null) throw new ArgumentException($"{nameof(messageList)}=null");
            if (userIdList == null) throw new ArgumentException($"{nameof(userIdList)}=null");

            #endregion

            // RequestUrl
            var requestUri = @"/message/multicast";

            // RequestContent
            var requestContent = new
            {
                // To 
                to = userIdList,

                // Messages
                messages = messageList.Select(message => this.SerializeMessages(message)).ToList()
            };

            // Execute
            {
                // PostAsync
                var resultModel = await _httpClientFactory.CreateMessageClient().PostAsync<string, ErrorModel>(requestUri, content: requestContent);
                if (resultModel == null) throw new InvalidOperationException($"{nameof(resultModel)}=null");

                // Return
                return resultModel;
            }
        }

        public async Task<string> BroadcastMessageAsync(List<Message> messageList)
        {
            #region Contracts

            if (messageList == null) throw new ArgumentException($"{nameof(messageList)}=null");

            #endregion

            // RequestUrl
            var requestUri = @"/message/broadcast";

            // RequestContent
            var requestContent = new
            {
                // Messages
                messages = messageList.Select(message => this.SerializeMessages(message)).ToList()
            };

            // Execute
            {
                // PostAsync
                var resultModel = await _httpClientFactory.CreateMessageClient().PostAsync<string, ErrorModel>(requestUri, content: requestContent);
                if (resultModel == null) throw new InvalidOperationException($"{nameof(resultModel)}=null");

                // Return
                return resultModel;
            }
        }


        private dynamic SerializeMessages(Message message)
        {
            #region Contracts

            if (message == null) throw new ArgumentException($"{nameof(message)}=null");

            #endregion

            // MessageModel
            dynamic messageModel = new ExpandoObject();
            {
                // Sender
                if (message.Sender != null)
                {
                    messageModel.sender = new
                    {
                        name = message.Sender.Name,
                        iconUrl = message.Sender.IconUrl,
                    };
                }
            }

            // TextMessage
            if (message is TextMessage textMessage)
            {
                messageModel.type = "text";
                messageModel.text = textMessage.Text.Replace("'", "\"");
                return messageModel;
            }

            // StickerMessage
            if (message is StickerMessage stickerMessage)
            {
                messageModel.type = "sticker";
                messageModel.packageId = stickerMessage.PackageId;
                messageModel.stickerId = stickerMessage.StickerId;
                return messageModel;
            }

            // ImageMessage
            if (message is ImageMessage imageMessage)
            {
                messageModel.type = "image";
                messageModel.originalContentUrl = imageMessage.OriginalContentUrl;
                messageModel.previewImageUrl = imageMessage.PreviewImageUrl;
                return messageModel;
            }

            // VideoMessage
            if (message is VideoMessage videoMessage)
            {
                messageModel.type = "video";
                messageModel.originalContentUrl = videoMessage.OriginalContentUrl;
                messageModel.previewImageUrl = videoMessage.PreviewImageUrl;
                return messageModel;
            }

            // AudioMessage
            if (message is AudioMessage audioMessage)
            {
                messageModel.type = "audio";
                messageModel.originalContentUrl = audioMessage.OriginalContentUrl;
                messageModel.duration = audioMessage.Duration;
                return messageModel;
            }

            // LocationMessage
            if (message is LocationMessage locationMessage)
            {
                messageModel.type = "location";
                messageModel.title = locationMessage.Title;
                messageModel.address = locationMessage.Address;
                messageModel.latitude = locationMessage.Latitude;
                messageModel.longitude = locationMessage.Longitude;
                return messageModel;
            }

            // FlexMessage
            if (message is FlexMessage flexMessage)
            {
                messageModel.type = "flex";
                messageModel.altText = flexMessage.AlternativeText;
                messageModel.contents = JsonSerializer.Deserialize<ExpandoObject>(flexMessage.Contents);
                return messageModel;
            }

            // Throw
            throw new InvalidOperationException($"Unknown Message Type={message.GetType()}");
        }
    }
}
