using CyberPet.Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using MQTTnet;
using MQTTnet.Client;
using MQTTnet.Client.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CyberPet.Api.Workers
{
    public class ScheduleWorker : IHostedService, IDisposable
    {
        private const string Server = "test.mosquitto.org";
        private const int Port = 1883;
        
        private Timer _timer;
        private IMqttClient _mqttClient;
        public ScheduleWorker()
        {
            var factory = new MqttFactory();
            _mqttClient = factory.CreateMqttClient();
        }
        public Task StartAsync(CancellationToken stoppingToken)
        {
            
            _timer = new Timer(CheckRun, null, TimeSpan.Zero,
                TimeSpan.FromSeconds(60));
            return Task.CompletedTask;
        }

        
        private async void CheckRun(object state)
        {
            DateTime now = DateTime.Now;
            if (!_mqttClient.IsConnected)
                await ConnectMqttServer();
            List<Schedule> schedules = await GetSchedules(now);
            if (schedules.Any())
            {
                schedules.ForEach(x => RunBowl(x?.Pet?.Bowl?.Token));
            }
        }


        private async Task<List<Schedule>> GetSchedules(DateTime date)
        {
            using CyberPetContext context = new CyberPetContext();
            return await context.Schedules
                .Include(x => x.Pet)
                    .ThenInclude(x => x.Bowl)
                .AsNoTracking()
                .Where(x => x.Hour == date.Hour && x.Minutes == date.Minute)
                .ToListAsync();
        }
        private async Task ConnectMqttServer()
        {
            _ = await _mqttClient.ConnectAsync(
                new MqttClientOptionsBuilder()
                    .WithTcpServer(Server, Port)
                    .Build());
        }

        private async Task RunBowl(string bowlToken)
        {
            _ = _mqttClient.PublishAsync($"cyber-pet/execute/{bowlToken}", "");
        }

        public Task StopAsync(CancellationToken stoppingToken)
        {
            _timer?.Change(Timeout.Infinite, 0);
            return Task.CompletedTask;
        }
        public void Dispose()
        {
            _timer?.Dispose();
        }
    }
}
