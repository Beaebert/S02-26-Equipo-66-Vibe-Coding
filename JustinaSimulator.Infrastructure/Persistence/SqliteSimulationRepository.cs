using JustinaSimulator.Application.Interfaces;
using JustinaSimulator.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace JustinaSimulator.Infrastructure.Persistence;

public class SqliteSimulationRepository : ISimulationStateRepository
{
    private readonly JustinaDbContext _context;

    public SqliteSimulationRepository(JustinaDbContext context)
    {
        _context = context;
        _context.Database.EnsureCreated(); // Auto-create schema for MVP
    }

    public async Task<Robot> GetLatestSessionAsync()
    {
        var robot = await _context.Robots
            .OrderByDescending(r => r.SessionDate)
            .FirstOrDefaultAsync();

        if (robot == null)
        {
            // Fallback for safety if no session exists yet when moving
            return await CreateNewSessionAsync("Dr. Juan Pérez");
        }

        return robot;
    }

    public async Task<Robot> CreateNewSessionAsync(string doctorName)
    {
        var newSession = new Robot(Guid.NewGuid(), doctorName);
        _context.Robots.Add(newSession);
        await _context.SaveChangesAsync();

        return newSession;
    }

    public async Task UpdateRobotAsync(Robot robot)
    {
        _context.Robots.Update(robot);
        await _context.SaveChangesAsync();
    }
}
