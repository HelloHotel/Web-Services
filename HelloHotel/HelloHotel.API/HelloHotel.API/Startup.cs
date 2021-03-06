using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelloHotel.API.Booking_System.Domain.Repositories;
using HelloHotel.API.Booking_System.Domain.Services;
using HelloHotel.API.Booking_System.Persistence.Repositories;
using HelloHotel.API.Booking_System.Services;
using HelloHotel.API.Hotel_System.Domain.Repositories;
using HelloHotel.API.Hotel_System.Domain.Services;
using HelloHotel.API.Hotel_System.Persistence.Repositories;
using HelloHotel.API.Hotel_System.Services;

using HelloHotel.API.Searching_System.Domain.Repositories;
using HelloHotel.API.Searching_System.Domain.Services;
using HelloHotel.API.Searching_System.Persistence.Repositories;
using HelloHotel.API.Searching_System.Services;

using HelloHotel.API.Rating_System.Domain.Repositories;
using HelloHotel.API.Rating_System.Domain.Services;
using HelloHotel.API.Rating_System.Persistence.Repositories;
using HelloHotel.API.Rating_System.Services;

using HelloHotel.API.Shared.Persistence.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace HelloHotel.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddRouting(options => options.LowercaseUrls = true);

            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseInMemoryDatabase("Hello-Hotel-in-memory");
                
            });
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "HelloHotel.API", Version = "v1"});
                c.EnableAnnotations();
            });

            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IEmployeeService, EmployeeService>();

            services.AddScoped<IEventRepository, EventRepository>();
            services.AddScoped<IEventService, EventService>();

            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddScoped<IClientService, ClientService>();

            services.AddScoped<IInventoryRepository, InventoryRepository>();
            services.AddScoped<IInventoryService, InventoryService>();
            
            services.AddScoped<IRoomRepository, RoomRepository>();
            services.AddScoped<IRoomService, RoomService>();

            services.AddScoped<IHotelRepository, HotelRepository>();
            services.AddScoped<IHotelService, HotelService>();
            
            services.AddScoped<IFeedbackRepository, FeedbackRepository>();
            services.AddScoped<IFeedbackService, FeedbackService>();

            services.AddScoped<IStairRepository, StairRepository>();
            services.AddScoped<IStairService, StairService>();
            
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddAutoMapper(typeof(Startup));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "HelloHotel.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}