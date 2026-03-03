using JustinaSimulator.Application.Interfaces;
using JustinaSimulator.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace JustinaSimulator.Infrastructure.Persistence;

public class InMemorySimulationRepository : ISimulationStateRepository
{
    // Simple singleton-like behavior for the simulation state
    private static Robot _currentRobot = new Robot(Guid.NewGuid());

    public Task<Robot> GetLatestSessionAsync()
    {
        return Task.FromResult(_currentRobot);
    }

    public Task<Robot> CreateNewSessionAsync(string doctorName)
    {
        _currentRobot = new Robot(Guid.NewGuid(), doctorName);
        return Task.FromResult(_currentRobot);
    }

    public Task UpdateRobotAsync(Robot robot)
    {
        _currentRobot = robot;
        return Task.CompletedTask;
    }
}
