# Microservices - Comprehensive Notes

## 📌 Overview

Microservices is an architectural approach to building applications as a suite of small, independent services that communicate with each other. Each service runs in its own process and is responsible for a specific business capability.

**Key Point:** Microservices enable building scalable, maintainable, and loosely-coupled distributed systems.

---

## 🎯 Learning Objectives

By the end of this module, you will:
- [ ] Understand microservices architecture principles
- [ ] Design services with clear boundaries
- [ ] Implement inter-service communication
- [ ] Use message brokers for asynchronous communication
- [ ] Implement resilience patterns
- [ ] Monitor and observe distributed systems
- [ ] Deploy microservices

---

## 📚 Core Concepts Learned

### 1. **Microservices Architecture Principles**

**Key Characteristics:**
- **Single Responsibility:** Each service handles one business capability
- **Autonomy:** Services are independently deployable
- **Loose Coupling:** Minimal dependencies between services
- **Distribution:** Services run separately, communicate over network
- **Resilience:** Should handle failures gracefully
- **Observability:** Easy to monitor and debug

**When to Use Microservices:**
✅ Large, complex applications
✅ Multiple teams
✅ Different scaling needs
✅ Technology diversity needed

❌ Small/simple projects
❌ Single team
❌ Tight time deadlines

### 2. **Service Design**

```csharp
// Good: Clear boundaries
[ApiController]
[Route("api/orders")]
public class OrderService : ControllerBase
{
    // Order-related operations only
    [HttpPost]
    public async Task<ActionResult> CreateOrder(CreateOrderDto dto) { }
    
    [HttpGet("{id}")]
    public async Task<ActionResult> GetOrder(int id) { }
}

[ApiController]
[Route("api/payments")]
public class PaymentService : ControllerBase
{
    // Payment-related operations only
    [HttpPost]
    public async Task<ActionResult> ProcessPayment(PaymentDto dto) { }
}

[ApiController]
[Route("api/inventory")]
public class InventoryService : ControllerBase
{
    // Inventory-related operations only
    [HttpPost("reserve")]
    public async Task<ActionResult> ReserveItems(ReservationDto dto) { }
}
```

### 3. **Synchronous Communication (REST)**

```csharp
// API Gateway
[ApiController]
[Route("api/gateway")]
public class GatewayController : ControllerBase
{
    private readonly HttpClient httpClient;
    
    [HttpPost("orders")]
    public async Task<ActionResult> CreateOrder(CreateOrderDto dto)
    {
        // Call order service
        var orderResponse = await httpClient.PostAsJsonAsync(
            "https://order-service/api/orders", 
            dto);
        
        if (!orderResponse.IsSuccessStatusCode)
            return BadRequest();
        
        var order = await orderResponse.Content.ReadAsAsync<Order>();
        
        // Call inventory service
        var reservationDto = new ReservationDto 
        { 
            OrderId = order.Id, 
            Items = dto.Items 
        };
        
        var inventoryResponse = await httpClient.PostAsJsonAsync(
            "https://inventory-service/api/inventory/reserve",
            reservationDto);
        
        if (!inventoryResponse.IsSuccessStatusCode)
            return BadRequest("Inventory reservation failed");
        
        return CreatedAtAction(nameof(GetOrder), new { id = order.Id }, order);
    }
}

// Service discovery
services.AddHttpClient<IOrderClient, OrderClient>()
    .ConfigureHttpClient(client =>
    {
        client.BaseAddress = new Uri("https://order-service");
    })
    .AddPolicyHandler(GetRetryPolicy())
    .AddPolicyHandler(GetCircuitBreakerPolicy());

private static IAsyncPolicy<HttpResponseMessage> GetRetryPolicy()
{
    return HttpPolicyExtensions
        .HandleTransientHttpError()
        .OrResult(r => r.StatusCode == System.Net.HttpStatusCode.NotFound)
        .WaitAndRetryAsync(retryCount: 3, 
            sleepDurationProvider: attempt =>
                TimeSpan.FromSeconds(Math.Pow(2, attempt)));
}

private static IAsyncPolicy<HttpResponseMessage> GetCircuitBreakerPolicy()
{
    return HttpPolicyExtensions
        .HandleTransientHttpError()
        .CircuitBreakerAsync(handledEventsAllowedBeforeBreaking: 3,
            durationOfBreak: TimeSpan.FromSeconds(30));
}
```

### 4. **Asynchronous Communication (Message Brokers)**

```csharp
// RabbitMQ with MassTransit
services.AddMassTransit(x =>
{
    x.AddConsumer<OrderCreatedConsumer>();
    x.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host("rabbitmq://localhost");
        cfg.ConfigureEndpoints(context);
    });
});

// Event definition
public class OrderCreatedEvent
{
    public int OrderId { get; set; }
    public int UserId { get; set; }
    public List<OrderItem> Items { get; set; }
    public decimal Total { get; set; }
}

// Publisher
[ApiController]
[Route("api/orders")]
public class OrderController : ControllerBase
{
    private readonly IPublishEndpoint publishEndpoint;
    
    [HttpPost]
    public async Task<ActionResult> CreateOrder(CreateOrderDto dto)
    {
        var order = new Order { /* ... */ };
        
        // Publish event
        await publishEndpoint.Publish<OrderCreatedEvent>(new
        {
            OrderId = order.Id,
            UserId = order.UserId,
            Items = order.Items,
            Total = order.Total
        });
        
        return CreatedAtAction(nameof(GetOrder), new { id = order.Id }, order);
    }
}

// Consumer (in another service)
public class OrderCreatedConsumer : IConsumer<OrderCreatedEvent>
{
    private readonly IInventoryService inventoryService;
    
    public async Task Consume(ConsumeContext<OrderCreatedEvent> context)
    {
        var message = context.Message;
        
        // Reserve items in inventory
        await inventoryService.ReserveAsync(
            message.OrderId,
            message.Items);
        
        // No need to wait for response
    }
}
```

