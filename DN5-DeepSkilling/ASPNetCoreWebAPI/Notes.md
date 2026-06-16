# ASP.NET Core Web API - Comprehensive Notes

## 📌 Overview

ASP.NET Core Web API is a framework for building RESTful web services using C# and .NET. It provides a robust, scalable, and modern platform for creating HTTP-based APIs that can be consumed by web, mobile, and desktop applications.

**Key Point:** ASP.NET Core Web API enables building scalable, secure, and performant REST services.

---

## 🎯 Learning Objectives

By the end of this module, you will:
- [ ] Understand REST principles and HTTP methods
- [ ] Build controllers and action methods
- [ ] Implement routing and model binding
- [ ] Handle authentication and authorization
- [ ] Implement validation and error handling
- [ ] Work with Entity Framework Core integration
- [ ] Deploy Web APIs

---

## 📚 Core Concepts Learned

### 1. **REST Principles**

**HTTP Methods:**
- `GET` - Retrieve data
- `POST` - Create new resource
- `PUT` - Update entire resource
- `PATCH` - Partial update
- `DELETE` - Remove resource

**Status Codes:**
- 2xx - Success
- 3xx - Redirection
- 4xx - Client errors
- 5xx - Server errors

### 2. **Controller & Routes**

```csharp
// API Controller
[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUserService userService;
    
    public UsersController(IUserService userService)
    {
        this.userService = userService;
    }
    
    // GET: api/users
    [HttpGet]
    public async Task<ActionResult<IEnumerable<UserDto>>> GetAll()
    {
        var users = await userService.GetAllAsync();
        return Ok(users);
    }
    
    // GET: api/users/{id}
    [HttpGet("{id}")]
    public async Task<ActionResult<UserDto>> GetById(int id)
    {
        var user = await userService.GetByIdAsync(id);
        if (user == null)
            return NotFound();
        return Ok(user);
    }
    
    // POST: api/users
    [HttpPost]
    public async Task<ActionResult<UserDto>> Create(CreateUserDto dto)
    {
        var user = await userService.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = user.Id }, user);
    }
    
    // PUT: api/users/{id}
    [HttpPut("{id}")]
    public async Task<ActionResult> Update(int id, UpdateUserDto dto)
    {
        var success = await userService.UpdateAsync(id, dto);
        if (!success)
            return NotFound();
        return NoContent();
    }
    
    // DELETE: api/users/{id}
    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var success = await userService.DeleteAsync(id);
        if (!success)
            return NotFound();
        return NoContent();
    }
}
```

### 3. **Model Binding & Validation**

```csharp
// DTO (Data Transfer Object)
public class CreateUserDto
{
    [Required]
    [StringLength(100)]
    public string Name { get; set; }
    
    [Required]
    [EmailAddress]
    public string Email { get; set; }
    
    [Range(18, 150)]
    public int Age { get; set; }
}

// Custom validation
[AttributeUsage(AttributeTargets.Property)]
public class NotAdultAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext context)
    {
        if (value is int age && age < 18)
            return ValidationResult.Success;
        return new ValidationResult("Must be under 18");
    }
}

// Model binding sources
[HttpPost]
public ActionResult CreateUser(
    [FromBody] CreateUserDto body,           // Request body
    [FromQuery] string searchTerm,           // Query string
    [FromRoute] int id,                     // Route parameter
    [FromHeader] string userAgent,          // Header
    [FromServices] IUserService service)    // Dependency injection
{
    return Ok();
}
```

### 4. **Dependency Injection & Services**

```csharp
// Service interface
public interface IUserService
{
    Task<IEnumerable<UserDto>> GetAllAsync();
    Task<UserDto> GetByIdAsync(int id);
    Task<UserDto> CreateAsync(CreateUserDto dto);
}

// Service implementation
public class UserService : IUserService
{
    private readonly ApplicationDbContext context;
    private readonly IMapper mapper;
    
    public UserService(ApplicationDbContext context, IMapper mapper)
    {
        this.context = context;
        this.mapper = mapper;
    }
    
    public async Task<IEnumerable<UserDto>> GetAllAsync()
    {
        var users = await context.Users.ToListAsync();
        return mapper.Map<IEnumerable<UserDto>>(users);
    }
    
    // ... other methods
}

// Startup configuration
public void ConfigureServices(IServiceCollection services)
{
    services.AddControllers();
    
    // Register services
    services.AddScoped<IUserService, UserService>();
    services.AddScoped<ApplicationDbContext>();
    
    // AutoMapper
    services.AddAutoMapper(typeof(Program));
    
    // Database
    services.AddDbContext<ApplicationDbContext>(options =>
        options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
    
    // Cors
    services.AddCors(options =>
    {
        options.AddPolicy("AllowAll", builder =>
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader());
    });
}

public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
{
    if (env.IsDevelopment())
        app.UseDeveloperExceptionPage();
    
    app.UseHttpsRedirection();
    app.UseRouting();
    app.UseCors("AllowAll");
    
    app.UseEndpoints(endpoints =>
    {
        endpoints.MapControllers();
    });
}
```

### 5. **Authentication & Authorization**

