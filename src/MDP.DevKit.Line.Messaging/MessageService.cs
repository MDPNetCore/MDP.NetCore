using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDP.DevKit.Line.Messaging
{
    public interface MessageService
    {
        // Methods
        Task<string> ReplyMessageAsync(Message message, string replyToken);

        Task<string> PushMessageAsync(Message message, string userId);

        Task<string> MulticastMessageAsync(Message message, List<string> userIdList);

        Task<string> BroadcastMessageAsync(Message message);


        Task<string> ReplyMessageAsync(List<Message> messageList, string replyToken);

        Task<string> PushMessageAsync(List<Message> messageList, string userId);

        Task<string> MulticastMessageAsync(List<Message> messageList, List<string> userIdList);

        Task<string> BroadcastMessageAsync(List<Message> messageList);
    }
}