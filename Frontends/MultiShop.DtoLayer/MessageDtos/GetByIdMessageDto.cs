﻿namespace MultiShop.DtoLayer.MessageDtos
{
    public class GetByIdMessageDto
    {
        public int UserMessageID { get; set; }

        public string SenderID { get; set; }

        public string ReceiverID { get; set; }

        public string Subject { get; set; }

        public string MessageDetail { get; set; }

        public bool IsRead { get; set; }

        public DateTime MessageDate { get; set; }
    }
}
