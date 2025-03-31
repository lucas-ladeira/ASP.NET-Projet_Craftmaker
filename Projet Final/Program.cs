using Microsoft.EntityFrameworkCore;
using Projet_Final.Data;
using Projet_Final.Data.Services;

namespace Projet_Final
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Ajouter des services au conteneur.
			builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

			// Configuration Interface Service
			builder.Services.AddScoped<IFurnitureService, FurnitureService>();
			builder.Services.AddControllersWithViews();

			var app = builder.Build();

			// Configurer le pipeline de requêtes HTTP.
			if (!app.Environment.IsDevelopment())
			{
				app.UseExceptionHandler("/Home/Error");
				// La valeur HSTS par défaut est de 30 jours. Vous pouvez modifier cette valeur pour des scénarios de production, voir https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}

			app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseRouting();

			app.UseAuthorization();

			app.UseStaticFiles();

			app.MapControllerRoute(
				name: "default",
				pattern: "{controller=Home}/{action=Index}/{id?}");

			app.Run();
		}
	}
}
