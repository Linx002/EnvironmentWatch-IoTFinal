using System.Linq;
using EnvironmentWatch.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace EnvironmentWatch.Migrations
{
    public class InitializeDatabase
    {
        public static void SeedData(IApplicationBuilder app)
        {
            using (var serviceScope =
                app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var serviceProvider = serviceScope.ServiceProvider;

                using (var db = serviceProvider.GetService<EnvWatchContext>())
                {
                    SeedDeviceTypes(db);
                    SeedLocations(db);
                    SeedMeasurementTypes(db);
                    SeedReportingDevices(db);
                }
            }
        }

        private static void SeedDeviceTypes(EnvWatchContext db)
        {
            if (!db.DeviceTypes.Any())
            {
                db.DeviceTypes.Add(new DeviceType
                {
                    DeviceTypeId = 1,
                    Name = "ESP8266",
                    Description = "ESP8266"
                });
                db.SaveChanges();
            }
        }

        private static void SeedLocations(EnvWatchContext db)
        {
            if (!db.Locations.Any())
            {
                db.Locations.AddAsync(new Location
                {
                    LocationId = 1,
                    Name = "Lince",
                    Description = "Casa de Lince"
                });
                db.Locations.AddAsync(new Location
                {
                    LocationId = 2,
                    Name = "Reynosa",
                    Description = "En algun lugar de Reynosa"
                });
                db.SaveChanges();
            }
        }

        private static void SeedMeasurementTypes(EnvWatchContext db)
        {
            if (!db.MeasurementTypes.Any())
            {
                db.MeasurementTypes.Add(new MeasurementType
                {
                    MeasurementTypeId = 1,
                    Name = "Temperature",
                    Description = "Ambient temperature in Farhenheit"
                });
                db.MeasurementTypes.Add(new MeasurementType
                {
                    MeasurementTypeId = 2,
                    Name = "Humidity",
                    Description = "Level of relative humidity"
                });
                db.MeasurementTypes.Add(new MeasurementType
                {
                    MeasurementTypeId = 3,
                    Name = "Light",
                    Description = "Light level measured in percent"
                });
                db.SaveChanges();
            }
        }

        private static void SeedReportingDevices(EnvWatchContext db)
        {
            if (!db.ReportingDevices.Any())
            {
                db.ReportingDevices.Add(new ReportingDevice
                {
                    ReportingDeviceId = 1,
                    DeviceTypeId = 1,
                    LocationId = 1,
                    Name = "ESP8266",
                    Description = "ESP8266"
                });
                db.SaveChanges();
            }
        }
    }
}