### 5. **Data Management**

```csharp
// Database per microservice pattern
// OrderService has its own DB
public class OrderServiceDbContext : DbContext
{
    public DbSet<Order> Orders { get; set; }
    
    public OrderServiceDbContext(DbContextOptions options) : base(options) { }
}

// InventoryService has its own DB
public class InventoryServiceDbContext : DbContext
{
    public DbSet<InventoryItem> Items { get; set; }
    
    public InventoryServiceDbContext(DbContextOptions options) : base(options) { }
}

// Saga pattern for distributed transactions
public class CreateOrderSaga : IInitiatedBy<CreateOrderCommand>
{
    private readonly ISagaRepository<CreateOrderSagaState> sagaRepository;
    
    public async Task Consume(ConsumeContext<CreateOrderCommand> context)
    {
        var sagaState = new CreateOrderSagaState { /* ... */ };
        
        // Step 1: Create order
        var orderCreatedEvent = new OrderCreatedEvent { /* ... */ };
        await context.Publish(orderCreatedEvent);
        
        // Step 2: Wait for inventory reservation
        // Step 3: Process payment
        // Step 4: Confirm order
        
        // If any step fails, compensate
    }
}
```

### 6. **Resilience Patterns**

```csharp
// Retry pattern
var retryPolicy = Policy
    .Handle<HttpRequestException>()
    .Or<TimeoutRejectedException>()
    .WaitAndRetry(
        retryCount: 3,
        sleepDurationProvider: attempt => 
            TimeSpan.FromSeconds(Math.Pow(2, attempt)));

// Circuit breaker
var circuitBreakerPolicy = Policy
    .Handle<HttpRequestException>()
    .CircuitBreaker(
        handledEventsAllowedBeforeBreaking: 3,
        durationOfBreak: TimeSpan.FromSeconds(30));

// Bulkhead isolation
var bulkheadPolicy = Policy.BulkheadAsync(
    maxParallelization: 10,
    maxQueuingActions: 5);

// Timeout
var timeoutPolicy = Policy.TimeoutAsync(
    TimeSpan.FromSeconds(5));

// Combine policies
var combinedPolicy = Policy.WrapAsync(
    retryPolicy,
    circuitBreakerPolicy,
    bulkheadPolicy,
    timeoutPolicy);

// Usage
try
{
    var result = await combinedPolicy.ExecuteAsync(async () =>
    {
        return await httpClient.GetAsync("https://api.example.com");
    });
}
catch (Exception ex)
{
    // Handle failure
}
```

### 7. **Monitoring & Observability**

```csharp
// Structured logging with Serilog
Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Information()
    .WriteTo.Console()
    .WriteTo.File("logs/app-.txt", rollingInterval: RollingInterval.Day)
    .Enrich.WithProperty("Application", "OrderService")
    .CreateLogger();

// Distributed tracing (OpenTelemetry)
services.AddOpenTelemetryTracing((builder) =>
{
    builder
        .AddConsoleExporter()
        .AddZipkinExporter(o =>
        {
            o.Endpoint = new Uri("http://localhost:9411/api/v2/spans");
        })
        .AddSource("OrderService")
        .AddHttpClientInstrumentation()
        .AddSqlClientInstrumentation();
});

// Health checks
services.AddHealthChecks()
    .AddDbContextCheck<ApplicationDbContext>()
    .AddUrlGroup(new Uri("https://payment-service/health"));

app.MapHealthChecks("/health");
```

---

## 💻 Hands-On Exercises

### Exercise 1: Design Microservices
**Task:** Design services for an e-commerce system

### Exercise 2: API Gateway
**Task:** Implement an API gateway

### Exercise 3: Async Communication
**Task:** Set up message broker communication

### Exercise 4: Distributed Tracing
**Task:** Implement monitoring across services

### Exercise 5: Resilience
**Task:** Implement retry and circuit breaker patterns

---

## 📝 Assignments

1. **E-Commerce Microservices**
   - Order Service
   - Inventory Service
   - Payment Service
   - User Service
   - Implement async communication
   - Health checks

2. **Social Network Microservices**
   - User Service
   - Post Service
   - Comment Service
   - Notification Service
   - Real-time updates

3. **Multi-tenant SaaS Platform**
   - Tenant Management
   - Core Services
   - Billing Service
   - Integration Service

---

## 🔗 References

### Books:
- Building Microservices by Sam Newman
- Microservices Patterns by Chris Richardson

### Tools:
- Docker & Kubernetes for deployment
- RabbitMQ / Apache Kafka for messaging
- Prometheus & Grafana for monitoring
- ELK Stack for logging

---

## 📋 Personal Notes

**Date Started:** _______________
**Topics Mastered:**
- [ ] Architecture Design
- [ ] Service Boundaries
- [ ] Communication Patterns
- [ ] Data Management
- [ ] Resilience
- [ ] Monitoring

**Challenges Faced:**
_________________________________
_________________________________

**Key Takeaways:**
_________________________________
_________________________________

---

**Last Updated:** June 2026
**Completion Status:** Not Started
