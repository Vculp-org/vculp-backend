namespace Vculp.Api.Domain.Notifications.Email.EventHandlers.DomainEvents
{
    // public class EmailCustomerOnOrderCreatedEventHandler : IAsyncDomainEventHandler<OrderSentToProductionEvent>
    // {
    //     private readonly ICommandBus _commandBus;
    //     private readonly ILogger<EmailCustomerOnOrderCreatedEventHandler> _logger;
    //     
    //     public EmailCustomerOnOrderCreatedEventHandler(ICommandBus commandBus,
    //         ILogger<EmailCustomerOnOrderCreatedEventHandler> logger, IOrderRepository orderRepository)
    //     {
    //         _commandBus = commandBus ?? throw new ArgumentNullException(nameof(commandBus));
    //         _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    //         _orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
    //     }
    //
    //     public async Task HandleAsync(OrderSentToProductionEvent domainEvent)
    //     {
    //         if (domainEvent == null)
    //         {
    //             throw new ArgumentNullException(nameof(domainEvent));
    //         }
    //
    //         var order = await _orderRepository.GetByOrderNumber(domainEvent.OrderNumber);
    //
    //         if (!string.IsNullOrWhiteSpace(order.OrderContact.Email))
    //         {
    //             // Create SendSmsMessageCommand command for command bus.
    //             var command = new SendOrderCreatedEmailToCustomerCommand()
    //             {
    //                 OrderNumber = domainEvent.OrderNumber,
    //                 OrderId = order.Id,
    //                 To = order.OrderContact.Email,
    //                 ToName = $"{order.OrderContact.FirstName} {order.OrderContact.Surname}"
    //             };
    //
    //             await _commandBus.SendAsync(command);
    //         }
    //         else
    //         {
    //             _logger.LogWarning("Order number {0} email is null or empty", domainEvent.OrderNumber);
    //         }
    //     }
    // }
}
