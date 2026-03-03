using JustinaSimulator.Domain.Entities;
using System.Threading.Tasks;

namespace JustinaSimulator.Application.Interfaces;

public interface ISimulationStateRepository
{
    Task<Robot> GetLatestSessionAsync();
    Task<Robot> CreateNewSessionAsync(string doctorName);
    Task UpdateRobotAsync(Robot robot);
}
