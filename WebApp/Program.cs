namespace WebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            // le inyecto al proyecto el uso de session
            builder.Services.AddSession();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseSession();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Usuario}/{action=Index}/{id?}");

            /*
            app.MapControllerRoute(
                name: "administrador",
                pattern: "/administrador",
                defaults: new { controller = "Usuario", action = "AdministradorIndex" });

            app.MapControllerRoute(
                name: "miembro",
                pattern: "/miembro",
                defaults: new { controller = "Usuario", action = "MiembroIndex" });
            
            */


            app.Run();
        }
    }
}