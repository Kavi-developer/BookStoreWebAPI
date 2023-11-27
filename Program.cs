
using BooksStoreWebAPI.Models;
using BooksStoreWebAPI.Repository.Author_Repository;
using BooksStoreWebAPI.Repository.Book_Repository;
using BooksStoreWebAPI.Repository.Contact_Repository;
using BooksStoreWebAPI.Repository.Customer_Repository;
using BooksStoreWebAPI.Repository.Menu_Repository;
using BooksStoreWebAPI.Repository.Purchase_Repository;
using BooksStoreWebAPI.Repository.Role_Repository;
using BooksStoreWebAPI.Repository.Sales_Repository;
using BooksStoreWebAPI.Repository.User_Repository;
using BooksStoreWebAPI.Repository.Vendor_Repository;
using BooksStoreWebAPI.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Globalization;
using System.Text;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



builder.Services.AddDbContext<BookDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
}, ServiceLifetime.Scoped);

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminPolicy", policy =>
    {
        policy.Requirements.Add(new CustomRequirement("Administrator"));

    });
    options.AddPolicy("GuestPolicy", policy =>
    {
        policy.Requirements.Add(new CustomRequirement("Guest"));

    });
    options.AddPolicy("TwoMemberPolicy", policy =>
    {
        policy.Requirements.Add(new CustomRequirement(["Administrator","Guest"]));

    });
});

builder.Services.AddScoped<IUserRespository,UserRepository>();
builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<IPurchaseRepository,PurchaseRepository>();
builder.Services.AddScoped<ISalesRepository, SalesRepository>();
builder.Services.AddScoped<IMenuRepository, MenuRepository>();  
builder.Services.AddScoped<IRoleRepository, RoleRepository>();
builder.Services.AddScoped<IContactRepository, ContactRepository>();
builder.Services.AddScoped<IAuthorRepository, AuthorRepository>();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<IVendorRepository, VendorRepository>();
builder.Services.AddScoped<CustomRequirement>();
builder.Services.AddScoped<IAuthorizationHandler,CustomerHandler> ();
builder.Services.AddHttpContextAccessor();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidIssuer = builder.Configuration["JWT:Issuer"],
            ValidAudience = builder.Configuration["JWT:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey
            (Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"]))
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();


app.MapControllers();

app.Run();
