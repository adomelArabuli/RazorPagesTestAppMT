using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using RazorPagesTestAppMT.Data.Models;
using RazorPagesTestAppMT.Services.Implementations;
using RazorPagesTestAppMT.Services.Interfaces;

namespace RazorPagesTestAppMT
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            // Add services to the container.

            builder.Services.AddScoped<IEmailSender, EmailSender>();

            builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddDefaultTokenProviders().AddEntityFrameworkStores<ApplicationDbContext>();

            builder.Services.AddAuthentication().AddFacebook(options =>
            {
                options.AppId = "test";
                options.AppSecret = "test";
            });

            builder.Services.AddAuthentication().AddMicrosoftAccount(options =>
            {
                options.ClientId = "test";
                options.ClientSecret = "test";
            });

            builder.Services.AddAuthentication().AddGoogle(options =>
            {
                options.ClientId = "test";
                options.ClientSecret = "test";
            });

            builder.Services.AddRazorPages();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.MapRazorPages();

            app.Run();
        }
    }
}