```csharp
// JWT Authentication
public void ConfigureJWT(IServiceCollection services)
{
    var jwtSettings = Configuration.GetSection("Jwt");
    var secretKey = jwtSettings.GetValue<string>("SecretKey");
    
    services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        .AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey)),
                ValidateIssuer = true,
                ValidIssuer = jwtSettings.GetValue<string>("Issuer"),
                ValidateAudience = true,
                ValidAudience = jwtSettings.GetValue<string>("Audience"),
                ValidateLifetime = true
            };
        });
    
    services.AddAuthorization(options =>
    {
        options.AddPolicy("AdminOnly", policy =>
            policy.RequireRole("Admin"));
    });
}

// JWT Token service
public class JwtTokenService
{
    public string GenerateToken(User user, int expiryMinutes = 60)
    {
        var secretKey = Encoding.UTF8.GetBytes("your-secret-key");
        var key = new SymmetricSecurityKey(secretKey);
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        
        var claims = new[]
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(ClaimTypes.Role, user.Role)
        };
        
        var token = new JwtSecurityToken(
            issuer: "your-app",
            audience: "your-app-users",
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(expiryMinutes),
            signingCredentials: creds
        );
        
        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}

// Using authentication
[ApiController]
[Route("api/[controller]")]
[Authorize]
public class ProtectedController : ControllerBase
{
    [AllowAnonymous]
    [HttpPost("login")]
    public ActionResult Login(LoginRequest request)
    {
        // Authenticate user
        var user = VerifyCredentials(request.Email, request.Password);
        if (user == null)
            return Unauthorized();
        
        var token = tokenService.GenerateToken(user);
        return Ok(new { token });
    }
    
    [HttpGet("profile")]
    [Authorize(Roles = "Admin")]
    public ActionResult GetProfile()
    {
        var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        return Ok(new { Message = $"User {userId}" });
    }
}
```

### 6. **Error Handling & Middleware**

```csharp
// Custom exception
public class NotFoundException : Exception
{
    public NotFoundException(string message) : base(message) { }
}

// Exception middleware
public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate next;
    private readonly ILogger<ExceptionHandlingMiddleware> logger;
    
    public ExceptionHandlingMiddleware(RequestDelegate next, 
        ILogger<ExceptionHandlingMiddleware> logger)
    {
        this.next = next;
        this.logger = logger;
    }
    
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Unhandled exception");
            await HandleExceptionAsync(context, ex);
        }
    }
    
    private Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.ContentType = "application/json";
        
        var response = new ErrorResponse
        {
            Message = exception.Message
        };
        
        return context.Response.WriteAsJsonAsync(response);
    }
}

// Register middleware
app.UseMiddleware<ExceptionHandlingMiddleware>();
```

### 7. **Logging & Monitoring**

```csharp
// Logging configuration
services.AddLogging(config =>
{
    config.AddConsole();
    config.AddDebug();
    config.AddFile("logs/app-{Date}.txt");
});

// Using logging
[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly ILogger<UsersController> logger;
    
    public UsersController(ILogger<UsersController> logger)
    {
        this.logger = logger;
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult> GetUser(int id)
    {
        logger.LogInformation($"Retrieving user with id {id}");
        
        try
        {
            var user = await service.GetByIdAsync(id);
            if (user == null)
            {
                logger.LogWarning($"User with id {id} not found");
                return NotFound();
            }
            
            return Ok(user);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error retrieving user");
            throw;
        }
    }
}
```

---

## 💻 Hands-On Exercises

### Exercise 1: Create API Controllers
**Task:** Build CRUD endpoints for a resource

### Exercise 2: Add Validation
**Task:** Implement model validation with custom rules

### Exercise 3: Authentication
**Task:** Implement JWT authentication

### Exercise 4: Error Handling
**Task:** Create global exception handling middleware

### Exercise 5: API Documentation
**Task:** Add Swagger/OpenAPI documentation

---

## 📝 Assignments

1. **Blog API**
   - Posts, comments, users endpoints
   - Authentication and authorization
   - Pagination and filtering
   - Error handling

2. **E-Commerce API**
   - Products, orders, users
   - Shopping cart functionality
   - Order processing
   - Inventory management

3. **Social Network API**
   - User management
   - Friend requests
   - Posts and comments
   - Real-time notifications (SignalR)

---

## 🔗 References

### Official Documentation:
- [Microsoft ASP.NET Core](https://docs.microsoft.com/aspnet/core/)
- [ASP.NET Core Web API](https://docs.microsoft.com/aspnet/core/web-api/)

### Tools:
- Postman - API testing
- Swagger/OpenAPI - API documentation

---

## 📋 Personal Notes

**Date Started:** _______________
**Topics Mastered:**
- [ ] Controllers & Routing
- [ ] Model Binding
- [ ] Dependency Injection
- [ ] Authentication/Authorization
- [ ] Validation
- [ ] Error Handling
- [ ] Logging

**Challenges Faced:**
_________________________________
_________________________________

**Key Takeaways:**
_________________________________
_________________________________

---

**Last Updated:** June 2026
**Completion Status:** Not Started
