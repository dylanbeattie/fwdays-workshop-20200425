using System;

namespace MessagesExample {
    public class Message {
        public readonly Guid MessageGuid = Guid.NewGuid();
        public string Content { get; set; }
    }
}
