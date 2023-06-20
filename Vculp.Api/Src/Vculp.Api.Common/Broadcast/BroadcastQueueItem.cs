using System;

namespace Vculp.Api.Common.Broadcast
{
    public class BroadcastQueueItem
    {
        /// <summary>
        /// Used during Json Deserialization
        /// </summary>
        private BroadcastQueueItem()
        {
        }

        public BroadcastQueueItem(IBroadcast broadcast)
        {
            if (broadcast == null)
            {
                throw new ArgumentNullException(nameof(broadcast));
            }

            BroadcastType = broadcast.GetType().FullName;
            Payload = broadcast;
        }

        public string BroadcastType { get; private set; }
        public object Payload { get; private set; }
    }
}
